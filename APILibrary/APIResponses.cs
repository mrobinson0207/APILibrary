using System;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Xml.Resolvers;
using System.Collections.Generic;
using System.Xml.Serialization;
// Response classes

[XmlRoot("orders"), Serializable]
public class orders
{
    [XmlElement("num_records")]
    public string num_records { get; set; }
    [XmlElement("order")]
    public order[] order { get; set; }
}

[Serializable]
public class order
{
    // Common Fields - order
    [XmlElement("order_id")]
    public string order_id {get; set; }
    [XmlElement("order_reference")]
    public string order_reference { get; set; }
    [XmlElement("order_datetime")]
    public string order_datetime { get; set; }
    [XmlElement("order_total")]
    public string order_total { get; set; }
    [XmlElement("order_currency")]
    public string order_currency { get; set; }
    [XmlElement("test_transaction")]
    public string test_transaction { get; set; }
    [XmlElement("order_status")]
    public string order_status { get; set; }
    // Shipping fields
    //public shipping shipping { get; set; }
    [XmlElement("customer_first_name")]
    public string customer_first_name { get; set; }
    [XmlElement("customer_last_name")]
    public string customer_last_name { get; set; }
    [XmlElement("customer_company")]
    public string customer_company { get; set; }
    [XmlElement("customer_address")]
    public string customer_address { get; set; }
    [XmlElement("customer_city")]
    public string customer_city { get; set; }
    [XmlElement("customer_state")]
    public string customer_state { get; set; }
    [XmlElement("customer_postcode")]
    public string customer_postcode { get; set; }
    [XmlElement("customer_country")]
    public string customer_country { get; set; }
    [XmlElement("customer_email")]
    public string customer_email { get; set; }
    [XmlElement("customer_phone")]
    public string customer_phone { get; set; }
    [XmlElement("shipping_last_name")]
    public string shipping_last_name { get; set; }
    [XmlElement("shipping_company")]
    public string shipping_company { get; set; }
    [XmlElement("shipping_address")]
    public string shipping_address { get; set; }
    [XmlElement("shipping_city")]
    public string shipping_city { get; set; }
    [XmlElement("shipping_state")]
    public string shipping_state { get; set; }
    [XmlElement("shipping_postcode")]
    public string shipping_postcode { get; set; }
    [XmlElement("shipping_country")]
    public string shipping_country { get; set; }
    [XmlArray("items")]
    [XmlArrayItem("item", typeof(item))]
    public item[] items { get; set; }

}

// Split this into customer and shipping??
[Serializable]
public class shipping
{
    // Shipping fields
    [XmlElement("customer_first_name")]
    public string customer_first_name { get; set; }
    [XmlElement("customer_last_name")]
    public string customer_last_name { get; set; }
    [XmlElement("customer_company")]
    public string customer_company { get; set; }
    [XmlElement("customer_address")]
    public string customer_address { get; set; }
    [XmlElement("customer_city")]
    public string customer_city { get; set; }
    [XmlElement("customer_state")]
    public string customer_state { get; set; }
    [XmlElement("customer_postcode")]
    public string customer_postcode { get; set; }
    [XmlElement("customer_country")]
    public string customer_country { get; set; }
    [XmlElement("customer_email")]
    public string customer_email { get; set; }
    [XmlElement("customer_phone")]
    public string customer_phone { get; set; }
    [XmlElement("shipping_last_name")]
    public string shipping_last_name { get; set; }
    [XmlElement("shipping_company")]
    public string shipping_company { get; set; }
    [XmlElement("shipping_address")]
    public string shipping_address { get; set; }
    [XmlElement("shipping_city")]
    public string shipping_city { get; set; }
    [XmlElement("shipping_state")]
    public string shipping_state { get; set; }
    [XmlElement("shipping_postcode")]
    public string shipping_postcode { get; set; }
    [XmlElement("shipping_country")]
    public string shipping_country { get; set; }
}

