using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.Services;
using Jayrock.Json;
using Jayrock.JsonRpc;
using Jayrock.JsonRpc.Web;
using Jayrock.Json.Conversion;
using System.Linq;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types; 
using System.Data;
using System.Web.Security;
using System.Reflection;
using BSM;
using BsmDatabaseObjects;
using BSM_Info;

using log4net;
using log4net.Config;

using System.Text;
using System.Net;

using Newtonsoft.Json.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace BSMPCService
{


    /// <summary>
    /// 購買記錄
    /// </summary>
    /// 

    public class bsm_pc_service : JsonRpcHandler
    {
        OracleConnection conn;

        private BSM_Info_Service_base _info_base;
        private BSM_Purchase_Service_base _purchase_base;
        private string MongoDBConnectString;
        private string MongoDB_Database;
        private string acg_url = "https://s-acg.svc.litv.tv/acg/rpc/bsm";
        static ILog logger;

        public bsm_pc_service()
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            String ConnectString;
            ConnectString = "";
            conn = new OracleConnection();
            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            System.Configuration.ConnectionStringSettings connString;
            if (0 < rootWebConfig.ConnectionStrings.ConnectionStrings.Count)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["BsmConnectionString"];
                ConnectString = connString.ConnectionString;
                conn.ConnectionString = ConnectString;
                MongoDBConnectString = rootWebConfig.ConnectionStrings.ConnectionStrings["MongoDb"].ToString();
                MongoDB_Database = rootWebConfig.ConnectionStrings.ConnectionStrings["MongoDb_Database"].ToString();
                acg_url = rootWebConfig.ConnectionStrings.ConnectionStrings["ACG_URL"].ToString();
            }
            _info_base = new BSM_Info_Service_base(ConnectString, MongoDBConnectString, MongoDB_Database);
            _purchase_base = new BSM_Purchase_Service_base(ConnectString, MongoDBConnectString, MongoDB_Database);
            _info_base.acg_url = acg_url;

        }


        /// <summary>
        /// 取服務方案狀態
        /// </summary>
        /// <param name="client_id"></param>
        /// <returns></returns>
        [JsonRpcMethod("get_group_info")]
        [JsonRpcHelp("取服務狀態")]
        public JsonArray get_group_info(string token, string software_version, string browser_type, string client_id, string device_id)
        {
            return _info_base.get_group_info(software_version, browser_type);
        }


        /// <summary>
        /// 取各館狀態
        /// </summary>
        /// <param name="client_id"></param>
        /// <returns></returns>
        [JsonRpcMethod("get_catalog_info")]
        [JsonRpcHelp("取服務狀態")]
        public List<catalog_info> get_catalog_info(string token, string software_version, string client_id, string device_id)
        {
            List<catalog_info> v_result = new List<catalog_info>();
            v_result = _info_base.get_catalog_info(client_id, device_id);

            return v_result;
        }

        /// <summary>
        /// 取得服務到期日
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="client_id">client_id</param>
        /// <param name="device_id">device_id</param>
        /// <param name="asset_id">asset_id</param>
        /// <returns></returns>
        [JsonRpcMethod("get_service_end_date")]
        [JsonRpcHelp("取得服務到期日")]
        public string get_service_end_date(string token, string software_version, string client_id, string device_id, string asset_id)
        {
            string v_result = _info_base.get_service_end_date(token, client_id, device_id, asset_id);
            return v_result;
        }

        [JsonRpcMethod("get_acc_info")]
        [JsonRpcHelp("取得帳號資訊")]
        public JsonObject get_acc_info(string client_id, string device_id, string sw_version)
        {
            JsonObject _result = new JsonObject();

            _result = _info_base.get_acc_info(client_id, device_id, sw_version);

            string jsonstr = Jayrock.Json.Conversion.JsonConvert.ExportToString(_result);

            logger.Info(jsonstr);
            return _result;
        }

        [JsonRpcMethod("get_promotion_packages")]
        [JsonRpcHelp("取得帳號資訊")]
        public JsonArray get_promotion_packages(string product_code)
        {
            JsonArray _result = new JsonArray();

            _result = _info_base.get_promotion_packages(product_code);
            string jsonstr = Jayrock.Json.Conversion.JsonConvert.ExportToString(_result);

            logger.Info(jsonstr);
            return _result;
        }


        /// <summary>
        /// 取得訂購狀態
        /// </summary>
        /// <param name="client_id"></param>
        /// <returns></returns>
        [JsonRpcMethod("get_order_info")]
        [JsonRpcHelp("取得購買紀錄")]
        public List<purchase_info> get_order_info(string token, string software_version, string client_id, string device_id)
        {
            List<purchase_info> v_result = new List<purchase_info>();
            v_result = _info_base.get_order(client_id, device_id, null);
            return v_result;
        }


        /// <summary>
        /// 取得訂購狀態
        /// </summary>
        /// <param name="client_id"></param>
        /// <returns></returns>
        [JsonRpcMethod("get_purchase_info")]
        [JsonRpcHelp("取得購買紀錄")]
        public List<purchase_info> get_purchase_info(string token, string software_version, string client_id, string device_id)
        {
            List<purchase_info> v_result = new List<purchase_info>();
            v_result = (from i in _info_base.cache_client_purchase(client_id, false).purchases orderby i.purchase_date descending select i ).ToList();
            foreach (var a in v_result)
            {
                if(a.pay_type =="信用卡二次扣款")
                { a.pay_type = "CREDIT"; }
                if ( a.pay_type != "CREDIT" && a.pay_type != "信用卡" && a.pay_type != "REMIT" && a.pay_type != "ATM" && a.pay_type != "C_HINET" )
                {
                    a.amount = null;
                   
                }
            }
            return v_result;
        }

        /// <summary>
        /// 取得所有方案
        /// </summary>
        /// <returns></returns>
        [JsonRpcMethod("get_package_info")]
        [JsonRpcHelp("查詢所有方案")]
        public JsonArray get_package_info(string token, string group_id, string software_version, string client_id, string device_id)
        {

            string v_software_group = (software_version.Substring(0, 7) == "LTFTV00") ? "LTFTV00" : ((software_version.Substring(0, 7) == "LTAGP01") ? "LTAGP01" : "LTWEB00");

            JsonArray v_result = _info_base.get_package_info(client_id, "BUY", null, device_id, group_id, null, v_software_group);
            return v_result;
        }

        /// <summary>
        /// 取得方案BY ID
        /// </summary>
        /// <returns></returns>
        [JsonRpcMethod("get_package_info_by_id")]
        [JsonRpcHelp("查詢方案BY PACKAGE_ID")]
        public JsonObject get_package_info_by_id(string token, string software_version, string client_id, string device_id, string package_id)
        {
            JsonObject result;
            string v_software_group = (software_version.Substring(0, 7) == "LTFTV00") ? "LTFTV00" : ((software_version.Substring(0, 7) == "LTAGP01") ? "LTAGP01" : "LTWEB00");
            result = _info_base.get_package_info_by_id(client_id, "BUY", 0, device_id, package_id, v_software_group);
            return result;
        }

        public JsonArray get_package_info_by_multi_id(string token, string software_version, string client_id, string device_id, string[] package_id)
        {
            JsonArray result = _info_base.get_package_info_by_multi_id(client_id, "BUY", 0, device_id, null, software_version, package_id);
            return result;
        }

        public List<package_info> get_content_package_info(string token, string client_id, string content_id, string device_id)
        {
            List<package_info> v_result = _info_base.get_content_package_info(client_id, content_id, null);
            return v_result;
        }

        public List<BSM_Result> web_batch_purchase(string token, string software_version, purchase_list purchase_order, string otpw, string authority)
        {
            List<BSM_Result> results = new List<BSM_Result>();
            foreach (BSM_Purchase_Request vp in purchase_order.purchases)
            {
                BSM_Result result = _purchase_base.purchase(null, vp.device_id, software_version, vp, null, otpw, authority,null,null);
                results.Add(result);
            }
            return results;

        }

        [JsonRpcMethod("web_purchase")]
        [JsonRpcHelp("訂單")]
        public BSM_Result web_batch_purchase(string token, string software_version, BSM_Purchase_Request purchase_info, JsonObject cht_params, string otpw, string authority,string user_agent,string browser_type)
        {
            BSM_Result result = _purchase_base.purchase(null, purchase_info.device_id, software_version, purchase_info, cht_params, otpw, authority, user_agent,browser_type);
            return result;
        }

        [JsonRpcMethod("modify_purchase")]
        [JsonRpcHelp("訂單修改")]
        public BSM_Result modify_purchase(string token, string software_version, string purchase_id, BSM_Purchase_Request purchase_info)
        {
            BSM_Result result = _purchase_base.modify_purchase(purchase_id, purchase_info);
            return result;
        }

        [JsonRpcMethod("web_promotion_order")]
        [JsonRpcHelp("購買-促銷訂單")]
        public JsonObject web_promotion_order(string token, string client_id, string device_id, string sw_version, JsonObject order)
        {
            JsonObject result = _purchase_base.order(token, client_id, device_id, sw_version, order);
            return result;
        }

        public List<purchase_info> get_order(string client_id, string device_id, string src_no)
        {
            List<purchase_info> result = _info_base.get_order(client_id, device_id, src_no);
            return result;
        }

        public List<BSM_Info.purchase_info> test_get_purchase_info_by_id_atm(string client_id, string purchase_id)
        {
            return _purchase_base.get_purchase_info_by_id_atm(client_id, purchase_id);
        }

        [JsonRpcMethod("get_message")]
        [JsonRpcHelp("取得get_message")]
        public string get_message(string message_type, string sw_version)
        {
            return _info_base.get_message(message_type, sw_version);
        }

        public messamge_box get_message_box(string client_id, string device_id, string sw_version, string message_id)
        {
            return _info_base.get_message_box(client_id, device_id, sw_version, message_id);
        }

        public List<messamge_box> get_message_box()
        {
            return _info_base.get_all_message_box();
        }

        [JsonRpcMethod("register_coupon")]
        [JsonRpcHelp("兌換券輸入,請輸入ClientInfo 已即Coupon No ,回傳BSM-00000代表成功")]
        /// <summary>
        /// 登錄coupon 號碼
        /// </summary>
        /// <param name="token"></param>
        /// <param name="Client_Info"></param>
        /// <param name="Coupon_NO"></param>
        /// <returns></returns>
        public BSM_Result register_coupon(string token, BSM_ClientInfo client_info, string coupon_no, string device_id, string sw_version)
        {
            BSM_Result _result;
            BSM_Info.BSM_Info_Service_base BSM_Info_base = new BSM_Info.BSM_Info_Service_base(conn.ConnectionString, MongoDBConnectString, MongoDB_Database);
            _result = new BSM_Result();
            BSM_ClientInfo v_Client_Info = new BSM_ClientInfo();
            string coupon_mas_no;

            if (coupon_no == null || coupon_no == "")
            {
                _result.result_code = "BSM-00609";
                _result.result_message = "沒有Coupon NO";
                _result.client = v_Client_Info;
                return _result;
            }

            conn.Open();
            string sql1 = "begin :M_RESULT := BSM_CLIENT_SERVICE.register_coupon(:M_CLIENT_INFO,:P_COUPON_NO,:P_SRC_NO,:P_SW_VERSION); end; ";

            TBSM_CLIENT_INFO t_client_info = new TBSM_CLIENT_INFO();
            TBSM_RESULT bsm_result = new TBSM_RESULT();

            t_client_info.SERIAL_ID = client_info.client_id;

            t_client_info.OWNER_PHONE = client_info.owner_phone_no;
            if (device_id != null)
            {
                t_client_info.MAC_ADDRESS = device_id;
            }
            else
            {
                t_client_info.MAC_ADDRESS = client_info.mac_address;
            }

            OracleCommand cmd = new OracleCommand(sql1, conn);
            try
            {
                cmd.BindByName = true;

                OracleParameter param1 = new OracleParameter();
                param1.ParameterName = "M_CLIENT_INFO";
                param1.OracleDbType = OracleDbType.Object;
                param1.Direction = ParameterDirection.InputOutput;
                param1.UdtTypeName = "TBSM_CLIENT_INFO";
                param1.Value = t_client_info;
                cmd.Parameters.Add(param1);

                OracleParameter param2 = new OracleParameter();
                param2.ParameterName = "P_COUPON_NO";
                param2.OracleDbType = OracleDbType.Varchar2;
                param2.Direction = ParameterDirection.InputOutput;
                param2.Value = coupon_no;
                cmd.Parameters.Add(param2);

                OracleParameter param4 = new OracleParameter();
                param4.ParameterName = "P_SRC_NO";
                param4.OracleDbType = OracleDbType.Varchar2;
                param4.Direction = ParameterDirection.InputOutput;
                param4.Size = 64;
                param4.Value = "12345678";
                cmd.Parameters.Add(param4);

                OracleParameter param3 = new OracleParameter();
                param3.ParameterName = "M_RESULT";
                param3.OracleDbType = OracleDbType.Object;
                param3.Direction = ParameterDirection.InputOutput;
                param3.UdtTypeName = "TBSM_RESULT";
                cmd.Parameters.Add(param3);

                OracleParameter param5 = new OracleParameter();
                param5.ParameterName = "P_SW_VERSION";
                param5.OracleDbType = OracleDbType.Varchar2;
                param5.Direction = ParameterDirection.InputOutput;
                param5.Size = 64;
                param5.Value = sw_version ?? client_info.sw_version;
                cmd.Parameters.Add(param5);

                cmd.ExecuteNonQuery();

                bsm_result = (TBSM_RESULT)param3.Value;
                coupon_mas_no = param4.Value.ToString();
                if (bsm_result.RESULT_CODE == "BSM-00000")
                {
                    _result.purchase_list = BSM_Info_base.get_purchase_info(client_info.client_id, client_info.mac_address, coupon_mas_no);
                }

                if (bsm_result.RESULT_CODE != "BSM-00000")
                {
                    _result.result_code = bsm_result.RESULT_CODE;
                    _result.result_message = bsm_result.RESULT_MESSAGE;
                    _result.client = v_Client_Info;
                    return _result;
                }
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }

            _result.result_code = bsm_result.RESULT_CODE;
            _result.result_message = bsm_result.RESULT_MESSAGE;
            _result.client = v_Client_Info;
            return _result;
        }

        [JsonRpcMethod("check_promo_code")]
        [JsonRpcHelp("檢查促銷代碼")]
        public JsonObject check_promo_code(string client_id, string device_id, string promo_code, string pay_type, string package_id)
        {
         //   promo_code = promo_code.ToUpper();
            JsonObject _result = new JsonObject();
            BSM_Result _result_bsm = new BSM_Result();
            _result_bsm.result_code = "BSM-00000";
            _result_bsm.result_message = "";
            JsonObject promotion_json = new JsonObject();

            List<promotion_info> _promo_infos = _info_base.get_promtion_code(promo_code.ToUpper());

            if (_promo_infos == null || _promo_infos.Count <= 0) { _result_bsm.result_code = "BSM-07001"; }
            else
            {
                List<promotion_info> _promo_infos_2 = (from _promo in _promo_infos where _promo.discount_package_id == package_id select _promo).ToList();
                if (_promo_infos_2.Count == 0) { _result_bsm.result_code = "BSM-07002"; }
                else
                {
                    promotion_info _promo_info = _promo_infos_2[0];
                    if (_promo_info.status == false) { _result_bsm.result_code = "BSM-07003"; }

                    if (_promo_info.end_date <= DateTime.Now)
                    {
                        _result_bsm.result_code = "BSM-07006";
                    }

                    if (_promo_info.client_cnt_limit > 0)
                    {

                        List<purchase_info> _purchase_info = _info_base.cache_client_purchase(client_id, false).purchases;
                        int cnt = (from pur in _purchase_info where pur.promo_code == _promo_info.promo_code && pur.promo_code == _promo_info.promo_code select pur).ToList().Count;
                        if (cnt >= _promo_info.client_cnt_limit) { _result_bsm.result_code = "BSM-07004"; }
                    }

                    List<package_info> all_packages = _info_base.get_all_package();

                    var package_info = _info_base.get_package_info_by_id(client_id, "BUY", 0, device_id, package_id, null);
             
                    if (package_info["recurrent"].ToString() == "R" && package_info["current_recurrent_status"].ToString() == "R")
                    {
                        _result_bsm.result_code = "BSM-07008";
                        _result_bsm.result_message = "已使用自動扣款方案,無法使用自動扣款";
                    }

                    if (_promo_info.nobuy_from != null)
                    {
                        string[] pay_type_list = {"CREDIT", "信用卡", "ATM", "REMIT", "信用卡二次扣款" ,"GOOGLE","IOS","HINET","GOOGLEPLAY"};
                        List<purchase_info> _purchase_info = _info_base.cache_client_purchase(client_id, false).purchases;
                        List<purchase_info> l = (from pur in _purchase_info where String.Compare(pur.purchase_date, _promo_info.nobuy_from.Value.ToString("yyyy/MM/dd") ) >=0
                                       && pay_type_list.Contains(pur.pay_type)  
                                   select pur).ToList();
                        foreach (var la in l)
                        {
                            foreach (var dtl in la.details)
                            {
                            List<package_info> pks = (from pkg in all_packages where pkg.package_id == dtl.package_id select pkg).ToList();
                            if (pks != null && pks.Count > 0)
                            {
                                package_info pk = pks[0];
                                if (pk.catalog_id == _promo_info.discount_package_cat_id1)
                                {
                                    _result_bsm.result_code = "BSM-07007";
                                    _result_bsm.result_message = "不符資格,非新會員購買";
                                }
                            }

                            }

                        }
                    }


                    if (_promo_info.check_client)
                    {

                        List<promotion_clients> lc = new List<promotion_clients>();

                        lc = _info_base.get_promotion_client(_promo_info.promo_code, client_id);
                        if (lc.Count == 0)
                        {
                            _result_bsm.result_code = "BSM-07005";
                        }

                    }

                    if (_result_bsm.result_code == "BSM-00000")
                    {
                        promotion_json = (JsonObject)JsonConvert.Import(JsonConvert.ExportToString(_promo_info));
                        promotion_json.Remove("promo_info");
                        JsonObject _promo_info_json = new JsonObject();
                        if(_promo_info.promo_info != "") {
                        _promo_info_json = (JsonObject)JsonConvert.Import(_promo_info.promo_info);
                        }
                        foreach (var a in _promo_info_json) promotion_json.Add(a.Name, a.Value);
                 

                            JsonObject _package = this.get_package_info_by_id(null, "LTWEB00", null, null, package_id);

                            if (_package != null)
                            {
                                try
                                {

                                    List<JsonObject> _packages_options = (List<JsonObject>)_package["options"];
                                    foreach (JsonObject a in _packages_options)
                                    {
                                        /*    if (Convert.ToDecimal(a["amount"]) > 0)
                                            {
                                                a["enabled"] = false;
                                            }
                                            else
                                            { a["enabled"] = true; } */
                                        a["enabled"] = true;
                                    }
                                }
                                catch (InvalidCastException e)
                                {
                                    List<JsonObject> _packages_options = new List<JsonObject>();
                                }
                                catch (NullReferenceException e)
                                {
                                }
                            }
                            
                            // promotion_json.Add("options", _package["options"]);
                            promotion_json.Add("option_title", _package["option_title"]);
                            promotion_json.Add("option_subtitle", _package["option_subtitle"]);
                        


                    }
                }
            }

            _result = (JsonObject)JsonConvert.Import(JsonConvert.ExportToString(_result_bsm));
            if (_result_bsm.result_code == "BSM-00000")
            { foreach (var a in promotion_json) { _result.Add(a.Name, a.Value); } }

            _result.Remove("purchase");
            _result.Remove("purchase_list");
            return _result;
        }

        [JsonRpcMethod("set_all_promo_code")]
        [JsonRpcHelp("設定促銷代碼")]
        public void set_all_promo_code()
        {
            _info_base.set_all_promotion_code();
        }

        [JsonRpcMethod("set_promo_code")]
        [JsonRpcHelp("設定促銷代碼")]
        public void set_promo_code(string client_id )
        {
            _info_base.set_promotion_code(client_id);
        }

        [JsonRpcMethod("get_promo_code")]
        [JsonRpcHelp("取得促銷代碼資訊")]
        public List<promotion_info> get_promo_code(string promo_code)
        {
            return _info_base.get_promtion_code(promo_code);
        }

        [JsonRpcMethod("get_client_purchase_info")]
        public List<purchase_info> get_client_purchase_info(string client_id)
        {
            return _info_base.cache_client_purchase(client_id, false).purchases;
        }

        [JsonRpcMethod("post_package_special")]
        public void bsm_package_special()
        {
            _info_base.post_package_special();
        }


        [JsonRpcMethod("post_package_group_special")]
        public void bsm_package_group_special()
        {
            _info_base.post_package_group_special();
        }

        [JsonRpcMethod("refresh")]
        [JsonRpcHelp("refresh")]
        public void refresh()
        {
            _info_base.refresh();
            _info_base.post_package_special();
            _info_base.post_package_group_special();
            _info_base.set_all_promotion_code();
            _info_base.post_promotion_product();

        }

        [JsonRpcMethod("refresh_all_client_purchase")]
        [JsonRpcHelp("更新所有Client端資訊")]
        public void refresh_all_client_purchse()
        {
            _info_base.cache_all_client_purchase();
        }

        [JsonRpcMethod("refresh_client")]
        [JsonRpcHelp("更新Client資訊")]
        public void refresh_client(string client_id)
        {
            _info_base.refresh_client(client_id);
            _info_base.set_promotion_code(client_id);
            _info_base.set_promotion_code(client_id);
        }

        [JsonRpcMethod("httpRequest")]
        public string httppost(string url,JsonObject postData)
        {
            

            string _result;
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                string _post_data = JsonConvert.ExportToString(postData);
            //    string _post_data = postData;
                logger.Info(_post_data);

                var jsonBytes = Encoding.UTF8.GetBytes(_post_data);
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var httpWebRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
                httpWebRequest.ProtocolVersion = HttpVersion.Version10;//http1.0
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Headers.Add("Authorization", "Basic ZWR3YXJkaHVhbmc6UXdlcjEyMzQ=");
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentLength = jsonBytes.Length;
                var streamWriter = httpWebRequest.GetRequestStream();
                string json = _post_data;

                streamWriter.Write(jsonBytes, 0, jsonBytes.Length);
                streamWriter.Flush();
                try
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream());
                    String result = streamReader.ReadToEnd();
                    _result = result;
                }
                catch (WebException ex)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        String result = reader.ReadToEnd();
                        return result;
                    }
                }
                logger.Info(_result);
                return _result;
            }
            catch (Exception e)
            {
                logger.Info(e.Message);
                return e.Message;
            }

        }
        public override void ProcessRequest(HttpContext context)
        {

            long pos = context.Request.InputStream.Position;

            var read = new StreamReader(context.Request.InputStream);
            string jsontstr = read.ReadToEnd();
            context.Request.InputStream.Position = pos;
            int card_pos = jsontstr.ToUpper().IndexOf("CARD_NUMBER");
            if(card_pos > 0){
            jsontstr = jsontstr.Substring(0, card_pos) + jsontstr.Substring(card_pos + 47);
            }
            logger.Info(jsontstr);

            base.ProcessRequest(context);
        }

    }
}