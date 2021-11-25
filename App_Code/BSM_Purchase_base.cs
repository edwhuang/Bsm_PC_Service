using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using Jayrock.Json;
using Jayrock.JsonRpc;
using Jayrock.JsonRpc.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using BsmDatabaseObjects;
using System.Linq;
using Jayrock.Json.Conversion;

using log4net;
using log4net.Config;





/// <summary>
/// Summary description for Class1
/// </summary>
namespace BSM
{

    public class BSM_ClientInfo
    {
#if NET20
        [JsonProperty]
        public int? region;
#else

        public int region;
#endif

        public string client_id;

        public string serial_id;

        public string mac_address;

        public string client_status;

        public string owner_id;

        public string owner_email;

        public string owner_phone_no;

        public string owner_phone_status;

        public string sw_version;


        public BSM_ClientInfo()
        {
            this.region = 0;
            this.client_status = "unregister";
        }

    }

    /// <summary>
    /// the BSM_Result is a result object, result process sucess or fail or another result code, or result message
    /// </summary>

    public class BSM_Result
    {

        /// <summary>
        /// result code response the process status to caller, result code format is XXX-AABCC, XXX is module name, AA for program ,B for sub program, CC is a serial number, some mesage is intergate , like BSM-00000 is process surcess.
        /// </summary>
        public string result_code;

        /// <summary>
        /// result message is message that want to response to function caller, some API (like purchase BSM-00403) will put the sub error code in message
        /// </summary>
        public string result_message;

        public BSM_ClientInfo client;

        public string purchase_id;

        public string session_uid;

        public BSM_Info.purchase_info purchase;

        public List<BSM_Info.purchase_info> purchase_list;

        public BSM_Result()
        {
            this.result_code = "BSM-00001";
            this.result_message = "FAILURE";
            this.purchase = new BSM_Info.purchase_info();
            this.purchase_list = new List<BSM_Info.purchase_info>();
        }
    }

    public class BsmPurchaseResult
    {

        public string ResultCode;

        public string ResultMessage;

        public string PurchaseId;

        public BSM_ClientInfo client;
    }

    /// <summary>
    /// 信用卡物件
    /// </summary>
    public class Credit
    {
        public string card_type;
        public string card_number;
        public string card_expiry;
        public string cvc2;
    }

    /// <summary>
    /// 購買明細
    /// </summary>
    public class BSM_Purchase_detail
    {
        /// <summary>
        /// item number 請給序號
        /// </summary>
        public int? item_no;

        /// <summary>
        /// 方案代號
        /// </summary>
        public string package_id;

        /// <summary>
        /// content 的明細代號
        /// </summary>
        public string item_id;

        /// <summary>
        /// 價格
        /// </summary>
        public string price;

        public string device_id;
    }
    /// <summary>
    /// 購買需求主檔
    /// </summary>
    public class BSM_Purchase_Request
    {

        /// <summary>
        /// session 唯一鍵值
        /// </summary>
        public string session_uid;

        /// <summary>
        /// 付款方式:'CREDIT' => 信用卡 ,點數=> CREDITS
        /// </summary>
        public string pay_type;

        /// <summary>
        /// client id :請給Mac Address (大寫)
        /// </summary>
        public string client_id;

        /// <summary>
        /// 卡種:VISA or MASTER
        /// </summary>
        public string card_type;

        /// <summary>
        /// 卡號
        /// </summary>
        public string card_number;

        /// <summary>
        /// 到期日
        /// </summary>
        public string card_expiry;

        /// <summary>
        /// CVC2
        /// </summary>
        public string cvc2;

        /// <summary>
        /// 購買明細
        /// </summary>
        //public System.Collections.Generic.List<BSM_Purchase_detail> details;
        public BSM_Purchase_detail[] details;

        /// <summary>
        /// 發票捐贈: 'Y' or N
        /// </summary>
        public string invoice_gift_flg;

        /// <summary>
        /// Recurrent billing : 'R'  recurrent or 'O' OneTime
        /// </summary>
        public string recurrent;

        public string device_id;

        public string promo_code;

        public JsonObject order;

        public JsonObject extra;

        public Purchase_Message_Response[] box_responses;

        public BSM_Purchase_Request()
        {
            this.invoice_gift_flg = "Y";
            this.recurrent = "O";
        }

    }

    public class Purchase_Message_Response
    {
        public string message_id;
        public string btn_id;
    }

    /// <summary>
    /// 購買明細
    /// </summary>
    public class BSM_Purchase_Info_detail
    {
        /// <summary>
        /// 序號
        /// </summary>
        public int? item_no;

        /// <summary>
        /// 方案代號
        /// </summary>
        public string package_id;


        /// <summary>
        /// 方案名稱
        /// </summary>
        public string package_name;

        /// <summary>
        /// content 明細代號
        /// </summary>
        public string item_id;

        /// <summary>
        /// item name
        /// </summary>
        public string item_name;

        /// <summary>
        /// 金額
        /// </summary>
        public int? price;

        /// <summary>
        /// 可播放時間:小時
        /// </summary>
        public int? duration; // hour

        /// <summary>
        /// 可播放數量
        /// </summary>
        public int? quota;
    }

    public class purchase_list
    {
        public BSM_Purchase_Request[] purchases { set; get; }
    }

    /// <summary>
    /// 購買資訊
    /// </summary>
    public class BSM_Purchase_Info
    {

        /// <summary>
        /// session 唯一鍵值
        /// </summary>
        public string session_uid;

        /// <summary>
        /// 訂單代號
        /// </summary>
        public string purchase_id;

        /// <summary>
        /// 訂購日期
        /// </summary>
        public string purchase_date;


        /// <summary>
        /// 狀態
        /// </summary>
        public string status;

        /// <summary>
        /// 發票號碼
        /// </summary>
        public string invoice_no;

        /// <summary>
        /// 發票日期
        /// </summary>
        public string invoice_date;


        /// <summary>
        /// 付款方式
        /// </summary>
        public string pay_type;


        /// <summary>
        /// client id 
        /// </summary>
        public string client_id;

        /// <summary>
        /// 卡種
        /// </summary>
        public string card_type;

        /// <summary>
        /// 卡號
        /// </summary>
        public string card_number;


        /// <summary>
        /// 到期日
        /// </summary>
        public string card_expiry;

        /// <summary>
        /// cvc2
        /// </summary>
        public string cvc2;


        /// <summary>
        /// 授權號
        /// </summary>
        public string approval_code;


