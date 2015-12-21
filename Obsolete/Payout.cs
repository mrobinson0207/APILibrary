using System;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Xml.Resolvers;
using System.Collections.Generic;
using System.Xml.Serialization;

public class payoutResp
{
    [XmlRoot("payout"), Serializable]
    public class payout
    {
        [XmlElement("response")]
        public string response { get; set; }
        [XmlElement("responsecode")]
        public string responsecode { get; set; }
        [XmlElement("responsetext")]
        public string responsetext { get; set; }
        [XmlElement("trans_id")]
        public string trans_id { get; set; }
        [XmlElement("ukash_voucher")]
        public ukash_voucher ukash_voucher { get; set; }
    }

    public class ukash_voucher
    {
        [XmlElement("number")]
        public string number { get; set; }
        [XmlElement("currency")]
        public string currency { get; set; }
        [XmlElement("amount")]
        public string amount { get; set; }
        [XmlElement("expirydate")]
        public string expirydate { get; set; }
    }

    public payoutResp()
    {}
}
