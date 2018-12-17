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
using BSM;
using BsmDatabaseObjects;
using BSM_Info;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

using log4net;
using log4net.Config;

public class promo_coupon
{
    public string _id;
    public string coupon_id;
    public string account_key;
    public Boolean booking_flg;
    public DateTime booking_date;
}

public class bank_credit
{
    public string _id; 
    public string credit_no;
    public string bank_code;
}


/// <summary>
/// bsm_pc_api :
///   WEB API
/// </summary>
/// 
/// 
/// 

namespace BSMPCService
{

    public class bsm_pc_api : JsonRpcHandler
    {
        static ILog logger;
        private string PrimaryMongoDBConnectString;
        private string PrimaryMongoDB_Database;
        private string ReadMongoDBConnectString;
        private MongoClient ReadMongoclient;
        private MongoServer ReadMongoServer;
        private MongoDatabase ReadMongoDB;
        public bsm_pc_api()
        {
            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            System.Configuration.ConnectionStringSettings connString;
            if (0 < rootWebConfig.ConnectionStrings.ConnectionStrings.Count)
            {
                PrimaryMongoDBConnectString = rootWebConfig.ConnectionStrings.ConnectionStrings["APIPrimaryMongoDb"].ToString();
                PrimaryMongoDB_Database = rootWebConfig.ConnectionStrings.ConnectionStrings["APIPrimaryMongoDb_Database"].ToString();
                ReadMongoDBConnectString = rootWebConfig.ConnectionStrings.ConnectionStrings["MongoDb"].ToString();
                String DBName = "PCDB";
                ReadMongoclient = new MongoClient(ReadMongoDBConnectString);
                ReadMongoServer = ReadMongoclient.GetServer();
                ReadMongoDB = ReadMongoServer.GetDatabase(PrimaryMongoDB_Database + DBName);
            }
        }


        [JsonRpcMethod("create_dev_data")]
        public promo_coupon create_dev_data(string promotions_project, string account_key)
        {
            promo_coupon _result = new promo_coupon();
            MongoClient _MongoclientMaster;
            MongoServer _MongoServerMaster;
            MongoDatabase _MongoDBMaster;
            String DBName = "PCDB";
            String CouponCollectionName = "promo_coupons";
            _MongoclientMaster = new MongoClient(PrimaryMongoDBConnectString);
            _MongoServerMaster = _MongoclientMaster.GetServer();
            _MongoDBMaster = _MongoServerMaster.GetDatabase(PrimaryMongoDB_Database + DBName);

            MongoCollection<promo_coupon> promo_coupon_collection = _MongoDBMaster.GetCollection<promo_coupon>(CouponCollectionName);

            promo_coupon _t1 = new promo_coupon();
            _t1._id = "1321321312312";
            _t1.coupon_id = "321321312312";
            _t1.booking_flg = false;

            promo_coupon_collection.Save(_t1);
            
   

            return null;
        }


        [JsonRpcMethod("booking_coupon")]
        [JsonRpcHelp("促銷用取得兌換券(輸入promotions_project與account_key (每個account_key 僅能取得一個號碼)")]
        public JsonObject booking_coupons(string promotions_project, string account_key)
        {
            JsonObject _result = new JsonObject();
            MongoClient _MongoclientMaster;
            MongoServer _MongoServerMaster;
            MongoDatabase _MongoDBMaster;
            String DBName = "PCDB";
            String CouponCollectionName = "promo_coupons";
            _MongoclientMaster = new MongoClient(PrimaryMongoDBConnectString);
            _MongoServerMaster = _MongoclientMaster.GetServer();
            _MongoDBMaster = _MongoServerMaster.GetDatabase(PrimaryMongoDB_Database + DBName);

            MongoCollection<promo_coupon> promo_coupon_collection = _MongoDBMaster.GetCollection<promo_coupon>(CouponCollectionName);
            var query = Query.EQ("account_key", account_key);
            promo_coupon _promo_coupon = promo_coupon_collection.FindOne(query);
            if (_promo_coupon == null)
            {
                DateTime _now = DateTime.Now;
                var _query = Query.EQ("booking_flg", false);
                _promo_coupon = promo_coupon_collection.FindOne(_query);
                if (_promo_coupon != null)
                {
                    _promo_coupon.account_key = account_key;
                    _promo_coupon.booking_flg = true;
                    _promo_coupon.booking_date = DateTime.Now;

                    _result.Add("result_code", "BSM-00000");
                    _result.Add("coupon_id", _promo_coupon.coupon_id);
                    _result.Add("account_key", _promo_coupon.account_key);
                    _result.Add("booking_date", _promo_coupon.booking_flg);
                    promo_coupon_collection.Save(_promo_coupon);
                }
                else
                {
                    _result.Add("result_code","BSM-00630");
                    _result.Add("result_message","無Coupon");
                }

                


            }
            else
            {
                _result.Add("result_code", "BSM-00000");
                _result.Add("coupon_id", _promo_coupon.coupon_id);
                _result.Add("account_key", _promo_coupon.account_key);
                _result.Add("booking_date", _promo_coupon.booking_flg);
            }

            return _result;
        }

        [JsonRpcMethod("get_bank_creditno")]
        [JsonRpcHelp("取得銀行信用卡前六碼列表,輸入bank_code :TAISHI 台新,CTBCBANK 中國信託")]
        public List<bank_credit>  get_bank_creditno(string bank_code)
        {
            JsonArray _result = new JsonArray();
            MongoCollection<bank_credit> _bank_credit_col = ReadMongoDB.GetCollection<bank_credit>("bank_credit");
            var qry = Query.EQ("bank_code", bank_code);
            List<bank_credit> _rs = _bank_credit_col.Find(qry).ToList();
            return _rs;

        }

    }
}