[Serializable]
public class Trans
{
    public string status { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string zip { get; set; }
    public string country { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string cardholdername { get; set; }
    public string ccfirst6 { get; set; }
    public string cclast4 { get; set; }
    public string cardbrand { get; set; }
    public string eci { get; set; }
    public string amount { get; set; }
    public string ipaddress { get; set; }
    public string trans_id { get; set; }
    public string thm_session_id { get; set; }
    public string ioblackbox { get; set; }
    public string cavv_present { get; set; }

}


[Serializable]
public class item
{
    // Item fields
    [XmlElement("id")]
    public string id { get; set; }
    [XmlElement("code")]
    public string code { get; set; }
    [XmlElement("name")]
    public string name { get; set; }
    [XmlElement("description")]
    public string description { get; set; }
    [XmlElement("qty")]
    public string qty { get; set; }
    [XmlElement("digital")]
    public string digital { get; set; }
    [XmlElement("discount")]
    public string discount { get; set; }
    [XmlElement("predefined")]
    public string predefined { get; set; }
    [XmlElement("realm_name")]
    public string realm_name { get; set; }
    [XmlElement("unit_price")]
    public string unit_price { get; set; }
}

[Serializable]
public class cart
{
    // Cart items
    [XmlArray("items")]
    [XmlArrayItem("item", typeof(item))]
    public item[] items { get; set; }
}

[Serializable]
public class providers
{
    [XmlElement("Trans")]
    public Trans Trans { get; set; }
}

[Serializable]
public class transaction
{
    [XmlElement("type")]
    public string type { get; set; }
    [XmlElement("response")]
    public string response { get; set; }
    [XmlElement("response_code")]
    public string response_code { get; set; }
    [XmlElement("response_text")]
    public string response_text { get; set; }
    [XmlElement("trans_id")]
    public string trans_id { get; set; }
    [XmlElement("account_id")]
    public string account_id { get; set; }
    [XmlElement("risk")]
    public providers risk { get; set; }
}

[Serializable]
public class error
{
    public string code { get; set; }
    public string text { get; set; }
}

[Serializable]
public class ukash_voucher
{
    // ukash fields
    public string number { get; set; }
    public string value { get; set; }
    public changevoucher _changevoucher { get; set; }
}

[Serializable]
public class changevoucher
{
    public string number { get; set; }
    public string currency { get; set; }
    public string amount { get; set; }
    public string usebydate { get; set; }
}

[Serializable]
public class inpay_invoice
{
    // inpay invoice
    public string status  { get; set; }
    public string transfer_amount  { get; set; }
    public string is_third_party  { get; set; }
    public string buyer_email { get; set; }
    public string order_id { get; set; }
    public string reference { get; set; }
    public string merchant { get; set; }
    public string transfer_amount_with_currency { get; set; }
    public string transfer_currency { get; set; }
    public string bank_id { get; set; }
    public string amount { get; set; }
    public string order_text { get; set; }
    public string buyer_address { get; set; }
    public string invoice_comment { get; set; }
    public string buyer_submitted_details { get; set; }
    public string delay { get; set; }
    public string currency { get; set; }
}

[Serializable]
public class bank
{
    public string id { get; set; }
    public string name { get; set; }
    public string country { get; set; }
}

[Serializable]
public class inpay_bank
{
    // inpay bank
    public string owner_address { get; set; }
    public string bank_address { get; set; }
    public string online_bank_url { get; set; }
    public string logo { get; set; }
    public inpay_bank_account inpay_bank_account { get; set; }
    public string url { get; set; }
    public string name { get; set; }
    public string country { get; set; }
    public string id { get; set; }
    public payment_instructions payment_instructions { get; set; }

}

[Serializable]
public class inpay_bank_account
{
    public string date_format { get; set; }
    public string account { get; set; }
    public string swift { get; set; }
    public string iban { get; set; }
    public string money_format { get; set; }
    public string currency { get; set; }
}

[Serializable]
public class payment_instructions
{
    public string binaries_revision { get; set; }
    public account_details account_details { get; set; }
    public string reference { get; set; }
    public string amount { get; set; }
    public string currency { get; set; }
    public string bank_name { get; set; }
    public string account_name { get; set; }
    public string account_country { get; set; }
    public string iban { get; set; }
    public string bic { get; set; }
    public string sort_code { get; set; }
    public string account_number { get; set; }
}

[Serializable]
public class account_details
{
    public field[] fields { get; set; }
}

[Serializable]
public class field
{
    public string label { get; set; }
    public string transfer_route { get; set; }
    public string value { get; set; }
    public string label_value { get; set; }

}

[Serializable]
public class avs_response
{
    public string acquirer_approvalcode { get; set; }
    public string acquirer_actioncode { get; set; }
    public string acquirer_description { get; set; }
    public string iso_actioncode { get; set; }
}

[Serializable]
public class rebill
{
    public transaction transaction { get; set; }
    public item item { get; set; }
    public order order { get; set; }
}

[Serializable]
public class settle
{
    public string response { get; set; }
    public string responsecode { get; set; }
    public string responsetext { get; set; }
    public string trans_id { get; set; }
}

[Serializable]
public class payout
{
    public string response { get; set; }
    public string responsecode { get; set; }
    public string responsetext { get; set; }
    public string trans_id { get; set; }
    public string order_id { get; set; }
    public ukash_voucher ukash_voucher { get; set; } 
}

[Serializable]
public class _void
{
    public string response { get; set; }
    public string responsecode { get; set; }
    public string responsetext { get; set; }
    public string trans_id { get; set; }
}

[Serializable]
public class upgrade
{
    public string response { get; set; }
    public string responsecode { get; set; }
    public string responsetext { get; set; }
    public string trans_id { get; set; }
}

[Serializable]
public class cancelrebill
{
    public string response { get; set; }
    public string responsecode { get; set; }
    public string responsetext { get; set; }
    public string trans_id { get; set; }
}

[Serializable]
public class response
{
    public string requestid { get; set; }
    public string enrollmentstatus { get; set; }
    public string bouncerURL { get; set; }
}

[Serializable]
public class result
{
    public string requestId { get; set; }
    public string authenticationstatus { get; set; }
    public string eci { get; set; }
    public string xid { get; set; }
    public string cavv { get; set; }
}

[Serializable]
public class blacklist
{
    public string response { get; set; } 
}

[Serializable]
public class whitelist
{
    public string response { get; set; }
}

[Serializable]
public class customer
{
    public string customer_id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string creation_date { get; set; }
}

[Serializable]
public class card
{
    public string order_id { get; set; }
    public string type { get; set; }
    public string card_number { get; set; }
    public string exp_month { get; set; }
    public string exp_year { get; set; }
}

[Serializable]
public class phoneverify
{
    public string response { get; set; }
    public string responsecode { get; set; }
    public string phoneverify_id { get; set; }
}

[Serializable]
public class logo
{
    public int image_height { get; set; }
    public string data { get; set; }
    public string url { get; set; }
    public int image_width { get; set; }
    public int image_size { get; set; }
}

[Serializable]
public class banks_info
{
    public List<inpay_bank> banks { get; set; }
    public string binaries_revision { get; set; }
}

[Serializable]
public class instructions
{
    public List<inpay_bank> banks { get; set; }
}

[Serializable]
public class iDEAL_bank
{
    public string id { get; set; }
    public string name { get; set; }
    public string country { get; set; }
}

[Serializable]
public class iDEAL_banks
{
    public iDEAL_bank[] banks { get; set; }
}

[Serializable]
public class reconciliation_services
{
    public order[] orders { get; set; }
}

[Serializable]
public class fraud
{
    public string trans_id { get; set; }
    public string client_id { get; set; }
    public string client { get; set; }
    public string card_number { get; set; }
    public string amount { get; set; }
    public string currency { get; set; }
    public string card_type { get; set; }
    public string trans_date { get; set; }
    public string import_date { get; set; }
    public string action { get; set; }
    public string customer_name { get; set; }
    public string email { get; set; }
    public string ip_address { get; set; }
    public string reason_code { get; set; }
    public string reason { get; set; }
    public string reference { get; set; }
    public string acquirer_trans_id { get; set; }
}

[Serializable]
public class fraud_date_retrieval
{
    public fraud[] frauds { get; set; }
}

[Serializable]
public class chargeback
{
    public string chargeback_date { get; set; }
    public string import_date { get; set; }
    public string client_id { get; set; }
    public string client { get; set; }
    public string trans_id { get; set; }
    public string trans_type { get; set; }
    public string trans_amount { get; set; }
    public string card_type { get; set; }
    public string card_number { get; set; }
    public string card_category { get; set; }
    public string card_sub_category { get; set; }
    public string card_issuing_bank { get; set; }
    public string amount { get; set; }
    public string currency { get; set; }
    public string country { get; set; }
    public string customer_name { get; set; }
    public string email { get; set; }
    public string reference { get; set; }
    public string reason_code { get; set; }
    public string reason { get; set; }
}

[Serializable]
public class chargebacks
{
    public chargeback chargeback { get; set; }
    public chargeback representment { get; set; }
    public chargeback reversal { get; set; }
}

[Serializable]
public class customers
{
    public string num_records { get; set; }
    public customer[] customer_set { get; set; }
}

[Serializable]
public class airlinedata
{
    public string trans_id { get; set; }
    public string restricted_ticket_indicator { get; set; }
    public string passenger_name { get; set; }
    public string issue_date { get; set; }
    public string travel_agency_name { get; set; }
    public string travel_agency_code { get; set; }
    public string ticket_number { get; set; }
    public string customer_code { get; set; }
    public string issuing_carrier { get; set; }
    public string reservation_system { get; set; }
    public string total_fare { get; set; }
    public string total_taxes { get; set; }
    public string total_fee { get; set; }
    public string conjunction_ticket { get; set; }
    public string exchange_ticket { get; set; }
    public string coupon_number { get; set; }
    public string service_class { get; set; }
    public string travel_date { get; set; }
    public string carrier_code { get; set; }
    public string stopover_code { get; set; }
    public string city_of_origin_airport_code { get; set; }
    public string city_of_destination_airport_code { get; set; }
    public string flight_number { get; set; }
    public string departure_time { get; set; }
    public string departure_time_segment { get; set; }
    public string arrival_time { get; set; }
    public string arrival_time_segment { get; set; }
    public string fare_basis_code { get; set; }
    public string fare { get; set; }
    public string taxes { get; set; }
    public string fee { get; set; }
    public string endorsement_or_restrictions { get; set; }
}

[Serializable]
public class airlinetrans
{
    public string num_records { get; set; }
    public airlinedata[] airlinedata { get; set; }
}





public class APIResponses
{
    public orders my_orders;
  	public APIResponses(string responseXml)
	{
        try
        {
            XmlSerializer ser = new XmlSerializer(typeof(orders));
            my_orders = (orders)ser.Deserialize(new StringReader(responseXml));
        }
        catch (Exception ex)
        {
        }

        return;
	}
}
