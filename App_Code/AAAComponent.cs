using System;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


namespace Hinet
{
    public class TimeoutWebClient : WebClient
    {
        public int Timeout { get; set; }

        public TimeoutWebClient()
        {
            Timeout = 180000;
        }

        public TimeoutWebClient(int timeout)
        {
            Timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            request.Timeout = Timeout;
            return request;
        }
    } 

    public class AAAComponent : iTest
    {
        // 設定 HTTPS 連線時，不要理會憑證的有效性問題
        public static bool ValidateServerCertificate(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        private static string VERSION;

        private DomParser xml;

        private string m_DiffMsg = "";

        private static BitArray dontEncoding;

        static AAAComponent()
        {
            int i;
            AAAComponent.VERSION = "ASPNET 1.3";
            AAAComponent.dontEncoding = new BitArray(125, false);
            for (i = 48; i <= 57; i++)
            {
                AAAComponent.dontEncoding.Set(i, true);
            }
            for (i = 65; i <= 90; i++)
            {
                AAAComponent.dontEncoding.Set(i, true);
            }
            for (i = 97; i <= 122; i++)
            {
                AAAComponent.dontEncoding.Set(i, true);
            }
            AAAComponent.dontEncoding.Set(42, true);
            AAAComponent.dontEncoding.Set(45, true);
            AAAComponent.dontEncoding.Set(46, true);
            AAAComponent.dontEncoding.Set(95, true);
        }

        public AAAComponent()
        {
        }

        private static void AAALog(string funcName, string args, string result)
        {
            string str = "C:\\HinetLog\\";
            try
            {
                if (!Directory.Exists(str))
                {
                    Directory.CreateDirectory(str);
                }
                DateTime now = DateTime.Now;
                DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
                dateTimeFormatInfo.MonthDayPattern="yyyyMMdd";
                dateTimeFormatInfo.LongTimePattern="yyyy-MM-dd HH:mm:ss";
                string str1 = string.Concat(str, "ASPNET_AAA", now.ToString("m", dateTimeFormatInfo), ".log");
           //     FileStream fileStream = new FileStream(str1,FileMode.OpenOrCreate,FileAccess.ReadWrite,);
                StreamWriter streamWriter = new StreamWriter(str1, true);
                string[] vERSION = new string[] { "[Version ", AAAComponent.VERSION, "][", now.ToString("T", dateTimeFormatInfo), "][", funcName, "][Arguments]", args, "[Response]", result };
                streamWriter.WriteLine(string.Concat(vERSION));
                streamWriter.Close();
               // streamWriter.Flush();
             //   fileStream.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
        }

        public string Accounting(string aa_ServerName, string aa_OTPW, string aa_Fee, string aa_ApID, string aa_STime, string aa_SRemark, string aa_ProductID, string aa_Authority)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat(str, "<aa_OTPW=\"", aa_OTPW, "\">");
            str = string.Concat(str, "<aa_Fee=\"", aa_Fee, "\">");
            str = string.Concat(str, "<aa_ApID=\"", aa_ApID, "\">");
            str = string.Concat(str, "<aa_STime=\"", aa_STime, "\">");
            str = string.Concat(str, "<aa_SRemark=\"", aa_SRemark, "\">");
            str = string.Concat(str, "<aa_ProductID=\"", aa_ProductID, "\">");
            str = string.Concat(str, "<aa_Authority=\"", aa_Authority, "\">");
            if (aa_ServerName.Length == 0 || aa_OTPW.Length == 0 || aa_Fee.Length == 0 || aa_ApID.Length == 0 || aa_STime.Length == 0 || aa_SRemark.Length == 0 || aa_ProductID.Length == 0)
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                string str1 = string.Concat(AAAComponent.MyUrlEncode("aa-otpw"), "=", AAAComponent.MyUrlEncode(aa_OTPW));
                string str2 = str1;
                string[] strArray = new string[] { str2, "&", AAAComponent.MyUrlEncode("aa-fee"), "=", AAAComponent.MyUrlEncode(aa_Fee) };
                str1 = string.Concat(strArray);
                string str3 = str1;
                string[] strArray1 = new string[] { str3, "&", AAAComponent.MyUrlEncode("aa-apid"), "=", AAAComponent.MyUrlEncode(aa_ApID) };
                str1 = string.Concat(strArray1);
                string str4 = str1;
                string[] strArray2 = new string[] { str4, "&", AAAComponent.MyUrlEncode("aa-stime"), "=", AAAComponent.MyUrlEncode(aa_STime) };
                str1 = string.Concat(strArray2);
                string str5 = str1;
                string[] strArray3 = new string[] { str5, "&", AAAComponent.MyUrlEncode("aa-sremark"), "=", AAAComponent.MyUrlEncode(aa_SRemark) };
                str1 = string.Concat(strArray3);
                string str6 = str1;
                string[] strArray4 = new string[] { str6, "&", AAAComponent.MyUrlEncode("aa-productid"), "=", AAAComponent.MyUrlEncode(aa_ProductID) };
                str1 = string.Concat(strArray4);
                string str7 = null;
                if (aa_Authority.Length != 0)
                {
                    string lower = aa_Authority.ToLower();
                    lower = string.Concat(lower.Substring(0, 1).ToUpper(), lower.Substring(1));
                    str7 = string.Concat(aa_ServerName, "/", lower, "A3/Accounting");
                }
                else
                {
                    str7 = string.Concat(aa_ServerName, "/A3/Accounting");
                }
                string str8 = AAAComponent.BuildConnection(str7, str1);
                AAAComponent.AAALog("Accounting", str, str8);
                try
                {
                    this.xml = new DomParser(str8);
                    resultCode = this.GetResultCode();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                    resultCode = "c004";
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }

        public string AddDiffItem(string ItemName)
        {
            string str;
            if (ItemName.Length != 0)
            {
                if (this.m_DiffMsg.Length == 0)
                {
                    this.m_DiffMsg = "<?xml version=\"1.0\" encoding=\"UTF-8\"?> <Message>";
                }
                AAAComponent aAAComponent = this;
                aAAComponent.m_DiffMsg = string.Concat(aAAComponent.m_DiffMsg, "<DiffMsg>", ItemName, "</DiffMsg>");
                str = "Success";
            }
            else
            {
                str = "c001";
            }
            return str;
        }

        public string APAuthenticate(string aa_ServerName, string aa_OTPW, string aa_Fee, string aa_ApID, string aa_ProductID, string aa_Authority)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat(str, "<aa_OTPW=\"", aa_OTPW, "\">");
            str = string.Concat(str, "<aa_Fee=\"", aa_Fee, "\">");
            str = string.Concat(str, "<aa_ApID=\"", aa_ApID, "\">");
            str = string.Concat(str, "<aa_ProductID=\"", aa_ProductID, "\">");
            str = string.Concat(str, "<aa_Authority=\"", aa_Authority, "\">");
            if (aa_ServerName.Length == 0 || aa_OTPW.Length == 0 || aa_Fee.Length == 0 || aa_ApID.Length == 0 || aa_ProductID.Length == 0)
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                string str1 = string.Concat(AAAComponent.MyUrlEncode("aa-otpw"), "=", AAAComponent.MyUrlEncode(aa_OTPW));
                string str2 = str1;
                string[] strArray = new string[] { str2, "&", AAAComponent.MyUrlEncode("aa-fee"), "=", AAAComponent.MyUrlEncode(aa_Fee) };
                string str3 = string.Concat(strArray);
                string[] strArray1 = new string[] { str3, "&", AAAComponent.MyUrlEncode("aa-apid"), "=", AAAComponent.MyUrlEncode(aa_ApID) };
                string str4 = string.Concat(strArray1);
                string[] strArray2 = new string[] { str4, "&", AAAComponent.MyUrlEncode("aa-productid"), "=", AAAComponent.MyUrlEncode(aa_ProductID) };
                str1 = string.Concat(strArray2);
                string str5 = string.Concat(aa_ServerName, "/A1/APA1");
                string str6 = AAAComponent.BuildConnection(str5, str1);
                AAAComponent.AAALog("APAuthenticate", str, str6);
                try
                {
                    this.xml = new DomParser(str6);
                    resultCode = this.GetResultCode();
                }
                catch (Exception exception)
                {
                    resultCode = "c004";
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }

        public string Authorize(string aa_ServerName, string aa_OTPW, string aa_Fee, string aa_ApID, string aa_ProductID, string aa_Authority)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat(str, "<aa_OTPW=\"", aa_OTPW, "\">");
            str = string.Concat(str, "<aa_Fee=\"", aa_Fee, "\">");
            str = string.Concat(str, "<aa_ApID=\"", aa_ApID, "\">");
            str = string.Concat(str, "<aa_ProductID=\"", aa_ProductID, "\">");
            str = string.Concat(str, "<aa_Authority=\"", aa_Authority, "\">");
            if (aa_ServerName.Length == 0 || aa_OTPW.Length == 0 || aa_Fee.Length == 0 || aa_ApID.Length == 0 || aa_ProductID.Length == 0)
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                string str1 = string.Concat(AAAComponent.MyUrlEncode("aa-otpw"), "=", AAAComponent.MyUrlEncode(aa_OTPW));
                string str2 = str1;
                string[] strArray = new string[] { str2, "&", AAAComponent.MyUrlEncode("aa-fee"), "=", AAAComponent.MyUrlEncode(aa_Fee) };
                str1 = string.Concat(strArray);
                string str3 = str1;
                string[] strArray1 = new string[] { str3, "&", AAAComponent.MyUrlEncode("aa-apid"), "=", AAAComponent.MyUrlEncode(aa_ApID) };
                str1 = string.Concat(strArray1);
                string str4 = str1;
                string[] strArray2 = new string[] { str4, "&", AAAComponent.MyUrlEncode("aa-productid"), "=", AAAComponent.MyUrlEncode(aa_ProductID) };
                str1 = string.Concat(strArray2);
                string str5 = null;
                if (aa_Authority.Length != 0)
                {
                    string lower = aa_Authority.ToLower();
                    lower = string.Concat(lower.Substring(0, 1).ToUpper(), lower.Substring(1));
                    str5 = string.Concat(aa_ServerName, "/", lower, "A2/Authorization");
                }
                else
                {
                    str5 = string.Concat(aa_ServerName, "/A2/Authorization");
                }
                string str6 = AAAComponent.BuildConnection(str5, str1);
                AAAComponent.AAALog("Authorize", str, str6);
                try
                {
                    this.xml = new DomParser(str6);
                    resultCode = this.GetResultCode();
                }
                catch (Exception exception)
                {
                    AAAComponent.AAALog("Authorize", str, exception.ToString());
                    resultCode = "c004";
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }

        private static string BuildConnection(string url, string args)
        {
            string str;
            string str1 = "";
            try
            {
                // 設定 HTTPS 連線時，不要理會憑證的有效性問題
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                TimeoutWebClient webClient = new TimeoutWebClient(30000);
                ServicePointManager.DefaultConnectionLimit = 256;
                WebRequest.DefaultWebProxy = null;
                webClient.Proxy = GlobalProxySelection.GetEmptyWebProxy();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                
                byte[] bytes = Encoding.ASCII.GetBytes(args);
                byte[] numArray = webClient.UploadData(url, "POST", bytes);
                str1 = Encoding.GetEncoding("big5").GetString(numArray);
            }
            catch (Exception exception)
            {
                str = exception.ToString();
                return str;
            }
            str = (str1.Length != 0 ? str1.TrimEnd(new char[0]) : "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Result><response-code>c016</response-code><response-message>Connection Error</response-message></Result>");
            return str;
        }

        private static string BuildConnection(string url, string args,string encode_name)
        {
            string str;
            string str1 = "";
            try
            {
                // 設定 HTTPS 連線時，不要理會憑證的有效性問題
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                TimeoutWebClient webClient = new TimeoutWebClient(30000);
                ServicePointManager.DefaultConnectionLimit = 256;
                WebRequest.DefaultWebProxy = null;
                webClient.Proxy = GlobalProxySelection.GetEmptyWebProxy();
                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                byte[] bytes = Encoding.ASCII.GetBytes(args);
                byte[] numArray = webClient.UploadData(url, "POST", bytes);
                str1 = Encoding.GetEncoding(encode_name).GetString(numArray);
            }
            catch (Exception exception)
            {
                str = exception.ToString();
                return str;
            }
            str = (str1.Length != 0 ? str1.TrimEnd(new char[0]) : "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Result><response-code>c016</response-code><response-message>Connection Error</response-message></Result>");
            return str;
        }

        public string GetCurTime()
        {
            DateTime now = DateTime.Now;
            DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
            dateTimeFormatInfo.LongTimePattern="yyyyMMddHHmmss";
            return now.ToString("T", dateTimeFormatInfo);
        }

        private string GetErrDesc()
        {
            string str;
            str = (this.xml == null ? "c005" : this.xml.GetErrDesc());
            return str;
        }

        public string GetMonthSubscribeNo()
        {
            string str;
            str = (this.xml == null ? "c005" : this.xml.GetSubscribeNo());
            return str;
        }

        public string GetMonthSubscribeNoEx(string Item)
        {
            string str;
            if (Item.Length != 0)
            {
                str = (this.xml == null ? "c005" : this.xml.GetMonthSubscribeNoEx(Item));
            }
            else
            {
                str = "c001";
            }
            return str;
        }

        public string GetMonthSubscribePolicyEx(string Item, string attrib)
        {
            string str;
            if (Item.Length == 0 || attrib.Length == 0)
            {
                str = "c001";
            }
            else
            {
                str = (this.xml == null ? "c005" : this.xml.GetMonthSubscribePolicyEx(Item, attrib));
            }
            return str;
        }

        public string GetOTPW()
        {
            string str;
            str = (this.xml == null ? "c005" : this.xml.GetOTPW());
            return str;
        }

        public string GetPolicy(string attrib)
        {
            string str;
            if (attrib.Length != 0)
            {
                str = (this.xml == null ? "c005" : this.xml.GetPolicy(attrib, null));
            }
            else
            {
                str = "c001";
            }
            return str;
        }

        private string GetResultCode()
        {
            string str;
            str = (this.xml == null ? "c005" : this.xml.GetResultCode());
            return str;
        }

        public string HinetMemberQuerySubscribe(string aa_ServerName, string aa_ProductID, string aa_OTPW, string aa_TotalMonth, string aa_Reserved)
        {
            string str = this.HinetMemberQuerySubscribeEx(aa_ServerName, aa_ProductID, aa_OTPW, aa_TotalMonth, "", "", "", aa_Reserved);
            return str;
        }

        public string HinetMemberQuerySubscribeEx(string aa_ServerName, string aa_ProductID, string aa_OTPW, string aa_TotalMonth, string aa_SettingCharge, string aa_InstallCharge, string aa_FirstCharge, string aa_Reserved)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat(str, "<aa_ProductID=\"", aa_ProductID, "\">");
            str = string.Concat(str, "<aa_OTPW=\"", aa_OTPW, "\">");
            str = string.Concat(str, "<aa_TotalMonth=\"", aa_TotalMonth, "\">");
            str = string.Concat(str, "<aa_SettingCharge=\"", aa_SettingCharge, "\">");
            str = string.Concat(str, "<aa_InstallCharge=\"", aa_InstallCharge, "\">");
            str = string.Concat(str, "<aa_FirstCharge=\"", aa_FirstCharge, "\">");
            str = string.Concat(str, "<aa_Reserved=\"", aa_Reserved, "\">");
            if (aa_ServerName.Length == 0 || aa_ProductID.Length == 0 || aa_OTPW.Length == 0)
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                string str1 = string.Concat(aa_ProductID, aa_OTPW);
                if (aa_TotalMonth.Length != 0)
                {
                    str1 = string.Concat(str1, aa_TotalMonth);
                }
                if (aa_SettingCharge.Length != 0)
                {
                    str1 = string.Concat(str1, aa_SettingCharge);
                }
                if (aa_InstallCharge.Length != 0)
                {
                    str1 = string.Concat(str1, aa_InstallCharge);
                }
                if (aa_FirstCharge.Length != 0)
                {
                    str1 = string.Concat(str1, aa_FirstCharge);
                }
                string str2 = AAAComponent.MD5(str1);
                string str3 = string.Concat(AAAComponent.MyUrlEncode("ProductID"), "=", AAAComponent.MyUrlEncode(aa_ProductID));
                string str4 = str3;
                string[] strArray = new string[] { str4, "&", AAAComponent.MyUrlEncode("MixCode"), "=", AAAComponent.MyUrlEncode(aa_OTPW) };
                string str5 = string.Concat(strArray);
                string[] strArray1 = new string[] { str5, "&", AAAComponent.MyUrlEncode("TotalMonth"), "=", AAAComponent.MyUrlEncode(aa_TotalMonth) };
                string str6 = string.Concat(strArray1);
                string[] strArray2 = new string[] { str6, "&", AAAComponent.MyUrlEncode("SettingCharge"), "=", AAAComponent.MyUrlEncode(aa_SettingCharge) };
                string str7 = string.Concat(strArray2);
                string[] strArray3 = new string[] { str7, "&", AAAComponent.MyUrlEncode("InstallCharge"), "=", AAAComponent.MyUrlEncode(aa_InstallCharge) };
                string str8 = string.Concat(strArray3);
                string[] strArray4 = new string[] { str8, "&", AAAComponent.MyUrlEncode("FirstCharge"), "=", AAAComponent.MyUrlEncode(aa_FirstCharge) };
                string str9 = string.Concat(strArray4);
                string[] strArray5 = new string[] { str9, "&", AAAComponent.MyUrlEncode("CheckSum"), "=", AAAComponent.MyUrlEncode(str2) };
                string str10 = string.Concat(strArray5);
                string[] strArray6 = new string[] { str10, "&", AAAComponent.MyUrlEncode("Reserved"), "=", AAAComponent.MyUrlEncode(aa_Reserved) };
                str3 = string.Concat(strArray6);
                string str11 = string.Concat(aa_ServerName, "/HinetNoMember/QuerySubscribe");
                string str12 = AAAComponent.BuildConnection(str11, str3);
                AAAComponent.AAALog("HinetMemberQuerySubscribeEx", str, str12);
                try
                {
                    this.xml = new DomParser(str12);
                    resultCode = this.GetResultCode();
                }
                catch (Exception exception)
                {
                    resultCode = "c004";
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }

        public string HinetMemberUnSubscribe(string aa_ServerName, string aa_ProductID, string aa_OTPW, string aa_ActionDate, string aa_Reserved)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat(str, "<aa_ProductID=\"", aa_ProductID, "\">");
            str = string.Concat(str, "<aa_OTPW=\"", aa_OTPW, "\">");
            str = string.Concat(str, "<aa_ActionDate=\"", aa_ActionDate, "\">");
            str = string.Concat(str, "<aa_Reserved=\"", aa_Reserved, "\">");
            if (aa_ServerName.Length == 0 || aa_ProductID.Length == 0 || aa_OTPW.Length == 0)
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                string str1 = string.Concat(aa_ProductID, aa_OTPW);
                if (aa_ActionDate.Length != 0)
                {
                    str1 = string.Concat(str1, aa_ActionDate);
                }
                string str2 = AAAComponent.MD5(str1);
                string str3 = string.Concat(AAAComponent.MyUrlEncode("ProductID"), "=", AAAComponent.MyUrlEncode(aa_ProductID));
                string str4 = str3;
                string[] strArray = new string[] { str4, "&", AAAComponent.MyUrlEncode("MixCode"), "=", AAAComponent.MyUrlEncode(aa_OTPW) };
                string str5 = string.Concat(strArray);
                string[] strArray1 = new string[] { str5, "&", AAAComponent.MyUrlEncode("ActionDate"), "=", AAAComponent.MyUrlEncode(aa_ActionDate) };
                string str6 = string.Concat(strArray1);
                string[] strArray2 = new string[] { str6, "&", AAAComponent.MyUrlEncode("CheckSum"), "=", AAAComponent.MyUrlEncode(str2) };
                string str7 = string.Concat(strArray2);
                string[] strArray3 = new string[] { str7, "&", AAAComponent.MyUrlEncode("Reserved"), "=", AAAComponent.MyUrlEncode(aa_Reserved) };
                str3 = string.Concat(strArray3);
                string str8 = string.Concat(aa_ServerName, "/HinetNoMember/Unsubscribe");
                string str9 = AAAComponent.BuildConnection(str8, str3);
                AAAComponent.AAALog("HinetMemberUnSubscribe", str, str9);
                try
                {
                    this.xml = new DomParser(str9);
                    resultCode = this.GetResultCode();
                }
                catch (Exception exception)
                {
                    resultCode = "c004";
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }

        public string Make1AChecksum(string aa_Version, string aa_ProductID, string aa_curl, string aa_eurl, string aa_Fee, string aa_others)
        {
            string[] aaVersion = new string[] { aa_Version, aa_ProductID, aa_curl, aa_eurl, aa_Fee, aa_others };
            return AAAComponent.MD5(string.Concat(aaVersion));
        }

        private static string MD5(string input)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(input);
            byte[] numArray = (new MD5CryptoServiceProvider()).ComputeHash(bytes);
            string str = "";
            byte[] numArray1 = numArray;
            for (int i = 0; i < (int)numArray1.Length; i++)
            {
                byte num = numArray1[i];
                str = string.Concat(str, num.ToString("x2"));
            }
            return str;
        }

        public string MMAXGetResult(string Name)
        {
            string str;
            str = (this.xml == null ? "c005" : this.xml.MMAXGetResult(Name));
            return str;
        }

        public string MMAXMbrQuery(string aa_ServerName, string aa_ProductID, string aa_MbrOTPW, string aa_Alias)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat(str, "<aa_ProductID=\"", aa_ProductID, "\">");
            str = string.Concat(str, "<aa_MbrOTPW=\"", aa_MbrOTPW, "\">");
            str = string.Concat(str, "<aa_Alias=\"", aa_Alias, "\">");
            if (aa_ServerName.Length == 0 || aa_Alias.Length == 0 || aa_ProductID.Length == 0 || aa_MbrOTPW.Length == 0)
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                string str1 = string.Concat(aa_Alias, aa_ProductID, aa_MbrOTPW);
                string str2 = AAAComponent.MD5(str1);
                string str3 = string.Concat(AAAComponent.MyUrlEncode("ProductID"), "=", AAAComponent.MyUrlEncode(aa_ProductID));
                string str4 = str3;
                string[] strArray = new string[] { str4, "&", AAAComponent.MyUrlEncode("MbrOTPW"), "=", AAAComponent.MyUrlEncode(aa_MbrOTPW) };
                string str5 = string.Concat(strArray);
                string[] strArray1 = new string[] { str5, "&", AAAComponent.MyUrlEncode("Alias"), "=", AAAComponent.MyUrlEncode(aa_Alias) };
                string str6 = string.Concat(strArray1);
                string[] strArray2 = new string[] { str6, "&", AAAComponent.MyUrlEncode("CheckSum"), "=", AAAComponent.MyUrlEncode(str2) };
                str3 = string.Concat(strArray2);
                string str7 = string.Concat(aa_ServerName, "/Member/MMAQuery");
                string str8 = AAAComponent.BuildConnection(str7, str3);
                AAAComponent.AAALog("MMAXMbrQuery", str, str8);
                try
                {
                    this.xml = new DomParser(str8);
                    resultCode = this.GetResultCode();
                }
                catch (Exception exception)
                {
                    resultCode = "c004";
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }

        public string MMAXQuery(string aa_ServerName, string aa_ProductID, string aa_UserID, string aa_Alias)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat(str, "<aa_ProductID=\"", aa_ProductID, "\">");
            str = string.Concat(str, "<aa_UserID=\"", aa_UserID, "\">");
            str = string.Concat(str, "<aa_Alias=\"", aa_Alias, "\">");
            if (aa_ServerName.Length == 0 || aa_Alias.Length == 0 || aa_ProductID.Length == 0 || aa_UserID.Length == 0)
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                string str1 = string.Concat(aa_Alias, aa_UserID, aa_ProductID);
                string str2 = AAAComponent.MD5(str1);
                string str3 = string.Concat(AAAComponent.MyUrlEncode("ProductID"), "=", AAAComponent.MyUrlEncode(aa_ProductID));
                string str4 = str3;
                string[] strArray = new string[] { str4, "&", AAAComponent.MyUrlEncode("UserID"), "=", AAAComponent.MyUrlEncode(aa_UserID) };
                string str5 = string.Concat(strArray);
                string[] strArray1 = new string[] { str5, "&", AAAComponent.MyUrlEncode("Alias"), "=", AAAComponent.MyUrlEncode(aa_Alias) };
                string str6 = string.Concat(strArray1);
                string[] strArray2 = new string[] { str6, "&", AAAComponent.MyUrlEncode("CheckSum"), "=", AAAComponent.MyUrlEncode(str2) };
                str3 = string.Concat(strArray2);
                string str7 = string.Concat(aa_ServerName, "/Member/MMAQuery");
                string str8 = AAAComponent.BuildConnection(str7, str3);
                AAAComponent.AAALog("MMAXQuery", str, str8);
                try
                {
                    this.xml = new DomParser(str8);
                    resultCode = this.GetResultCode();
                }
                catch (Exception exception)
                {
                    resultCode = "c004";
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }

        public string ATMQuery(string aa_ServerName,string aa_otpw)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat("<aa_OTPW=\"", aa_otpw, "\">");
            if (aa_otpw.Length == 0 )
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
            //    string str1 = AAAComponent.MD5(string.Concat(aa_Alias, aa_SubscribeNO, aa_ProductID));
                string str2 = string.Concat(AAAComponent.MyUrlEncode("aa-otpw"), "=", AAAComponent.MyUrlEncode(aa_otpw));
                string str8 = string.Concat(aa_ServerName, "/AtmA3/replyCP");
                string str9 = AAAComponent.BuildConnection(str8, str2);
                AAAComponent.AAALog("AtmQuery", str, str9);
                try
                {
                    this.xml = new DomParser(str9);
                    resultCode = this.GetResultCode();
                }
                catch (Exception exception)
                {
                    resultCode = "c004";
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }

        public string ATMMultiplebills(string aa_ServerName, string aa_otpw, string multiplebills)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat("<aa_OTPW=\"", aa_otpw, "\">");
            str = string.Concat(str,"<multiplebills=\"", multiplebills, "\">");
            if (aa_otpw.Length == 0)
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                //    string str1 = AAAComponent.MD5(string.Concat(aa_Alias, aa_SubscribeNO, aa_ProductID));
                string str2 = string.Concat(AAAComponent.MyUrlEncode("aa-otpw"), "=", AAAComponent.MyUrlEncode(aa_otpw));
                str2 = string.Concat(str2, "&", AAAComponent.MyUrlEncode("multiplebills"), "=", AAAComponent.MyUrlEncode(multiplebills));
                string str8 = string.Concat(aa_ServerName, "/AtmA3/multiplebills");
                string str9 = AAAComponent.BuildConnection(str8, str2);
                AAAComponent.AAALog("AtmQuery", str, str9);
                try
                {
                    this.xml = new DomParser(str9);
                    resultCode = this.GetResultCode();
                }
                catch (Exception exception)
                {
                    resultCode = "c004";
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }


        public string CreditRevoke(string aa_ServerName, string aa_otpw)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat("<aa_OTPW=\"", aa_otpw, "\">");

            if (aa_otpw.Length == 0)
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                string str2 = string.Concat(AAAComponent.MyUrlEncode("aa-otpw"), "=", AAAComponent.MyUrlEncode(aa_otpw));
                string str8 = string.Concat(aa_ServerName, "/CreditA3/revoke");
                string str9 = AAAComponent.BuildConnection(str8, str2);
                AAAComponent.AAALog("CreditRevoke", str + "|" + str8 + "|" + str2, str9);
        //       try
        //        {
              //      this.xml = new DomParser(str9);
                    resultCode = str9;
       //         }
         //       catch (Exception exception)
         //       {
                 //   resultCode = "c004";
         //       }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }


        public string GetTxntime()
        {
            string str;
            str = (this.xml == null ? "c005" : this.xml.GetTxntime());
            return str;
        }



        public string MonthQuery(string aa_ServerName, string aa_Alias, string aa_SubscribeNO, string aa_ProductID, string aa_ApID, string aa_Reserved)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat(str, "<aa_Alias=\"", aa_Alias, "\">");
            str = string.Concat(str, "<aa_SubscribeNO=\"", aa_SubscribeNO, "\">");
            str = string.Concat(str, "<aa_ProductID=\"", aa_ProductID, "\">");
            str = string.Concat(str, "<aa_ApID=\"", aa_ApID, "\">");
            str = string.Concat(str, "<aa_Reserved=\"", aa_Reserved, "\">");
            if (aa_ServerName.Length == 0 || aa_Alias.Length == 0 || aa_SubscribeNO.Length == 0 || aa_ProductID.Length == 0 || aa_ApID.Length == 0)
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                string str1 = AAAComponent.MD5(string.Concat(aa_Alias, aa_SubscribeNO, aa_ProductID));
                string str2 = string.Concat(AAAComponent.MyUrlEncode("Alias"), "=", AAAComponent.MyUrlEncode(aa_Alias));
                string str3 = str2;
                string[] strArray = new string[] { str3, "&", AAAComponent.MyUrlEncode("SubscribeNo"), "=", AAAComponent.MyUrlEncode(aa_SubscribeNO) };
                string str4 = string.Concat(strArray);
                string[] strArray1 = new string[] { str4, "&", AAAComponent.MyUrlEncode("ProductID"), "=", AAAComponent.MyUrlEncode(aa_ProductID) };
                string str5 = string.Concat(strArray1);
                string[] strArray2 = new string[] { str5, "&", AAAComponent.MyUrlEncode("ApID"), "=", AAAComponent.MyUrlEncode(aa_ApID) };
                string str6 = string.Concat(strArray2);
                string[] strArray3 = new string[] { str6, "&", AAAComponent.MyUrlEncode("CheckSum"), "=", AAAComponent.MyUrlEncode(str1) };
                string str7 = string.Concat(strArray3);
                string[] strArray4 = new string[] { str7, "&", AAAComponent.MyUrlEncode("Reserved"), "=", AAAComponent.MyUrlEncode(aa_Reserved) };
                str2 = string.Concat(strArray4);
                string str8 = string.Concat(aa_ServerName, "/Member/Query");
                string str9 = AAAComponent.BuildConnection(str8, str2);
                AAAComponent.AAALog("MonthQuery", str2, str8);
                AAAComponent.AAALog("MonthQuery", str, str9);
                try
                {
                    this.xml = new DomParser(str9);
                    resultCode = this.GetResultCode();
                }
                catch (Exception exception)
                {
                    resultCode = "c004";
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }

        public string MonthSubscribe(string aa_ServerName, string aa_Alias, string aa_ProductID, string aa_ApID, string aa_OTPW, string aa_Authority, string aa_ActionDate, string aa_TotalMonth, string aa_Reserved)
        {
            string str = this.MonthSubscribeEx(aa_ServerName, aa_Alias, aa_ProductID, aa_ApID, aa_OTPW, aa_Authority, aa_ActionDate, aa_TotalMonth, "", "", "", aa_Reserved);
            return str;
        }

        public string MonthSubscribeEx(string aa_ServerName, string aa_Alias, string aa_ProductID, string aa_ApID, string aa_OTPW, string aa_Authority, string aa_ActionDate, string aa_TotalMonth, string aa_SettingCharge, string aa_InstallCharge, string aa_FirstCharge, string aa_Reserved)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat(str, "<aa_Alias=\"", aa_Alias, "\">");
            str = string.Concat(str, "<aa_ProductID=\"", aa_ProductID, "\">");
            str = string.Concat(str, "<aa_ApID=\"", aa_ApID, "\">");
            str = string.Concat(str, "<aa_OTPW=\"", aa_OTPW, "\">");
            str = string.Concat(str, "<aa_Authority=\"", aa_Authority, "\">");
            str = string.Concat(str, "<aa_ActionDate=\"", aa_ActionDate, "\">");
            str = string.Concat(str, "<aa_TotalMonth=\"", aa_TotalMonth, "\">");
            str = string.Concat(str, "<aa_SettingCharge=\"", aa_SettingCharge, "\">");
            str = string.Concat(str, "<aa_InstallCharge=\"", aa_InstallCharge, "\">");
            str = string.Concat(str, "<aa_FirstCharge=\"", aa_FirstCharge, "\">");
            str = string.Concat(str, "<aa_Reserved=\"", aa_Reserved, "\">");
            if (aa_ServerName.Length == 0 || aa_Alias.Length == 0 || aa_ProductID.Length == 0 || aa_ApID.Length == 0 || aa_OTPW.Length == 0 || aa_Authority.Length == 0)
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                string str1 = string.Concat(aa_Alias, aa_ProductID, aa_OTPW);
                if (aa_ActionDate.Length != 0)
                {
                    str1 = string.Concat(str1, aa_ActionDate);
                }
                if (aa_TotalMonth.Length != 0)
                {
                    str1 = string.Concat(str1, aa_TotalMonth);
                }
                if (aa_SettingCharge.Length != 0)
                {
                    str1 = string.Concat(str1, aa_SettingCharge);
                }
                if (aa_InstallCharge.Length != 0)
                {
                    str1 = string.Concat(str1, aa_InstallCharge);
                }
                if (aa_FirstCharge.Length != 0)
                {
                    str1 = string.Concat(str1, aa_FirstCharge);
                }
                string str2 = AAAComponent.MD5(str1);
                string str3 = string.Concat(AAAComponent.MyUrlEncode("Alias"), "=", AAAComponent.MyUrlEncode(aa_Alias));
                string str4 = str3;
                string[] strArray = new string[] { str4, "&", AAAComponent.MyUrlEncode("ProductID"), "=", AAAComponent.MyUrlEncode(aa_ProductID) };
                string str5 = string.Concat(strArray);
                string[] strArray1 = new string[] { str5, "&", AAAComponent.MyUrlEncode("ApID"), "=", AAAComponent.MyUrlEncode(aa_ApID) };
                string str6 = string.Concat(strArray1);
                string[] strArray2 = new string[] { str6, "&", AAAComponent.MyUrlEncode("MixCode"), "=", AAAComponent.MyUrlEncode(aa_OTPW) };
                string str7 = string.Concat(strArray2);
                string[] strArray3 = new string[] { str7, "&", AAAComponent.MyUrlEncode("ActionDate"), "=", AAAComponent.MyUrlEncode(aa_ActionDate) };
                string str8 = string.Concat(strArray3);
                string[] strArray4 = new string[] { str8, "&", AAAComponent.MyUrlEncode("TotalMonth"), "=", AAAComponent.MyUrlEncode(aa_TotalMonth) };
                string str9 = string.Concat(strArray4);
                string[] strArray5 = new string[] { str9, "&", AAAComponent.MyUrlEncode("SettingCharge"), "=", AAAComponent.MyUrlEncode(aa_SettingCharge) };
                string str10 = string.Concat(strArray5);
                string[] strArray6 = new string[] { str10, "&", AAAComponent.MyUrlEncode("InstallCharge"), "=", AAAComponent.MyUrlEncode(aa_InstallCharge) };
                string str11 = string.Concat(strArray6);
                string[] strArray7 = new string[] { str11, "&", AAAComponent.MyUrlEncode("FirstCharge"), "=", AAAComponent.MyUrlEncode(aa_FirstCharge) };
                string str12 = string.Concat(strArray7);
                string[] strArray8 = new string[] { str12, "&", AAAComponent.MyUrlEncode("CheckSum"), "=", AAAComponent.MyUrlEncode(str2) };
                string str13 = string.Concat(strArray8);
                string[] strArray9 = new string[] { str13, "&", AAAComponent.MyUrlEncode("Reserved"), "=", AAAComponent.MyUrlEncode(aa_Reserved) };
                str3 = string.Concat(strArray9);
                string lower = aa_Authority.ToLower();
                lower = string.Concat(lower.Substring(0, 1).ToUpper(), lower.Substring(1));
                string str14 = string.Concat(aa_ServerName, "/", lower, "Member/Subscribe");
                string str15 = AAAComponent.BuildConnection(str14, str3);
                AAAComponent.AAALog("MonthSubscribeEx", str, str15);
                try
                {
                    this.xml = new DomParser(str15);
                    resultCode = this.GetResultCode();
                }
                catch (Exception exception)
                {
                    resultCode = "c004";
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }

        public string MonthSubscribePhysicalEx(string aa_ServerName, string aa_Alias, string aa_ProductID, string aa_ApID, string aa_OTPW, string aa_Authority, string aa_ActionDate, string aa_TotalMonth, string aa_SettingCharge, string aa_InstallCharge, string aa_FirstCharge, string aa_Rent, string aa_Amount, string aa_DiffMsg, string aa_Reserved)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat(str, "<aa_Alias=\"", aa_Alias, "\">");
            str = string.Concat(str, "<aa_ProductID=\"", aa_ProductID, "\">");
            str = string.Concat(str, "<aa_ApID=\"", aa_ApID, "\">");
            str = string.Concat(str, "<aa_OTPW=\"", aa_OTPW, "\">");
            str = string.Concat(str, "<aa_Authority=\"", aa_Authority, "\">");
            str = string.Concat(str, "<aa_ActionDate=\"", aa_ActionDate, "\">");
            str = string.Concat(str, "<aa_TotalMonth=\"", aa_TotalMonth, "\">");
            str = string.Concat(str, "<aa_SettingCharge=\"", aa_SettingCharge, "\">");
            str = string.Concat(str, "<aa_InstallCharge=\"", aa_InstallCharge, "\">");
            str = string.Concat(str, "<aa_FirstCharge=\"", aa_FirstCharge, "\">");
            str = string.Concat(str, "<aa_Rent=\"", aa_Rent, "\">");
            str = string.Concat(str, "<aa_Amount=\"", aa_Amount, "\">");
            str = string.Concat(str, "<aa_DiffMsg=\"", aa_DiffMsg, "\">");
            str = string.Concat(str, "<aa_Reserved=\"", aa_Reserved, "\">");
            if (aa_ServerName.Length == 0 || aa_Alias.Length == 0 || aa_ProductID.Length == 0 || aa_OTPW.Length == 0 || aa_Authority.Length == 0)
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                string str1 = string.Concat(aa_Alias, aa_ProductID, aa_OTPW);
                if (aa_ActionDate.Length != 0)
                {
                    str1 = string.Concat(str1, aa_ActionDate);
                }
                if (aa_TotalMonth.Length != 0)
                {
                    str1 = string.Concat(str1, aa_TotalMonth);
                }
                if (aa_SettingCharge.Length != 0)
                {
                    str1 = string.Concat(str1, aa_SettingCharge);
                }
                if (aa_InstallCharge.Length != 0)
                {
                    str1 = string.Concat(str1, aa_InstallCharge);
                }
                if (aa_FirstCharge.Length != 0)
                {
                    str1 = string.Concat(str1, aa_FirstCharge);
                }
                if (aa_Amount.Length != 0)
                {
                    str1 = string.Concat(str1, aa_Amount);
                }
                if (aa_Rent.Length != 0)
                {
                    str1 = string.Concat(str1, aa_Rent);
                }
                string str2 = AAAComponent.MD5(str1);
                if (this.m_DiffMsg.Length != 0)
                {
                    AAAComponent aAAComponent = this;
                    aAAComponent.m_DiffMsg = string.Concat(aAAComponent.m_DiffMsg, "</Message>");
                }
                string str3 = string.Concat(AAAComponent.MyUrlEncode("Alias"), "=", AAAComponent.MyUrlEncode(aa_Alias));
                string str4 = str3;
                string[] strArray = new string[] { str4, "&", AAAComponent.MyUrlEncode("ProductID"), "=", AAAComponent.MyUrlEncode(aa_ProductID) };
                str3 = string.Concat(strArray);
                string str5 = str3;
                string[] strArray1 = new string[] { str5, "&", AAAComponent.MyUrlEncode("ApID"), "=", AAAComponent.MyUrlEncode(aa_ApID) };
                str3 = string.Concat(strArray1);
                string str6 = str3;
                string[] strArray2 = new string[] { str6, "&", AAAComponent.MyUrlEncode("MixCode"), "=", AAAComponent.MyUrlEncode(aa_OTPW) };
                str3 = string.Concat(strArray2);
                string str7 = str3;
                string[] strArray3 = new string[] { str7, "&", AAAComponent.MyUrlEncode("ActionDate"), "=", AAAComponent.MyUrlEncode(aa_ActionDate) };
                str3 = string.Concat(strArray3);
                string str8 = str3;
                string[] strArray4 = new string[] { str8, "&", AAAComponent.MyUrlEncode("TotalMonth"), "=", AAAComponent.MyUrlEncode(aa_TotalMonth) };
                str3 = string.Concat(strArray4);
                string str9 = str3;
                string[] strArray5 = new string[] { str9, "&", AAAComponent.MyUrlEncode("SettingCharge"), "=", AAAComponent.MyUrlEncode(aa_SettingCharge) };
                str3 = string.Concat(strArray5);
                string str10 = str3;
                string[] strArray6 = new string[] { str10, "&", AAAComponent.MyUrlEncode("InstallCharge"), "=", AAAComponent.MyUrlEncode(aa_InstallCharge) };
                str3 = string.Concat(strArray6);
                string str11 = str3;
                string[] strArray7 = new string[] { str11, "&", AAAComponent.MyUrlEncode("FirstCharge"), "=", AAAComponent.MyUrlEncode(aa_FirstCharge) };
                str3 = string.Concat(strArray7);
                string str12 = str3;
                string[] strArray8 = new string[] { str12, "&", AAAComponent.MyUrlEncode("Rent"), "=", AAAComponent.MyUrlEncode(aa_Rent) };
                str3 = string.Concat(strArray8);
                string str13 = str3;
                string[] strArray9 = new string[] { str13, "&", AAAComponent.MyUrlEncode("Amount"), "=", AAAComponent.MyUrlEncode(aa_Amount) };
                str3 = string.Concat(strArray9);
                string str14 = str3;
                string[] strArray10 = new string[] { str14, "&", AAAComponent.MyUrlEncode("CheckSum"), "=", AAAComponent.MyUrlEncode(str2) };
                str3 = string.Concat(strArray10);
                string str15 = str3;
                string[] strArray11 = new string[] { str15, "&", AAAComponent.MyUrlEncode("Reserved"), "=", AAAComponent.MyUrlEncode(aa_Reserved) };
                str3 = string.Concat(strArray11);
                if (aa_DiffMsg.Length == 0)
                {
                    string str16 = str3;
                    string[] strArray12 = new string[] { str16, "&", AAAComponent.MyUrlEncode("DiffMsg"), "=", AAAComponent.MyUrlEncode(this.m_DiffMsg) };
                    str3 = string.Concat(strArray12);
                }
                else
                {
                    string str17 = str3;
                    string[] strArray13 = new string[] { str17, "&", AAAComponent.MyUrlEncode("DiffMsg"), "=", AAAComponent.MyUrlEncode(aa_DiffMsg) };
                    str3 = string.Concat(strArray13);
                }
                string lower = aa_Authority.ToLower();
                lower = string.Concat(lower.Substring(0, 1).ToUpper(), lower.Substring(1));
                string str18 = string.Concat(aa_ServerName, "/", lower, "Goods/Subscribe");
                string str19 = AAAComponent.BuildConnection(str18, str3);
                AAAComponent.AAALog("MonthSubscribePhysicalEx", str, str19);
                if (this.m_DiffMsg.Length != 0)
                {
                    this.m_DiffMsg = "";
                }
                try
                {
                    this.xml = new DomParser(str19);
                    resultCode = this.GetResultCode();
                }
                catch (Exception exception)
                {
                    resultCode = "c004";
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }

        public string MonthUnSubscribe(string aa_ServerName, string aa_Alias, string aa_SubscribeNO, string aa_ProductID, string aa_ApID, string aa_ActionDate, string aa_Reserved)
        {
            string str = this.MonthUnSubscribePhysicalEx(aa_ServerName, aa_Alias, aa_SubscribeNO, aa_ProductID, aa_ApID, aa_ActionDate, "", aa_Reserved, "");
            return str;
        }

        public string MonthUnSubscribe(string aa_ServerName, string aa_Alias, string aa_SubscribeNO, string aa_ProductID, string aa_ApID, string aa_ActionDate, string aa_Reserved, string aa_Authority)
        {
            string str = this.MonthUnSubscribePhysicalEx(aa_ServerName, aa_Alias, aa_SubscribeNO, aa_ProductID, aa_ApID, aa_ActionDate, "", aa_Reserved, aa_Authority);
            return str;
        }

        public string MonthUnSubscribePhysicalEx(string aa_ServerName, string aa_Alias, string aa_SubscribeNO, string aa_ProductID, string aa_ApID, string aa_ActionDate, string aa_Amount, string aa_Reserved)
        {
            string str = this.MonthUnSubscribePhysicalEx(aa_ServerName, aa_Alias, aa_SubscribeNO, aa_ProductID, aa_ApID, aa_ActionDate, aa_Amount, aa_Reserved, "");
            return str;
        }

        public string MonthUnSubscribePhysicalEx(string aa_ServerName, string aa_Alias, string aa_SubscribeNO, string aa_ProductID, string aa_ApID, string aa_ActionDate, string aa_Amount, string aa_Reserved, string aa_Authority)
        {
            string resultCode;
            string str = string.Concat("<aa_ServerName=\"", aa_ServerName, "\">");
            str = string.Concat(str, "<aa_Alias=\"", aa_Alias, "\">");
            str = string.Concat(str, "<aa_SubscribeNO=\"", aa_SubscribeNO, "\">");
            str = string.Concat(str, "<aa_ProductID=\"", aa_ProductID, "\">");
            str = string.Concat(str, "<aa_ApID=\"", aa_ApID, "\">");
            str = string.Concat(str, "<aa_ActionDate=\"", aa_ActionDate, "\">");
            str = string.Concat(str, "<aa_Amount=\"", aa_Amount, "\">");
            str = string.Concat(str, "<aa_Reserved=\"", aa_Reserved, "\">");
            str = string.Concat(str, "<aa_Authority=\"", aa_Authority, "\">");
            if (aa_ServerName.Length == 0 || aa_Alias.Length == 0 || aa_SubscribeNO.Length == 0 || aa_ProductID.Length == 0 || aa_ApID.Length == 0)
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                string[] aaAlias = new string[] { aa_Alias, aa_SubscribeNO, aa_ProductID, aa_ActionDate, aa_Amount };
                string str1 = AAAComponent.MD5(string.Concat(aaAlias));
                string str2 = string.Concat(AAAComponent.MyUrlEncode("Alias"), "=", AAAComponent.MyUrlEncode(aa_Alias));
                string str3 = str2;
                string[] strArray = new string[] { str3, "&", AAAComponent.MyUrlEncode("SubscribeNo"), "=", AAAComponent.MyUrlEncode(aa_SubscribeNO) };
                str2 = string.Concat(strArray);
                string str4 = str2;
                string[] strArray1 = new string[] { str4, "&", AAAComponent.MyUrlEncode("ProductID"), "=", AAAComponent.MyUrlEncode(aa_ProductID) };
                str2 = string.Concat(strArray1);
                string str5 = str2;
                string[] strArray2 = new string[] { str5, "&", AAAComponent.MyUrlEncode("ApID"), "=", AAAComponent.MyUrlEncode(aa_ApID) };
                str2 = string.Concat(strArray2);
                string str6 = str2;
                string[] strArray3 = new string[] { str6, "&", AAAComponent.MyUrlEncode("ActionDate"), "=", AAAComponent.MyUrlEncode(aa_ActionDate) };
                str2 = string.Concat(strArray3);
                string str7 = str2;
                string[] strArray4 = new string[] { str7, "&", AAAComponent.MyUrlEncode("Amount"), "=", AAAComponent.MyUrlEncode(aa_Amount) };
                str2 = string.Concat(strArray4);
                string str8 = str2;
                string[] strArray5 = new string[] { str8, "&", AAAComponent.MyUrlEncode("CheckSum"), "=", AAAComponent.MyUrlEncode(str1) };
                str2 = string.Concat(strArray5);
                string str9 = str2;
                string[] strArray6 = new string[] { str9, "&", AAAComponent.MyUrlEncode("Reserved"), "=", AAAComponent.MyUrlEncode(aa_Reserved) };
                str2 = string.Concat(strArray6);
                string str10 = null;
                if (aa_Authority == null || aa_Authority.Length == 0)
                {
                    str10 = string.Concat(aa_ServerName, "/Member/Unsubscribe");
                }
                else
                {
                    string lower = aa_Authority.ToLower();
                    lower = string.Concat(lower.Substring(0, 1).ToUpper(), lower.Substring(1));
                    str10 = string.Concat(aa_ServerName, "/", lower, "Member/Unsubscribe");
                }
                string str11 = AAAComponent.BuildConnection(str10, str2);
                AAAComponent.AAALog("MonthUnSubscribePhysicalEx", str, str11);
                try
                {
                    this.xml = new DomParser(str11);
                    resultCode = this.GetResultCode();
                }
                catch (Exception exception)
                {
                    resultCode = "c004";
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }

        public string MonthlyTransferAuth(string aa_ServerName, string aa_ProductID, string aa_Fee, string aa_others, string aa_authinfo, string aa_defaultpay)
        {
            string resultCode;
            string aa_version = "3.1";
            string aa_key = "F1478AB1B6953C951A515CD44589AACD1FA801AA4EB8C71C";

            string str = string.Concat("<aa_ProductID=\"", aa_ProductID, "\">");
            str = string.Concat(str, "<aa_Fee=\"", aa_Fee, "\">");
            str = string.Concat(str, "<aa_others=\"", aa_others, "\">");
            str = string.Concat(str, "<aa_authinfo=\"", aa_authinfo, "\">");
            str = string.Concat(str, "<aa_defaultpay=\"", aa_defaultpay, "\">");

           

            if (aa_ProductID.Length == 0 || aa_Fee.Length == 0|| aa_authinfo.Length == 0 || aa_defaultpay.Length == 0 )
            {
                resultCode = "c001";
            }
            else if (aa_ServerName.StartsWith("http"))
            {
                string str_sum_str=aa_version+aa_ProductID+aa_Fee+aa_others+aa_authinfo+aa_defaultpay;

                HMACSHA1 hmacsha1 = new HMACSHA1();
                hmacsha1.Key=System.Text.Encoding.ASCII.GetBytes(aa_key);

                byte[] aa_data = System.Text.Encoding.ASCII.GetBytes(str_sum_str);
                byte[] hashBytes = hmacsha1.ComputeHash(aa_data);
                string aa_sum = "";
                foreach (byte c in hashBytes) aa_sum = aa_sum + c.ToString("x2");

                string str1 = string.Concat(AAAComponent.MyUrlEncode("aa-version"), "=", AAAComponent.MyUrlEncode(aa_version));
                string str0 = str1;
                string[] strArray0 = new string[] { str0, "&", AAAComponent.MyUrlEncode("aa-productid"), "=", AAAComponent.MyUrlEncode(aa_ProductID) };
                str1 = string.Concat(strArray0);
                string str2 = str1;
                string[] strArray = new string[] { str2, "&", AAAComponent.MyUrlEncode("aa-fee"), "=", AAAComponent.MyUrlEncode(aa_Fee) };
                str1 = string.Concat(strArray);
                string str3 = str1;
                string[] strArray1 = new string[] { str3, "&", AAAComponent.MyUrlEncode("aa-others"), "=", AAAComponent.MyUrlEncode(aa_others) };
                str1 = string.Concat(strArray1);
                string str4 = str1;
                string[] strArray2 = new string[] { str4, "&", AAAComponent.MyUrlEncode("aa-authinfo"), "=", AAAComponent.MyUrlEncode(aa_authinfo) };
                str1 = string.Concat(strArray2);
                string str5 = str1;
                string[] strArray3 = new string[] { str5, "&", AAAComponent.MyUrlEncode("aa-defaultpay"), "=", AAAComponent.MyUrlEncode(aa_defaultpay) };
                str1 = string.Concat(strArray3);
                string str6 = str1;
                string[] strArray4 = new string[] { str6, "&", AAAComponent.MyUrlEncode("aa-sum"), "=", AAAComponent.MyUrlEncode(aa_sum) };
                str1 = string.Concat(strArray4);
                string url = null;

                 url = string.Concat(aa_ServerName, "/A1/MonthlyTransferAuth");

                string str8 = AAAComponent.BuildConnection(url, str1,"UTF-8");
                AAAComponent.AAALog("Accounting", url, str8);
                AAAComponent.AAALog("Accounting", url, str1);
                try
                {
                    this.xml = new DomParser(str8);
                    if(this.GetResultCode() == "s000"){
                    resultCode = this.GetResultCode() + '|' + (this.xml == null ? "c005" : this.xml.GetMonthlyTransferOTPW())+'|'+ (this.xml == null ? "c005" : this.xml.GetMonthlyTransferAAUID());
                    } else {
                        resultCode = str8;
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                    resultCode = str8;
                }
            }
            else
            {
                resultCode = "c002";
            }
            return resultCode;
        }


        private static string MyUrlEncode(string src)
        {
            char[] charArray = src.ToCharArray();
            StringWriter stringWriter = new StringWriter();
            for (int i = 0; i < (int)charArray.Length; i++)
            {
                int num = charArray[i];
                if (num < 125 && AAAComponent.dontEncoding.Get(num))
                {
                    stringWriter.Write((char)num);
                }
                else if (num != 32)
                {
                    Encoding encoding = Encoding.GetEncoding("big5");
                    char[] chrArray = new char[] { charArray[i] };
                    byte[] bytes = encoding.GetBytes(chrArray);
                    for (int j = 0; j < (int)bytes.Length; j++)
                    {
                        stringWriter.Write("%{0:x2}", bytes[j]);
                    }
                }
                else
                {
                    stringWriter.Write("+");
                }
            }
            return stringWriter.ToString();
        }

        public string Version()
        {
            return AAAComponent.VERSION;
        }
    }
}