using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Text;
using Hinet;

public partial class hinet_payment : System.Web.UI.Page
{
 
    public string result_code = "";
    public string aa_Alias;
    public string aa_ProductID;
    public string aa_MixCode;
    public string aa_ActionDate;
    public string aa_TotalMonth;
    public string aa_SettingCharge;
    public string aa_InstallCharge;
    public string aa_FirstCharge;
    public string aa_Amount;
    public string aa_Rent;
    public string aa_CheckSum;
    public string aa_ApID;
    public string aa_DiffMsg;
    public string aa_Reserved;

    public class hinet_result
    {
        public string result_code;
        public string subscribeno;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       // string aa_ServerName = "https://aaav2.hinet.net";

        aa_Alias = "hihi"; 
        aa_ProductID = "273592"; ;
        aa_MixCode = Request.Params["aa-otpw"].ToString(); 
        aa_ActionDate="";
        aa_TotalMonth="";
        aa_SettingCharge="";
        aa_InstallCharge="";
        aa_FirstCharge="";
        aa_Amount="";
        aa_Rent="";

        string cl = aa_Alias + aa_ProductID + aa_MixCode + aa_ActionDate + aa_TotalMonth + aa_SettingCharge + aa_InstallCharge + aa_FirstCharge + aa_Amount + aa_Rent;
        string pwd = "";
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] b = md5.ComputeHash(Encoding.ASCII.GetBytes(cl));
        foreach (byte c in b) pwd = pwd + c.ToString("x2");


        aa_CheckSum = pwd;
        aa_ApID="hinet";
        aa_DiffMsg="";
        aa_Reserved="";

/*
        hinet_result hinet_res = new hinet_result();

        AAAComponent AAA = new AAAComponent();
        hinet_res.result_code = AAA.MonthSubscribe(aa_ServerName, aa_Alias, aa_ProductID, aa_ApID, aa_OTPW, aa_Authority, aa_ActionDate, aa_TotalMonth, "");
    //    hinet_res.result_code = hinet.MonthSubscribeEx(aa_ServerName, aa_Alias, aa_ProductID, aa_ApID, aa_OTPW, aa_Authority, aa_ActionDate, aa_TotalMonth, aa_SettingCharge, aa_InstallCharge, aa_FirstCharge, "");
        if (hinet_res.result_code == "Success")
        {
            hinet_res.subscribeno = AAA.GetMonthSubscribeNo();
        }
        result_code = hinet_res.result_code; */
    }
}
