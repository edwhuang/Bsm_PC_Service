using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.Services;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using Jayrock.JsonRpc;
using Jayrock.JsonRpc.Web;
using Oracle.DataAccess.Client; 
using Oracle.DataAccess.Types;
using Hinet;

using log4net;
using log4net.Config;


/// <summary>
/// HINet_Payment 的摘要描述
/// </summary>
public class HINet_Payment : JsonRpcHandler
{
    static ILog logger;
    string _cht_server_name;
	public HINet_Payment()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
        logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
         _cht_server_name = "https://aaav2.hinet.net";
      //  _cht_server_name = "https://aaatest.hinet.net";
	}

    public class hinet_result
    {
        public string result_code;
        public string subscribeno;
        public string txndatetime;
    }

    [JsonRpcMethod("Authorize")]
    [JsonRpcHelp("訂閱")]
    public hinet_result Authorize(string Alias, string ProductID, string OTPW, string Authority, string Fee)
    {
        string aa_ServerName = _cht_server_name;
        string aa_Alias = Alias;
        string aa_ProductID = ProductID;
        string aa_ApID = Authority;
        string aa_OTPW = OTPW;
        string aa_Authority = Authority;
        string aa_Fee = Fee;

        hinet_result hinet_res = new hinet_result();

        AAAComponent hinet = new AAAComponent();
        hinet_res.result_code = hinet.Authorize(aa_ServerName, aa_OTPW, aa_Fee, aa_ApID, aa_ProductID, aa_Authority);

        logger.Info(JsonConvert.ExportToString(hinet_res));

        if (hinet_res.result_code == "Success")
        {
        }

        return hinet_res;

    }


    [JsonRpcMethod("Accounting")]
    [JsonRpcHelp("r計費")]
    public hinet_result Accounting(string Alias, string ProductID, string OTPW, string Authority, string Fee,string SRemark)
    {
        string aa_ServerName = _cht_server_name;
        string aa_Alias = Alias;
        string aa_ProductID = ProductID;
        string aa_ApID = Authority;
        string aa_OTPW = OTPW;
        string aa_Authority = Authority;
        string aa_Fee = Fee;
        string aa_STime = DateTime.Now.ToString("yyyyMMddHHmmss");
        string aa_SRemark = SRemark;

        hinet_result hinet_res = new hinet_result();

        AAAComponent hinet = new AAAComponent();
        hinet_res.result_code = hinet.Accounting(aa_ServerName, aa_OTPW, aa_Fee, aa_ApID, aa_STime, aa_SRemark, aa_ProductID, aa_Authority);

        logger.Info(JsonConvert.ExportToString(hinet_res));

        if (hinet_res.result_code == "Success")
        {
        }

        return hinet_res;

    }



    [JsonRpcMethod("Subscribe")]
    [JsonRpcHelp("訂閱")]
    public hinet_result Subscribe(string Alias,string ProductID,string OTPW,string Authority, string ActionDate)
    {
        string aa_ServerName = _cht_server_name;
        string aa_Alias = Alias;
        string aa_ProductID = ProductID;
        string aa_ApID = Authority;
        string aa_OTPW = OTPW;
        string aa_Authority = Authority;
        string aa_ActionDate = ActionDate??"";
        string aa_TotalMonth = "";
        string aa_SettingCharge = "";
        string aa_InstallCharge = "";
        string aa_FirstCharge ="";

        hinet_result hinet_res = new hinet_result();

        AAAComponent hinet = new AAAComponent();
        hinet_res.result_code = hinet.MonthSubscribeEx(aa_ServerName, aa_Alias, aa_ProductID, aa_ApID, aa_OTPW, aa_Authority, aa_ActionDate, aa_TotalMonth,aa_SettingCharge,aa_InstallCharge,aa_FirstCharge, "");
        if (hinet_res.result_code == "Success")
        {
             hinet_res.subscribeno = hinet.GetMonthSubscribeNo();
        }

        logger.Info(JsonConvert.ExportToString(hinet_res));

        return hinet_res;
    }

    [JsonRpcMethod("Authorization")]
    [JsonRpcHelp("訂閱")]
    public hinet_result Authorization(string Alias, string ProductID, string OTPW, string Authority,string Fee)
    {
        string aa_ServerName = _cht_server_name;
        string aa_Alias = Alias;
        string aa_ProductID = ProductID;
        string aa_ApID = Authority;
        string aa_OTPW = OTPW;
        string aa_Authority = Authority;
        string aa_ActionDate = "";
        string aa_TotalMonth = "";
        string aa_SettingCharge = "";
        string aa_InstallCharge = "";
        string aa_FirstCharge = "";
        string aa_Fee = Fee;

        hinet_result hinet_res = new hinet_result();

        AAAComponent hinet = new AAAComponent();
        hinet_res.result_code = hinet.Authorize(aa_ServerName, aa_OTPW, aa_Fee, aa_ApID, aa_ProductID, aa_Authority);

        if (hinet_res.result_code == "Success")
        {
       //     hinet_res.subscribeno = hinet.GetMonthSubscribeNo();
        }

        logger.Info(JsonConvert.ExportToString(hinet_res));
        return hinet_res;
    }


    [JsonRpcMethod("UnSubscribe")]
    [JsonRpcHelp("訂閱")]
    public hinet_result UnSubscribe(string Alias,string SubscribeNo, string ProductID,  string ApID,string ActionDate)
    {
        string aa_ServerName = _cht_server_name;
        string aa_Alias = Alias;
        string aa_ProductID = ProductID;
        string aa_ApID = ApID;
        string aa_SubscribeNo = SubscribeNo;
        string aa_ActionDate = ActionDate;

        hinet_result hinet_res = new hinet_result();

        AAAComponent hinet = new AAAComponent();
        hinet_res.result_code = hinet.MonthUnSubscribe(aa_ServerName, aa_Alias, aa_SubscribeNo, aa_ProductID,aa_ApID, aa_ActionDate,"");
        if (hinet_res.result_code == "Success")
        {
            hinet_res.subscribeno = hinet.GetMonthSubscribeNo();
        }

        logger.Info(JsonConvert.ExportToString(hinet_res));

        return hinet_res;
    }

    [JsonRpcMethod("QuerySubscribe")]
    [JsonRpcHelp("訂閱")]
    public hinet_result QuerySubscribe(string Alias, string SubscribeNo, string ProductID, string ApID)
    {
        string aa_ServerName = _cht_server_name;
        string aa_Alias = Alias;
        string aa_ProductID = ProductID;
        string aa_ApID = ApID;
        string aa_SubscribeNo = SubscribeNo;

        hinet_result hinet_res = new hinet_result();

        AAAComponent hinet = new AAAComponent();
        hinet_res.result_code = hinet.MonthQuery(aa_ServerName, aa_Alias, aa_SubscribeNo, aa_ProductID, aa_ApID, "");


        logger.Info(JsonConvert.ExportToString(hinet_res));
        return hinet_res;
    }

    [JsonRpcMethod("QueryATM")]
    [JsonRpcHelp("QueryATM")]
    public hinet_result QueryATM(string aa_OTPW)
    {
        string aa_ServerName = _cht_server_name;

        hinet_result hinet_res = new hinet_result();

        AAAComponent hinet = new AAAComponent();
        hinet_res.result_code = hinet.ATMQuery(aa_ServerName, aa_OTPW);
        hinet_res.txndatetime = hinet.GetTxntime();

        logger.Info(JsonConvert.ExportToString(hinet_res));
        return hinet_res;
    }

    [JsonRpcMethod("RevokeCredit")]
    [JsonRpcHelp("RevokeCredit")]
    public hinet_result RevokeCredit(string aa_OTPW)
    {
        string aa_ServerName = _cht_server_name;

        hinet_result hinet_res = new hinet_result();

        AAAComponent hinet = new AAAComponent();
        hinet_res.result_code = hinet.CreditRevoke(aa_ServerName, aa_OTPW);
       // hinet_res.txndatetime = hinet.GetTxntime();

        logger.Info(JsonConvert.ExportToString(hinet_res));
        return hinet_res;
    }

    [JsonRpcMethod("ATMMultiplebills")]
    [JsonRpcHelp("ATMMultiplebills")]
    public hinet_result ATMMultiplebills(string aa_OTPW, string Multiplebills)
    {
        string aa_ServerName = _cht_server_name;

        hinet_result hinet_res = new hinet_result();

        AAAComponent hinet = new AAAComponent();
        hinet_res.result_code = hinet.ATMMultiplebills(aa_ServerName, aa_OTPW, Multiplebills);
        // hinet_res.txndatetime = hinet.GetTxntime();

        logger.Info(JsonConvert.ExportToString(hinet_res));
        return hinet_res;
    }


    [JsonRpcMethod("MonthlyTransferAuth")]
    [JsonRpcHelp("重新訂閱")]
    public hinet_result MonthlyTransferAuth( string aa_ProductID, string aa_Fee, string aa_others, string aa_authinfo, string aa_defaultpay)
    {
        string aa_ServerName = _cht_server_name;

        hinet_result hinet_res = new hinet_result();

        AAAComponent hinet = new AAAComponent();
        hinet_res.result_code = hinet.MonthlyTransferAuth(aa_ServerName,aa_ProductID,aa_Fee,aa_others,aa_authinfo,aa_defaultpay);

        if (hinet_res.result_code == "Success")
        {
            //     hinet_res.subscribeno = hinet.GetMonthSubscribeNo();
        }

        logger.Info(JsonConvert.ExportToString(hinet_res));
        return hinet_res;
    }





    public override void ProcessRequest(HttpContext context)
    {

        long pos = context.Request.InputStream.Position;

        var read = new StreamReader(context.Request.InputStream);
        string jsontstr = read.ReadToEnd();
        context.Request.InputStream.Position = pos;
        logger.Info(jsontstr);

        base.ProcessRequest(context);


    }
}
