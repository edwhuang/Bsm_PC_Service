namespace BSM_Info
{

    using System;
    using System.Web;
    using System.Data;
    using System.Web.Services.Protocols;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Net;
    using Jayrock.Json;
    using Jayrock.Json.Conversion;
    using Jayrock.JsonRpc;
    using Jayrock.JsonRpc.Web;
    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    using System.Text;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    using System.Reflection;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.GridFS;
    using MongoDB.Driver.Linq;
    using log4net;
    using log4net.Config;
    using System.Web.Security;


    public class service_status
    {
        public string catalog_id { get; set; }
        public string catalog_description { get; set; }
    }

    public class package_group
    {
        public string _id;
        public string group_id;
        public string title;
        public string logo;
        public decimal? stand_price { get; set; }
        public decimal? sale_price { get; set; }
        public string use_status { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string suggest_group_id;
        public List<package_group> suggest_service_list;
        public decimal? suggest_price;
        public string suggest_desc;
        public string[] suggest_services;
        public string current_recurrent_status;
        public string group_description;
        public string hide;
        public string software_group;
        public decimal? sort_no;
        public JsonArray packages;
        public package_group()
        {

        }
    }

    public class service_info
    {
        public string _id;
        public string service_id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public decimal stand_price { get; set; }
        public decimal sale_price { get; set; }
        public string use_status { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string suggest_service_id;
        public List<service_info> suggest_service_list;
        public decimal suggest_price;
        public decimal suggest_desc;
        public string[] suggest_services;
        public string current_recurrent_status { get; set; }
    }

    public class package_service_info
    {
        public string service_id;
        public string name;
        public string description;
        public string package_id;
    }

    /// <summary>
    /// 方案狀態
    /// </summary>
    public class catalog_info
    {
        /// <summary>
        /// catalog id:catalog identified id
        /// </summary>
        public string catalog_id;

        /// <summary>
        ///  catalog name
        /// </summary>
        public string catalog_name;

        /// <summary>
        /// catalog description
        /// </summary>
        public string catalog_description;

        /// <summary>
        ///  catalog status :catalog status 
        /// </summary>
        public string catalog_status;

        /// <summary>
        /// use status ,'Y' client can use this catalog ,'N' can't use this catalog 
        /// </summary>
        public string use_status;

        /// <summary>
        /// use status description: to client to show 
        /// </summary>
        public string status_description;

        /// <summary>
        /// start_date: string field, just for client to show start date information 
        /// </summary>
        public string start_date;

        /// <summary>
        /// end date : string field, just for client to show end information
        /// </summary>
        public string end_date;

        /// <summary>
        /// package_description:this catalog main packgage's description, html string field. 
        /// </summary>
        public string package_description;

        /// <summary>
        /// package_name :  catalog main package's name,string field.
        /// </summary>
        public string package_name;

        /// <summary>
        ///  package id :package id
        /// </summary>
        public string package_id;

        /// <summary>
        ///  price description : jsut for client to show price information
        /// </summary>
        public string price_description;

        /// <summary>
        /// logo : picture file name ,the picture will preload to client 
        /// </summary>
        public string logo;

        /// <summary>
        /// Recurrent 
        /// </summary>
        public string current_recurrent_status;
        public string next_pay_date;
        public string can_extend;
        public string device_id;
    }

    public class cup_package_id
    {
        public string package_id;
    }

    public class package_dtl
    {
        public string desc;
        public string client_id;
        public string coupon_id;
        public decimal cup_dtl_pk_no;
        public List<cup_package_id> cup_package_id;
    }

    public class purchase_detail
    {
        public string mas_pk_no;
        public string catalog_description;
        public string status_description;
        public string start_date;
        public string end_date;
        public string package_name;
        public string package_id;
        public decimal price;
        public decimal orig_price;
        public string price_description;
        public string use_status;
        public string current_recurrent_status;
        public List<package_dtl> package_dtls;
    }

    public class purchase_info
    {
        public string pk_no;
        public string purchase_date;
        public string purchase_datetime;
        public string purchase_id;
        public string card_no;
        public string pay_type;
        public decimal? amount;
        public decimal orig_amount;
        public decimal pay_status;
        public string pay_due_date;
        public string invoice_no;
        public string invoice_gift_flg;
        public string bar_invo_no;
        public string bar_due_date;
        public string bar_price;
        public string bar_atm;
        public string bank_code;
        public string cost_credits;
        public string after_credits;
        public string recurrent;
        public string next_pay_date;
        public Boolean is_default;
        public string promo_desc;
        public string promo_code;
        public string promo_prog_id;
        public string promo_title;
        public credits_balance_info src_credits_details;
        public credits_balance_info after_credits_details;
        public List<purchase_detail> details;
    }

    public class purchase_info_list
    {
        public string catalog_id;
        public string catalog_name;
        public string catalog_description;
        public string status_description;
        public string start_date;
        public string end_date;
        public string package_description;
        public string package_name;
        public string package_id;
        public string price_description;
        public string amount_description;
        public string purchase_date;
        public string purchase_datetime;
        public string approval_code;
        public string purchase_id;
        public string card_no;
        public string pay_type;
        public string invoice_date;
        public string invoice_no;
        public string invoice_einv_id;
        public string invoice_gift_flg;
        public string cost_credits;
        public string after_credits;
        public string recurrent;
        public string next_pay_date;
        public string pay_type_code;
        public string use_status;
        public string logo;
        public string device_id;
        public string src_no;
        public string calculation_type;
    }



    public class dsp_message
    {
        public string message_type;
        public string message;
    }

    public class pay_method
    {
        public string pay_type;
        public string cash_flow;
        public string name;
        public Boolean enabled;
        public string cht_payment_code;
        public string cht_product_id;
    }

    public class package_option
    {
        public string _id;
        public string package_id;
        public string option_package_id;
        public List<string> pay_type;
        public string option_name;
        public Decimal amount;
        public string option_type;
        public Boolean enabled;
        public string package_info;
        public Boolean ship_flg;
        public JsonObject ship_note;
        public package_option()
        {
            pay_type = new List<string>();
            ship_flg = false;
            ship_note = new JsonObject();
        }
    }


    /// <summary>
    /// 方案狀態
    /// </summary
    public class package_info
    {
        public string _id;
        /// <summary>
        /// catalog id:catalog identified id
        /// </summary>
        /// 
        public string catalog_id;

        /// <summary>
        ///  catalog name
        /// </summary>
        public string catalog_name;

        /// <summary>
        /// catalog description
        /// </summary>
        public string catalog_description;

        /// <summary>
        /// 使用狀態 ,'Y' client can use this catalog ,'N' can't use this catalog 
        /// </summary>
        public string use_status;

        /// <summary>
        /// 使用狀態說明 description: to client to show 
        /// </summary>
        public string status_description;

        /// <summary>
        /// start_date: string field, just for client to show start date information 
        /// </summary>
        public string start_date;

        /// <summary>
        /// end date : string field, just for client to show end information
        /// </summary>
        public string end_date;

        /// <summary>
        /// 方案說明(HTML):this catalog main packgage's description, html string field. 
        /// </summary>
        //   public string package_description;

        /// <summary>
        /// 方案說明(文字型態):this catalog main packgage's description, html string field. 
        /// </summary>
        //    public string package_description_text;

        /// <summary>
        /// 方案名稱 :  catalog main package's name,string field.
        /// </summary>
        public string package_name;

        /// <summary>
        ///  package id :package id
        /// </summary>
        public string package_id;


        /// <summary>
        ///  catalgo status :catalog status 
        /// </summary>
        public string catalog_status;


        /// <summary>
        /// 方案說明明細
        /// </summary>

        //    public string package_description_dtl;

        /// <summary>
        ///  price description : jsut for client to show price information
        /// </summary>
        /// 
        public string price_description;

        public string price;

        /// <summary>
        /// logo : picture file name ,the picture will preload to client 
        /// </summary>
        //    public string logo;

        /// <summary>
        /// item_id : 單片此欄位回應可播放的item_id
        /// </summary>
        public string item_id;

        /// <summary>
        /// 顯示名細項附 'Y' 顯示,'N' 不顯示
        /// </summary>
        public string show_detail_flg;

        /// <summary>
        /// 
        /// </summary>
        public string cost_credits;
        public string after_credits;
        public Decimal credits_balance;
        public Decimal credits;
        public credits_balance_info credits_info;
        public credits_balance_info credits_balance_info;
        public string cal_type; // 計算方式P by package,T by title
        public string days;
        public string credits_description; //點數說明
        public string credits_type; // 點數的使用方式(紅利GIFT, 儲值點數BUY
        public string remark;
        public string recurrent; //是否可Recurrent
        public string next_pay_date; //下次購款日
        public string current_recurrent_status;  //目前recurrent 狀態
        public Boolean enable;
        public string system_type;
        public string apt_only;
        public string promo_title;
        public string promo_desc;
        public string promo_prices_desc;
        public string[] pay_method_list; //付款方式
        public string pay_message;
        public Decimal? duration_by_day;
        public List<package_service_info> services;
        public List<pay_method> payments;
        public List<string> message_ids;
        public string include_box;
        public Decimal display_order;
        public string recommend_message;
        public string recommend_id;
        public List<package_option> options;
        public List<string> option_disable_pay_type;

        public package_info()
        {
            payments = new List<pay_method>();
            options = new List<package_option>();
            option_disable_pay_type = new List<string>();
            option_disable_pay_type.Add("HINET");
        }
    }

    public class package_sg_info
    {
        public string _id;
        public string package_id;
        public string software_group;
        public string version;
        public string version_end;
    }

    public class content_info
    {
        /// <summary>
        /// title
        /// </summary>
        public string title;
        /// <summary>
        /// content_id 
        /// </summary>
        public string content_id;
        /// <summary>
        /// 畫質
        /// </summary>
        public string sdhd;
        /// <summary>
        /// 級別
        /// </summary>
        /// 
        public string eng_title;
        public string release_year;
        public decimal score;
        public decimal score10;
        public string rating;
        /// <summary>
        /// 類型
        /// </summary>
        public string genre;
        /// <summary>
        /// 片長
        /// </summary>
        public string runtime;
        /// <summary>
        /// 下假日期
        /// </summary>
        public string off_shelf_date;

        /// <summary>
        /// 備註
        /// </summary>
        public string remark;
    }

    /// <summary>
    /// content 與 package detail 資料
    /// </summary>
    public class content_package_info
    {
        /// <summary>
        /// 顯示名細項附 'Y' 顯示,'N' 不顯示
        /// </summary>
        public string show_detail_flg;
        /// <summary>
        /// Content info
        /// </summary>
        public content_info content_info;
        /// <summary>
        /// package info
        /// </summary>
        public package_info package_info;

    }

    public class client_detail
    {
        public string src_no;
        public string src_pay_type;
        public string start_date;
        public string end_date;
        public string cat_id;
        public string package_id;
        public string package_status;
        public string used;
        public string package_start_date_desc;
        public string package_end_date_desc;
        public string recurrent;
        public string device_id;
    }


    public class credits_detail
    {
        public string credits_type; // 點數種類
        public string credits_desc; //點數說明
        public int? credits; //剩餘點數
        public int? use_credits; //
        public string expired_date;

        public credits_detail()
        {
            credits = 0;
            use_credits = 0;
        }
    }

    public class credits_balance_info
    {
        public int? credits;
        public string credits_description;
        public string creaits_remind;
        public string expired_date;
        public List<credits_detail> details;

        public credits_balance_info()
        {
            credits = 0;
            details = new List<credits_detail>();
        }
    }

    public class messamge_box_button
    {
        /// <summary>
        /// 
        /// </summary>
        public string message_box_id;

        /// <summary>
        /// button id
        /// </summary>
        public string button_id;

        /// <summary>
        /// button display name
        /// </summary>
        public string button_name;

        /// <summary>
        /// client action 
        /// </summary>
        public string client_action;
    }

    public class messamge_box
    {
        /// <summary>
        /// message box id
        /// </summary>
        public string id;

        /// <summary>
        /// message title
        /// </summary>
        public string title;

        /// <summary>
        /// message description
        /// </summary>
        public string description;

        /// <summary>
        /// default button id
        /// </summary>
        public string default_button;

        /// <summary>
        /// buttons list
        /// </summary>
        public List<messamge_box_button> buttons;
    }

    public class cht_prodduct_code
    {
        public string _id;
        public string cht_product_code;
        public string package_id;
        public string cht_paymethod;
    }

    public class bsm_package_group_special
    {
        public string _id;
        public string package_group_id;
        public DateTime start_date;
        public DateTime end_date;
        public JsonObject Option;
    }

    public class bsm_package_special
    {
        public string _id;
        public string package_id;
        public DateTime start_date;
        public DateTime end_date;
        public JsonObject Option;
    }

    public class promotion_code_prog
    {
        public string _id;
        public string promo_prog_id;
        public string discount_package_id;
        public string discount_package_cat_id1;
        public decimal amount;
        public decimal discount_amount;
        public decimal extend_days;
        public decimal prog_limit;
        public string promo_prog_type;
        public string promo_info;
        public string promo_title;
        public DateTime start_date;
        public DateTime end_date;
    }

    public class promotion_code
    {
        public string _id;
        public string promo_prog_id;
        public string promo_code;
        public string owner;
        public Boolean check_client;
        public decimal client_cnt_limit;
        public DateTime expired_date;
        public DateTime? nobuy_from;
        public Boolean status;
    }


    public class promotion_info
    {
        public string _id;
        public string promo_prog_id;
        public string discount_package_id;
        public string discount_package_cat_id1;
        public string promo_code;
        public Boolean status;
        public decimal amount;
        public decimal discount_amount;
        public decimal extend_days;
        public string promo_prog_type;
        public string promo_info;
        public string promo_title;
        public string owner;
        public decimal client_cnt_limit;
        public Boolean check_client;
        public DateTime start_date;
        public DateTime end_date;
        public DateTime? nobuy_from;
    }

    public class promotion_clients
    {
        public string _id;
        public string promo_code;
        public string client_id;
        public Boolean status_flg;

        public promotion_clients()
        {
            status_flg = false;
        }
    }

    public class account_info
    {
        public string _id;
        public string client_id;
        public string activation_code;
        public List<client_detail> package_details;
        public List<catalog_info> services;
        public List<purchase_info> purchases;
        public credits_balance_info credits;
        public List<purchase_info_list> purchase_dtls;
        public DateTime last_refresh_time;

        public account_info()
        {
            package_details = new List<client_detail>();
            credits = new credits_balance_info();
            services = new List<catalog_info>();
            purchases = new List<purchase_info>();
            purchase_dtls = new List<purchase_info_list>();
        }
    }

    public class acg_post_log
    {
        public ObjectId _id;
        public DateTime eventtime;
        public string url;
        public string request;
        public string result;
        public string status;
        
    }



    public class BSM_Info_Service_base
    {
        OracleConnection conn;

        public string _connString;

        private string _MongoDbconnectionString;
        private MongoClient _Mongoclient;
        private MongoServer _MongoServer;
        private MongoDatabase _MongoDB;


        private string _MongoDbconnectionStringMaster;
        private MongoClient _MongoclientMaster;
        private MongoServer _MongoServerMaster;
        private MongoDatabase _MongoDBMaster;
        private MongoDatabase _MongoClientInfoDB;

        private account_info _client_info;
        public string acg_url;

        Dictionary<string, string> cht_payments;
        Dictionary<string, string> cht_prodduct_code;
        static ILog logger;


        public BSM_Info_Service_base(string connString, string MongodbConnectString, string MongoDB_Database)
        {
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            _connString = connString;
            _MongoDbconnectionString = MongodbConnectString;
            _Mongoclient = new MongoClient(_MongoDbconnectionString);
            _MongoServer = _Mongoclient.GetServer();
            _MongoDB = _MongoServer.GetDatabase(MongoDB_Database + "PCPackageInfo");

            _MongoDbconnectionStringMaster = _MongoDbconnectionString.Replace("readPreference=SecondaryPreferred", "readPreference=primaryPreferred");

           // _MongoDbconnectionStringMaster = "mongodb://172.23.200.107:27017,172.23.200.106:27017/?connect=replicaset;replicaSet=bsmDBrs;slaveOk=true;readPreference=primaryPreferred";
            _MongoclientMaster = new MongoClient(_MongoDbconnectionStringMaster);
            _MongoServerMaster = _MongoclientMaster.GetServer();
            _MongoDBMaster = _MongoServerMaster.GetDatabase(MongoDB_Database + "PCPackageInfo");
            _MongoClientInfoDB = _MongoServerMaster.GetDatabase(MongoDB_Database + "ClientInfo");

            cht_payments = new Dictionary<string, string>();
            cht_prodduct_code = new Dictionary<string, string>();
        }

        private void connectDB()
        {
            if (conn == null)
            {
                conn = new OracleConnection();
                conn.ConnectionString = _connString;
            }
            if (conn.State == ConnectionState.Closed) conn.Open();
        }

        private void closeDB()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        private OracleDataReader ExecuteReader(string _sql)
        {
            connectDB();
            OracleCommand _cmd = new OracleCommand(_sql, conn);
            _cmd.BindByName = true;
            OracleDataReader _Data_Reader = _cmd.ExecuteReader();
            return _Data_Reader;
        }

        private void DataReaderToObject(OracleDataReader a, object b)
        {
            Type p = b.GetType();
            System.Reflection.FieldInfo[] pf = p.GetFields();
            System.Reflection.PropertyInfo[] pp = p.GetProperties();
            for (int i = 0; i < a.FieldCount; i++)
            {
                string fieldName = a.GetName(i);
                string fieldType = a[i].GetType().Name;

                object vaule = a.GetValue(i);
                if (vaule != DBNull.Value)
                {
                    foreach (var ps2 in pf)
                    {
                        Type ft = ps2.FieldType;

                        if (ps2.Name.ToUpper() == fieldName.ToUpper())
                        {
                            if (ft == typeof(Nullable<decimal>))
                                ps2.SetValue(b, Convert.ToDecimal(vaule));
                            else if (ft == typeof(string[]) && vaule.GetType() == typeof(string))
                                ps2.SetValue(b, Convert.ToString(vaule).Split(','));
                            else if (ft == typeof(string) && vaule.GetType() == typeof(string))
                                ps2.SetValue(b, vaule);
                        }
                    }

                    foreach (var ps3 in pp)
                    {
                        Type ft = ps3.PropertyType;

                        if (ps3.Name.ToUpper() == fieldName.ToUpper())
                        {
                            if (ft == typeof(Nullable<decimal>))
                                ps3.SetValue(b, Convert.ToDecimal(vaule), null);
                            else if (ft == typeof(string[]) && vaule.GetType() == typeof(string))
                                ps3.SetValue(b, Convert.ToString(vaule).Split(','), null);
                            else if (ft == typeof(string) && vaule.GetType() == typeof(string))
                                ps3.SetValue(b, vaule, null);
                        }
                    }
                }
            };
        }

        private IList<T> DataReaderToObjectList<T>(OracleDataReader rd) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();
            while (rd.Read())
            {
                T item = new T();
                DataReaderToObject(rd, item);
                result.Add(item);
            }
            return result;
        }

        private IList<T> DataReaderToObjectList<T>(string sql) where T : new()
        {
            OracleDataReader rd = this.ExecuteReader(sql);
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();
            while (rd.Read())
            {
                T item = new T();
                DataReaderToObject(rd, item);
                result.Add(item);
            }
            return result;
        }

        private List<package_service_info> get_all_package_service()
        {
            string package_services_colname = "package_services";
            var _collection = _MongoDB.GetCollection<package_service_info>(package_services_colname);
            List<package_service_info> d_list = _collection.AsQueryable().ToList();
            if (d_list.Count() == 0)
            {
                string _sql = @"Select package_id||'+'||a.cat_id ""_ID"",package_id,a.cat_id service_id,name,description
from service_cat_mas a,bsm_package_service b
where a.cat_id=b.cat_id and b.status_flg='P'";
                List<package_service_info> _result = DataReaderToObjectList<package_service_info>(_sql).ToList();
                _MongoDBMaster.GetCollection<package_service_info>(package_services_colname).InsertBatch(_result);
                return _result;
            }
            else
            {
                return d_list;
            }
        }

        public List<bsm_package_group_special> get_all_package_group_special()
        {
            var _collection = _MongoDB.GetCollection<bsm_package_group_special>("bsm_package_group_special");
            List<bsm_package_group_special> _result = _collection.AsQueryable().ToList();
            return _result;
        }

        public List<bsm_package_special> get_package_special()
        {
            var _collection = _MongoDB.GetCollection<bsm_package_special>("bsm_package_special");
            List<bsm_package_special> _result = _collection.AsQueryable().ToList();
            return _result;
        }

        public void post_package_group_special()
        {
            var _collection = _MongoDBMaster.GetCollection<bsm_package_group_special>("bsm_package_group_special");
            bsm_package_group_special _data = new bsm_package_group_special();
            connectDB();

            string sql = @"select pk_no id,x.src_id,(start_date+8/24) start_date,(end_date+8/24) end_date,x.pc_option from bsm_package_special_setting x where type = 'GROUP' and status_flg in ('R','P','Z')";
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                _data._id = Convert.ToString(rd["ID"]);
                _data.package_group_id = Convert.ToString(rd["SRC_ID"]);
                _data.start_date = Convert.ToDateTime(rd["START_DATE"]);
                _data.end_date = Convert.ToDateTime(rd["END_DATE"]);
                _data.Option = (JsonObject)JsonConvert.Import(Convert.ToString(rd["PC_OPTION"]));
                _collection.Save(_data);
            };
        }

        public void post_package_special()
        {
            var _collection = _MongoDBMaster.GetCollection<bsm_package_group_special>("bsm_package_special");
            bsm_package_special _data = new bsm_package_special();
            connectDB();

            string sql = @"select pk_no id,x.src_id,(start_date+8/24) start_date,(end_date+8/24) end_date,x.pc_option from bsm_package_special_setting x where type = 'PACKAGE' and status_flg in ('P','Z')";
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                _data._id = Convert.ToString(rd["ID"]);
                _data.package_id = Convert.ToString(rd["SRC_ID"]);
                _data.start_date = Convert.ToDateTime(rd["START_DATE"]);
                _data.end_date = Convert.ToDateTime(rd["END_DATE"]);
                _data.Option = (JsonObject)JsonConvert.Import(Convert.ToString(rd["PC_OPTION"]));
                _collection.Save(_data);
            };
        }

        private List<package_group> get_all_package_group()
        {
            string package_group_colname = "package_group";
            var _collection = _MongoDB.GetCollection<package_group>(package_group_colname);
            List<package_group> d_list = _collection.AsQueryable().ToList();
            d_list = (from package_group pg in d_list orderby pg.sort_no select pg).ToList();
            if (d_list.Count() == 0)
            {
                string _sql = @"Select  group_id||'+'||software_group ""_ID"" ,group_id,title,logo,description group_description,stand_price,sale_price,suggest_desc,suggest_group_id,suggest_price,suggest_services,
hide,software_group,sort_no from bsm_package_group_mas a order by sort_no";
                List<package_group> _result = DataReaderToObjectList<package_group>(_sql).ToList();

                foreach (var a in _result)
                {
                    a.suggest_service_list = (a.suggest_services != null) ? new List<package_group>() : null;
                    if (a.suggest_services != null)
                        foreach (var x in (from x in _result where a.suggest_services.Contains(x.group_id) select x).ToList())
                        {
                            package_group _b = new package_group();
                            _b._id = x._id;
                            _b.title = x.title;
                            _b.group_id = x.group_id;

                            a.suggest_service_list.Add(_b);
                        }
                    a.suggest_services = null;
                    _MongoDBMaster.GetCollection<package_group>(package_group_colname).Save(a);

                }

                return _result;
            }
            else
            {
                return d_list;
            }
        }

        private List<messamge_box_button> get_all_message_box_button()
        {
            string _sql = @"Select message_box_id,button_id,button_name,client_action from bsm_message_box_item";
            return DataReaderToObjectList<messamge_box_button>(_sql).ToList();
        }

        public List<messamge_box> get_all_message_box()
        {
            string _sql = @"Select id,title,description,default_button from bsm_message_box";
            return DataReaderToObjectList<messamge_box>(_sql).ToList();
        }

        public JsonArray get_group_info(string sw_version, string browser_info)
        {
            List<package_group> lp;
            JsonObject package;
            JsonArray _result = new JsonArray();
            List<bsm_package_group_special> _all_group_special = this.get_all_package_group_special();
            if (sw_version == null)
            {
                lp = (from a in get_all_package_group() where (a.hide != "Y" && a.software_group == null) select a).ToList();

            }
            else
            {
                lp = (from a in get_all_package_group() where (a.hide != "Y" && a.software_group == sw_version.Substring(0, 7)) select a).ToList();
                if (lp.Count <= 0)
                {
                    lp = (from a in get_all_package_group() where (a.hide != "Y" && a.software_group == null) select a).ToList();
                }
            }

            if (browser_info == "browser_mobile")
                lp.RemoveAll(x => x.group_id == "CHANNEL_4GCPBL");

            foreach (var a in lp)
            {
                a.hide = null;
                package = (JsonObject)JsonConvert.Import(JsonConvert.ExportToString(a));

                List<bsm_package_group_special> specials = (from c in _all_group_special where c.package_group_id == a.group_id && (DateTime.Compare(c.start_date, DateTime.Now) <= 0 && DateTime.Compare(DateTime.Now, c.end_date) <= 0) select c).ToList();
                foreach (var special in specials)
                {
                    JsonObject _option = special.Option;
                    foreach (string name in _option.Names)
                    {
                        package.Add(name, _option[name]);
                    }
                }
                _result.Add(package);
            }

            return _result;
        }

        public List<client_detail> get_client_detail(string client_id, string device_id)
        {
            List<client_detail> _result = new List<client_detail>();
            connectDB();

            string _sql = @"select t3.pay_type,
       t.src_no,
       to_char(trunc(t.start_date), 'yyyy/mm/dd') start_date,
       to_char(trunc(t.end_date), 'yyyy/mm/dd') end_date,
       decode(t.start_date,
              null,
              '未啟用',
              decode(sign(t.end_date - sysdate), 1, '已啟用', '已到期')) package_status,
       t2.package_start_date_desc,
       t2.package_end_date_desc,
       decode(t.start_date,
              null,
              'N',
              decode(sign(t.end_date - sysdate), 1, 'Y', 'N')) used,
       t2.package_id,
       t2.package_cat_id1,
       case when t4.status_flg='P' then
         'R'
       else
         'O'
       end recurrent
  from bsm_client_details t, bsm_package_mas t2, bsm_purchase_mas t3,bsm_recurrent_mas t4
 where t.status_flg = 'P'
   and t2.package_id = t.package_id
   and t3.mas_no(+) = t.src_no
   and t2.acl_period_duration is null
   and t.mac_address = :CLIENT_ID
   and t4.src_pk_no (+) = t3.pk_no
 order by end_date";

            OracleCommand _cmd = new OracleCommand(_sql, conn);
            _cmd.BindByName = true;
            _cmd.Parameters.Add("CLIENT_ID", client_id);
         //   _cmd.Parameters.Add("DEVICE_ID", device_id);
            OracleDataReader _rd = _cmd.ExecuteReader();
            while (_rd.Read())
            {
                client_detail _detail = new client_detail();
                _detail.src_no = Convert.ToString(_rd["SRC_NO"]);
                _detail.src_pay_type = Convert.ToString(_rd["PAY_TYPE"]);
                _detail.cat_id = Convert.ToString(_rd["PACKAGE_CAT_ID1"]);
                _detail.package_id = Convert.ToString(_rd["PACKAGE_ID"]);
                _detail.start_date = Convert.ToString(_rd["START_DATE"]);
                _detail.end_date = Convert.ToString(_rd["END_DATE"]);
                _detail.package_start_date_desc = Convert.ToString(_rd["PACKAGE_START_DATE_DESC"]);
                _detail.package_end_date_desc = Convert.ToString(_rd["PACKAGE_END_DATE_DESC"]);
                _detail.package_status = Convert.ToString(_rd["PACKAGE_STATUS"]);
                _detail.used = Convert.ToString(_rd["USED"]);
                _detail.recurrent = Convert.ToString(_rd["RECURRENT"]);
                if (Convert.ToString(_rd["PACKAGE_STATUS"]) == "已到期")
                { _detail.recurrent = "O"; }

                _result.Add(_detail);
            }
            return _result;
        }


        /// <summary>
        /// 取各館狀態
        /// </summary>
        /// <param name="client_id"></param>
        /// <returns></returns>
        public List<catalog_info> get_catalog_info(string client_id, string device_id)
        {
            List<catalog_info> v_result = new List<catalog_info>();
            string _sql;
            client_id = client_id.ToUpper();

            connectDB();
            try
            {
                _sql = @"with cte as (
Select case when cal_type = 'T' then
              t.package_name 
            else
              t2.package_cat1
            end package_cat1,
        
         case when  min(t.start_date) is null 
              then max(t2.package_start_date_desc)
            else to_char(trunc(min(t.start_date)),'YYYY/MM/DD') end start_date,

        case when min(t.end_date) is null then '未啟用'
             when t2.cal_type ='T' then
                to_char(max(t.end_date),'YYYY/MM/DD HH24:MI')
             else
                to_char(trunc(max(t.end_date)),'YYYY/MM/DD')
             end end_date,
        case when min(t.start_date) is null
          then '未啟用'
          else
            case when max(t.end_date) >= sysdate 
              then
                   '已啟用'
              else '已到期'
              end
          end package_status,
        case when min(t.start_date) is null
          then 'N'
          else
            case when max(t.end_date) >= sysdate 
              then
                   'Y'
              else 'N'
              end
          end package_status_flg,
        max(t.pk_no) detail_pk_no,
        t2.package_cat_id1
         from bsm_client_details t,bsm_package_mas t2
 where t.status_flg = 'P'
   and t.package_id in (Select t2.package_id from bsm_package_mas t2 where system_type not in ( 'CLIENT_ACTIVED','FREE','SYSTEM'))
   and t2.package_id= t.package_id
   and t.mac_address=:CLIENT_ID
   and ((t2.cal_type ='T' and t.end_date >=sysdate) or (t2.cal_type <> 'T')) 
   and (
    ((:DEVICE_ID is not null) and (t.device_id is null or t.device_id=:DEVICE_ID))
   or ((:DEVICE_ID is null) and (t.device_id is null or t.device_id not in  (select c.device_id from bsm_client_device_list c where c.client_id=:CLIENT_ID
   and c.software_group ='LTSMS02')) ))
   
 group by
          case when cal_type = 'T' then
              t.package_name 
            else
              t2.package_cat1
            end ,
          t2.cal_type,
          t2.package_cat1,
          t2.package_cat_id1,
          t.item_id
          )
select cte.package_cat1,t3.supply_name||t3.package_name package_name,cte.start_date,cte.end_date,PACKAGE_DES_HTML,PRICE_DES,package_status,logo,t2.package_id,package_type,system_type,
decode(BSM_RECURRENT_UTIL.check_recurrent(cte.package_cat_id1, :CLIENT_ID,:DEVICE_ID),'Y','R','O') recurrent,
decode(BSM_RECURRENT_UTIL.check_recurrent(cte.package_cat_id1, :CLIENT_ID,:DEVICE_ID),'Y',BSM_RECURRENT_UTIL.get_next_pay_date(cte.package_cat_id1, :CLIENT_ID),'無') next_pay_date,
cte.package_cat_id1,
cte.package_status_flg
from cte,bsm_package_mas t2,bsm_client_details t3
where cte.detail_pk_no =t3.pk_no 
and t3.package_id=t2.package_id
 union all 
select b.PACKAGE_CAT1, 
       b.DESCRIPTION, 
       '', 
       '已啟用', 
       b.PACKAGE_DESC_HTML, 
       '免費使用', 
       '已啟用', 
       b.logo logo, 
       b.package_id ,'P','FREE',
       'O' returrent,
       '無' next_pay_date,
       package_cat_id1,
        ''
  from mfg_free_service b
  where (b.software_group is null)
  or (instr(b.software_group,get_software_group(:CLIENT_ID,:DEVICE_ID))>0)
  order by package_type,system_type,package_status desc,end_date desc";


                OracleCommand _cmd = new OracleCommand(_sql, conn);
                _cmd.BindByName = true;
                _cmd.Parameters.Add("CLIENT_ID", client_id);
                _cmd.Parameters.Add("DEVICE_ID", device_id);
                OracleDataReader v_Data_Reader = _cmd.ExecuteReader();
                int _i = 0;
                try
                {
                    while (v_Data_Reader.Read())
                    {
                        catalog_info v_catalog_info = new catalog_info();
                        if (!v_Data_Reader.IsDBNull(0))
                        {
                            v_catalog_info.catalog_name = v_Data_Reader.GetString(0);
                            v_catalog_info.catalog_description = v_Data_Reader.GetString(0);
                        }
                        if (!v_Data_Reader.IsDBNull(1))
                        {
                            v_catalog_info.package_name = v_Data_Reader.GetString(1);
                        }
                        if (!v_Data_Reader.IsDBNull(2))
                        {
                            v_catalog_info.start_date = v_Data_Reader.GetString(2);
                        }
                        if (!v_Data_Reader.IsDBNull(3))
                        {
                            v_catalog_info.end_date = v_Data_Reader.GetString(3);
                        }
                        if (!v_Data_Reader.IsDBNull(4))
                        {
                            v_catalog_info.package_description = v_Data_Reader.GetString(4);
                        }
                        if (!v_Data_Reader.IsDBNull(5))
                        {
                            v_catalog_info.price_description = v_Data_Reader.GetString(5);
                        }
                        if (!v_Data_Reader.IsDBNull(6))
                        {
                            v_catalog_info.status_description = v_Data_Reader.GetString(6);
                        }
                        if (!v_Data_Reader.IsDBNull(7))
                        {
                            v_catalog_info.logo = v_Data_Reader.GetString(7);
                        }
                        if (!v_Data_Reader.IsDBNull(8))
                        {
                            v_catalog_info.package_id = v_Data_Reader.GetString(8);
                        }
                        if (!v_Data_Reader.IsDBNull(11))
                        {
                            v_catalog_info.current_recurrent_status = v_Data_Reader.GetString(11);
                            if (v_catalog_info.status_description == "已到期") { v_catalog_info.current_recurrent_status = "O"; };
                        }

                        if (!v_Data_Reader.IsDBNull(12))
                        {
                            v_catalog_info.next_pay_date = v_Data_Reader.GetString(12);
                        }

                        if (!v_Data_Reader.IsDBNull(13))
                        {
                            v_catalog_info.catalog_id = v_Data_Reader.GetString(13);
                        }

                        if (!v_Data_Reader.IsDBNull(14))
                        {
                            v_catalog_info.use_status = v_Data_Reader.GetString(14);
                        }

                        v_catalog_info.can_extend = (v_catalog_info.catalog_id == "SEVENDAYS") ? "N" : "Y";
                        v_catalog_info.can_extend = (v_catalog_info.current_recurrent_status == "O") ? v_catalog_info.can_extend : "N";
                        v_result.Add(v_catalog_info);
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
                closeDB();
            }
            return v_result;
        }

        private List<package_option> get_all_package_option()
        {
            string package_options_colname = "package_options";

            var package_option_collection = _MongoDB.GetCollection<package_option>(package_options_colname);
            List<package_option> _result = package_option_collection.AsQueryable().ToList();
            if (_result.Count == 0)
            {
                connectDB();
                string _sql = @"Select a.package_id,a.stk_package_id,b.package_name,a.pay_types,a.option_amt,a.option_info,a.package_type,ship_note 
                                from bsm_package_options a,stk_package_mas b
                                where a.status_flg='P' and nvl(a.start_date,sysdate)<=sysdate and nvl(a.end_date,sysdate)>=sysdate
                                       and b.package_id (+)=a.stk_package_id order by a.no";
                OracleCommand _cmd = new OracleCommand(_sql, conn);
                _cmd.BindByName = true;
                OracleDataReader _rd = _cmd.ExecuteReader();
                while (_rd.Read())
                {
                    package_option _package_option = new package_option();
                    _package_option.package_id = Convert.ToString(_rd["PACKAGE_ID"]);
                    _package_option.option_package_id = Convert.ToString(_rd["STK_PACKAGE_ID"]);
                    _package_option.option_name = Convert.ToString(_rd["PACKAGE_NAME"]);
                    _package_option.package_info = Convert.ToString(_rd["OPTION_INFO"]);
                    string v_package_type = Convert.ToString(_rd["PACKAGE_TYPE"]);
                    if (v_package_type == "STOCK")
                    {
                        _package_option.ship_flg = true;
                    }
                    if (_rd["OPTION_AMT"] != null) _package_option.amount = Convert.ToDecimal(_rd["OPTION_AMT"]);
                    string _pay_type = Convert.ToString(_rd["PAY_TYPES"]);
                    char[] _c = { ',' };
                    _package_option.pay_type = _pay_type.Split(_c).ToList();
                    _package_option.enabled = true;
                    _package_option._id = _package_option.option_package_id + "+" + _package_option.package_id;

                    string ship_note_str = Convert.ToString(_rd["SHIP_NOTE"]);
                    if (ship_note_str != null && ship_note_str != "")
                    {
                        JsonObject ship_note = new JsonObject();
                        ship_note = (JsonObject)JsonConvert.Import(ship_note_str);
                        _package_option.ship_note = ship_note;

                    }
                    _result.Add(_package_option);

                }
                _MongoDBMaster.GetCollection<package_option>(package_options_colname).InsertBatch(_result);
            }


            return _result;
        }

        public List<package_info> get_all_package()
        {
            init_cht_parame();
            List<package_option> _all_package_options = get_all_package_option();
            List<package_info> v_result = new List<package_info>();

            string packages_colname = "packages";

            var package_collection = _MongoDB.GetCollection<package_info>(packages_colname);
            List<package_info> d_list = package_collection.AsQueryable().ToList();
            if (d_list.Count == 0)
            {

                connectDB();

                string _sql = @"Select 
       t2.system_type,
       t2.package_id,
       t2.description             package_name,
       t2.package_cat1            cat,
       t2.package_cat_id1,
       t2.price_des,
       t2.charge_amount   price,
       t2.logo,
       t2.package_des_html,
       t2.package_des,
       t2.package_start_date_desc,
       t2.package_end_date_desc,
       t2.package_des_text,
       t2.credits_des,
       nvl(t2.credits,0) credits,
       t2.package_cat_id1,
       t2.cal_type,
       t2.recurrent recurrent,
        APT_ProductCode,
        APT_Only ,
        Pay_credits_type,
        ref2,
        ref3,
        ref4,
        ref5,
        duration_by_day,
        cht_product_id,
        cht_pay_method,
        include_box,
        nvl(t2.display_order,0) display_order,
        (select recommend_message from bsm_package_recommend where group_id = t2.package_cat_id1 and rownum <=1) recommend_message,
        (select recommend_id from bsm_package_recommend where group_id = t2.package_cat_id1 and rownum <=1) recommend_id
        FROM  bsm_package_mas t2
        WHERE  t2.acl_period_duration is null
        and status_flg='P'
        ORDER BY  t2.display_order nulls first , t2.package_cat_id1,decode(t2.package_id,'CH4G03','1','CH4G02','2','CH4G04','3','CH4G05','4','CH4G00','0',t2.package_id)";

                OracleCommand _cmd = new OracleCommand(_sql, conn);
                _cmd.BindByName = true;
                OracleDataReader _Data_Reader = _cmd.ExecuteReader();
                while (_Data_Reader.Read())
                {
                    package_info v_package_info = new package_info();
                    try
                    {
                        v_package_info.use_status = "N";
                        v_package_info.status_description = "未購買";
                        v_package_info.system_type = Convert.ToString(_Data_Reader["SYSTEM_TYPE"]);
                        v_package_info.package_id = Convert.ToString(_Data_Reader["PACKAGE_ID"]);
                        v_package_info._id = v_package_info.package_id;
                        v_package_info.package_name = Convert.ToString(_Data_Reader["PACKAGE_NAME"]);
                        v_package_info.catalog_description = Convert.ToString(_Data_Reader["CAT"]);
                        v_package_info.catalog_id = Convert.ToString(_Data_Reader["PACKAGE_CAT_ID1"]);
                        v_package_info.price_description = Convert.ToString(_Data_Reader["PRICE_DES"]);
                        v_package_info.price = Convert.ToString(_Data_Reader["PRICE"]);
                        v_package_info.start_date = Convert.ToString(_Data_Reader["PACKAGE_START_DATE_DESC"]);
                        v_package_info.end_date = Convert.ToString(_Data_Reader["PACKAGE_END_DATE_DESC"]);
                        v_package_info.credits = Convert.ToDecimal(_Data_Reader["CREDITS"]);
                        v_package_info.catalog_id = Convert.ToString(_Data_Reader["PACKAGE_CAT_ID1"]);
                        v_package_info.cal_type = Convert.ToString(_Data_Reader["CAL_TYPE"]);
                        v_package_info.recurrent = Convert.ToString(_Data_Reader["RECURRENT"]);
                        v_package_info.apt_only = Convert.ToString(_Data_Reader["APT_ONLY"]);
                        v_package_info.cost_credits = Convert.ToString(_Data_Reader["CREDITS_DES"]);
                        v_package_info.credits_description = Convert.ToString(_Data_Reader["CREDITS_DES"]);
                        v_package_info.credits_type = Convert.ToString(_Data_Reader["PAY_CREDITS_TYPE"]);
                        v_package_info.promo_title = Convert.ToString(_Data_Reader["REF2"]);
                        v_package_info.promo_desc = Convert.ToString(_Data_Reader["REF3"]);
                        v_package_info.promo_prices_desc = Convert.ToString(_Data_Reader["REF4"]);
                        v_package_info.include_box = Convert.ToString(_Data_Reader["INCLUDE_BOX"]);
                        v_package_info.display_order = Convert.ToDecimal(_Data_Reader["DISPLAY_ORDER"]);
                        v_package_info.recommend_message = Convert.ToString(_Data_Reader["RECOMMEND_MESSAGE"]);
                        v_package_info.recommend_id = Convert.ToString(_Data_Reader["RECOMMEND_ID"]);
                        v_package_info.enable = true;

                        v_package_info.options = (from _package_option in _all_package_options where _package_option.package_id == v_package_info.package_id select _package_option).ToList();

                    }
                    catch (Exception e)
                    {
                        int v = 0;
                    }

                    try
                    {

                        if (v_package_info.recurrent == "R")
                        {
                            v_package_info.pay_method_list = new string[] { "CREDIT" };
                            pay_method _pay1 = new pay_method();
                            _pay1.pay_type = "CREDIT";
                            _pay1.cash_flow = "LITV";
                            _pay1.enabled = true;
                            v_package_info.payments.Add(_pay1);
                        }
                        else
                        {
                            v_package_info.pay_method_list = new string[] { "CREDIT", "REMIT", "ATM" };
                            pay_method _pay1 = new pay_method();
                            _pay1.pay_type = "CREDIT";
                            _pay1.cash_flow = "LITV";
                            _pay1.enabled = true;
                            pay_method _pay2 = new pay_method();
                            _pay2.pay_type = "REMIT";
                            _pay2.cash_flow = "LITV";
                            _pay2.enabled = true;
                            pay_method _pay3 = new pay_method();
                            _pay3.pay_type = "ATM";
                            _pay3.cash_flow = "LITV";
                            _pay3.enabled = true;
                            v_package_info.payments.Add(_pay1);
                            if (!(v_package_info.package_id.IndexOf("CH4G") >= 0 || v_package_info.package_id.IndexOf("CPBL") >= 0))
                            {
                                v_package_info.payments.Add(_pay2);
                                v_package_info.payments.Add(_pay3);
                            }

                        }

                    }
                    catch (Exception e)
                    {
                        int v = 0;
                    }

                    try
                    {

                        if (Convert.ToString(_Data_Reader["CHT_PAY_METHOD"]) != "")
                        {
                            // v_package_info.cht_product_id = Convert.ToString(_Data_Reader["CHT_PRODUCT_ID"]);
                            string[] _pay_method_list = Convert.ToString(_Data_Reader["CHT_PAY_METHOD"]).ToUpper().Split(',');
                            v_package_info.pay_method_list = _pay_method_list;
                            if (Convert.ToString(_Data_Reader["CHT_PAY_METHOD"]).ToUpper().IndexOf("HINET") > 0
                                || v_package_info.package_id.Substring(0, 4) == "CH4G" || v_package_info.package_id.Substring(0, 6) == "CHCPBL"
                                )
                            {
                                v_package_info.payments.Clear();
                            }
                            foreach (var a in _pay_method_list)
                            {
                                pay_method _pay4 = new pay_method();
                                _pay4.pay_type = a.ToUpper();
                                _pay4.cash_flow = "HINET";
                                _pay4.enabled = true;
                                _pay4.cht_payment_code = a.Replace("C_", "").ToUpper();
                                if (_pay4.cht_payment_code != "ATM" && _pay4.cht_payment_code != "WEBATM")
                                {
                                    _pay4.cht_payment_code = _pay4.cht_payment_code.Substring(0, 1).ToUpper() + _pay4.cht_payment_code.Substring(1).ToLower();

                                }
                                try
                                {
                                    _pay4.cht_product_id = cht_prodduct_code[_pay4.cht_payment_code + "+" + v_package_info.package_id];
                                    _pay4.name = cht_payments[_pay4.cht_payment_code];
                                }
                                catch (KeyNotFoundException)
                                {
                                    throw new System.ArgumentException(_pay4.cht_payment_code + "+" + v_package_info.package_id + "not found");
                                }
                                v_package_info.payments.Add(_pay4);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        int v = 0;
                    }
                    v_package_info.duration_by_day = Convert.ToDecimal(_Data_Reader["DURATION_BY_DAY"]);
                    v_package_info.remark = (v_package_info.system_type == "CREDITS") ? "購買LiTV點數之面額最低為500元,每次購買面額回饋10%點數,例如購買500元可使用550點,依此類推" : null;
                    v_result.Add(v_package_info);

                }
                _MongoDBMaster.GetCollection<package_info>(packages_colname).InsertBatch(v_result);
            }
            else
            {
                v_result = d_list;
            }


            return v_result;
        }

        /// <summary>
        /// 取得方案軟體群組
        /// </summary>
        /// <param name="sw_group"></param>
        /// <returns></returns>
        public List<package_sg_info> get_sg_package(string sw_group, string sw_version)
        {
            string sg_package_colname = "sg_package";
            var _collection = _MongoDB.GetCollection<package_sg_info>(sg_package_colname);
            List<package_sg_info> d_list = _collection.AsQueryable().ToList();
            if (d_list.Count() == 0)
            {
                connectDB();
                OracleCommand _cmd = new OracleCommand(@"Select software_group||'+'||package_id ""_ID"",package_id,software_group,version,version_end from bsm_package_sg where status_flg='P' ", conn);

                OracleDataReader rd = _cmd.ExecuteReader();
                List<package_sg_info> all_package_sg_info = DataReaderToObjectList<package_sg_info>(rd).ToList();
                _MongoDBMaster.GetCollection<package_sg_info>(sg_package_colname).InsertBatch(all_package_sg_info);

                List<package_sg_info> _result = (from a in all_package_sg_info where a.software_group == sw_group && (a.version == null || String.Compare(a.version, sw_version) >= 0) && (a.version_end == null || String.Compare(a.version_end, sw_version) <= 0) select a).ToList();
                return _result;
            }
            else
            {
                List<package_sg_info> d_list2 = (from a in d_list where a.software_group == sw_group select a).ToList();
                List<package_sg_info> _result = (from a in d_list2 where (a.version == null || String.Compare(a.version, sw_version) <= 0) && (a.version_end == null || String.Compare(a.version_end, sw_version) >= 0) select a).ToList();
                return _result;
            }
        }

        /// <summary>
        /// 取所有方案
        /// Sample :
        ///  { "client_id" : "0080C8001002" }
        /// [{"catalog_id":"HIDO","catalog_description":"Hido\u96fb\u5f71\u9928","package_name":"\u4e00\u500b\u6708","package_id":"M00001","price_description":"\u6bcf\u670899\u5143"},{"catalog_id":"IFILM","catalog_description":"iFilm\u96fb\u5f71\u9928","package_name":"\u4e00\u500b\u6708","package_id":"M00002","price_description":"\u6bcf\u670899\u5143"},{"catalog_id":"KOD","catalog_description":"\u7f8e\u83ef\u5361\u62c9OK","package_name":"\u4e00\u500b\u6708","package_id":"K00001","price_description":"\u6bcf\u670869\u5143"}]
        /// </summary>
        /// 
        public JsonArray get_package_info(string client_id, string system_type, string device_id, string imsi, string sw_version)
        {
            return get_package_info(client_id, system_type, 0, device_id, null, imsi, sw_version);
        }

        public JsonArray get_package_info(string client_id, string system_type, int? min_credits, string device_id, string group_id, string imsi, string sw_version)
        {
            List<package_info> v_result = new List<package_info>();
            List<package_info> all_packages = get_all_package();
            List<bsm_package_special> _all_special = get_package_special();
            init_cht_parame();

            try
            {
                string sw_group = "";

                all_packages = (group_id != "" && group_id != null) ? (from a in all_packages where a.catalog_id == group_id select a).ToList() : all_packages;

                List<package_sg_info> sg_packages = new List<package_sg_info>();
                if (sw_version != null)
                {
                    sw_group = sw_version.Substring(0, 7);
                    sg_packages = get_sg_package(sw_group, sw_version);

                    all_packages = (from a in all_packages where a.system_type == system_type select a).ToList();


                    if (system_type != "CREDITS") all_packages = (from x in all_packages orderby x.display_order, x.package_id where (sg_packages.Exists(y => (y.package_id == x.package_id || y.package_id == x.catalog_id))) select x).ToList();
                }

                if (client_id != "" && client_id != null)
                {
                    List<client_detail> _client_details = this.cache_client_purchase(client_id, false).package_details;
                    var _client_service_details = (from _x in _client_details group _x by _x.cat_id into k select new { cat_id = k.Key, recurrent = k.Max(x => x.recurrent) }).ToList();
                    foreach (var _a in all_packages)
                    {
                        List<client_detail> _detail_packages = (from _b in _client_details where _b.cat_id == _a.catalog_id select _b).ToList();
                        string start_date = (from _b in _detail_packages select _b.start_date).Min();
                        string end_date = (from _b in _detail_packages select _b.end_date).Max();
                        string start_date_desc = (from _b in _detail_packages select _b.package_start_date_desc).Max();
                        string end_date_desc = (from _b in _detail_packages select _b.package_end_date_desc).Max();
                        string used = (from _b in _detail_packages select _b.used).Max();
                        string package_status = (from _b in _detail_packages select _b.package_status).Max();
                        _a.start_date = (start_date == "" || start_date == null) ? start_date_desc : start_date;
                        _a.end_date = (end_date == "" || end_date == null) ? end_date_desc : end_date;
                        _a.use_status = used ?? "N";
                        _a.status_description = package_status ?? "未購買";
                        _a.current_recurrent_status = ((from a in _detail_packages where a.recurrent == "R" && a.package_id==_a.package_id select a).Count() > 0) ? "R" : "O";
                        string[] l_packages = { "XD0001", "XD0012","XD0007"};
                        if (!Array.Exists<string>(l_packages, eml => eml == _a.package_id))
                        {
                            _a.current_recurrent_status = ((from a in _client_details where a.recurrent == "R" && Array.Exists<string>(l_packages, eml => eml == a.package_id) select a).Count() > 0) ? "R" : _a.current_recurrent_status;
                        }
                        else
                        {
                            _a.current_recurrent_status = ((from a in _client_details where a.recurrent == "R" &&  a.package_id== "XD0012" select a).Count() > 0) ? "R" : _a.current_recurrent_status;
                        

                        }
                        _a.next_pay_date = (_a.current_recurrent_status == "R") ? end_date : null;

                        _a.enable = ((from a in _detail_packages where a.src_pay_type == "中華電信帳單" select a).Count() > 0 && _a.current_recurrent_status == "R") ? false : (_a.current_recurrent_status == "R" && _a.recurrent == "R") ? false : true;
                        _a.pay_message = ((from a in _detail_packages where a.src_pay_type == "中華電信帳單" select a).Count() > 0 && _a.current_recurrent_status == "R") ? "已使用中華支付" : (_a.current_recurrent_status == "R" && _a.recurrent == "R") ? "已使用自動扣款" : null;

                        List<string> _pay_method = new List<string>(_a.pay_method_list);

                        _a.apt_only = null;

                        string v_credits_type = _a.credits_type;
                        List<string> v_credits_type_list = new List<string>(v_credits_type.Split(','));
                        {
                            credits_balance_info _credit_b = this.get_credits_balance(client_id);
                            credits_balance_info _credit_c = this.get_credits_balance(client_id);
                            decimal _credits = _a.credits;
                            decimal _after_credits = (decimal)_credit_b.credits - _credits;

                            _a.after_credits = _after_credits.ToString() + "點";
                            _a.credits_balance = _after_credits;
                            _a.credits_info = _credit_b;

                            decimal _b = _credits;

                            _a.credits_balance_info = _credit_c;

                        };

                        _a.credits_balance_info.details = (from _x in _a.credits_balance_info.details orderby _x.credits_type select _x).ToList();
                        _a.credits_info.details = (from _x in _a.credits_info.details orderby _x.credits_type select _x).ToList();
                        _a.pay_method_list = _pay_method.ToArray();
                    }

                }
                foreach (var a in all_packages) a.system_type = null;
            }
            finally
            {

                closeDB();
            }

            v_result = all_packages;
            JsonObject package = new JsonObject();
            JsonArray _result_a = new JsonArray();
           
                foreach (var item in all_packages)
                {
                    package = (JsonObject)JsonConvert.Import(JsonConvert.ExportToString(item));

                    package.Remove("_id");
                    package.Remove("logo");
                    package.Remove("message_ids");
                    package.Remove("recommend_message");
                    package.Remove("recommend_id");
                    package.Remove("include_box");
                    package.Remove("include_box");
                    package.Remove("package_description");
                    package.Remove("package_description_text");
                    package.Remove("package_description_dtl");
                    package.Remove("options");
                    package.Remove("option_pay_type");
                    package.Add("option_pay_type", null);

                    List<JsonObject> _opa = new List<JsonObject>();
                    try
                    {
                        foreach (var _op in item.options)
                        {
                            try
                            {
                                JsonObject _opb = new JsonObject();
                                _opb = (JsonObject)JsonConvert.Import(JsonConvert.ExportToString(_op));
                                _opb.Remove("package_info");
                                _opb.Remove("package_id");
                                _opb.Remove("_id");
                                package.Remove("option_pay_type");
                                package.Add("option_pay_type", _op.pay_type);
                                JsonObject _opc = new JsonObject();
                                if (_op.package_info != "")
                                    _opc = (JsonObject)JsonConvert.Import(_op.package_info);
                                foreach (string a in _opc.Names)
                                {
                                    if (_opb.Contains(a)) _opb.Remove(a);
                                    _opb.Add(a, _opc[a]);
                                }
                                _opa.Add(_opb);
                            }
                            catch (Exception e)
                            {
                                logger.Info(e.Message);
                            }

                        }
                    }
                    catch (Exception e)
                    {
                        logger.Info(e.Message);
                    }
                    package.Add("options", _opa);

                    List<bsm_package_special> specials = (from c in _all_special where c.package_id == item.package_id && (DateTime.Compare(c.start_date, DateTime.Now) <= 0 && DateTime.Compare(DateTime.Now, c.end_date) <= 0) select c).ToList();
                    foreach (var special in specials)
                    {
                        JsonObject _option = special.Option;
                        foreach (string name in _option.Names)
                        {
                            if (package.Contains(name))
                            {
                                package[name] = _option[name];
                            }
                            else
                            {
                                package.Add(name, _option[name]);
                            }
                        }
                    }
                    _result_a.Add(package);
                }
            

            logger.Info(JsonConvert.ExportToString(v_result));
            return new JsonArray(_result_a);
        }

        /// <summary>
        /// 取各Group 方案
        /// </summary>
        /// <param name="token"></param>
        /// <param name="client_id"></param>
        /// <param name="device_id"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public JsonArray get_group_package_info(string token, string client_id, string device_id, string imsi, string sw_version)
        {
            List<package_group> _result = new List<package_group>();
            package_group _g;
            string _sw_group = "";

            connectDB();
            try
            {
                string _sql = "SELECT GET_SOFTWARE_GROUP(:CLIENT_ID,:DEVICE_ID) FROM DUAL";
                OracleCommand _cmd = new OracleCommand(_sql, conn);
                _cmd.BindByName = true;
                _cmd.Parameters.Add("CLIENT_ID", client_id);
                _cmd.Parameters.Add("DEVICE_ID", device_id);
                OracleDataReader _rd = _cmd.ExecuteReader();
                if (_rd.Read())
                {
                    if (!_rd.IsDBNull(0))
                    {
                        _sw_group = _rd.GetString(0);
                    }
                }
                _cmd.Dispose();
            }
            finally
            {
                closeDB();
            }
            JsonArray _package_info_list = this.get_package_info(client_id, "BUY", 0, device_id, null, imsi, sw_version);
            JsonArray _package_group_list = new JsonArray(from _package_info in _package_info_list
                                                          group _package_info by new { catalog_id = (_package_info as JsonObject)["catalog_id"].ToString(), catalog_description = (_package_info as JsonObject)["catalog_description"].ToString() } into g
                                                          select new { group_id = g.Key.catalog_id, title = g.Key.catalog_description });

            foreach (JsonObject _pg in _package_group_list)
            {
                _g = new package_group();
                _g.group_id = _pg["group_id"].ToString();

                _g.title = _pg["title"].ToString();
                _g.packages = new JsonArray((from _package_info in _package_info_list where (_package_info as JsonObject)["catalog_id"].ToString() == _g.group_id select _package_info)); ;
                _result.Add(_g);
            };

            return new JsonArray(_result);
        }

        public JsonObject get_package_info_by_id(string client_id, string system_type, int? min_credits, string device_id, string package_id, string sw_version)
        {
            system_type = system_type ?? "BUY";
            JsonArray v_result = get_package_info(client_id, "BUY", min_credits, device_id, null, null, sw_version);
            JsonObject result = new JsonObject();

            if (package_id != null)
            {
                foreach (JsonObject a in v_result)
                {
                    if (a["package_id"].ToString() == package_id)
                    {
                        result = a;
                    }

                }
            }
            JsonObject _result = result;

            return _result;
        }

        public JsonArray get_package_info_by_multi_id(string client_id, string system_type, int? min_credits, string device_id, string group_id, string sw_version, string[] package_id)
        {
            JsonArray v_result = get_package_info(client_id, system_type, min_credits, device_id, group_id, null, sw_version);
            return new JsonArray((from a in v_result where package_id.Contains((a as BSM_Info.package_info).package_id) select a));
        }

        /// <summary>
        /// 取購買紀錄
        /// </summary>
        /// <param name="token"></param>
        /// <param name="client_id"></param>
        /// <returns></returns>
        public List<purchase_info> get_purchase_info(string client_id, string device_id, string src_no)
        {
            List<purchase_info> v_result = new List<purchase_info>();
            client_id = client_id.ToUpper();

            connectDB();
            try
            {
                string _sql;
                string _sql_dtl;
                string _dev_sql = "e.device_id is null";
                _dev_sql = " ( e.device_id = '" + device_id + "' or e.device_id is null) ";

                if (src_no != null && src_no != "")
                {
                    _dev_sql = " (a.src_no = '" + src_no + "' ) and " + _dev_sql;
                }

                _sql = "with cte as (" +
  "Select a.pk_no, to_char(a.purchase_date, 'yyyy/mm/dd') purchase_date, to_char(a.purchase_date, 'yyyy/mm/dd hh24:mi') purchase_datetime, " +
  " a.mas_no purchase_id,a.card_no card_no, " +
  " decode(a.pay_type,'其他','OTHER','贈送','GIFT','手動刷卡','CREDIT','兌換券','COUPON','儲值卡','CREDITS','信用卡','CREDIT','便利商店','REMIT','匯款','REMIT',a.pay_type) pay_type, " +
  " a.amount,decode(a.status_flg,'Z',3,'P', case when (least((a.due_date + 1), sysdate) > a.due_date) then 2 else 1 end ) pay_status," +
  " to_char(a.due_date, 'yyyy/mm/dd') pay_due_date, " +
  " a.tax_inv_no invoice_no, a.tax_gift invoice_gift_flag, " +
  " a.bar_no bar_invo_no, a.bar_due_date, a.bar_code bar_price, " +
  " a.inv_acc bar_atm, DECODE(a.recurrent, 'Y', 'R', 'N', 'O', a.recurrent) recurrent, " +
  " decode(a.recurrent,'R',nvl(to_char(a.next_pay_date,'YYYY/MM/DD'),BSM_RECURRENT_UTIL.get_next_pay_date(d.package_cat_id1, :MAC_ADDRESS)),'無') next_pay_date, " +
  " a.cht_auth, " +
  " a.promo_prog_id, " +
  " a.promo_code, " +
  " a.promo_title, " +
  " d.charge_amount orig_amount" +
  " from bsm_purchase_mas   a, " +
  "     bsm_purchase_item  e, " +
  "     bsm_client_details c, " +
  "     bsm_package_mas    d " +
  " where e.mas_pk_no(+) =a.pk_no " +
  " and c.src_pk_no (+) =e.mas_pk_no " +
  " and c.src_item_pk_no (+) = e.pk_no " +
  " and e.package_id = d.package_id (+) " +
  " and a.status_flg in ('P', 'Z') " +
  " and not a.show_flg ='N' " +
  " and a.serial_id = :MAC_ADDRESS " +
  " and a.trans_to is null and a.show_flg <> 'N' )" +
  "select pk_no, purchase_date, purchase_datetime, purchase_id, card_no, pay_type, amount, pay_status, pay_due_date, invoice_no, invoice_gift_flag, " +
  "bar_invo_no, bar_due_date, bar_price, bar_atm, recurrent, next_pay_date,cht_auth,promo_prog_id,promo_code,promo_title,sum(orig_amount) orig_amount from cte " +
  "group by  pk_no, purchase_date, purchase_datetime, purchase_id, card_no, pay_type, amount, pay_status, pay_due_date, invoice_no, invoice_gift_flag, " +
  "bar_invo_no, bar_due_date, bar_price, bar_atm, recurrent, next_pay_date,cht_auth,promo_prog_id,promo_code,promo_title " +
  "Order by purchase_date desc, purchase_id desc ";

                _sql_dtl = "select e.mas_pk_no,decode(d.cal_type,'T',c.package_name,d.package_cat1) catalog_description, decode(c.start_date,null,'未啟用',decode(sign(end_date - sysdate), 1, '已啟用', '已到期')) status_description," +
  "to_char(nvl(e.service_start_date,c.start_date), 'YYYY/MM/DD') start_date,to_char(nvl(e.service_end_date,c.end_date), 'YYYY/MM/DD') end_date,nvl(c.package_name,decode(d.ref3,null,d.description,d.description||' '||d.ref3)) package_name,e.package_id,e.price,d.price_des ,d.charge_amount orig_amount,e.package_dtls " +
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
  " and a.trans_to is null and a.show_flg <> 'N'" +
  " and a.pk_no = :PK_NO " +
  " Order by to_char(a.purchase_date, 'YYYY/MM/DD') desc, a.mas_no desc";


                OracleCommand _cmd = new OracleCommand(_sql, conn);
                _cmd.BindByName = true;
                _cmd.Parameters.Add("MAC_ADDRESS", client_id);

                OracleDataReader v_Data_Reader = _cmd.ExecuteReader();

                string pk_no;
                string mas_pk_no;
                try
                {
                    int _i = 0;
                    while (v_Data_Reader.Read())
                    {
                        purchase_info v_purchase_info = new purchase_info();
                        v_purchase_info.details = new List<purchase_detail>();
                        v_purchase_info.purchase_date = Convert.ToString(v_Data_Reader["PURCHASE_DATE"]);
                        v_purchase_info.purchase_datetime = Convert.ToString(v_Data_Reader["PURCHASE_DATETIME"]);
                        v_purchase_info.purchase_id = Convert.ToString(v_Data_Reader["PURCHASE_ID"]);
                        v_purchase_info.card_no = Convert.ToString(v_Data_Reader["CARD_NO"]);
                        v_purchase_info.promo_code = Convert.ToString(v_Data_Reader["PROMO_CODE"]);
                        v_purchase_info.promo_prog_id = Convert.ToString(v_Data_Reader["PROMO_PROG_ID"]);

                        string[] hinet_pay = { "中華電信帳單", "中華電信信用卡", "中華電信ATM" };
                        v_purchase_info.pay_type = hinet_pay.Contains(Convert.ToString(v_Data_Reader["PAY_TYPE"])) ? "C_" + Convert.ToString(v_Data_Reader["CHT_AUTH"]).ToUpper() : Convert.ToString(v_Data_Reader["PAY_TYPE"]);
                        v_purchase_info.bank_code = Convert.ToString(v_Data_Reader["PAY_TYPE"]) == "中華電信ATM" ? "004" : "812";

                        v_purchase_info.amount = v_Data_Reader["AMOUNT"] == DBNull.Value ? 0 : Convert.ToDecimal(v_Data_Reader["AMOUNT"]);

                        v_purchase_info.orig_amount = v_Data_Reader["ORIG_AMOUNT"] == DBNull.Value ? 0 : Convert.ToDecimal(v_Data_Reader["ORIG_AMOUNT"]);

                        if (!v_Data_Reader.IsDBNull(7))
                        {
                            v_purchase_info.pay_status = v_Data_Reader.GetDecimal(7);
                        }
                        if (!v_Data_Reader.IsDBNull(8))
                        {
                            v_purchase_info.pay_due_date = v_Data_Reader.GetString(8);
                        }

                        string v_tax_gift = Convert.ToString(v_Data_Reader["INVOICE_GIFT_FLAG"]) ?? "N";
                        string v_tax_no = Convert.ToString(v_Data_Reader["INVOICE_NO"]);
                        if (v_tax_gift == "Y" && v_tax_no != "") { v_tax_no = "捐贈"; }
                        v_purchase_info.invoice_no = v_tax_no;
                        v_purchase_info.invoice_gift_flg = v_tax_gift;
                        v_purchase_info.invoice_no = (v_purchase_info.invoice_no == null || v_purchase_info.invoice_no == "") ? "無" : v_purchase_info.invoice_no;
                        v_purchase_info.invoice_gift_flg = (v_purchase_info.invoice_gift_flg == null || v_purchase_info.invoice_gift_flg == "") ? "N" : v_purchase_info.invoice_gift_flg;
                        if (!v_Data_Reader.IsDBNull(11))
                        {
                            v_purchase_info.bar_invo_no = v_Data_Reader.GetString(11) == "**" ? null : v_Data_Reader.GetString(11);
                        }
                        if (!v_Data_Reader.IsDBNull(12))
                        {
                            v_purchase_info.bar_due_date = v_Data_Reader.GetString(12) == "**" ? null : v_Data_Reader.GetString(12);
                        }
                        if (!v_Data_Reader.IsDBNull(13))
                        {
                            v_purchase_info.bar_price = v_Data_Reader.GetString(13) == "**" ? null : v_Data_Reader.GetString(13);
                        }
                        if (!v_Data_Reader.IsDBNull(14))
                        {
                            v_purchase_info.bar_atm = v_Data_Reader.GetString(14) == "**" ? null : v_Data_Reader.GetString(14);
                        }

                        v_purchase_info.recurrent = Convert.ToString(v_Data_Reader["RECURRENT"]);
                        v_purchase_info.promo_title = Convert.ToString(v_Data_Reader["PROMO_TITLE"]);


                        v_purchase_info.next_pay_date = Convert.ToString(v_Data_Reader["PAY_TYPE"]) == "中華電信帳單" ? "依帳單日期" : Convert.ToString(v_Data_Reader["NEXT_PAY_DATE"]);
                        if (v_purchase_info.pay_type == "IOS") { v_purchase_info.next_pay_date = "請查詢iTunes帳號"; };

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

                                purchase_detail v_purchase_detail = new purchase_detail();
                                v_purchase_detail.catalog_description = Convert.ToString(v_Data_Reader_d["CATALOG_DESCRIPTION"]);
                                v_purchase_detail.status_description = Convert.ToString(v_Data_Reader_d["STATUS_DESCRIPTION"]);
                                if (v_purchase_detail.status_description == "已到期")
                                {
                                    /*          v_purchase_info.recurrent = "O";
                                              v_purchase_info.next_pay_date = "已到期"; */
                                }

                                v_purchase_detail.start_date = Convert.ToString(v_Data_Reader_d["START_DATE"]);
                                v_purchase_detail.end_date = Convert.ToString(v_Data_Reader_d["END_DATE"]);
                                v_purchase_detail.package_name = Convert.ToString(v_Data_Reader_d["PACKAGE_NAME"]);
                                v_purchase_detail.package_id = Convert.ToString(v_Data_Reader_d["PACKAGE_ID"]);
                                if (!v_Data_Reader_d.IsDBNull(7))
                                {
                                    v_purchase_detail.price = v_Data_Reader_d.GetDecimal(7);
                                }
                                v_purchase_detail.orig_price = v_Data_Reader_d["ORIG_AMOUNT"] == DBNull.Value ? 0 : Convert.ToDecimal(v_Data_Reader_d["ORIG_AMOUNT"]);
                                v_purchase_detail.price_description = Convert.ToString(v_Data_Reader_d["STATUS_DESCRIPTION"]);
                                mas_pk_no = v_Data_Reader_d.GetValue(0).ToString();


                                string v_package_dtls = Convert.ToString(v_Data_Reader_d["PACKAGE_DTLS"]);

                                if (v_package_dtls == "") { v_purchase_detail.package_dtls = null; }
                                else
                                {
                                    v_purchase_detail.package_dtls = new List<package_dtl>();
                                    foreach (JsonObject _v in (JsonArray)JsonConvert.Import(v_package_dtls))
                                    {
                                        package_dtl _p = new package_dtl();
                                        try
                                        {
                                            _p.client_id = _v["client_id"].ToString();
                                            _p.coupon_id = _v["coupon_id"].ToString();
                                            _p.desc = _v["desc"].ToString();
                                            _p.cup_dtl_pk_no = Convert.ToDecimal(_v["cup_dtl_pk_no"]);
                                            _p.cup_package_id = new List<cup_package_id>();
                                            foreach (JsonObject _v2 in (JsonArray)_v["cup_package_id"])
                                            {
                                                cup_package_id _v3 = new cup_package_id();
                                                _v3.package_id = _v2["package_id"].ToString();


                                                _p.cup_package_id.Add(_v3);
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                        }

                                        v_purchase_detail.package_dtls.Add(_p);
                                    }
                                }

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

                        String _sql_dtl2 = @"SELECT C.PACKAGE_NAME CATALOG_DESCRIPTION,B.AMOUNT,b.package_id package_id FROM bsm_purchase_item b,stk_package_mas c where c.package_id=b.package_id and b.mas_pk_no =:PK_NO and c.package_type <> 'COUPON'";
                        OracleCommand _cmd_d2 = new OracleCommand(_sql_dtl2, conn);
                        _cmd_d2.BindByName = true;

                        _cmd_d2.Parameters.Add("PK_NO", pk_no);
                        OracleDataReader v_Data_Reader_d2 = _cmd_d2.ExecuteReader();
                        try
                        {
                            // int _j = 0;
                            while (v_Data_Reader_d2.Read())
                            {

                                purchase_detail v_purchase_detail = new purchase_detail();
                                v_purchase_detail.package_id = Convert.ToString(v_Data_Reader_d2["PACKAGE_ID"]);
                                v_purchase_detail.catalog_description = Convert.ToString(v_Data_Reader_d2["CATALOG_DESCRIPTION"]);
                                v_purchase_detail.price = v_Data_Reader_d2.IsDBNull(v_Data_Reader_d2.GetOrdinal("AMOUNT")) ? 0 : Convert.ToDecimal(v_Data_Reader_d2["AMOUNT"]);
                                v_purchase_detail.orig_price = v_Data_Reader_d2.IsDBNull(v_Data_Reader_d2.GetOrdinal("AMOUNT")) ? 0 : Convert.ToDecimal(v_Data_Reader_d2["AMOUNT"]);
                                v_purchase_info.details.Add(v_purchase_detail);
                            }
                        }
                        finally
                        {
                            v_Data_Reader_d2.Dispose();
                        }

                        String _sql_dtl3 = @"Select b.promo_prog_id,promo_title,discount_amt from bsm_purchase_item a,promotion_prog_item b where a.mas_pk_no = :P_PK_NO and b.discount_package_id=a.package_id and b.promo_prog_id=:P_PROMO_PROG_ID";
                        OracleCommand _cmd_d4 = new OracleCommand(_sql_dtl3, conn);
                        _cmd_d4.BindByName = true;
                        _cmd_d4.Parameters.Add("P_PK_NO", pk_no);
                        _cmd_d4.Parameters.Add("P_PROMO_PROG_ID", v_purchase_info.promo_prog_id);
                        OracleDataReader _rd = _cmd_d4.ExecuteReader();
                        try
                        {
                            while (_rd.Read())
                            {
                                purchase_detail v_pd = new purchase_detail();
                                v_pd.package_id = Convert.ToString(_rd["PROMO_PROG_ID"]);
                                v_pd.catalog_description = Convert.ToString(_rd["PROMO_TITLE"]);

                                v_pd.price = 0;
                                v_pd.orig_price = Convert.ToDecimal(_rd["DISCOUNT_AMT"]);
                                v_purchase_info.details.Add(v_pd);
                            }
                        }
                        finally
                        {
                            _rd.Dispose();
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
                closeDB();
            }

            List<purchase_info> order_result = get_order(client_id, device_id, src_no);
            v_result.InsertRange(0, order_result);

            v_result = v_result.OrderByDescending(e => e.purchase_id).ToList<purchase_info>();

            return v_result;
        }

        public List<purchase_info_list> get_purchase_info_oracle(string client_id)
        {

            List<purchase_info_list> v_result = new List<purchase_info_list>();
            client_id = client_id.ToUpper(); 

            connectDB();
            try
            {
                string _sql;
                string _dev_sql = "device_id is null"; ;

                _sql = @"Select
       d.package_cat1 cat_description,
       nvl(c.package_name, decode(d.ref3,null,d.description,d.description||' '||d.ref3))||
       (select ' '||promo_title from promotion_prog_item x where x.promo_prog_id=a.promo_prog_id and x.discount_package_id=e.package_id) package_name,
       to_char(a.purchase_date, 'YYYY/MM/DD') purchase_date,
       d.price_des,
       decode(a.pay_type,
              'REMIT',
              '便利商店',
              'ATM',
              'ATM',
              'CREDIT',
              '信用卡',
              'credit',
              '信用卡',
              '點數',
              '點數',
              a.pay_type) pay_type,
       '************' || substr(a.card_no, 13, 4) card_no,
       a.mas_no purchase_id,
       a.approval_code approval_code,
       decode(c.start_date,
              null,
              '未啟用',
              decode(sign(end_date - sysdate), 1, '已啟用', '已到期')) status_description,
       to_char(c.start_date, 'YYYY/MM/DD') start_date,
       to_char(c.end_date, 'YYYY/MM/DD') end_date,
       to_char(a.purchase_date, 'YYYY/MM/DD HH24:MI') purchase_time,
       d.package_cat1 cat_name,
       d.package_start_date_desc,
       d.package_end_date_desc,
       nvl(a.tax_inv_no,'') tax_inv_no,
       nvl(a.tax_gift,'N') tax_gift,
       '' title,
       d.cal_type,
       NVL(TO_CHAR(TAX_INV_DATE,'YYYY/MM/DD'),(select to_char(F_INVO_DATE, 'YYYY/MM/DD')
          from tax_inv_mas inv
         where inv.f_invo_no = a.tax_inv_no
           and rownum <= 1)) INVO_DATE,
       NVL((select IDENTIFY_ID
          from tax_inv_mas inv
         where inv.f_invo_no = a.tax_inv_no
           and rownum <= 1),'N') INVO_IDENTIFY_ID,
       decode(a.cost_credits,
              '',
              '',
              replace(a.cost_credits, '點', '') || '點') cost_credits,
       decode(a.after_credits,
              '',
              '',
              replace(a.after_credits, '點', '') || '點') after_credits,
       d.system_type,
       DECODE(a.recurrent, 'Y', 'R', 'N', 'O', a.recurrent) recurrent,
       decode(a.recurrent,
              'R',
              to_char(BSM_RECURRENT_UTIL.get_service_end_date(d.package_cat_id1,
                                                              :MAC_ADDRESS),
                      'YYYY/MM/DD'),
              '無') next_pay_date,
       decode(a.pay_type,
              '其他',
              'OTHER',
              'CREDIT',
              'CREDIT',
              '贈送',
              'GIFT',
              '手動刷卡',
              'CREDIT',
              '兌換券',
              'GOUPON',
              '儲值卡',
              'CREDITS',
              '信用卡',
              'CREDIT',
              'ATM',
              'ATM',
              'REMIT',
              'REMIT',
              '便利商店',
              'REMIT',
              '匯款',
              'REMIT',
              pay_type) pay_type_code,
       d.package_cat_id1,
       d.logo,
       a.pk_no,
       c.device_id,
       a.src_no,
       e.price item_price,
       a.promo_prog_id,
       e.package_id
  from bsm_purchase_mas a,
       bsm_purchase_item e,
       bsm_client_details c,
       (select package_id,
               package_cat1,
               package_name,
               description,
               price_des,
               package_end_date_desc,
               package_start_date_desc,
               cal_type,
               system_type,
               package_cat_id1,
               logo,
               ref3
          from bsm_package_mas
       union all
         select package_id,package_name,'','',to_char(amount)||'元','','','P','OPTION','','','' from stk_package_mas where package_type <> 'COUPON') d
 where e.mas_pk_no = a.pk_no
   and c.src_pk_no(+) = e.mas_pk_no
   and c.src_item_pk_no(+) = e.pk_no
   and e.package_id = d.package_id(+)
   and ((a.status_flg = 'P' and a.due_date >= sysdate) or
       a.status_flg = 'Z')
   and not a.show_flg = 'N'
   and a.serial_id = :MAC_ADDRESS
   and a.trans_to is null
   and a.show_flg <> 'N'
 Order by to_char(a.purchase_date, 'YYYY/MM/DD') desc, a.mas_no desc,d.cal_type
";


                OracleCommand _cmd = new OracleCommand(_sql, conn);
                _cmd.BindByName = true;
                _cmd.Parameters.Add("MAC_ADDRESS", client_id);
                OracleDataReader v_Data_Reader = _cmd.ExecuteReader();
                int _i = 0;
                try
                {
                    while (v_Data_Reader.Read())
                    {
                        purchase_info_list v_purchase_info = new purchase_info_list();

                        v_purchase_info.catalog_description = Convert.ToString(v_Data_Reader["CAT_DESCRIPTION"]);
                        v_purchase_info.package_name = Convert.ToString(v_Data_Reader["PACKAGE_NAME"]);
                        v_purchase_info.purchase_date = Convert.ToString(v_Data_Reader["PURCHASE_DATE"]);
                        v_purchase_info.price_description = Convert.ToString(v_Data_Reader["PRICE_DES"]);
                        v_purchase_info.amount_description = Convert.ToString(v_Data_Reader["ITEM_PRICE"]) + "元";
                        v_purchase_info.device_id = Convert.ToString(v_Data_Reader["DEVICE_ID"]);
                        v_purchase_info.src_no = Convert.ToString(v_Data_Reader["SRC_NO"]);

                        if (!v_Data_Reader.IsDBNull(4))
                        {
                            if (v_Data_Reader.GetString(4) == "儲值卡")
                            {
                                v_purchase_info.pay_type = "點數";
                                v_purchase_info.cost_credits = Convert.ToString(v_Data_Reader["COST_CREDITS"]);
                                v_purchase_info.after_credits = Convert.ToString(v_Data_Reader["AFTER_CREDITS"]);
                            }
                            else
                            {
                                v_purchase_info.pay_type = v_Data_Reader.GetString(4);
                                v_purchase_info.cost_credits = v_purchase_info.price_description;
                                v_purchase_info.after_credits = Convert.ToString(v_Data_Reader["AFTER_CREDITS"]) ?? get_credits_balance(client_id).credits_description;
                                v_purchase_info.after_credits = get_credits_balance(client_id).credits_description;
                            }

                        }
                        else
                        {
                            v_purchase_info.pay_type = "信用卡";
                            v_purchase_info.cost_credits = v_purchase_info.price_description;
                            v_purchase_info.after_credits = Convert.ToString(v_Data_Reader["AFTER_CREDITS"]) ?? get_credits_balance(client_id).credits_description;
                            v_purchase_info.after_credits = get_credits_balance(client_id).credits_description;
                        }

                        v_purchase_info.card_no = Convert.ToString(v_Data_Reader["CARD_NO"]);
                        v_purchase_info.purchase_id = Convert.ToString(v_Data_Reader["PURCHASE_ID"]);
                        v_purchase_info.approval_code = Convert.ToString(v_Data_Reader["APPROVAL_CODE"]);


                        if (!v_Data_Reader.IsDBNull(8))
                        {
                            if (!v_Data_Reader.IsDBNull(23))
                            {
                                if (v_Data_Reader.GetString(23) == "CREDITS" || v_Data_Reader.GetString(23) == "FREE_CREDITS")
                                {
                                    v_purchase_info.status_description = null;
                                    v_purchase_info.end_date = null;
                                    string _sql_credits = "SELECT to_char(a.expiration_date,'YYYY/MM/DD')  FROM bsm_client_credits_Mas a  WHERE mas_pk_no = " + v_Data_Reader["PK_NO"].ToString();
                                    OracleCommand _cmd_credits = new OracleCommand(_sql_credits, conn);
                                    try
                                    {
                                        OracleDataReader v_Data_Reader_2 = _cmd_credits.ExecuteReader();
                                        if (v_Data_Reader_2.Read())
                                        {
                                            v_purchase_info.status_description = "已購買";
                                            v_purchase_info.end_date = v_Data_Reader_2[0].ToString();
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        v_purchase_info.end_date = null;
                                    }
                                    _cmd_credits.Dispose();
                                }
                                else
                                {
                                    v_purchase_info.status_description = v_Data_Reader.GetString(8);
                                    if (!v_Data_Reader.IsDBNull(10))
                                    {

                                        v_purchase_info.end_date = v_Data_Reader.GetString(10);
                                    }
                                    else
                                    {
                                        if (!v_Data_Reader.IsDBNull(14)) { v_purchase_info.end_date = v_Data_Reader.GetString(14); }
                                        else
                                        {
                                            v_purchase_info.end_date = "";

                                        }
                                    }
                                }
                            }
                            else
                            {
                                v_purchase_info.status_description = v_Data_Reader.GetString(8);
                                if (!v_Data_Reader.IsDBNull(10))
                                {
                                    v_purchase_info.end_date = v_Data_Reader.GetString(10);
                                }
                                else
                                {
                                    if (!v_Data_Reader.IsDBNull(14)) { v_purchase_info.end_date = v_Data_Reader.GetString(14); }
                                    else
                                    {
                                        v_purchase_info.end_date = "";

                                    }
                                }
                            }

                        }
                        else
                        {
                            v_purchase_info.status_description = "未啟用";
                            if (!v_Data_Reader.IsDBNull(10))
                            {
                                v_purchase_info.end_date = v_Data_Reader.GetString(10);
                            }
                            else
                            {
                                if (!v_Data_Reader.IsDBNull(14)) { v_purchase_info.end_date = v_Data_Reader.GetString(14); }
                                else
                                {
                                    v_purchase_info.end_date = "";

                                }
                            }
                        }

                        if (!v_Data_Reader.IsDBNull(9))
                        {
                            v_purchase_info.start_date = v_Data_Reader.GetString(9);
                        }
                        else
                        {
                            if (!v_Data_Reader.IsDBNull(13)) { v_purchase_info.start_date = v_Data_Reader.GetString(13); }
                            else
                            {
                                v_purchase_info.start_date = "";

                            }
                        }


                        if (!v_Data_Reader.IsDBNull(12))
                        {
                            v_purchase_info.catalog_name = v_Data_Reader.GetString(12);
                        }

                        if (!v_Data_Reader.IsDBNull(15))
                        {
                            // Tax Gift

                            if (v_Data_Reader.IsDBNull(16))
                            {
                                v_purchase_info.invoice_no = v_Data_Reader.GetString(15);
                                v_purchase_info.invoice_date = v_Data_Reader.GetString(19);
                                v_purchase_info.invoice_einv_id = v_Data_Reader.GetString(20);
                                v_purchase_info.invoice_gift_flg = "N";
                            }
                            else
                            {
                                if (v_Data_Reader.GetString(16) == "Y")
                                {
                                    v_purchase_info.invoice_no = "捐贈";
                                    v_purchase_info.invoice_date = "";
                                    v_purchase_info.invoice_einv_id = "";
                                    v_purchase_info.invoice_gift_flg = v_Data_Reader.GetString(16);
                                }
                                else
                                {
                                    v_purchase_info.invoice_no = Convert.ToString(v_Data_Reader["TAX_INV_NO"]);
                                    v_purchase_info.invoice_date = Convert.ToString(v_Data_Reader["INVO_DATE"]);
                                    v_purchase_info.invoice_einv_id = Convert.ToString(v_Data_Reader["INVO_IDENTIFY_ID"]);
                                    v_purchase_info.invoice_gift_flg = Convert.ToString(v_Data_Reader["TAX_GIFT"]);
                                }
                            }

                        }
                        else
                        {
                            v_purchase_info.invoice_no = "無";
                            if (v_Data_Reader.IsDBNull(16))
                            {

                                v_purchase_info.invoice_gift_flg = "N";
                            }
                            else
                            {
                                v_purchase_info.invoice_gift_flg = v_Data_Reader.GetString(16);
                            }

                        }

                        v_purchase_info.calculation_type = Convert.ToString(v_Data_Reader["CAL_TYPE"]);

                        if (!v_Data_Reader.IsDBNull(18))
                        {
                            if (v_Data_Reader.GetString(18) == "T")
                            {
                                if (!v_Data_Reader.IsDBNull(17))
                                {
                                    v_purchase_info.catalog_description = v_Data_Reader.GetString(17);
                                    if (!v_Data_Reader.IsDBNull(19))
                                    {
                                        v_purchase_info.invoice_date = v_Data_Reader.GetString(19);
                                    }
                                    if (!v_Data_Reader.IsDBNull(20))
                                    {
                                        v_purchase_info.invoice_einv_id = v_Data_Reader.GetString(20);
                                    }
                                }
                            }
                        }

                        if (!v_Data_Reader.IsDBNull(24))
                        {
                            v_purchase_info.recurrent = v_Data_Reader.GetString(24);
                        }

                        if (!v_Data_Reader.IsDBNull(25))
                        {
                            v_purchase_info.next_pay_date = v_Data_Reader.GetString(25);
                        }

                        if (!v_Data_Reader.IsDBNull(26))
                        {
                            v_purchase_info.pay_type_code = v_Data_Reader.GetString(26);
                        }

                        if (!v_Data_Reader.IsDBNull(27))
                        {
                            v_purchase_info.catalog_id = v_Data_Reader.GetString(27);
                        }


                        v_purchase_info.logo = Convert.ToString(v_Data_Reader["LOGO"]);


                        string _sql2 = "select to_char(trunc(t.start_date),'YYYY/MM/DD')  start_date," +
"to_char(trunc(t.end_date),'YYYY/MM/DD') end_date," +
"decode(t.start_date,null,'未啟用',decode(sign(end_date-sysdate),1,'已啟用','已到期') ) package_status,t2.package_start_date_desc,t2.package_end_date_desc ,decode(t.start_date,null,'N',decode(sign(end_date-sysdate),1,'Y','N') ) status " +
" from bsm_client_details t,bsm_package_mas t2 " +
" where t.status_flg = 'P' " +
"and t.mac_address =:mac_address " +
"and t.package_id = :package_id and t2.package_id= t.package_id";

                        OracleCommand _cmd2 = new OracleCommand(_sql2, conn);
                        _cmd2.BindByName = true;
                        _cmd2.Parameters.Add("mac_address", client_id);
                        _cmd2.Parameters.Add("package_id", v_purchase_info.package_id);
                        OracleDataReader v_Data_Reader2 = _cmd2.ExecuteReader();
                        v_purchase_info.use_status = "N";
                        while (v_Data_Reader2.Read()) v_purchase_info.use_status = Convert.ToString(v_Data_Reader2["PACKAGE_STATUS"]);
                        v_purchase_info.purchase_datetime = v_Data_Reader.GetString(11);

                        v_Data_Reader2.Dispose();


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

            }
            return v_result;
        }


        public List<purchase_info> get_order(string client_id, string device_id, string src_no)
        {
            List<purchase_info> v_result = new List<purchase_info>();

            string _sql = @"Select to_char(mas_date,'YYYY/MM/DD') mas_date,to_char(mas_date,'YYYY/MM/DD  HH24:MI') mas_time,mas_no,card_no,'CREDIT' pay_type,price amount,decode(status_flg,'P',3,'N',1,0) pay_status,tax_inv_no,promotion_code,tax_gift_flg
                            From bsm_order_mas where 1=1  and status_flg='P' ";

            if (src_no != null)
            {
                _sql = _sql + " and MAS_NO = '" + src_no + "'";
            }

            if (client_id != null)
            {
                _sql = _sql + " and CLIENT_ID = '" + client_id + "'";
            }

            connectDB();
            try
            {
                OracleCommand cmd = new OracleCommand(_sql, conn);
                cmd.BindByName = true;
                OracleDataReader _rd = cmd.ExecuteReader();
                while (_rd.Read())
                {
                    purchase_info _pur = new purchase_info();
                    _pur.purchase_date = Convert.ToString(_rd["MAS_DATE"]);
                    _pur.purchase_datetime = Convert.ToString(_rd["MAS_TIME"]);
                    _pur.purchase_id = Convert.ToString(_rd["MAS_NO"]);
                    _pur.card_no = Convert.ToString(_rd["CARD_NO"]);
                    _pur.pay_type = Convert.ToString(_rd["PAY_TYPE"]);

                    _pur.pay_status = Convert.ToInt16(_rd["PAY_STATUS"]);
                    _pur.invoice_no = Convert.ToString(_rd["TAX_INV_NO"]);
                    _pur.recurrent = "O";
                    _pur.invoice_gift_flg = Convert.ToString(_rd["TAX_GIFT_FLG"]);

                    _pur.amount = _rd["AMOUNT"] == DBNull.Value ? 0 : Convert.ToDecimal(_rd["AMOUNT"]);

                    _pur.details = new List<purchase_detail>();

                    JsonObject _promotion = get_promotion_product(Convert.ToString(_rd["PROMOTION_CODE"]));

                    if (_promotion["items"] != null)
                    {

                        foreach (JsonObject v in (JsonArray)_promotion["items"])
                        {
                            purchase_detail _dtl = new purchase_detail();
                            _dtl.package_id = _promotion["code"].ToString();
                            _dtl.catalog_description = v["description"].ToString();
                            _dtl.package_name = "加價購";

                            _dtl.price = Convert.ToInt16(v["price"].ToString());

                            _pur.details.Add(_dtl);
                        }
                    }
                    else
                    {
                        purchase_detail _dtl = new purchase_detail();
                        if (_promotion["code"] == null)
                        {
                            _dtl.package_id = Convert.ToString(_rd["PROMOTION_CODE"]);
                            _dtl.package_name = Convert.ToString(_rd["PROMOTION_CODE"]);
                        }
                        else
                        {
                            _dtl.package_id = _promotion["code"].ToString();
                            _dtl.catalog_description = _promotion["description"].ToString();
                            _dtl.package_name = "加價購";
                            _dtl.price = Convert.ToInt16(_promotion["price"].ToString());
                        }
                    }

                    v_result.Add(_pur);
                }
                _rd.Dispose();
            }
            finally
            {
                closeDB();
            }

            return v_result;
        }


        /// <summary>
        /// 取得服務到期日
        /// </summary>
        /// <param name="token"></param>
        /// <param name="client_id"></param>
        /// <param name="device_id"></param>
        /// <param name="asset_id"></param>
        /// <returns></returns>
        public string get_service_end_date(string token, string client_id, string device_id, string asset_id)
        {
            connectDB();

            string sql1 = "begin :P_RESULT := check_cdi_access(:P_CLIENT_ID,:P_ASSET_ID,:P_DEVICE_ID); end; ";
            string v_can_access = "N";
            string result = "";
            try
            {
                OracleCommand cmd = new OracleCommand(sql1, conn);

                v_can_access = "Y";
                sql1 = "Select get_end_date(:P_CLIENT_ID,:P_ASSET_ID,:P_DEVICE_ID) FROM dual";


                if (v_can_access == "Y")
                {
                    cmd = new OracleCommand(sql1, conn);
                    cmd.BindByName = true;
                    cmd.Parameters.Add("P_CLIENT_ID", OracleDbType.Varchar2, 32, client_id, ParameterDirection.Input);
                    cmd.Parameters.Add("P_ASSET_ID", OracleDbType.Varchar2, 32, asset_id, ParameterDirection.Input);
                    cmd.Parameters.Add("P_DEVICE_ID", OracleDbType.Varchar2, 32, device_id, ParameterDirection.Input);
                    OracleDataReader _reader = cmd.ExecuteReader();
                    if (_reader.Read())
                    {
                        if (!_reader.IsDBNull(0))
                        {
                            result = (_reader.GetDateTime(0).ToString("yyyy/MM/dd") != "2999/12/31") ? _reader.GetDateTime(0).ToString("yyyy/MM/dd") : "";
                        }
                        else
                        {
                            result = "";
                        }
                    }
                }
                else
                {
                    result = "未定";
                }

                if (asset_id == "com.tgc.stock")
                {
                    string sql_log = @"insert into bsm_client_event_log
      (client_id,
       f_client_id,
       unix_timestamp,
       event_name,
       event_time,
       client_read_access)
    values
      (:p_client_id,
       0,
       (sysdate - TO_DATE('19700101', 'YYYYMMDD')) * 86400000000,
       'E_STOCK',
       sysdate,
       'com.tgc.stock')";

                    OracleCommand cmd_log = new OracleCommand(sql_log, conn);
                    cmd_log.BindByName = true;
                    cmd_log.Parameters.Add("P_CLIENT_ID", OracleDbType.Varchar2, 32, client_id, ParameterDirection.Input);
                    cmd_log.ExecuteNonQuery();

                }
            }
            finally
            {
                closeDB();
            }


            return result;
        }

        public string get_message_2(string message_type, string sw_version)
        {
            string _result = "";
            connectDB();
            string _sql = "select message,message_type from BSM_CREDIT_MESSAGE t ";
            OracleCommand _cmd = new OracleCommand(_sql, conn);
            _cmd.BindByName = true;
            _cmd.Parameters.Add("MESSAGE_TYPE", message_type);
            OracleDataReader _reader = _cmd.ExecuteReader();
            while (_reader.Read())
            {
                dsp_message ob = new dsp_message();
                DataReaderToObject(_reader, ob);
                _result = ob.message;
            }
            _cmd.Dispose();
            closeDB();
            return _result;
        }

        public string get_message(string message_type, string sw_version)
        {
            string _result = "";
            string software_group = sw_version.Substring(0, 7);

            connectDB();

            string _sql = "select message,message_type from BSM_MESSAGE_MAS t where message_type =:MESSAGE_TYPE and software_group ='" + software_group + "'";
            OracleCommand _cmd = new OracleCommand(_sql, conn);
            _cmd.BindByName = true;
            _cmd.Parameters.Add("MESSAGE_TYPE", message_type);
            OracleDataReader _reader = _cmd.ExecuteReader();
            _result = _reader.Read() ? Convert.ToString(_reader["MESSAGE"]) : null;

            if (_result == null)
            {
                _sql = "select message,message_type from BSM_CREDIT_MESSAGE t where message_type =:MESSAGE_TYPE";
                _cmd = new OracleCommand(_sql, conn);
                _cmd.BindByName = true;
                _cmd.Parameters.Add("MESSAGE_TYPE", message_type);
                _reader = _cmd.ExecuteReader();
                _result = _reader.Read() ? Convert.ToString(_reader["MESSAGE"]) : null;
            }
            _cmd.Dispose();
            closeDB();
            return _result;
        }

        /// <summary>
        /// 取信用卡訊息
        /// </summary>
        /// <returns></returns>
        public string get_credit_message()
        {
            string _result = "";
            connectDB();
            string _sql = "select message from BSM_CREDIT_MESSAGE t where message_type='CREDIT'";

            OracleCommand _cmd = new OracleCommand(_sql, conn);
            OracleDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                if (!_reader.IsDBNull(0))
                {
                    _result = _reader.GetString(0);
                }
            }
            _cmd.Dispose();
            closeDB();

            return _result;
        }

        /// <summary>
        /// 取COUPON訊息
        /// </summary>
        /// <returns></returns>
        public string get_coupon_message()
        {
            string _result = "";
            connectDB();
            string _sql = "select message from BSM_CREDIT_MESSAGE t where message_type='COUPON'";

            OracleCommand _cmd = new OracleCommand(_sql, conn);
            OracleDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                if (!_reader.IsDBNull(0))
                {
                    _result = _reader.GetString(0);
                }
            }
            _cmd.Dispose();
            closeDB();

            return _result;
        }

        /// <summary>
        /// 取儲值卡訊息
        /// </summary>
        /// <returns></returns>
        public string get_credits_message()
        {
            string _result = "";
            connectDB();
            string _sql = "select message from BSM_CREDIT_MESSAGE t where message_type='CREDITS'";

            OracleCommand _cmd = new OracleCommand(_sql, conn);
            OracleDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                if (!_reader.IsDBNull(0))
                {
                    _result = _reader.GetString(0);
                }
            }
            _cmd.Dispose();
            closeDB();

            return _result;
        }

        /// <summary>
        /// 取儲值卡訊息
        /// </summary>
        /// <returns></returns>
        public string get_dsp_message(string client_id)
        {
            string _result = "";
            connectDB();
            string _sql = "select message from BSM_CREDIT_MESSAGE t where message_type='DSP'";

            OracleCommand _cmd = new OracleCommand(_sql, conn);
            OracleDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                if (!_reader.IsDBNull(0))
                {
                    _result = _reader.GetString(0);
                }
            }
            _cmd.Dispose();
            closeDB();

            return _result;
        }

        /// <summary>
        /// 取Recurrent Contract
        /// </summary>
        /// <returns></returns>
        public string get_recurrent_contract()
        {
            string _result = "";
            connectDB();
            string _sql = "select message from BSM_CREDIT_MESSAGE t where message_type='RECURRENT_CNT'";

            OracleCommand _cmd = new OracleCommand(_sql, conn);
            OracleDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                if (!_reader.IsDBNull(0))
                {
                    _result = _reader.GetString(0);
                }
            }
            _cmd.Dispose();
            closeDB();

            return _result;
        }

        /// <summary>
        /// 取Already Recurrent Contract
        /// </summary>
        /// <returns></returns>
        public string get_already_recurrent_message()
        {
            string _result = "";
            connectDB();
            string _sql = "select message from BSM_CREDIT_MESSAGE t where message_type='RECURRENT_ALREADY'";

            OracleCommand _cmd = new OracleCommand(_sql, conn);
            OracleDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                if (!_reader.IsDBNull(0))
                {
                    _result = _reader.GetString(0);
                }
            }
            _cmd.Dispose();
            closeDB();

            return _result;
        }

        public string get_onetime_message()
        {
            string _result = "";
            connectDB();
            string _sql = "select message from BSM_CREDIT_MESSAGE t where message_type='ONETIME_ALREADY'";

            OracleCommand _cmd = new OracleCommand(_sql, conn);
            OracleDataReader _reader = _cmd.ExecuteReader();
            if (_reader.Read())
            {
                if (!_reader.IsDBNull(0))
                {
                    _result = _reader.GetString(0);
                }
            }
            _cmd.Dispose();
            closeDB();

            return _result;
        }
        /// <summary>
        /// 取Content package 資訊
        /// </summary>
        /// <param name="token"></param>
        /// <param name="client_id"></param>
        /// <param name="content_id"></param>
        /// <returns></returns>
        public List<package_info> get_content_package_info(string client_id, string content_id, string device_id)
        {
            List<package_info> v_result = new List<package_info>();
            string _sql;
            if (client_id != "" && client_id != null)
            {
                client_id = client_id.ToUpper();
            }

            connectDB(); ;
            try
            {
                if (client_id != "" && client_id != null)
                {

                    if (content_id == "KOD")
                    {
                        _sql = @"select t2.package_id,t2.description  package_name,t2.package_cat1 cat,t2.package_cat_id1,t2.price_des,t2.charge_amount   price, t2.logo,t2.package_des_html, null item_id,t2.package_des,t2.package_start_date_desc,t2.package_end_date_desc ,t2.package_type ,t2.credits,t2.credits_des ,t2.package_des_text,t2.cal_type,
t2.recurrent,
t2.recurrent current_recurrent_status
 from bsm_package_mas t2  
 where t2.system_type = 'BUY' 
 and t2.status_flg = 'P' 
 and t2.package_cat_id1=:content_id 
 and t2.package_id in (select package_id from bsm_package_sg where software_group = 'LTWEB00' and status_flg = 'P')
union all 
 select t2.package_id,t2.description  package_name,t2.package_cat1 cat,t2.package_cat_id1,t2.price_des,t2.charge_amount   price, t2.logo,t2.package_des_html, null item_id,t2.package_des,t2.package_start_date_desc,t2.package_end_date_desc ,t2.package_type ,t2.credits,t2.credits_des ,t2.package_des_text,t2.cal_type,
t2.recurrent,
t2.recurrent, current_recurrent_status
 from bsm_package_mas t2  
 where t2.system_type = 'BUY' 
 and t2.status_flg = 'P' 
 and t2.package_cat_id1 <> :content_id 
 and t2.package_id in (select package_id from bsm_package_sg where software_group = 'LTWEB00' and status_flg = 'P')";
                    }
                    else
                    {

                        _sql = @"with cte as
 (select t2.package_id,
         t2.description             package_name,
         t2.package_cat1            cat,
         t2.package_cat_id1,
         t2.price_des,
         t2.charge_amount           price,
         t2.logo,
         t2.package_des_html,
         b.item_id                  item_id,
         t2.package_des,
         t2.package_start_date_desc,
         t2.package_end_date_desc,
         t2.package_type,
         t2.credits,
         t2.credits_des,
         t2.package_des_text,
         t2.cal_type,
         t2.recurrent,
         t2.recurrent               current_recurrent_status
    from mid_cms_content  c,
         mid_cms_item_rel a,
         mid_cms_item     b,
         bsm_package_mas  t2
   where t2.system_type = 'BUY'
     and t2.status_flg = 'P'
     and b.status_flg = 'P'
     and ((t2.package_id = b.package_id and a.mas_pk_no = c.pk_no and
         c.content_id = :CONTENT_ID and type = 'P' and
         b.pk_no = a.detail_pk_no))
  union all
  select t2.package_id,
         t2.description             package_name,
         t2.package_cat1            cat,
         t2.package_cat_id1,
         t2.price_des,
         t2.charge_amount           price,
         t2.logo,
         t2.package_des_html,
         c.content_id               item_id,
         t2.package_des,
         t2.package_start_date_desc,
         t2.package_end_date_desc,
         t2.package_type,
         t2.credits,
         t2.credits_des,
         t2.package_des_text,
         t2.cal_type,
         t2.recurrent,
         t2.recurrent               current_recurrent_status
    from (select distinct a.category_id     category_id,
                        b.package_cat_id2 content_type,
                        a.content_id      content_id,
                        b.package_id      package_id
          from ccc_program_asset a, bsm_package_mas b, bsm_acl_details c
         where b.package_id = c.acl_id
           and b.package_cat_id1 = c.cat_id
           and a.category_id = c.cat_id
           and a.active_flg = 'Y') c,
       bsm_package_mas t2
 where t2.system_type = 'BUY'
   and t2.status_flg = 'P'
   and t2.package_id = c.package_id
   and t2.package_cat_id1 = c.category_id and
         c.content_id = :CONTENT_ID) 
select *
  from cte
 where package_id in
       (select package_id from bsm_package_sg
         where software_group = 'LTWEB00'
           and status_flg = 'P') ";

                    }
                }
                else
                {
                    _sql = @"select t2.package_id,
       t2.description             package_name,
       t2.package_cat1            cat,
       t2.package_cat_id1,
       t2.price_des,
       t2.charge_amount           price,
       t2.logo,
       t2.package_des_html,
       b.item_id                  item_id,
       t2.package_des,
       t2.package_start_date_desc,
       t2.package_end_date_desc,
       t2.package_type,
       t2.credits,
       t2.credits_des,
       t2.package_des_text,
       t2.cal_type,
       t2.recurrent,
       t2.recurrent current_recurrent_status
  from mid_cms_content  c,
       mid_cms_item_rel a,
       mid_cms_item     b,
       bsm_package_mas  t2
 where t2.system_type = 'BUY'
   and t2.status_flg = 'P'
   and b.status_flg='P'
   and ((t2.package_id = b.package_id and a.mas_pk_no = c.pk_no and
       c.content_id = :content_id and type = 'P' and
       b.pk_no = a.detail_pk_no)) 
union all       
select t2.package_id,
       t2.description             package_name,
       t2.package_cat1            cat,
       t2.package_cat_id1,
       t2.price_des,
       t2.charge_amount           price,
       t2.logo,
       t2.package_des_html,
       c.content_id                item_id,
       t2.package_des,
       t2.package_start_date_desc,
       t2.package_end_date_desc,
       t2.package_type,
       t2.credits,
       t2.credits_des,
       t2.package_des_text,
       t2.cal_type,
       t2.recurrent,
       t2.recurrent               current_recurrent_status
  from (select distinct a.category_id     category_id,
                        b.package_cat_id2 content_type,
                        a.content_id      content_id,
                        b.package_id      package_id
          from ccc_program_asset a, bsm_package_mas b, bsm_acl_details c
         where b.package_id = c.acl_id
           and b.package_cat_id1 = c.cat_id
           and a.category_id = c.cat_id
           and a.active_flg = 'Y') c,
       bsm_package_mas t2
 where t2.system_type = 'BUY'
   and t2.status_flg = 'P'
   and t2.package_id = c.package_id
   and t2.package_cat_id1 = c.category_id
   and c.content_id = :content_id  ";
                }

                OracleCommand _cmd = new OracleCommand(_sql, conn);
                _cmd.BindByName = true;
                _cmd.Parameters.Add("content_id", content_id);

                OracleDataReader v_Data_Reader = _cmd.ExecuteReader();
                int _i = 0;
                try
                {
                    while (v_Data_Reader.Read())
                    {
                        package_info v_package_info = new package_info();
                        v_package_info.package_id = v_Data_Reader.GetString(0);
                        v_package_info.package_name = v_Data_Reader.GetString(1);
                        v_package_info.catalog_description = v_Data_Reader.GetString(2);
                        v_package_info.catalog_id = v_Data_Reader.GetString(3);
                        if (!v_Data_Reader.IsDBNull(4))
                        {
                            v_package_info.price_description = v_Data_Reader.GetString(4);
                        }
                        if (!v_Data_Reader.IsDBNull(5))
                        {
                            v_package_info.price = v_Data_Reader.GetString(5);
                        }

                        if (!v_Data_Reader.IsDBNull(8))
                        {
                            v_package_info.item_id = v_Data_Reader.GetString(8);
                        }

                        if (!v_Data_Reader.IsDBNull(10))
                        {
                            v_package_info.start_date = v_Data_Reader.GetString(10);
                        }

                        if (!v_Data_Reader.IsDBNull(11))
                        {
                            v_package_info.end_date = v_Data_Reader.GetString(11);
                        }
                        if (!v_Data_Reader.IsDBNull(12))
                        {
                            if (v_Data_Reader.GetString(12) == "PPV")
                            {
                                v_package_info.show_detail_flg = "Y";
                            }
                            else
                            {
                                v_package_info.show_detail_flg = "N";
                            }
                        }

                        if (!v_Data_Reader.IsDBNull(13))
                        {
                            v_package_info.credits = v_Data_Reader.GetDecimal(13);
                        }

                        if (!v_Data_Reader.IsDBNull(16))
                        {
                            v_package_info.cal_type = v_Data_Reader.GetString(16);
                        }

                        if (!v_Data_Reader.IsDBNull(17))
                        {
                            v_package_info.recurrent = v_Data_Reader.GetString(17);
                        }

                        if (!v_Data_Reader.IsDBNull(18))
                        {
                            v_package_info.current_recurrent_status = v_Data_Reader.GetString(18);
                        }

                        if (!v_Data_Reader.IsDBNull(13))
                        {
                            v_package_info.cost_credits = v_package_info.credits.ToString() + "點";
                        }

                        v_package_info.credits_balance = (int)get_credits_balance(client_id).credits - v_package_info.credits;


                        if (v_package_info.credits_balance >= 0)
                        {
                            v_package_info.after_credits = v_package_info.credits_balance.ToString() + "點";
                        }
                        else
                        {
                            v_package_info.after_credits = "0點";
                        }


                        v_package_info.status_description = "尚未付費";

                        string _sql2 = "select decode(trunc(t.start_date),null,t2.package_start_date_desc,to_char(trunc(t.start_date),'YYYY/MM/DD'))  start_date," +
        "decode(trunc(t.end_date),null,'無'" +
        ",to_char(trunc(t.end_date),'YYYY/MM/DD')) end_date," +
       "decode(t.start_date,null,'可使用,未啟用',decode(sign(end_date-sysdate),1,'已啟用','已到期') ) package_status  " +
  " from bsm_client_details t,bsm_package_mas t2 " +
 " where t2.status_flg = 'P' and t2.package_id=t.package_id " +
 "and t.mac_address =:mac_address " +
 "and t.package_id = :package_id";

                        OracleCommand _cmd2 = new OracleCommand(_sql2, conn);
                        _cmd2.BindByName = true;
                        _cmd2.Parameters.Add("mac_address", client_id);
                        _cmd2.Parameters.Add("package_id", v_package_info.package_id);
                        OracleDataReader v_Data_Reader2 = _cmd2.ExecuteReader();
                        while (v_Data_Reader2.Read())
                        {
                            if (!v_Data_Reader2.IsDBNull(0)) { v_package_info.start_date = v_Data_Reader2.GetString(0); }
                            if (!v_Data_Reader2.IsDBNull(1)) { v_package_info.end_date = v_Data_Reader2.GetString(1); }
                            if (!v_Data_Reader2.IsDBNull(2)) { v_package_info.status_description = v_Data_Reader2.GetString(2); }
                        }


                        int v_package_cnt = 0;

                        v_package_cnt = (from _t in v_result where _t.package_id == v_package_info.package_id select _t).Count();
                        if (v_package_cnt <= 0)
                        {
                            v_result.Add(v_package_info);
                            _i++;
                        }

                    }
                }
                finally
                {
                    v_Data_Reader.Dispose();
                }
            }
            finally
            {
                closeDB();
            }
            return v_result;
        }

        /// <summary>
        /// 取package detail 的內容
        /// </summary>
        /// <param name="token"></param>
        /// <param name="client_id"></param>
        /// <param name="package_id"></param>
        /// <param name="item_id"></param>
        /// <returns></returns>
        public BSM_Info.content_package_info get_package_detail(string client_id, string package_id, string item_id, string p_content_id)
        {

            if (package_id != null && package_id != "" && p_content_id == null)
            {
                string[] _str = package_id.Split(',');
                package_id = _str[0];
                if (_str.Length > 1)
                {
                    p_content_id = _str[1];
                }
            }

            if (p_content_id != "" && p_content_id != null)
            {
                List<package_info> v_package_list = get_content_package_info(client_id, p_content_id, null);
                if (v_package_list.Count > 0)
                {
                    package_id = v_package_list[0].package_id;
                    item_id = v_package_list[0].item_id;
                }
            }

            content_package_info v_result = new content_package_info();
            package_info v_package_info = new package_info();
            content_info v_content_info = new content_info();

            client_id = client_id.ToUpper();

            string _sql;

            connectDB();

            try
            {
                if ((item_id != "" && item_id != null) || p_content_id != null)
                {
                    //
                    // get content info
                    //

                    if (item_id == "" || item_id == null)
                    { item_id = p_content_id; }
                    _sql = "select a.title,a.content_id,decode(a.sdhd,'SD','SD 畫質','HD','HD 高畫質','一般畫質') sdhd,a.rating,a.genre,a.runtime,a.off_shelf_date ,a.eng_title,to_number(nvl(a.score,0))/2,release_year||'出品',to_number(nvl(a.score,0)) from mid_cms_content a " +
                    "where pk_no in (select mas_pk_no from mid_cms_item_rel a " +
                    "where a.detail_pk_no in (select pk_no from mid_cms_item where item_id=:item_id)) or content_id=:content_id";

                    OracleCommand _cmd_content = new OracleCommand(_sql, conn);
                    _cmd_content.Parameters.Add("item_id", item_id);
                    _cmd_content.Parameters.Add("content_id", item_id);
                    OracleDataReader v_dr_content = _cmd_content.ExecuteReader();

                    try
                    {
                        if (v_dr_content.Read())
                        {
                            if (!v_dr_content.IsDBNull(0))
                            {
                                v_content_info.title = v_dr_content.GetString(0);
                            }
                            if (!v_dr_content.IsDBNull(1))
                            {
                                v_content_info.content_id = v_dr_content.GetString(1);
                            }

                            if (!v_dr_content.IsDBNull(2))
                            {
                                v_content_info.sdhd = v_dr_content.GetString(2);
                            }

                            if (!v_dr_content.IsDBNull(3))
                            {
                                v_content_info.rating = v_dr_content.GetString(3);
                            }
                            if (!v_dr_content.IsDBNull(4))
                            {
                                v_content_info.genre = v_dr_content.GetString(4);
                            }
                            if (!v_dr_content.IsDBNull(5))
                            {
                                v_content_info.runtime = v_dr_content.GetString(5);
                            }
                            if (!v_dr_content.IsDBNull(6))
                            {
                                v_content_info.off_shelf_date = v_dr_content.GetString(6);
                            }

                            if (!v_dr_content.IsDBNull(7))
                            {
                                v_content_info.eng_title = v_dr_content.GetString(7);
                            }

                            if (!v_dr_content.IsDBNull(8))
                            {
                                v_content_info.score = v_dr_content.GetDecimal(8);
                            }


                            if (!v_dr_content.IsDBNull(9))
                            {
                                v_content_info.release_year = v_dr_content.GetString(9);
                            }


                            if (!v_dr_content.IsDBNull(10))
                            {
                                v_content_info.score10 = v_dr_content.GetDecimal(10);
                            }


                            v_content_info.remark = " ";

                        }
                    }
                    finally
                    {
                        v_dr_content.Dispose();
                        _cmd_content.Dispose();
                    }
                }

                //
                // get package info 
                //

                if (v_content_info.content_id != null)
                {
                    _sql = @"select t2.package_id,t2.description  package_name,t2.package_cat1 cat,t2.package_cat_id1,t2.price_des,t2.charge_amount   price, 'http://streaming01.tw.svc.litv.tv/'||replace(c.main_picture,'http://streaming01.tw.svc.litv.tv/','') logo,t2.package_des_html, c.content_id item_id,t2.package_type,t2.package_start_date_desc,t2.package_end_date_desc,t2.credits_des,t2.credits,to_char(t2.duration_by_day)||'天' ,
                             t2.recurrent,
                             t2.recurrent current_recurrent_status,
                             decode(t2.recurrent,'R',to_char(BSM_RECURRENT_UTIL.get_service_end_date(t2.package_cat_id1, :MAC_ADDRESS),'YYYY/MM/DD'),'無') next_pay_date
   from mid_cms_content c,mid_cms_item_rel a, mid_cms_item b,bsm_package_mas t2 
 where t2.system_type in ('BUY','CREDITS') 
   and t2.status_flg = 'P' 
   and a.mas_pk_no = c.pk_no 
   and type = 'P' 
   and b.pk_no = a.detail_pk_no 
   and t2.package_id = b.package_id ";

                }
                else
                {
                    _sql = @"select t2.package_id, package_name,cat,t2.package_cat_id1,t2.price_des, price, t2.logo,t2.package_des_html, '' item_id,t2.package_type,t2.package_start_date_desc,t2.package_end_date_desc ,t2.credits_des,t2.credits, day ,
                                                     'O' ,
                             'O' current_recurrent_status,
                             '無' next_pay_date
                        from  bsm_package_mas_free t2 
                        where 1=1 ";
                };

                if (v_content_info.content_id != null)
                {
                    _sql = _sql + "and c.content_id = '" + v_content_info.content_id + "' " +
                    "and t2.package_id = '" + package_id + "' ";
                }
                else
                {
                    _sql = _sql + "and t2.package_id = '" + package_id + "' ";

                };

                OracleCommand _cmd = new OracleCommand(_sql, conn);
                _cmd.Parameters.Add("MAC_ADDRESS", client_id);

                OracleDataReader v_Data_Reader = _cmd.ExecuteReader();
                try
                {
                    if (v_Data_Reader.Read())
                    {
                        v_package_info.package_id = v_Data_Reader.GetString(0);
                        if (!v_Data_Reader.IsDBNull(1))
                        {
                            v_package_info.package_name = v_Data_Reader.GetString(1);
                        }
                        if (!v_Data_Reader.IsDBNull(2))
                        {
                            v_package_info.catalog_description = v_Data_Reader.GetString(2);
                        }
                        if (!v_Data_Reader.IsDBNull(3))
                        {
                            v_package_info.catalog_id = v_Data_Reader.GetString(3);
                        }
                        if (!v_Data_Reader.IsDBNull(4))
                        {
                            v_package_info.price_description = v_Data_Reader.GetString(4);
                        }
                        if (!v_Data_Reader.IsDBNull(5))
                        {
                            v_package_info.price = v_Data_Reader.GetString(5);
                        }
                        if (!v_Data_Reader.IsDBNull(8))
                        {
                            v_package_info.item_id = v_Data_Reader.GetString(8);
                        }

                        if (!v_Data_Reader.IsDBNull(9))
                        {
                            if (v_Data_Reader.GetString(9) == "PPV")
                            {
                                v_result.show_detail_flg = "Y";
                            }
                            else
                            {
                                v_result.show_detail_flg = "N";
                            }
                        }
                        else { v_result.show_detail_flg = "N"; }

                        if (!v_Data_Reader.IsDBNull(10))
                        { v_package_info.start_date = v_Data_Reader.GetString(10); }

                        if (!v_Data_Reader.IsDBNull(11))
                        { v_package_info.end_date = v_Data_Reader.GetString(11); }

                        if (!v_Data_Reader.IsDBNull(12))
                        {
                            v_package_info.cost_credits = v_Data_Reader.GetString(12);
                        }
                        if (!v_Data_Reader.IsDBNull(13))
                        {
                            v_package_info.credits = v_Data_Reader.GetDecimal(13);

                        }
                        if (!v_Data_Reader.IsDBNull(14))
                        {
                            v_package_info.days = v_Data_Reader.GetString(14);
                        }

                        if (!v_Data_Reader.IsDBNull(15))
                        {
                            v_package_info.recurrent = v_Data_Reader.GetString(15);
                        }


                        if (!v_Data_Reader.IsDBNull(16))
                        {
                            v_package_info.current_recurrent_status = v_Data_Reader.GetString(16);
                        }

                        if (!v_Data_Reader.IsDBNull(17))
                        {
                            v_package_info.next_pay_date = v_Data_Reader.GetString(17);
                        }

                        v_package_info.credits_balance = (int)get_credits_balance(client_id).credits - v_package_info.credits;
                        if (v_package_info.credits_balance >= 0)
                        {
                            v_package_info.after_credits = v_package_info.credits_balance.ToString() + "點";
                        }
                        else
                        {
                            v_package_info.after_credits = "0點";
                        }


                        v_package_info.status_description = "尚未付費";

                    }
                    if (p_content_id != "" && p_content_id != null)
                    {
                        string _sql2 = "select decode(trunc(t.start_date),null,t2.package_start_date_desc,to_char(trunc(t.start_date),'YYYY/MM/DD'))  start_date," +
          "decode(trunc(t.end_date),null,null" +
          ",to_char(trunc(t.end_date),'YYYY/MM/DD')) end_date," +
         "decode(t.start_date,null,'可使用,未啟用',decode(sign(end_date-sysdate),1,'已啟用','已到期') ) package_status,decode(t.start_date,null,'N',decode(sign(end_date-sysdate),1,'Y','N') ) status  " +
    " from bsm_client_details t,bsm_package_mas t2 " +
   " where t2.status_flg = 'P' and t2.package_id=t.package_id " +
   "and t.mac_address =:mac_address " +
   "and t.status_flg ='P' " +
  "and (t.package_id, decode(t2.cal_type, 'T',nvl(t.item_id, ' '),' ')) in " +
     "  (select t2.package_id, decode(t2.cal_type, 'T', b.item_id, ' ') " +
  "from mid_cms_content c,mid_cms_item_rel a, mid_cms_item b,bsm_package_mas t2 " +
  "where t2.status_flg = 'P' " +
  "and a.mas_pk_no = c.pk_no " +
  "and c.content_id = :content_id " +
  "and type = 'P' " +
  "and b.pk_no = a.detail_pk_no " +
  "and t2.package_id = b.package_id) ";


                        OracleCommand _cmd2 = new OracleCommand(_sql2, conn);
                        _cmd2.BindByName = true;
                        _cmd2.Parameters.Add("mac_address", client_id);
                        _cmd2.Parameters.Add("content_id", p_content_id);
                        OracleDataReader v_Data_Reader2 = _cmd2.ExecuteReader();
                        v_package_info.use_status = "N";
                        while (v_Data_Reader2.Read())
                        {
                            if (!v_Data_Reader2.IsDBNull(0)) { v_package_info.start_date = v_Data_Reader2.GetString(0); }
                            if (!v_Data_Reader2.IsDBNull(1)) { v_package_info.end_date = v_Data_Reader2.GetString(1); }
                            if (!v_Data_Reader2.IsDBNull(2)) { v_package_info.status_description = v_Data_Reader2.GetString(2); }
                            if (!v_Data_Reader2.IsDBNull(3)) { v_package_info.use_status = v_Data_Reader2.GetString(3); }
                        }
                    }
                    else
                    {
                        string _sql3 = "select '' start_date,'無' end_date,'已啟用' from mfg_free_service where package_id=:P_PACKAGE_ID ";
                        OracleCommand _cmd3 = new OracleCommand(_sql3, conn);
                        _cmd3.Parameters.Add("P_PACKAGE_ID", package_id);
                        OracleDataReader _Data_Reader3 = _cmd3.ExecuteReader();
                        while (_Data_Reader3.Read())
                        {
                            if (!_Data_Reader3.IsDBNull(0)) { v_package_info.start_date = _Data_Reader3.GetString(0); }
                            if (!_Data_Reader3.IsDBNull(1)) { v_package_info.end_date = _Data_Reader3.GetString(1); }
                            if (!_Data_Reader3.IsDBNull(2)) { v_package_info.status_description = _Data_Reader3.GetString(2); }
                        }


                        string _sql2 = "select decode(trunc(t.start_date),null,t2.package_start_date_desc,to_char(trunc(t.start_date),'YYYY/MM/DD'))  start_date," +
                            "decode(trunc(t.end_date),null,null" +
                            ",to_char(trunc(t.end_date),'YYYY/MM/DD')) end_date," +
                            "decode(t.start_date,null,'可使用,未啟用',decode(sign(end_date-sysdate),1,'已啟用','已到期') ) package_status ,decode(t.start_date,null,'N',decode(sign(end_date-sysdate),1,'Y','N') ) status " +
                            " from bsm_client_details t,bsm_package_mas t2 " +
                            " where t2.status_flg = 'P' and t2.package_id=t.package_id " +
                            "and t.mac_address =:mac_address " +
                            "and t.package_id = :package_id and t.status_flg ='P'";
                        OracleCommand _cmd2 = new OracleCommand(_sql2, conn);
                        _cmd2.BindByName = true;
                        _cmd2.Parameters.Add("mac_address", client_id);
                        _cmd2.Parameters.Add("package_id", package_id);
                        OracleDataReader v_Data_Reader2 = _cmd2.ExecuteReader();
                        v_package_info.use_status = "N";
                        while (v_Data_Reader2.Read())
                        {
                            if (!v_Data_Reader2.IsDBNull(0)) { v_package_info.start_date = v_Data_Reader2.GetString(0); }
                            if (!v_Data_Reader2.IsDBNull(1)) { v_package_info.end_date = v_Data_Reader2.GetString(1); }
                            if (!v_Data_Reader2.IsDBNull(2)) { v_package_info.status_description = v_Data_Reader2.GetString(2); }
                            if (!v_Data_Reader2.IsDBNull(3)) { v_package_info.status_description = v_Data_Reader2.GetString(3); }
                        }
                    }
                }
                finally
                {
                    v_Data_Reader.Dispose();
                }
            }
            finally
            {
                closeDB();
            }

            v_result.package_info = v_package_info;
            v_result.content_info = v_content_info;
            return v_result;
        }


        /// <summary>
        /// 取得Client Activation Code
        /// </summary>
        /// <param name="client_id"></param>
        /// <returns></returns>
        public string get_activation_code(string client_id)
        {
            connectDB();
            client_id = client_id.ToUpper();

            string _sql = "Select activation_code from bsm_client_mas a where a.MAC_ADDRESS=:CLIENT_ID";
            string _result = "";
            OracleCommand _cmd = new OracleCommand(_sql, conn);
            _cmd.Parameters.Add("CLIENT_ID", client_id);
            OracleDataReader _Data_Reader;

            try
            {
                _Data_Reader = _cmd.ExecuteReader();
                if (_Data_Reader.Read())
                {
                    if (!_Data_Reader.IsDBNull(0))
                    {
                        _result = _Data_Reader.GetString(0);
                    }
                }
            }
            finally
            {
                _cmd.Dispose();
                closeDB();
            }
            return _result;
        }

        public string get_client_info(string client_id)
        {
            connectDB();

            client_id = client_id.ToUpper();

            string _sql = "Select bsm_cdi_service_test.get_cdi_info(mac_address) FROM bsm_client_mas a where a.MAC_ADDRESS=:CLIENT_ID";
            string _result = "";
            OracleCommand _cmd = new OracleCommand(_sql, conn);
            _cmd.Parameters.Add("CLIENT_ID", client_id);
            OracleDataReader _Data_Reader;

            try
            {
                _Data_Reader = _cmd.ExecuteReader();
                if (_Data_Reader.Read())
                {
                    if (!_Data_Reader.IsDBNull(0))
                    {
                        _result = _Data_Reader.GetString(0);
                    }
                }
            }
            finally
            {
                _cmd.Dispose();
                closeDB();
            }
            return _result;
        }

        public string check_access(string token, string client_id, string asset_id, string device_id)
        {
            connectDB();

            string sql1 = "begin :P_RESULT := check_cdi_access(:P_CLIENT_ID,:P_ASSET_ID); end; ";
            string result = "N";
            try
            {
                OracleCommand cmd = new OracleCommand(sql1, conn);
                cmd.BindByName = true;
                OracleString v_o_result;
                cmd.Parameters.Add("P_CLIENT_ID", OracleDbType.Varchar2, 32, client_id, ParameterDirection.Input);
                cmd.Parameters.Add("P_ASSET_ID", OracleDbType.Varchar2, 32, asset_id, ParameterDirection.Input);
                cmd.Parameters.Add("P_RESULT", OracleDbType.Varchar2, 32, ParameterDirection.InputOutput);
                cmd.ExecuteNonQuery();

                v_o_result = (OracleString)cmd.Parameters["P_RESULT"].Value;
                result = v_o_result.ToString();
            }
            finally
            {
                closeDB();
            }

            return result;

        }

        public string get_stock_broker(string client_id)
        {
            connectDB();

            client_id = client_id.ToUpper();

            string _sql = "Select stock_broker FROM bsm_client_mas a where a.MAC_ADDRESS=:CLIENT_ID";
            string _result = "";
            OracleCommand _cmd = new OracleCommand(_sql, conn);
            _cmd.Parameters.Add("CLIENT_ID", client_id);
            OracleDataReader _Data_Reader;

            try
            {
                _Data_Reader = _cmd.ExecuteReader();
                if (_Data_Reader.Read())
                {
                    if (!_Data_Reader.IsDBNull(0))
                    {
                        _result = _Data_Reader.GetString(0);
                    }
                }
            }
            finally
            {
                _cmd.Dispose();
                closeDB();
            }
            return _result;

        }

        public credits_balance_info get_credits_balance(string client_id)
        {
            connectDB();
            credits_balance_info _result = new credits_balance_info();

            OracleCommand _cmd = new OracleCommand("SELECT credits_type,open_credits,to_char(expiration_date,'YYYY/MM/DD') expiration_date FROM bsm_client_credits_Mas WHERE CLIENT_ID=:P_CLIENT_ID Order by credits_type desc,EXPIRATION_DATE desc", conn);
            _cmd.Parameters.Add("CLIENT_ID", client_id);
            OracleDataReader _reader; 
            try
            {
                _reader =  _cmd.ExecuteReader();
                try
                {
                    _result.credits = 0;
                    credits_detail _buy_credits = new credits_detail();
                    _buy_credits.credits_type = "BUY";
                    _buy_credits.credits_desc = "儲值點數";
                    _buy_credits.credits = 0;
                    credits_detail _gift_credits = new credits_detail();
                    _gift_credits.credits_type = "GIFT";
                    _gift_credits.credits_desc = "紅利點數";
                    _gift_credits.credits = 0;

                    while (_reader.Read())
                    {
                        _result.credits += Convert.ToInt32(_reader["OPEN_CREDITS"]);
                        if ((string)_reader["CREDITS_TYPE"] == "BUY")
                        {
                            _buy_credits.credits += Convert.ToInt32(_reader["OPEN_CREDITS"]);
                        }
                        else
                        {
                            if (Convert.ToString(_reader["EXPIRATION_DATE"]) != "")
                            {
                                _buy_credits.expired_date = Convert.ToString(_reader["EXPIRATION_DATE"]);
                                _result.creaits_remind = (Convert.ToInt32(_reader["OPEN_CREDITS"]) > 0) ? "紅利點數" + Convert.ToString(_reader["OPEN_CREDITS"]) + "點將於" + _buy_credits.expired_date + "到期" : "";
                            }

                            _gift_credits.credits += Convert.ToInt32(_reader["OPEN_CREDITS"]);
                        }
                    }

                    _result.credits_description = Convert.ToString(_result.credits) + "點";

                    _result.details = new List<credits_detail>();
                    _result.details.Add(_gift_credits);
                    _result.details.Add(_buy_credits);
                }
                finally
                {
                    _reader.Dispose();
                   
                }
            }
            finally
            {
                
                _cmd.Dispose();
            }

            return _result;
        }

        public void get_purchase_credits(string purchase_id, credits_balance_info src_credits, credits_balance_info after_credits)
        {
            connectDB();

            credits_detail _buy_credits = new credits_detail();
            _buy_credits.credits_type = "BUY";
            _buy_credits.credits_desc = "儲值點數";
            _buy_credits.credits = 0;
            credits_detail _gift_credits = new credits_detail();
            _gift_credits.credits_type = "GIFT";
            _gift_credits.credits_desc = "紅利點數";
            _gift_credits.credits = 0;


            string _sql = "select b.credits_type,src_credits,credits,b.after_credits from bsm_purchase_mas a,bsm_purchase_credits b where b.mas_pk_no=a.pk_no and a.mas_no = :purchase_id";
            OracleCommand _cmd = new OracleCommand(_sql, conn);
            _cmd.Parameters.Add("PURCHASE_ID", purchase_id);
            OracleDataReader _rd = _cmd.ExecuteReader();
            try
            {
                src_credits.details = new List<credits_detail>();
                after_credits.details = new List<credits_detail>();

                src_credits.credits = 0;
                after_credits.credits = 0;
                while (_rd.Read())
                {
                    credits_detail _src_cd = new credits_detail();
                    _src_cd.credits_type = Convert.ToString(_rd["CREDITS_TYPE"]);
                    _src_cd.credits_desc = (_src_cd.credits_type == "BUY") ? "儲值點數" : "紅利點數";
                    _src_cd.credits = Convert.ToInt32(_rd["SRC_CREDITS"]);

                    src_credits.details.Add(_src_cd);
                    src_credits.credits += _src_cd.credits;

                    //src_credits.credits

                    credits_detail _cd = new credits_detail();
                    _cd.credits_type = Convert.ToString(_rd["CREDITS_TYPE"]);
                    _cd.credits_desc = (_src_cd.credits_type == "BUY") ? "儲值點數" : "紅利點數";
                    _cd.credits = Convert.ToInt32(_rd["AFTER_CREDITS"]);
                    after_credits.details.Add(_cd);
                    after_credits.credits += _cd.credits;

                }
            }
            finally
            {
                _rd.Dispose();
                _cmd.Dispose();
            }
            src_credits.credits_description = Convert.ToString(src_credits.credits) + "點";
            after_credits.credits_description = Convert.ToString(after_credits.credits) + "點";
        }

        public messamge_box get_message_box(string client_id, string device_id, string sw_version, string message_id)
        {
            List<messamge_box> _result = get_all_message_box();
            return (from _x in _result where _x.id == message_id select _x).First();
        }

        public void refresh()
        {
            _MongoDBMaster.Drop();
        }

        private void init_cht_parame()
        {
            //
            // 中華電信帳單
            //
            cht_payments.Clear();
            cht_payments.Add("Hinet", "寬頻帳單付款");
            cht_payments.Add("Chtld", "手機帳單付款");
            cht_payments.Add("Chtn", "市話帳單付款");
            cht_payments.Add("ATM", "中華支付ATM付款");
            cht_payments.Add("WEBATM", "中華支付WEBATM付款");
            cht_payments.Add("Credit", "中華支付信用卡付款");

            cht_prodduct_code.Clear();

            string cht_product_codes_colname = "cht_product_codes";
            var _collection = _MongoDB.GetCollection<cht_prodduct_code>(cht_product_codes_colname);

            List<cht_prodduct_code> d_list = _collection.AsQueryable().ToList();
            if (d_list.Count() == 0)
            {
                string _sql = @"Select cht_payment_method||'+'||package_id ""_id"",package_id,cht_product_id cht_product_code,cht_payment_method cht_paymethod from BSM_CHT_MAP";
                d_list = DataReaderToObjectList<cht_prodduct_code>(_sql).ToList();

                _MongoDBMaster.GetCollection<cht_prodduct_code>(cht_product_codes_colname).InsertBatch(d_list);
            }

            foreach (var a in d_list)
                cht_prodduct_code.Add(a.cht_paymethod + "+" + a.package_id, a.cht_product_code);
        }

        public class promotion_item
        {
            public string description;
            public decimal price;
        }
        public class promotion_product
        {
            public string _id;
            public string code;
            public string description;
            public decimal price;
            public Boolean stock_out;
            public List<promotion_item> items;
            public promotion_product()
            {
                items = new List<promotion_item>();
                stock_out = false;
            }
        }
        public void post_promotion_product()
        {
            connectDB();
            var promo_product_collection = _MongoDBMaster.GetCollection<promotion_product>("promo_product_collection");
            promo_product_collection.Drop();

            try
            {
                string _sql = @"Select PACKAGE_ID,PACKAGE_NAME,AMOUNT,STATUS_FLG 
from STK_PACKAGE_MAS a where a.STATUS_FLG in ('P','L')";
                OracleCommand _cmd = new OracleCommand(_sql, conn);
                _cmd.BindByName = true;
                OracleDataReader _rd = _cmd.ExecuteReader();

                string _sql_item = @"Select ITEM_NAME,AMOUNT
from STK_PACKAGE_ITEM a where a.PACKAGE_ID=:P_PACKAGE_ID";
                OracleCommand _cmd_item = new OracleCommand(_sql_item, conn);
                _cmd.BindByName = true;
                OracleParameter _pa = new OracleParameter("P_PACKAGE_ID", OracleDbType.Varchar2);
                _cmd_item.Parameters.Add(_pa);


                List<promotion_product> _l_promo_p = new List<promotion_product>();
                while (_rd.Read())
                {


                    promotion_product _promotion_p = new promotion_product();
                    _promotion_p._id = Convert.ToString(_rd["PACKAGE_ID"]);
                    _promotion_p.code = Convert.ToString(_rd["PACKAGE_ID"]);
                    _promotion_p.description = Convert.ToString(_rd["PACKAGE_NAME"]);
                    _promotion_p.price = Convert.ToDecimal(_rd["AMOUNT"]);
                    if (Convert.ToString(_rd["STATUS_FLG"]) == "L")
                    {
                        _promotion_p.stock_out = true;
                    }

                    _pa.Value = _promotion_p._id;

                    OracleDataReader _rd2 = _cmd_item.ExecuteReader();
                    while (_rd2.Read())
                    {
                        promotion_item _pi = new promotion_item();
                        _pi.description = Convert.ToString(_rd2["ITEM_NAME"]);
                        _pi.price = Convert.ToDecimal(_rd2["AMOUNT"]);
                        _promotion_p.items.Add(_pi);
                    }
                    _l_promo_p.Add(_promotion_p);

                }
                if (_l_promo_p.Count() > 0)
                {
                    promo_product_collection.InsertBatch(_l_promo_p);
                }

            }
            finally
            {
                closeDB();
            }
        }
        public JsonObject get_promotion_product(string promotion_code)
        {
            JsonObject _rs = new JsonObject();
            var promo_product_collection = _MongoDBMaster.GetCollection<promotion_product>("promo_product_collection");
            promotion_product _result_pl = new promotion_product();
            var _q = Query.EQ("_id", promotion_code);

            _result_pl = promo_product_collection.FindOne(_q);
            if (_result_pl != null)
            {

                _rs = (JsonObject)JsonConvert.Import(JsonConvert.ExportToString(_result_pl));
            }
            return _rs;
        }

        public JsonArray get_promotion_packages(string product_code)
        {
            JsonArray _result = new JsonArray();
            JsonObject promotion1 = new JsonObject();
            if (product_code == "SHARP9999")
            {
                promotion1 = get_promotion_product("TV0001");
            }
            else
            {
                promotion1 = get_promotion_product(product_code);

                if (promotion1 == null || promotion1.Count == 0)
                {
                    promotion1 = get_promotion_product("PRO5");
                }
            }
            _result.Add(promotion1);
            return _result;

        }

        public void set_all_promotion_code()
        {
            var promotion_code_collection = _MongoDBMaster.GetCollection<promotion_info>("promotion_collection");
            promotion_code_collection.Drop();
            var promotion_client_collection = _MongoDBMaster.GetCollection<promotion_info>("promotion_client_collection");
            promotion_client_collection.Drop();

            var promotion_prog_collection = _MongoDBMaster.GetCollection<promotion_code_prog>("promotion_prog_collection");
            promotion_prog_collection.Drop();

            connectDB();

            try
            {
                string _sql = @"Select c.PROMO_PROG_ID,b.PROMO_TITLE,c.start_date,c.end_date,b.DISCOUNT_PACKAGE_ID,b.AMT,b.DISCOUNT_AMT,b.PROMO_PROG_TYPE,NVL(b.EXTEND_DAYS,0) EXTEND_DAYS,b.PROMO_INFO,c.prog_limit,d.package_cat_id1
from promotion_prog_item b,promotion_prog_mas c,bsm_package_mas d
where c.promo_prog_id=b.promo_prog_id and d.package_id(+)=b.discount_package_id";


                OracleCommand _cmd = new OracleCommand(_sql, conn);
                _cmd.BindByName = true;
                OracleDataReader _rd = _cmd.ExecuteReader();
                List<promotion_code_prog> _l_promo = new List<promotion_code_prog>();
                while (_rd.Read())
                {


                    promotion_code_prog _promotion_code_prog = new promotion_code_prog();
                    _promotion_code_prog.discount_package_id = Convert.ToString(_rd["DISCOUNT_PACKAGE_ID"]);
                    _promotion_code_prog.promo_prog_id = Convert.ToString(_rd["PROMO_PROG_ID"]);
                    _promotion_code_prog.promo_prog_type = Convert.ToString(_rd["PROMO_PROG_TYPE"]);

                    _promotion_code_prog.amount = _rd["AMT"] == DBNull.Value ? 0 : Convert.ToDecimal(_rd["AMT"]);
                    _promotion_code_prog.discount_amount = _rd["DISCOUNT_AMT"] == DBNull.Value ? 0 : Convert.ToDecimal(_rd["DISCOUNT_AMT"]);
                    _promotion_code_prog.extend_days = _rd["EXTEND_DAYS"] == DBNull.Value ? 0 : Convert.ToDecimal(_rd["EXTEND_DAYS"]);
                    _promotion_code_prog.promo_info = Convert.ToString(_rd["PROMO_INFO"]);
                    _promotion_code_prog.promo_title = Convert.ToString(_rd["PROMO_TITLE"]);
                    _promotion_code_prog.start_date = Convert.ToDateTime(_rd["START_DATE"]);
                    _promotion_code_prog.end_date = Convert.ToDateTime(_rd["END_DATE"]);
                    _promotion_code_prog.discount_package_cat_id1 = Convert.ToString(_rd["PACKAGE_CAT_ID1"]);
                    _promotion_code_prog.prog_limit = _rd["PROG_LIMIT"] == DBNull.Value ? 0 : Convert.ToDecimal(_rd["PROG_LIMIT"]);
                    _promotion_code_prog._id = _promotion_code_prog.promo_prog_id + "+" + _promotion_code_prog.discount_package_id;
                    _l_promo.Add(_promotion_code_prog);

                }
                if (_l_promo.Count > 0)
                {
                    promotion_prog_collection.InsertBatch(_l_promo);
                }
            }
            finally
            {
                closeDB();
            }


            set_promotion_code(null);
        }

        public void set_promotion_code(string client_id)
        {
            var promotion_code_collection = _MongoDBMaster.GetCollection<promotion_code>("promotion_collection");
            var promotion_client_collection = _MongoDBMaster.GetCollection<promotion_info>("promotion_client_collection");
            connectDB();

            try
            {
                string _sql = @"Select a.PROMO_PROG_ID,a.PROMO_CODE,a.STATUS_FLG,LIMIT,CLIENT_LIMIT CLIENT_CNT_LIMIT,
(SELECT COUNT(*) FROM BSM_PROMOTION_CLIENTS d where d.promo_code=a.promo_code) client_limit,
a.OWNER,
a.NOBUY_FROM
from PROMOTION_MAS a
where a.STATUS_FLG='P'";
                if (!(client_id == null))
                {
                    _sql = _sql + " and a.owner = :p_client_id";
                }

                OracleCommand _cmd = new OracleCommand(_sql, conn);
                _cmd.BindByName = true;
                if (!(client_id == null))
                {
                    _cmd.Parameters.Add("P_CLIENT_ID", client_id);
                }
                OracleDataReader _rd = _cmd.ExecuteReader();
                List<promotion_code> _l_promo = new List<promotion_code>();
                while (_rd.Read())
                {

                    promotion_code _promotion_info = new promotion_code();
                    _promotion_info.promo_prog_id = Convert.ToString(_rd["PROMO_PROG_ID"]);
                    _promotion_info.promo_code = Convert.ToString(_rd["PROMO_CODE"]);
                    _promotion_info.owner = Convert.ToString(_rd["OWNER"]);
                    _promotion_info.nobuy_from = _rd["NOBUY_FROM"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(_rd["NOBUY_FROM"]);
                    _promotion_info.client_cnt_limit = _rd["CLIENT_CNT_LIMIT"] == DBNull.Value ? 0 : Convert.ToDecimal(_rd["CLIENT_CNT_LIMIT"]);

                    if (Convert.ToDecimal(_rd["CLIENT_LIMIT"]) > 0)
                    {
                        _promotion_info.check_client = true;
                    }
                    _promotion_info._id = _promotion_info.promo_code;
                    _promotion_info.status = true;

                    if (client_id != null)
                    {
                        promotion_code_collection.Save(_promotion_info);
                    }

                    _l_promo.Add(_promotion_info);

                }

                if (client_id == null)
                {
                    promotion_code_collection.InsertBatch(_l_promo);
                }

                string _sql_client = @"SELECT PROMO_CODE,CLIENT_ID,STATUS_FLG FROM BSM_PROMOTION_CLIENTS WHERE 1=1";
                if (!(client_id == null))
                {
                _sql_client = @_sql_client+" AND Client_ID='"+client_id+"'";
                }
                   
                    OracleCommand _cmd2 = new OracleCommand(_sql_client, conn);
                    _cmd.BindByName = true;
                    OracleDataReader _rd2 = _cmd2.ExecuteReader();
                    List<promotion_clients> _l_promo_cliens = new List<promotion_clients>();
                    while (_rd2.Read())
                    {
                        promotion_clients _promo_clients = new promotion_clients();
                        _promo_clients.promo_code = Convert.ToString(_rd2["PROMO_CODE"]);
                        _promo_clients.client_id = Convert.ToString(_rd2["CLIENT_ID"]);
                        if (Convert.ToString(_rd2["STATUS_FLG"]) == "P")
                        {
                            _promo_clients.status_flg = true;
                        }
                        _promo_clients._id = _promo_clients.promo_code + "+" + _promo_clients.client_id;
                        promotion_client_collection.Save(_promo_clients);
                      //  _l_promo_cliens.Add(_promo_clients);
                    }
                  //  if (_l_promo_cliens.Count > 0)
                  //      promotion_client_collection.InsertBatch(_l_promo_cliens);
                
            }
            finally
            {
                closeDB();
            }


        }

        public List<promotion_info> get_promtion_code(string promotion_code)
        {
            List<promotion_code> _promo_code = new List<promotion_code>();
            var promotion_code_collection = _MongoDB.GetCollection<promotion_code>("promotion_collection");
            var query = Query.EQ("_id", promotion_code);
            _promo_code = promotion_code_collection.Find(query).ToList();
            List<promotion_info> _result = new List<promotion_info>();
            foreach (var _c in _promo_code)
            {
                var promotion_prog_collection = _MongoDB.GetCollection<promotion_code_prog>("promotion_prog_collection");
                var query2 = Query.EQ("promo_prog_id", _c.promo_prog_id);
                List<promotion_code_prog> _prog = promotion_prog_collection.Find(query2).ToList();
                foreach (var _p in _prog)
                {
                    promotion_info _r = new promotion_info();
                    _r.promo_code = _c.promo_code;
                    _r.promo_prog_id = _c.promo_prog_id;
                    _r.owner = _c.owner;
                    _r.status = _c.status;
                    _r.promo_info = _p.promo_info;
                    _r.promo_prog_type = _p.promo_prog_type;
                    _r.promo_title = _p.promo_title;
                    _r.start_date = _p.start_date;
                    _r.end_date = _p.end_date;
                    _r.nobuy_from = _c.nobuy_from;
                    _r.amount = _p.amount;
                    _r.discount_amount = _p.discount_amount;
                    _r.discount_package_id = _p.discount_package_id;
                    _r.discount_package_cat_id1 = _p.discount_package_cat_id1;
                    _r.check_client = _c.check_client;
                    _r.client_cnt_limit = _c.client_cnt_limit;

                    _result.Add(_r);
                }
            }
            return _result;

        }

        public List<promotion_clients> get_promotion_client(string promo_code, string client_id)
        {

            List<promotion_clients> lc = new List<promotion_clients>();

            var promotion_client_collection = _MongoDB.GetCollection<promotion_clients>("promotion_client_collection");
            var query = Query.And(Query.EQ("promo_code", promo_code), Query.EQ("client_id", client_id));
            lc = promotion_client_collection.Find(query).ToList();
            return lc;

        }

        public class client_info
        {
            public string _id;
            public List<purchase_info> purchase_info;
            public List<client_detail> client_details;
        }

        public account_info cache_client_purchase(string client_id, Boolean refresh)
        {
            account_info _cp = new account_info();
            string client_purchase_colname = "account_info";
            var bsm_purchase_collection = _MongoClientInfoDB.GetCollection<account_info>(client_purchase_colname);
            var query = Query.EQ("_id", client_id);

            if (!refresh)
            {
                try
                {
                    _cp = bsm_purchase_collection.FindOne(query);
                }
                catch (Exception e)
                {
                    _cp = cache_client_purchase(client_id, true);
                }
            }

            if (_cp == null || refresh)
            {
                _cp = new account_info();
                _cp._id = client_id;
                _cp.client_id = client_id;
                _cp.last_refresh_time = DateTime.Now;
                _cp.purchases = this.get_purchase_info(client_id, null, null);
                _cp.package_details = this.get_client_detail(client_id, null);
                _cp.services = this.get_catalog_info(client_id, null);
                _cp.credits = this.get_credits_balance(client_id);
                _cp.purchase_dtls = this.get_purchase_info_oracle(client_id);
                try
                {
                    _MongoClientInfoDB.GetCollection<account_info>(client_purchase_colname).Save(_cp);
                }
                catch (Exception e)
                {
                    logger.Info(e.Message);
                }
            }

            return _cp;
        }

        public string cache_all_client_purchase()
        {
            connectDB();

            string _sql = @"SELECT SERIAL_ID FROM BSM_CLIENT_MAS A WHERE A.SERIAL_ID LIKE '2A%' AND ROWNUM<=300000 GROUP BY SERIAL_ID";
            OracleCommand _cmd = new OracleCommand(_sql, conn);
            _cmd.BindByName = true;
            OracleDataReader _rd = _cmd.ExecuteReader();
            string client_purchase_colname = "client_purchase";
            var bsm_purchase_collection = _MongoClientInfoDB.GetCollection<client_info>(client_purchase_colname);
            bsm_purchase_collection.Drop();
            List<client_info> _lc = new List<client_info>();

            while (_rd.Read())
            {

                client_info _cp = new client_info();
                _cp._id = Convert.ToString(_rd["SERIAL_ID"]);
                _lc.Add(_cp);

            }
            foreach (var _a in _lc)
            {
                _a.purchase_info = this.get_purchase_info(_a._id, null, null);
                _a.client_details = this.get_client_detail(_a._id, null);
                bsm_purchase_collection.Save(_a);
            }
            return null;
        }

        public void refresh_client(string client_id)
        {
            this._client_info = cache_client_purchase(client_id, true);
            set_promotion_code(client_id);
        }

        public JsonObject get_acc_info(string client_id, string device_id, string sw_version)
        {
            //      connectDB();

            JsonObject _result = new JsonObject();
            string promotion_result = "";
            string promotion_message = "";

            List<package_info> v_all_package = get_all_package();
            List<purchase_info> v_purchases = new List<purchase_info>();
            account_info v_acc_info = new account_info();
            v_acc_info = this.cache_client_purchase(client_id, false);
            v_purchases = v_acc_info.purchases;
            string _acc = JsonConvert.ExportToString(v_acc_info);
            _result = (JsonObject)JsonConvert.Import(_acc);


            string[] package_cat_ary = { "VOD", "VOD_CHANNEL", "ALL", "CHANNEL", "CHANNEL_ELTA" };

            /*    string[] package_ary = {"WCCH01","CH0001","CH0002","CH0003","CH0004","CH0005","WC0001","W00001",
                                        "W00002","W00003","W00004","W00005","WDC001","WD0001","WD0002","WD0003","WD0004",
                                       "CHELTA01","CHELTA02","CHELTA03","CHELTA04","CHELTA05"}; */

            string[] package_ary_pro13 = { "CHG003", "CHGELTA03", "PPV04", "PPV03", "PPV02", "PPV01" };
            string[] promotions = { "PRO13" };
            //  string[] promotions = { };

            //  string[] package_ary_pro7 = {"XD0001","XD0002","XD0003","XD0003","XD0005","XDC001"};

            Boolean promotion_flg = false;
            Boolean promotion_flg2 = false;
            JsonObject promotion1 = new JsonObject();
            JsonObject promotion2 = new JsonObject();
            string _now = DateTime.Now.ToString("yyyy/MM/dd");

            if (client_id == null)
            {

                promotion_flg = false;
                promotion_result = "F";
                promotion_message = "未有購買資格";
            }
            else
            {
                promotion_flg = false;
                promotion_result = "F";
                promotion_message = "未有購買資格";
                foreach (var _purchase_info in v_purchases)
                    foreach (var _pur_dtl in _purchase_info.details)
                    {
                        if (_pur_dtl.end_date != null && _pur_dtl.end_date.CompareTo(_now) > 0)
                            if (!(package_ary_pro13.Contains<string>(_pur_dtl.package_id)) && _purchase_info.pay_status == 3)
                            {
                                promotion_flg = true;
                                if (_pur_dtl.package_id == "XD0005")
                                {
                                    promotion_flg2 = true;
                                    promotion1 = get_promotion_product("PRO13");
                                }
                                else
                                {
                                    if (promotion_flg2 != true)
                                        promotion1 = get_promotion_product("PRO13");
                                }

                                promotion_result = "";
                                promotion_message = "";

                            }
                    }

                var cnt = 0;

                if (promotion_flg)
                {

                    foreach (var _purchase_info in v_purchases)
                        foreach (var _pur_dtl in _purchase_info.details)
                        {
                            if (promotions.Contains<string>(_pur_dtl.package_id) && _purchase_info.pay_status == 3)
                            {
                                cnt++;

                                /*   if (cnt >= 2)
                                   {

                                       promotion_flg = false;
                                       promotion_result = "A";
                                       promotion_message = "已購買";
                                   } */

                            }
                        }
                }

            }

            _result.Add("promotion", promotion1);
            _result.Add("promotion_result", promotion_result);
            _result.Add("promotion_message", promotion_message);
            _result.Add("promotion_flg", promotion_flg);
            _result.Remove("client_id");
            _result.Add("client_id", client_id);
            // _result.Add("purchase_list", v_result);

            if (client_id != null)
            {
                List<promotion_code> promcodelist = new List<promotion_code>();
                var promotion_code_collection = _MongoDB.GetCollection<promotion_code>("promotion_collection");
                var query = Query.EQ("owner", client_id);
                promcodelist = promotion_code_collection.Find(query).ToList();
                _result.Add("promo_codes", promcodelist);
            }
            return _result;
        }

        public string saveACGClientServiceInfo(string p_client, account_info cp)
        {
            JsonObject acg_client = new JsonObject();
            string _result;
            JsonArray _subs = new JsonArray();
            acg_client.Add("client_id", p_client);
            //   client_info cp = cache_client_purchase(p_client, true);
            foreach (var a in cp.package_details)
            {
                JsonObject _sub = new JsonObject();
                _sub.Add("package_category_id", a.cat_id);
                _sub.Add("package_id", a.package_id);
                _sub.Add("start_date", a.start_date);
                _sub.Add("end_date", a.end_date);
                _sub.Add("expired_date", a.end_date);
                _sub.Add("status", "Y");
                _subs.Add(_sub);
            }
            acg_client.Add("subscriptions", _subs);
            _result = postACG("saveClientServiceInfo", acg_client);

            return _result;
        }

        
        private string postACG(string p_method, JsonObject p_params)
        {

            string _result;
            JsonObject js_rpc = new JsonObject();
            js_rpc.Add("id", "1");
            js_rpc.Add("jsonrpc", "2.0");
            js_rpc.Add("method", p_method);
            js_rpc.Add("params", p_params);
            _result = HttpRequest(acg_url, js_rpc);
            return _result;
        }
        public string HttpRequest(string url, JsonObject postData)
        {
            return HttpRequest(url, postData, 0);
        }
        public string HttpRequest(string url, JsonObject postData,int retry)
        {

            string _result;
            string _post_data = JsonConvert.ExportToString(postData);
            var acg_collection = _MongoClientInfoDB.GetCollection<acg_post_log>("ACG_POST_LOG");
            try
            {
                logger.Info(url+" "+postData);
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                logger.Info(_post_data);

                var jsonBytes = Encoding.ASCII.GetBytes(_post_data);
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var httpWebRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
                httpWebRequest.ProtocolVersion = HttpVersion.Version10;//http1.0
                httpWebRequest.ContentType = "application/json";
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
                acg_post_log acg_log = new acg_post_log();
                try
                {
                    JsonObject j = (JsonObject)JsonConvert.Import(_result);
                    JsonObject j2 = (JsonObject) j["result"];

                    acg_log.status = j2["error_code"].ToString();
                }
                catch (Exception e2)
                {
                    acg_log.status = "F";
                }
                acg_log.eventtime = DateTime.Now;
                acg_log.url = url;
                acg_log.request = _post_data;
                acg_log.result = _result;
                acg_collection.Save(acg_log);


                return _result;
            }
            catch (Exception e)
            {
                logger.Info(e.Message);

                if (retry <= 1)
                {
                    return  HttpRequest(url, postData, retry+1);
                }
                else
                {
                acg_post_log acg_log = new acg_post_log();
                acg_log._id =  new ObjectId();
                acg_log.eventtime = DateTime.Now;
                acg_log.url = url;
                acg_log.request = _post_data;
                acg_log.result = e.Message;
                acg_log.status = "F";
                acg_collection.Save(acg_log);
                }
                return e.Message;
            }
        }
    }
}