        /// <summary>
        /// 發票捐贈
        /// </summary>
        public string invoice_gift_flg;

        public string bar_invo_no;

        public string bar_due_date;

        public string bar_price;

        public string bar_atm;

        public string due_date;

        public string device_id;


        /// <summary>
        /// 購買明細
        /// </summary>
        public System.Collections.Generic.List<BSM_Purchase_Info_detail> details;

        public BSM_Purchase_Info()
        {
            // this.Details = new BSM_Purchase_Info_details();
            this.details = new List<BSM_Purchase_Info_detail>();
        }
    }

    public class BSM_Purchase_Service_base
    {
        public OracleConnection conn;
        private BSM_Info.BSM_Info_Service_base _info_base;
        private String _MongoDBConnect;
        private String MongoDB_Database;
        static ILog logger;

        Dictionary<string, string> cht_payments;
        Dictionary<string, string> cht_prodduct_code;

        public BSM_Purchase_Service_base(String ConnectString, String MongoDBConnect, String MongoDB_Database)
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            conn = new OracleConnection();
            conn.ConnectionString = ConnectString;
            _MongoDBConnect = MongoDBConnect;
            _info_base = new BSM_Info.BSM_Info_Service_base(ConnectString, _MongoDBConnect, MongoDB_Database);

            cht_payments = new Dictionary<string, string>();
            cht_prodduct_code = new Dictionary<string, string>();
        }


        /// <summary>
        /// 登錄
        /// </summary>
        /// <param name="token"></param>
        /// <param name="Client_Info"></param>
        /// <returns></returns>
        [JsonRpcMethod("register")]
        [JsonRpcHelp("Client 登錄")]
        public BSM_Result register(string token, BSM_ClientInfo Client_Info)
        {
            BSM_Result result;
            result = new BSM_Result();
            BSM_ClientInfo v_Client_Info = new BSM_ClientInfo();

            result.result_code = "BSM-00000";
            result.result_message = "OK";

            //Check MAC can't null
            if (Client_Info.mac_address == null)
            {
                result.result_code = "BSM-00103";
                result.result_message = "未輸入MAC_ADDRESS";
                result.client = Client_Info;
                return result;
            }
            else
            {
                Client_Info.mac_address = Client_Info.mac_address.Replace(":", "");
                Client_Info.mac_address = Client_Info.mac_address.ToUpper();

            }

            // 檢查是否輸入電話號碼
            if (Client_Info.owner_phone_no == null)
            {
                result.result_code = "BSM-00101";
                result.result_message = "未輸入電話號碼";
                result.client = Client_Info;
                return result;
            }
            //檢查電話號碼是否為空號
            else if (Client_Info.owner_phone_no == "")
            {
                result.result_code = "BSM-00101";
                result.result_message = "電話號碼為空字串";
                result.client = Client_Info;
                return result;
            }
            //檢查電話號碼是否為行動電話
            else if (Client_Info.owner_phone_no.Substring(0, 2) != "09")
            {

                result.result_code = "BSM-00102";
                result.result_message = "電話號碼不是行動電話號碼";
                result.client = Client_Info;
                return result;
            }

            // 更新資料庫項目

            conn.Open();
            string sql1 = "begin :M_RESULT := BSM_CLIENT_SERVICE.Check_And_Register_Client(:M_CLIENT_INFO); end; ";

            TBSM_CLIENT_INFO t_client_info = new TBSM_CLIENT_INFO();
            TBSM_RESULT bsm_result = new TBSM_RESULT();

            t_client_info.SERIAL_ID = Client_Info.serial_id;
            t_client_info.MAC_ADDRESS = Client_Info.mac_address;
            t_client_info.OWNER_PHONE = Client_Info.owner_phone_no;


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
                param2.ParameterName = "M_RESULT";
                param2.OracleDbType = OracleDbType.Object;
                param2.Direction = ParameterDirection.InputOutput;
                param2.UdtTypeName = "TBSM_RESULT";


                cmd.Parameters.Add(param2);

                cmd.ExecuteNonQuery();

                bsm_result = (TBSM_RESULT)param2.Value;

                t_client_info = (TBSM_CLIENT_INFO)param1.Value;

                v_Client_Info.serial_id = t_client_info.SERIAL_ID;
                v_Client_Info.region = (int)t_client_info.REGION;
                v_Client_Info.owner_phone_no = t_client_info.OWNER_PHONE;
                v_Client_Info.owner_phone_status = t_client_info.OWNER_PHONE_STATUS;
                v_Client_Info.mac_address = t_client_info.MAC_ADDRESS;
                v_Client_Info.client_status = t_client_info.STATUS_FLG;

                if (bsm_result.RESULT_CODE != "BSM-00000")
                {
                    result.result_code = bsm_result.RESULT_CODE;
                    result.result_message = bsm_result.RESULT_MESSAGE;
                    result.client = Client_Info;

                    return result;
                }


            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }


