using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

using Newtonsoft.Json.Linq;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


/// <summary>
/// Summary description for Class1
/// </summary>
///
namespace BSM
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Customer
    {
        [JsonProperty]
        public string MacAddress;
        [JsonProperty]
        public string ClientId;
        [JsonProperty]
        public string PhoneNo;
        [JsonProperty]
        public string CustName;
        [JsonProperty]
        public string DayPhone;
        [JsonProperty]
        public string Address;
        [JsonProperty]
        public string Fax;
        [JsonProperty]
        public string zip;
        [JsonProperty]
        public int? Gender;
        [JsonProperty]
        public string email;

        [JsonProperty]
        public string agree_epaper;
        [JsonProperty]
        public string agree_donate;

        public Customer()
        {
            
        }
    }

    public class CustomerList : CollectionBase
    {
        public Customer this[int index]
        {
            get { return (Customer)List[index]; }
            set { List[index] = value; }
        }

        public int Indexof(Customer p_Actor)
        {
            return this.List.IndexOf(p_Actor);
        }

        public void Add(Customer p_Actor)
        {
            this.List.Add(p_Actor);
        }

        public void Remove(Customer p_Actor)
        {
            if (this.Indexof(p_Actor) != -1)
                List.Remove(p_Actor);
        }

    }


}
