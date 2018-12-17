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
using Hinet;

public partial class hinet_payment : System.Web.UI.Page
{
    public string test;
    public string checksum;
    public string version = "3.1";
    public int productid = 273684;
 //  public int productid = 273592; // 測試包月方案
    public string curl = @"http://202.39.39.39/2A.asp"; // 成                       
    public string eurl = @"http://20239.39.39/AuthFail.asp";
    public int fee = 50;
    public string other = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        AAAComponent AAA = new AAAComponent();
        checksum = AAA.Make1AChecksum(version, productid.ToString(), curl, eurl, fee.ToString(), other);
    }
}