            return result;
        }


        /// <summary>
        /// 啟用
        /// </summary>
        /// <param name="token"></param>
        /// <param name="Client_Info"></param>
        /// <param name="Activation_Code"></param>
        /// <returns></returns>

        [JsonRpcMethod("activate")]
        [JsonRpcHelp("Client 啟用")]
        public BSM_Result activate(string token, BSM_ClientInfo Client_Info, string Activation_Code)
        {
            BSM_Result result;
            result = new BSM_Result();
            BSM_ClientInfo v_Client_Info = new BSM_ClientInfo();
            if (Client_Info.mac_address == null)
            {
                result.result_code = "BSM-00103";
                result.result_message = "未輸入MAC_ADDRESS";
                result.client = Client_Info;
                return result;
            }
            else
            {
                Client_Info.mac_address = Client_Info.mac_address.Replace(":", "");
                Client_Info.mac_address = Client_Info.mac_address.ToUpper();
            }


            // 檢查啟用碼是否為空值
            if (Activation_Code == "")
            {
                result.result_code = "BSM-00201";
                result.result_message = "未輸入Activation Code null";
                result.client = Client_Info;
                return result;
            }

            conn.Open();
            string sql1 = "begin :M_RESULT := BSM_CLIENT_SERVICE.Activate_Client(:M_CLIENT_INFO); end; ";

            TBSM_CLIENT_INFO t_client_info = new TBSM_CLIENT_INFO();
            TBSM_RESULT bsm_result = new TBSM_RESULT();

            t_client_info.SERIAL_ID = Client_Info.serial_id;
            t_client_info.MAC_ADDRESS = Client_Info.mac_address;
            t_client_info.OWNER_PHONE = Client_Info.owner_phone_no;
            t_client_info.ACTIVATION_CODE = Activation_Code;

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
                param2.ParameterName = "M_RESULT";
                param2.OracleDbType = OracleDbType.Object;
                param2.Direction = ParameterDirection.InputOutput;
                param2.UdtTypeName = "TBSM_RESULT";


                cmd.Parameters.Add(param2);
                cmd.ExecuteNonQuery();

                bsm_result = (TBSM_RESULT)param2.Value;
                t_client_info = (TBSM_CLIENT_INFO)param1.Value;

                v_Client_Info.serial_id = t_client_info.SERIAL_ID;
                v_Client_Info.region = (int)t_client_info.REGION;
                v_Client_Info.owner_phone_no = t_client_info.OWNER_PHONE;
                v_Client_Info.owner_phone_status = t_client_info.OWNER_PHONE_STATUS;
                v_Client_Info.mac_address = t_client_info.MAC_ADDRESS;
                v_Client_Info.client_status = t_client_info.STATUS_FLG;

                if (bsm_result.RESULT_CODE != "BSM-00000")
                {
                    result.result_code = bsm_result.RESULT_CODE;
                    result.result_message = bsm_result.RESULT_MESSAGE;
                    result.client = v_Client_Info;
                    return result;
                }
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }

            result.result_code = bsm_result.RESULT_CODE;
            result.result_message = bsm_result.RESULT_MESSAGE;
            result.client = v_Client_Info;
            return result;
        }
        /// <summary>
        /// 購買
        /// </summary>
        /// <param name="token"></param>
        /// <param name="purchase_info"></param>
        /// <returns></returns>
        [JsonRpcMethod("purchase")]
        [JsonRpcHelp("Client 購買")]
        public BSM_Result purchase(string token, string device_id, string sw_version, BSM_Purchase_Request purchase_info, JsonObject cht_params, string otpw, string authority, string user_agent, string browser_type)
        {
            BSM_Result result;
            result = new BSM_Result();
            try
            {

                //    BSM_Info.BSM_Info_Service_base BSM_Info_base;
                string v_gift_tax_flg = purchase_info.invoice_gift_flg ?? "Y";
                sw_version = sw_version ?? "LTWEB00";
                string v_option = "";
                JsonObject _option = new JsonObject();

                result.session_uid = purchase_info.session_uid;

                if (purchase_info.client_id == null)
                {
                    result.result_code = "BSM-00301";
                    result.result_message = "未輸入Client Id";
                    return result;
                }

                purchase_info.client_id = purchase_info.client_id.ToUpper();
                if (purchase_info.session_uid == null)
                {
                    purchase_info.session_uid = "PCBUGFIX" + DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString();
                }
                if (purchase_info.session_uid.Length > 32)
                {
                    purchase_info.session_uid = purchase_info.session_uid.Substring(0, 32);
                }

                conn.Open();
                string sql1 = "begin :M_RESULT := BSM_CLIENT_SERVICE.CRT_PURCHASE(:M_PURCHASE_INFO,:P_RECURRENT,:P_DEVICE_ID,:P_OPTION,:SW_VERSION); end; ";


                TBSM_PURCHASE bsm_purchase = new TBSM_PURCHASE();
                TBSM_PURCHASE_DTLS bsm_purchase_dtls = new TBSM_PURCHASE_DTLS();

                TBSM_RESULT bsm_result = new TBSM_RESULT();

                OracleCommand cmd = new OracleCommand(sql1, conn);
                bsm_purchase.SRC_NO = purchase_info.session_uid;
                bsm_purchase.SERIAL_ID = purchase_info.client_id;

                if (cht_params != null)
                {

                    if ((string)cht_params["aa-result"] != "Success" && (string)cht_params["aa-result"] != null && (string)cht_params["aa-result"] != "")
                    {
                        result.result_code = "BSM-00308";
                        result.result_message = "中華電信付款失敗,錯誤代碼" + (string)cht_params["aa-result"];
                        return result;
                    }
                }


                if ((purchase_info.client_id == null) || (purchase_info.client_id == ""))
                {
                    result.result_code = "BSM-00301";
                    result.result_message = "未輸入ClientID";
                    return result;
                }
                if ((purchase_info.pay_type == null) || (purchase_info.pay_type == ""))
                {
                    result.result_code = "BSM-00304";
                    result.result_message = "未輸入付款方式認證碼";
                    return result;
                }

                if (purchase_info.pay_type == "C_HINET" || purchase_info.pay_type == "C_CHTN" || purchase_info.pay_type == "C_CHTLD")
                {
                    purchase_info.pay_type = "中華電信帳單";

                    string[] Keys = new String[] { "aa-result", "aa-otpw", "aa-authority", "aa-uid" };

                    foreach (var Key in Keys)
                    {
                        _option.Add(Key.Replace("aa-", ""), cht_params[Key]);
                    }
                }

                if (purchase_info.pay_type == "C_CREDIT")
                {
                    purchase_info.pay_type = "中華電信信用卡";

                    string[] Keys = new String[] { "aa-result", "aa-otpw", "aa-authority", "aa-uid", "PAN", "ApproveCode" };

                    foreach (var Key in Keys)
                    {
                        _option.Add(Key.Replace("aa-", ""), cht_params[Key]);
                    }
                }

                if (purchase_info.pay_type == "C_ATM" || purchase_info.pay_type == "C_WEBATM")
                {
                    purchase_info.pay_type = "中華電信ATM";

                    string[] Keys = new String[] { "aa-result", "aa-otpw", "aa-authority", "aa-uid" };

                    foreach (var Key in Keys)
                    {
                        _option.Add(Key.Replace("aa-", ""), cht_params[Key]);
                    }
                }

                _option.Add("order", purchase_info.order);
                _option.Add("promo_code", purchase_info.promo_code);
                _option.Add("extra", purchase_info.extra);
                _option.Add("user_agent",user_agent);
                _option.Add("browser_type", browser_type);
                


                v_option = JsonConvert.ExportToString(_option);

                { bsm_purchase.PAY_TYPE = purchase_info.pay_type; }

                if (purchase_info.pay_type == "CREDIT")
                {
                    purchase_info.pay_type = "信用卡";
                }

                if (purchase_info.pay_type == "信用卡")
                {
                    if ((purchase_info.card_number == null) || (purchase_info.card_number == ""))
                    {
                        result.result_code = "BSM-00302";
                        result.result_message = "未輸入卡號";
                        return result;
                    }
                    else
                    { bsm_purchase.CARD_NO = purchase_info.card_number; }

                    if ((purchase_info.card_type == null) || (purchase_info.card_type == ""))
                    {
                        result.result_code = "BSM-00303";
                        result.result_message = "未輸入信用卡種類";
                        return result;
                    }
                    else
                    { bsm_purchase.CARD_TYPE = purchase_info.card_type; }

                    if ((purchase_info.card_expiry == null) || (purchase_info.card_expiry == ""))
                    {
                        result.result_code = "BSM-00304";
                        result.result_message = "未輸入信用卡期限";
                        return result;
                    }
                    else
                    { bsm_purchase.CARD_EXPIRY = purchase_info.card_expiry; }

                    if ((purchase_info.cvc2 == null) || (purchase_info.cvc2 == "") || (purchase_info.cvc2 == "null"))
                    {
                        result.result_code = "BSM-00304";
                        result.result_message = "未輸入信用卡認證碼";
                        return result;
                    }
                    { bsm_purchase.CVC2 = purchase_info.cvc2; }
                    if (purchase_info.card_number.Substring(0, 1) == "3")
                    { purchase_info.card_type = "JBC"; }
                    if ((purchase_info.card_type == "VISA" && purchase_info.card_number.Substring(0, 1) != "4") || (purchase_info.card_type == "MASTER" && purchase_info.card_number.Substring(0, 1) != "5") || (purchase_info.card_type == "JBC" && purchase_info.card_number.Substring(0, 1) != "3"))
                    {
                        result.result_code = "BSM-00306";
                        result.result_message = "信用卡種類錯誤";
                        return result;
                    }

                }



                bsm_purchase_dtls.Value = new TBSM_PURCHASE_DTL[purchase_info.details.Length];
                for (int i = 0; i < purchase_info.details.Length; i++)
                {
                    bsm_purchase_dtls.Value[i] = new TBSM_PURCHASE_DTL();
                    bsm_purchase_dtls.Value[i].ASSET_ID = purchase_info.details[i].item_id;
                    bsm_purchase_dtls.Value[i].OFFER_ID = purchase_info.details[i].package_id;
                }

                bsm_purchase.DETAILS = bsm_purchase_dtls;

                try
                {
                    cmd.BindByName = true;

                    OracleParameter param1 = new OracleParameter();
                    param1.ParameterName = "M_PURCHASE_INFO";
                    param1.OracleDbType = OracleDbType.Object;
                    param1.Direction = ParameterDirection.InputOutput;
                    param1.UdtTypeName = "TBSM_PURCHASE";
                    param1.Value = bsm_purchase;
                    cmd.Parameters.Add(param1);

                    OracleParameter param2 = new OracleParameter();
                    param2.ParameterName = "M_RESULT";
                    param2.OracleDbType = OracleDbType.Object;
                    param2.Direction = ParameterDirection.InputOutput;
                    param2.UdtTypeName = "TBSM_RESULT";
                    cmd.Parameters.Add(param2);

                    OracleParameter param3 = new OracleParameter();
                    param3.ParameterName = "P_RECURRENT";
                    param3.Direction = ParameterDirection.Input;
                    param3.Value = (purchase_info.recurrent != null && purchase_info.recurrent != "") ? purchase_info.recurrent : "";
                    cmd.Parameters.Add(param3);

                    OracleParameter param4 = new OracleParameter();
                    param4.ParameterName = "P_DEVICE_ID";
                    param4.Direction = ParameterDirection.Input;
                    param4.Value = device_id;

                    cmd.Parameters.Add(param4);


                    OracleParameter param6 = new OracleParameter();
                    param6.ParameterName = "P_OPTION";
                    param6.Direction = ParameterDirection.Input;
                    param6.Value = v_option;

                    cmd.Parameters.Add(param6);


                    OracleParameter param5 = new OracleParameter();
                    param5.ParameterName = "SW_VERSION";
                    param5.Direction = ParameterDirection.Input;
                    param5.Value = sw_version;

                    cmd.Parameters.Add(param5);


                    cmd.ExecuteNonQuery();

                    bsm_result = (TBSM_RESULT)param2.Value;
                    bsm_purchase = (TBSM_PURCHASE)param1.Value;

                    if (bsm_result.RESULT_CODE != "BSM-00000")
                    {
                        result.result_code = bsm_result.RESULT_CODE;
                        result.result_message = bsm_result.RESULT_MESSAGE;
                        result.purchase_id = bsm_purchase.MAS_NO;

                        if (result.purchase_id == null)
                        {
                            result.purchase_id = "PURXXXXXXXXXXXXXX";
                        }
                        else
                        {
                            if (result.purchase_list == null || result.purchase_list.Count <= 0)
                            {
                                result.purchase_list = (result.purchase_id == null) ? new List<BSM_Info.purchase_info>() : (from a in _info_base.get_purchase_info(purchase_info.client_id, null, null) where a.purchase_id == result.purchase_id select a).ToList();

                            }
                        }
                    }
                    else
                    {
                        result.result_code = bsm_result.RESULT_CODE;
                        result.result_message = bsm_result.RESULT_MESSAGE;
                        result.purchase_id = bsm_purchase.MAS_NO;
                        result.purchase_list = (result.purchase_id == null) ? new List<BSM_Info.purchase_info>() : (from a in _info_base.cache_client_purchase(purchase_info.client_id, true).purchases where a.purchase_id == result.purchase_id select a).ToList();
                        if (result.purchase_list == null || result.purchase_list.Count <= 0)
                        {
                            result.purchase_list = (result.purchase_id == null) ? new List<BSM_Info.purchase_info>() : (from a in _info_base.get_purchase_info(purchase_info.client_id, null,null) where a.purchase_id == result.purchase_id select a).ToList();
                        
                        }

                        this.set_invoice_gift(v_gift_tax_flg, bsm_purchase.MAS_NO);
                    }
                }
                catch(Exception e)
                {
                     logger.Info(e.Message);
                }
                finally
                {
                    conn.Close();
                    cmd.Dispose();
                }

                logger.Info(JsonConvert.ExportToString(result));
                return result;
            }
            catch (Exception e)
            {
                logger.Info(e.Message);
                return result;

            }
        }

        public BSM_Result modify_purchase(string purchase_id, BSM_Purchase_Request purchase_info)
        {
            BSM_Result _result = new BSM_Result();
            JsonObject _options = new JsonObject();
            string v_option;
            _result.result_code = "BSM-00000";
            _result.result_message = "Sucess";
            string _sql = @"UPDATE BSM_PURCHASE_MAS SET OPTIONS=:P_OPTIONS WHERE MAS_NO=:P_MAS_NO";
            OracleCommand _cmd = new OracleCommand(_sql, conn);
            _cmd.BindByName = true;
            conn.Open();
            try
            {
                _options.Add("order", purchase_info.order);
                v_option = JsonConvert.ExportToString(_options);
                _cmd.Parameters.Add("P_OPTIONS", v_option);
                _cmd.Parameters.Add("P_MAS_NO", purchase_id);
                _cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                _result.result_code = "BSM-00307";
                _result.result_message = e.Message;
            }
            finally
            {
                conn.Close();
            }

            return _result;
        }

        public JsonObject order(string token, string client_id, string device_id, string sw_version, JsonObject order)
        {

            JsonObject result = new JsonObject();

            result.Add("result_code", "BSM-00000");
            result.Add("result_message", "Success");

            conn.Open();

            string sql1 = "begin :M_RESULT := BSM_ORDER_SERVICE.create_order(:P_ORDER); end; ";

            OracleCommand cmd = new OracleCommand(sql1, conn);
            order.Add("client_id", client_id);

            string _json_string = JsonConvert.ExportToString(order);

            try
            {
                cmd.BindByName = true;

                OracleParameter param1 = new OracleParameter();
                param1.ParameterName = "P_ORDER";
                param1.Direction = ParameterDirection.InputOutput;
                param1.Value = _json_string;
                cmd.Parameters.Add(param1);

                OracleParameter param2 = new OracleParameter();
                param2.ParameterName = "M_RESULT";
                param2.Size = 1024;
                param2.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param2);
                cmd.ExecuteNonQuery();

                JsonArray _purchase_list = new JsonArray();

                string oracle_return = param2.Value.ToString();
                oracle_return = oracle_return.Replace("/n", "").Replace("/r", "");
                if (oracle_return != "")
                {
                    JsonObject oracle_json = (JsonObject)JsonConvert.Import(typeof(JsonObject), oracle_return);
                    result["result_code"] = oracle_json["result_code"].ToString();
                    result["result_message"] = oracle_json["result_message"].ToString();

                    if (result["result_code"].ToString() == "BSM-00000" || result["result_code"].ToString() == "BSM-00404")
                    {
                        order["cardNo"] = "********";
                        order.Add("order_no", oracle_json["order_no"].ToString());
                        result.Add("purchase_id", oracle_json["order_no"].ToString());

                        List<BSM_Info.purchase_info> _p_l = new List<BSM_Info.purchase_info>();

                        _p_l = this._info_base.get_order(client_id, device_id, order["order_no"].ToString());


                        if (_p_l.Count > 0)
                        {
                            _p_l[0].invoice_gift_flg = order["invoiceGiftFlg"].ToString();
                            order.Remove("invoiceGiftFlg");
                            _purchase_list.Add(JsonConvert.Import(typeof(JsonObject), JsonConvert.ExportToString(_p_l[0])));
                            foreach (string a in order.GetNamesArray())
                                ((JsonObject)_purchase_list[0]).Add(a, order[a]);
                        }

                    }
                }

                result.Add("purchase_list", _purchase_list);
            }
            catch (Exception e)
            {
                result["result_code"] = "BSM-00308";
                result["result_message"] = e.Message;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }
            logger.Info(JsonConvert.ExportToString(result));

            return result;
        }

        /// <summary>
        /// 設定發票捐贈
        /// </summary>
        /// <param name="gift_flg"></param>
        /// <param name="purchase_id"></param>
        /// <returns></returns>
        /// 
        [JsonRpcMethod("set_invoice_gift")]
        [JsonRpcHelp("發票贈送 gift_flg :Y 贈送 N不贈送")]
        public BSM_Purchase_Info set_invoice_gift(string gift_flg, string purchase_id)
        {
            BSM_Purchase_Info v_result = new BSM.BSM_Purchase_Info();

            string sql1 = "update bsm_purchase_mas a set a.tax_gift = :p_gift where a.mas_no = :p_purchase_id";
            OracleCommand cmd = new OracleCommand(sql1, conn);
            cmd.BindByName = true;
            cmd.Parameters.Add("P_GIFT", gift_flg);
            cmd.Parameters.Add("P_PURCHASE_ID", purchase_id);
            cmd.ExecuteNonQuery();
            v_result = GetPurchaseInfoPriv(purchase_id);

            return v_result;
        }

        [JsonRpcMethod("cancel_purchase")]
        [JsonRpcHelp("取消購買")]
        public BSM_Result cancel_purchase(string purchase_id)
        {
            BSM_Result v_result = new BSM.BSM_Result();
            conn.Open();
            try
            {

                v_result.result_code = "BSM-00000";

                string sql2 = @"Select a.status_flg from bsm_purchase_mas a where a.mas_no='" + purchase_id + "'";
                OracleCommand cmd2 = new OracleCommand(sql2, conn);
                try
                {
                    OracleDataReader _rd = cmd2.ExecuteReader();
                    if (_rd.Read()) { if (_rd.GetString(0) != "P") { v_result.result_code = "BSM-00305"; v_result.result_message = "單據狀態不正確."; } }
                    else { v_result.result_code = "BSM-00306"; v_result.result_message = "找不到單據."; }
                    _rd.Dispose();
                }
                finally
                {

                    cmd2.Dispose();

                }


                if (v_result.result_code == "BSM-00000")
                {
                    string sql1 = "update bsm_purchase_mas a set a.show_flg='N',a.status_flg='C' where a.mas_no = :p_purchase_id";
                    OracleCommand cmd = new OracleCommand(sql1, conn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add("P_PURCHASE_ID", purchase_id);
                    cmd.ExecuteNonQuery();
                    v_result.result_code = "BSM-00000";
                    v_result.result_message = "完成";
                }
            }
            finally
            {
                conn.Close();
            }

            return v_result;
        }


        [JsonRpcMethod("get_purchasde_id_test")]
        public BSM_Purchase_Info GetPurchaseInfoPriv(string purchase_id)
        {
            //conn.Open();
            BSM_Purchase_Info _result = new BSM.BSM_Purchase_Info();
            string _sql_mas = @" Select a.pk_no,
             mas_no,
             mas_date,
             mas_code,
             src_no,
             src_date,
             serial_no,
             serial_id,
             status_flg,
             purchase_date,
             decode(pay_type,
'其他','OTHER',
'CREDIT','CREDIT',
'贈送','GIFT',
'手動刷卡','CREDIT',
'兌換券','GOUPON',
'儲值卡','CREDITS',
'信用卡','CREDIT',
'ATM','ATM',
'REMIT','REMIT',
'便利商店','REMIT',
'匯款','REMIT',
pay_type)  pay_type,
             card_no,
             card_type,
             card_expiry,
             cvc2,
             a.approval_code,
             a.bar_no,
             a.bar_due_date,
             a.bar_code,
             a.inv_acc,
             to_char(a.due_date,'YYYY/MM/DD') due_date
        From bsm_purchase_mas a,bsm_purchase_item b
       Where a.mas_no = :P_PURCHASE_ID
         and b.mas_pk_no = a.pk_no";

            OracleCommand _cmd = new OracleCommand(_sql_mas, conn);
            _cmd.BindByName = true;

            OracleParameter param1 = new OracleParameter();
            param1.ParameterName = "P_PURCHASE_ID";
            param1.OracleDbType = OracleDbType.Varchar2;
            param1.Direction = ParameterDirection.Input;
            param1.Value = purchase_id;

            _cmd.Parameters.Add(param1);

            string _sql_item = @" Select *
        From bsm_purchase_item a
       Where a.mas_pk_no = :P_PK_NO";
            OracleCommand _cmd_i = new OracleCommand(_sql_item, conn);
            _cmd_i.BindByName = true;
            OracleParameter param2 = new OracleParameter();
            param2.ParameterName = "P_PK_NO";
            param2.OracleDbType = OracleDbType.Decimal;
            param2.Direction = ParameterDirection.Input;
            _cmd_i.Parameters.Add(param2);

            OracleDataReader _odr = _cmd.ExecuteReader();

            while (_odr.Read())
            {
                for (int i = 0; i < _odr.FieldCount; i++)
                {
                    if (!_odr.IsDBNull(i))
                    {
                        switch (_odr.GetName(i))
                        {
                            case "SRC_NO":
                                _result.session_uid = _odr.GetString(i);
                                break;
                            case "MAS_NO":
                                _result.purchase_id = _odr.GetString(i);
                                break;
                            case "SERIAL_ID":
                                _result.client_id = _odr.GetString(i);
                                break;
                            case "PAY_TYPE":
                                _result.pay_type = _odr.GetString(i);
                                break;
                            case "PURCHASE_DATE":
                                _result.purchase_date = _odr.GetDateTime(i).ToString("yyyy/M/dd HH:mm:ss"); ;
                                break;
                            case "CARD_NO":
                                _result.card_number = _odr.GetString(i);
                                break;
                            case "CARD_TYPE":
                                _result.card_type = _odr.GetString(i);
                                break;
                            case "CVC2":
                                _result.cvc2 = _odr.GetString(i);
                                break;
                            case "APPROVAL_CODE":
                                _result.approval_code = _odr.GetString(i);
                                break;
                            case "BAR_NO":
                                _result.bar_invo_no = _odr.GetString(i);
                                break;
                            case "BAR_CODE":
                                _result.bar_price = _odr.GetString(i);
                                break;
                            case "BAR_DUE_DATE":
                                _result.bar_due_date = _odr.GetString(i);
                                break;
                            case "INV_ACC":
                                _result.bar_atm = _odr.GetString(i);
                                break;
                            case "DUE_DATE":
                                _result.due_date = _odr.GetString(i);
                                break;

                        }
                    }


                }

                param2.Value = _odr.GetDecimal(0);

                OracleDataReader _odr2 = _cmd_i.ExecuteReader();

                while (_odr2.Read())
                {
                    BSM.BSM_Purchase_Info_detail m = new BSM_Purchase_Info_detail();

                    for (int i = 0; i < _odr2.FieldCount; i++)
                    {
                        if (!_odr2.IsDBNull(i))
                        {
                            switch (_odr2.GetName(i))
                            {
                                case "ITEM_ID":
                                    m.item_id = _odr2.GetString(i);
                                    break;
                                case "ITEM_NAME":
                                    m.item_name = _odr2.GetString(i);
                                    break;
                                case "PACKAGE_ID":
                                    m.package_id = _odr2.GetString(i);
                                    break;
                                case "PACKAGE_NAME":
                                    m.package_name = _odr2.GetString(i);
                                    break;
                                case "AMOUNT":
                                    m.price = (int)_odr2.GetDecimal(i);
                                    break;
                                case "QUOTA":
                                    m.quota = (int)_odr2.GetDecimal(i);
                                    break;
                                case "DURATION":
                                    m.duration = (int)_odr2.GetDecimal(i);
                                    break;
                                case "DEVICE_ID":
                                    _result.device_id = _odr2.GetString(i);
                                    break;

                            }

                        }
                    }
                    _result.details.Add(m);
                }
                _odr2.Dispose();
            }

            _odr.Dispose();
            _cmd.Dispose();
            _cmd_i.Dispose();
            //   conn.Close();

            return _result;
        }

        public List<BSM_Info.purchase_info> get_purchase_info_by_id_atm(string client_id, string purchase_id)
        {
            client_id = client_id.ToUpper();
            //BSM_Info.purchase_info v_result;
            List<BSM_Info.purchase_info> v_result = new List<BSM_Info.purchase_info>();
            if (conn.State == ConnectionState.Closed) conn.Open();

            try
            {
                string _sql;
                string _sql_dtl;

                _sql = "with cte as (" +
  "Select a.pk_no, to_char(a.purchase_date, 'yyyy/mm/dd') purchase_date, to_char(a.purchase_date, 'yyyy/mm/dd hh24:mi') purchase_datetime, " +
  " a.mas_no purchase_id,a.card_no card_no, " +
  " decode(a.pay_type,'其他','OTHER','贈送','GIFT','手動刷卡','CREDIT','兌換券','COUPON','儲值卡','CREDITS','信用卡','CREDIT','便利商店','REMIT','匯款','REMIT',a.pay_type) pay_type, " +
  " a.amount,decode(a.status_flg,'Z',3,'P', case when (least((a.due_date + 1), sysdate) > a.due_date) then 2 else 1 end) pay_status," +
  " to_char(a.due_date, 'yyyy/mm/dd') pay_due_date, " +
  " a.tax_inv_no invoice_no, a.tax_gift invoice_gift_flag, " +
  " a.bar_no bar_invo_no, a.bar_due_date, a.bar_code bar_price, " +
  " a.inv_acc bar_atm, DECODE(a.recurrent, 'Y', 'R', 'N', 'O', a.recurrent) recurrent, " +
  " decode(a.recurrent,'R',to_char(BSM_RECURRENT_UTIL.get_service_end_date(d.package_cat_id1, :MAC_ADDRESS),'YYYY/MM/DD'),'無') next_pay_date,e.device_id ,d.package_cat_id1 cat_id,a.cost_credits,a.chg_amt||'點' credits,a.after_credits," +
  " a.cht_auth " +
  " from bsm_purchase_mas   a, " +
  "     bsm_purchase_item  e, " +
  "     bsm_client_details c, " +
  "     bsm_package_mas    d " +
  " where e.mas_pk_no (+) =a.pk_no " +
  " and c.src_pk_no (+) =e.mas_pk_no " +
  " and c.src_item_pk_no (+) = e.pk_no " +
  " and e.package_id = d.package_id " +
  " and a.status_flg in ('P', 'Z') " +
  " and not a.show_flg ='N' " +
  " and a.serial_id = :MAC_ADDRESS " +
  " and a.purchase_date > (sysdate - 93) " +
  " and a.mas_no = :PURCHASE_ID " +
  " and a.trans_to is null and a.show_flg <> 'N' )" +
  "select distinct pk_no, purchase_date, purchase_datetime, purchase_id, card_no, pay_type, amount, pay_status, pay_due_date, invoice_no, invoice_gift_flag, " +
  "bar_invo_no, bar_due_date, bar_price, bar_atm, recurrent, next_pay_date,device_id ,cost_credits,credits,after_credits,cht_auth from cte " +
  "Order by purchase_date desc, purchase_id desc ";

                _sql_dtl = "select e.mas_pk_no,d.package_cat1 catalog_description, decode(c.start_date,null,'未啟用',decode(sign(end_date - sysdate), 1, '已啟用', '已到期')) status_description," +
  "to_char(c.start_date, 'YYYY/MM/DD') start_date,to_char(c.end_date, 'YYYY/MM/DD') end_date,d.description package_name,e.package_id,e.price,d.price_des,e.device_id,d.package_cat_id1 cat_id ,a.cost_credits,a.chg_amt||'點'  credits,a.after_credits" +
  " from bsm_purchase_mas   a, " +
  "     bsm_purchase_item  e, " +
  "     bsm_client_details c, " +
  "     bsm_package_mas    d " +
  " where e.mas_pk_no =a.pk_no " +
  " and c.src_pk_no (+) =e.mas_pk_no " +
  " and c.src_item_pk_no (+) = e.pk_no " +
  " and e.package_id = d.package_id " +
  " and a.status_flg in ('P', 'Z') " +
  " and not a.show_flg ='N' " +
  " and a.serial_id = :MAC_ADDRESS " +
  " and a.purchase_date > (sysdate - 93) " +
  " and a.trans_to is null and a.show_flg <> 'N'" +
  " and a.pk_no = :PK_NO " +
  " Order by to_char(a.purchase_date, 'YYYY/MM/DD') desc, a.mas_no desc";


                OracleCommand _cmd = new OracleCommand(_sql, conn);
                _cmd.BindByName = true;
                _cmd.Parameters.Add("MAC_ADDRESS", client_id);
                _cmd.Parameters.Add("PURCHASE_ID", purchase_id);

                OracleDataReader v_Data_Reader = _cmd.ExecuteReader();
                //mTable.Load(v_Data_Reader);

                string pk_no;
                string mas_pk_no;
                try
                {
                    int _i = 0;
                    while (v_Data_Reader.Read())
                    {

                        BSM_Info.purchase_info v_purchase_info = new BSM_Info.purchase_info();
                        v_purchase_info.details = new List<BSM_Info.purchase_detail>();

                        if (!v_Data_Reader.IsDBNull(1))
                        {
                            v_purchase_info.purchase_date = v_Data_Reader.GetString(1);
                        }

                        if (!v_Data_Reader.IsDBNull(2))
                        {
                            v_purchase_info.purchase_datetime = v_Data_Reader.GetString(2);
                        }

                        if (!v_Data_Reader.IsDBNull(3))
                        {
                            v_purchase_info.purchase_id = v_Data_Reader.GetString(3);
                        }

                        if (!v_Data_Reader.IsDBNull(4))
                        {
                            v_purchase_info.card_no = v_Data_Reader.GetString(4);
                        }

                        string[] hinet_pay = { "中華電信帳單", "中華電信信用卡", "中華電信ATM" };
                        v_purchase_info.pay_type = hinet_pay.Contains(Convert.ToString(v_Data_Reader["PAY_TYPE"])) ? "C_" + Convert.ToString(v_Data_Reader["CHT_AUTH"]).ToUpper() : Convert.ToString(v_Data_Reader["PAY_TYPE"]);
                        v_purchase_info.bank_code = Convert.ToString(v_Data_Reader["PAY_TYPE"]) == "中華電信ATM" ? "004" : "812";

                        if (!v_Data_Reader.IsDBNull(6))
                        {
                            v_purchase_info.amount = v_Data_Reader.GetDecimal(6);
                        }

                        if (!v_Data_Reader.IsDBNull(7))
                        {
                            v_purchase_info.pay_status = v_Data_Reader.GetDecimal(7);
                        }
                        if (!v_Data_Reader.IsDBNull(8))
                        {
                            v_purchase_info.pay_due_date = v_Data_Reader.GetString(8);
                        }
                        if (!v_Data_Reader.IsDBNull(9))
                        {
                            v_purchase_info.invoice_no = v_Data_Reader.GetString(9);
                        }
                        if (!v_Data_Reader.IsDBNull(10))
                        {
                            v_purchase_info.invoice_gift_flg = v_Data_Reader.GetString(10);
                        }
                        if (!v_Data_Reader.IsDBNull(11))
                        {
                            v_purchase_info.bar_invo_no = v_Data_Reader.GetString(11);
                        }
                        if (!v_Data_Reader.IsDBNull(12))
                        {
                            v_purchase_info.bar_due_date = v_Data_Reader.GetString(12);
                        }
                        if (!v_Data_Reader.IsDBNull(13))
                        {
                            v_purchase_info.bar_price = v_Data_Reader.GetString(13);
                        }
                        if (!v_Data_Reader.IsDBNull(14))
                        {
                            v_purchase_info.bar_atm = v_Data_Reader.GetString(14);
                        }
                        if (!v_Data_Reader.IsDBNull(15))
                        {
                            v_purchase_info.recurrent = v_Data_Reader.GetString(15);
                        }

                        v_purchase_info.next_pay_date = Convert.ToString(v_Data_Reader["PAY_TYPE"]) == "中華電信帳單" ? "依帳單日期" : Convert.ToString(v_Data_Reader["NEXT_PAY_DATE"]);

                        pk_no = v_Data_Reader.GetValue(0).ToString();
                        OracleCommand _cmd_d = new OracleCommand(_sql_dtl, conn);
                        _cmd_d.BindByName = true;
                        _cmd_d.Parameters.Add("MAC_ADDRESS", client_id);
                        _cmd_d.Parameters.Add("PK_NO", pk_no);
                        OracleDataReader v_Data_Reader_d = _cmd_d.ExecuteReader();
                        try
                        {
                            int _j = 0;
                            while (v_Data_Reader_d.Read())
                            {

                                BSM_Info.purchase_detail v_purchase_detail = new BSM_Info.purchase_detail();
                                if (!v_Data_Reader_d.IsDBNull(1))
                                {
                                    v_purchase_detail.catalog_description = v_Data_Reader_d.GetString(1);
                                }
                                if (!v_Data_Reader_d.IsDBNull(2))
                                {
                                    v_purchase_detail.status_description = v_Data_Reader_d.GetString(2);
                                }
                                if (!v_Data_Reader_d.IsDBNull(3))
                                {
                                    v_purchase_detail.start_date = v_Data_Reader_d.GetString(3);
                                }
                                if (!v_Data_Reader_d.IsDBNull(4))
                                {
                                    v_purchase_detail.end_date = v_Data_Reader_d.GetString(4);
                                }
                                if (!v_Data_Reader_d.IsDBNull(5))
                                {
                                    v_purchase_detail.package_name = v_Data_Reader_d.GetString(5);
                                }

                                string device_id = Convert.ToString(v_Data_Reader_d["DEVICE_ID"]);
                                string cat_id = Convert.ToString(v_Data_Reader_d["CAT_ID"]);
                                v_purchase_detail.package_id = Convert.ToString(v_Data_Reader_d["PACKAGE_ID"]);
                                List<BSM_Info.client_detail> _client_details = _info_base.get_client_detail(client_id, device_id);
                                List<BSM_Info.client_detail> _detail_packages = (from _b in _client_details where _b.cat_id == cat_id select _b).ToList();
                                string start_date = (from _b in _detail_packages select _b.start_date).Min();
                                string end_date = (from _b in _detail_packages select _b.end_date).Max();
                                string start_date_desc = (from _b in _detail_packages select _b.package_start_date_desc).Max();
                                string end_date_desc = (from _b in _detail_packages select _b.package_end_date_desc).Max();
                                string used = (from _b in _detail_packages select _b.used).Max();
                                string package_status = (from _b in _detail_packages select _b.package_status).Max();
                                v_purchase_detail.start_date = (start_date == "" || start_date == null) ? start_date_desc : start_date;
                                v_purchase_detail.end_date = (end_date == "" || end_date == null) ? end_date_desc : end_date;
                                v_purchase_detail.use_status = used ?? "N";
                                v_purchase_detail.status_description = package_status ?? "未購買";
                                v_purchase_detail.current_recurrent_status = ((from a in _detail_packages where a.recurrent == "R" select a).Count() > 0) ? "R" : "O";
                                // v_purchase_detail.next_pay_date = (_a.current_recurrent_status == "R") ? end_date : null;

                                if (!v_Data_Reader_d.IsDBNull(7))
                                {
                                    v_purchase_detail.price = v_Data_Reader_d.GetDecimal(7);
                                }
                                if (!v_Data_Reader_d.IsDBNull(8))
                                {
                                    v_purchase_detail.price_description = v_Data_Reader_d.GetString(8);
                                }
                                v_purchase_info.src_credits_details = new BSM_Info.credits_balance_info();
                                v_purchase_info.after_credits_details = new BSM_Info.credits_balance_info();
                                _info_base.get_purchase_credits(purchase_id, v_purchase_info.src_credits_details, v_purchase_info.after_credits_details);

                                v_purchase_info.cost_credits = Convert.ToString(v_Data_Reader_d["COST_CREDITS"]);
                                v_purchase_info.after_credits = Convert.ToString(v_Data_Reader_d["AFTER_CREDITS"]);

                                mas_pk_no = v_Data_Reader_d.GetValue(0).ToString();
                                if (pk_no == mas_pk_no)
                                {
                                    v_purchase_info.details.Add(v_purchase_detail);
                                }
                                _j++;
                            }
                        }
                        finally
                        {
                            v_Data_Reader_d.Dispose();
                        }


                        v_result.Add(v_purchase_info);
                        _i++;
                    }

                }

                finally
                {
                    v_Data_Reader.Dispose();
                }

            }
            finally
            {
                conn.Close();
                //  conn.Dispose();
            }
            return v_result;
        }


        [JsonRpcMethod("test_out")]
        public BSM_Purchase_Request test_out()
        {
            BSM_Purchase_Request result = new BSM_Purchase_Request();
            result.session_uid = "1234";
            result.pay_type = "rewrere";
            //  result.details.Add(new BSM_Purchase_detail());
            result.details[0].item_id = "1234";
            return result;
        }

        [JsonRpcMethod("test_inout")]
        public BSM_Purchase_Request test_out(BSM_Purchase_Request result)
        {
            return result;
        }

        [JsonRpcMethod("get_purchase_info_by_id_atm")]
        public List<BSM_Info.purchase_info> test_get_purchase_info_by_id_atm(string client_id, string purchase_id)
        {
            return this.get_purchase_info_by_id_atm(client_id, purchase_id);
        }


        private void init_cht_parame()
        {
            //
            // 中華電信帳單
            //

            cht_payments.Add("Hinet", "寬頻帳單付款");
            cht_payments.Add("Chtld", "手機帳單付款");
            cht_payments.Add("Chtn", "市話帳單付款");
            cht_payments.Add("ATM", "中華支付ATM付款");
            cht_payments.Add("WEBATM", "中華支付WEBATM付款");
            cht_payments.Add("Credit", "中華支付信用卡付款");


        }
    }
}
