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
    public string test;
    public string checksum;
    public string checksum_curr;
    public string version = "3.1";

    public int productid = 273675; // 測試包月方案

   public string curl = @"http://localhost:1679/BSM_PC_SERVICE/hinet_subscribe.aspx"; // 成                       
    public string eurl = @"http://20239.39.39/AuthFail.asp";
    public int fee = 99;
    public string other = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
         AAAComponent AAA = new AAAComponent();
        string cl = version+productid.ToString()+curl+ eurl+ fee.ToString()+ other;

        string pwd = "";
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] b = md5.ComputeHash(Encoding.ASCII.GetBytes(cl));
        foreach (byte c in b) pwd = pwd + c.ToString("x2");

        checksum = pwd;// AAA.Make1AChecksum(version, productid.ToString(), curl, eurl, fee.ToString(), other);
    }
}
