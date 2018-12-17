using System;
using System.Collections;
using System.Xml;

namespace Hinet
{
    public class DomParser
    {
        private XmlDocument doc;

        public DomParser(string xmlstr)
        {
            try
            {
                this.doc = new XmlDocument();
                this.doc.LoadXml(xmlstr);
            }
            catch (Exception exception)
            {
                throw new XmlException();
            }
        }

        public string GetErrDesc()
        {
            string str;
            if (this.doc == null || !this.doc.HasChildNodes)
            {
                str = "c007";
            }
            else
            {
                XmlNode xmlNode = this.doc.DocumentElement.SelectSingleNode("response-code");
                str = (xmlNode != null ? xmlNode.InnerText.Trim() : "c012");
            }
            return str;
        }

        public string GetMonthSubscribeNoEx(string Item)
        {
            string str;
            if (this.doc == null || !this.doc.HasChildNodes)
            {
                str = "c007";
            }
            else
            {
                XmlNodeList xmlNodeList = this.doc.DocumentElement.SelectNodes("subscribe");
                if (xmlNodeList.Count != 0)
                {
                    IEnumerator enumerator = xmlNodeList.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        XmlNode current = (XmlNode)enumerator.Current;
                        if (!current.SelectSingleNode("diffmsg").InnerText.Equals(Item))
                        {
                            continue;
                        }
                        str = current.SelectSingleNode("subno").InnerText.Trim();
                        return str;
                    }
                    str = "c011";
                }
                else
                {
                    str = "c011";
                }
            }
            return str;
        }

        public string GetMonthSubscribePolicyEx(string Item, string attrib)
        {
            string policy;
            if (this.doc == null || !this.doc.HasChildNodes)
            {
                policy = "c007";
            }
            else
            {
                XmlNodeList xmlNodeList = this.doc.DocumentElement.SelectNodes("subscribe");
                if (xmlNodeList.Count != 0)
                {
                    IEnumerator enumerator = xmlNodeList.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        XmlNode current = (XmlNode)enumerator.Current;
                        if (!current.SelectSingleNode("diffmsg").InnerText.Equals(Item))
                        {
                            continue;
                        }
                        policy = this.GetPolicy(attrib, (XmlElement)current);
                        return policy;
                    }
                    policy = "c011";
                }
                else
                {
                    policy = "c011";
                }
            }
            return policy;
        }


        public string GetOTPW()
        {
            string str;
            if (this.doc == null || !this.doc.HasChildNodes)
            {
                str = "c007";
            }
            else
            {
                XmlNode xmlNode = this.doc.DocumentElement.SelectSingleNode("NewOTPW");
                str = (xmlNode != null ? xmlNode.InnerText.Trim() : "c011");
            }
            return str;
        }

        public string GetMonthlyTransferOTPW()
        {
            string str;
            if (this.doc == null || !this.doc.HasChildNodes)
            {
                str = "c007";
            }
            else
            {
                XmlNode xmlNode = this.doc.DocumentElement.SelectSingleNode("aa-otpw");
                str = (xmlNode != null ? xmlNode.InnerText.Trim() : "c011");
            }
            return str;
        }

        public string GetMonthlyTransferAAUID()
        {
            string str;
            if (this.doc == null || !this.doc.HasChildNodes)
            {
                str = "c007";
            }
            else
            {
                XmlNode xmlNode = this.doc.DocumentElement.SelectSingleNode("aa-uid");
                str = (xmlNode != null ? xmlNode.InnerText.Trim() : "c011");
            }
            return str;
        }



        public string GetPolicy(string attrStr, XmlElement root)
        {
            string innerText;
            if (this.doc == null || !this.doc.HasChildNodes)
            {
                innerText = "c007";
            }
            else
            {
                if (root == null)
                {
                    root = this.doc.DocumentElement;
                }
                XmlNodeList xmlNodeList = root.SelectNodes("policy-response");
                if (xmlNodeList.Count != 0)
                {
                    IEnumerator enumerator = xmlNodeList.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        XmlNode current = (XmlNode)enumerator.Current;
                        XmlNode xmlNode = current.SelectSingleNode("Attribute");
                        if (xmlNode != null)
                        {
                            if (!xmlNode.InnerText.Equals(attrStr))
                            {
                                continue;
                            }
                            innerText = current.SelectSingleNode("value").InnerText;
                            return innerText;
                        }
                    }
                    innerText = "c008";
                }
                else
                {
                    innerText = "c009";
                }
            }
            return innerText;
        }

        public string GetResultCode()
        {
            string str;
            if (this.doc == null || !this.doc.HasChildNodes)
            {
                str = "c007";
            }
            else
            {
                XmlNode xmlNode = this.doc.DocumentElement.SelectSingleNode("response-code");
                str = (xmlNode != null ? xmlNode.InnerText.Trim() : "c010");
            }
            return str;
        }

        public string GetTxntime()
        {
            string str;
            if (this.doc == null || !this.doc.HasChildNodes)
            {
                str = "c007";
            }
            else
            {
                XmlNode xmlNode = this.doc.DocumentElement.SelectSingleNode("txndatetime");
                str = (xmlNode != null ? xmlNode.InnerText.Trim() : "c010");
            }
            return str;
        }

        public string GetSubscribeNo()
        {
            string str;
            if (this.doc == null || !this.doc.HasChildNodes)
            {
                str = "c007";
            }
            else
            {
                XmlNode xmlNode = this.doc.DocumentElement.SelectSingleNode("subscribeno");
                str = (xmlNode != null ? xmlNode.InnerText.Trim() : "c011");
            }
            return str;
        }

        public string MMAXGetResult(string Name)
        {
            string str;
            if (this.doc == null || !this.doc.HasChildNodes)
            {
                str = "c007";
            }
            else
            {
                XmlNode xmlNode = this.doc.DocumentElement.SelectSingleNode(Name);
                str = (xmlNode != null ? xmlNode.InnerText.Trim() : "c011");
            }
            return str;
        }
    }
}