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
    /*[XmlArrayItem("customer_info", typeof(customer_info))]
    public customer_info customer { get; set; }
    [XmlArrayItem("shipping_info", typeof(shipping_info))]
    public shipping_info shipping { get; set; } */
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
public class shipping_info
{
    // Shipping fields
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

// Split this into customer and shipping??
[Serializable]
public class customer_info
{
    // Customer fields
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
}

[Serializable]
public class Trans
{
    [XmlElement("status")]
    public string status { get; set; }
    [XmlElement("city")]
    public string city { get; set; }
    [XmlElement("state")]
    public string state { get; set; }
    [XmlElement("zip")]
    public string zip { get; set; }
    [XmlElement("country")]
    public string country { get; set; }
    [XmlElement("email")]
    public string email { get; set; }
    [XmlElement("phone")]
    public string phone { get; set; }
    [XmlElement("cardholdername")]
    public string cardholdername { get; set; }
    [XmlElement("ccfirst6")]
    public string ccfirst6 { get; set; }
    [XmlElement("cclast4")]
    public string cclast4 { get; set; }
    [XmlElement("cardbrand")]
    public string cardbrand { get; set; }
    [XmlElement("eci")]
    public string eci { get; set; }
    [XmlElement("amount")]
    public string amount { get; set; }
    [XmlElement("ipaddress")]
    public string ipaddress { get; set; }
    [XmlElement("trans_id")]
    public string trans_id { get; set; }
    [XmlElement("thm_session_id")]
    public string thm_session_id { get; set; }
    [XmlElement("ioblackbox")]
    public string ioblackbox { get; set; }
    [XmlElement("cavv_present")]
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
    [XmlElement("rebill")]
    public rebill rebill { get; set; }
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
    [XmlElement("redirect_url")]
    public string redirect_url { get; set; }
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
    [XmlElement("code")]
    public string code { get; set; }
    [XmlElement("text")]
    public string text { get; set; }
}

[XmlRoot("decline"), Serializable]
public class decline
{
    [XmlElement("transaction")]
    public transaction transaction { get; set; }
}

[Serializable]
public class ukash_voucher
{
    // ukash fields
    [XmlElement("number")]
    public string number { get; set; }
    [XmlElement("currency")]
    public string currency { get; set; }
    [XmlElement("amount")]
    public string amount { get; set; }
    [XmlElement("expirydate")]
    public string expirydate { get; set; }
}

[Serializable]
public class changevoucher
{
    [XmlElement("number")]
    public string number { get; set; }
    [XmlElement("currency")]
    public string currency { get; set; }
    [XmlElement("amount")]
    public string amount { get; set; }
    [XmlElement("usebydate")]
    public string usebydate { get; set; }
}

[Serializable]
public class inpay_invoice
{
    // inpay invoice
    [XmlElement("status")]
    public string status { get; set; }
    [XmlElement("transfer_amount")]
    public string transfer_amount { get; set; }
    [XmlElement("is_third_party")]
    public string is_third_party { get; set; }
    [XmlElement("buyer_email")]
    public string buyer_email { get; set; }
    [XmlElement("order_id")]
    public string order_id { get; set; }
    [XmlElement("reference")]
    public string reference { get; set; }
    [XmlElement("merchant")]
    public string merchant { get; set; }
    [XmlElement("transfer_amount_with_currency")]
    public string transfer_amount_with_currency { get; set; }
    [XmlElement("transfer_currency")]
    public string transfer_currency { get; set; }
    [XmlElement("bank_id")]
    public string bank_id { get; set; }
    [XmlElement("amount")]
    public string amount { get; set; }
    [XmlElement("order_text")]
    public string order_text { get; set; }
    [XmlElement("buyer_address")]
    public string buyer_address { get; set; }
    [XmlElement("invoice_comment")]
    public string invoice_comment { get; set; }
    [XmlElement("buyer_submitted_detail")]
    public string buyer_submitted_details { get; set; }
    [XmlElement("delay")]
    public string delay { get; set; }
    [XmlElement("currency")]
    public string currency { get; set; }
}

[Serializable]
public class bank
{
    [XmlElement("id")]
    public string id { get; set; }
    [XmlElement("name")]
    public string name { get; set; }
    [XmlElement("country")]
    public string country { get; set; }
}

[Serializable]
public class inpay_bank
{
    // inpay bank
    [XmlElement("owner_address")]
    public string owner_address { get; set; }
    [XmlElement("bank_address")]
    public string bank_address { get; set; }
    [XmlElement("online_bank_url")]
    public string online_bank_url { get; set; }
    [XmlElement("logo")]
    public string logo { get; set; }
    [XmlElement("inpay_bank_account")]
    public inpay_bank_account inpay_bank_account { get; set; }
    [XmlElement("url")]
    public string url { get; set; }
    [XmlElement("name")]
    public string name { get; set; }
    [XmlElement("country")]
    public string country { get; set; }
    [XmlElement("id")]
    public string id { get; set; }
    [XmlElement("payment_instructions")]
    public payment_instructions payment_instructions { get; set; }

}

[Serializable]
public class inpay_bank_account
{
    [XmlElement("date_format")]
    public string date_format { get; set; }
    [XmlElement("account")]
    public string account { get; set; }
    [XmlElement("swift")]
    public string swift { get; set; }
    [XmlElement("iban")]
    public string iban { get; set; }
    [XmlElement("money_format")]
    public string money_format { get; set; }
    [XmlElement("currency")]
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

/*[Serializable]
public class rebill
{
    public transaction transaction { get; set; }
    public item item { get; set; }
    public order order { get; set; }
}*/
[Serializable]
public class rebill
{
    [XmlElement("rebill_id")]
    public string rebill_id { get; set; }
    [XmlElement("rebill_period")]
    public string rebill_period { get; set; }
    [XmlElement("rebill_count")]
    public string rebill_count { get; set; }
    [XmlElement("rebills_remaining")]
    public string rebills_remaining { get; set; }
    [XmlElement("initial_price")]
    public string initial_price { get; set; }
    [XmlElement("next_due")]
    public string next_due { get; set; }
}

[XmlRoot("settle"), Serializable]
public class settle
{
    [XmlElement("response")]
    public string response { get; set; }
    [XmlElement("responsecode")]
    public string responsecode { get; set; }
    [XmlElement("responsetext")]
    public string responsetext { get; set; }
    [XmlElement("trans_id")]
    public string trans_id { get; set; }
}

[XmlRoot("credit"), Serializable]
public class credit
{
    [XmlElement("response")]
    public string response { get; set; }
    [XmlElement("responsecode")]
    public string responsecode { get; set; }
    [XmlElement("responsetext")]
    public string responsetext { get; set; }
    [XmlElement("trans_id")]
    public string trans_id { get; set; }
}

[XmlRoot("cft"), Serializable]
public class cft
{
    [XmlElement("response")]
    public string response { get; set; }
    [XmlElement("responsecode")]
    public string responsecode { get; set; }
    [XmlElement("responsetext")]
    public string responsetext { get; set; }
    [XmlElement("trans_id")]
    public string trans_id { get; set; }
}

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

[XmlRoot("void"), Serializable]
public class _void
{
    [XmlElement("response")]
    public string response { get; set; }
    [XmlElement("responsecode")]
    public string responsecode { get; set; }
    [XmlElement("responsetext")]
    public string responsetext { get; set; }
    [XmlElement("trans_id")]
    public string trans_id { get; set; }
}

[XmlRoot("upgrade"), Serializable]
public class upgrade
{
    [XmlElement("response")]
    public string response { get; set; }
    [XmlElement("responsecode")]
    public string responsecode { get; set; }
    [XmlElement("responsetext")]
    public string responsetext { get; set; }
    [XmlElement("trans_id")]
    public string trans_id { get; set; }
}

[XmlRoot("cancelrebill"), Serializable]
public class cancelrebill
{
    [XmlElement("response")]
    public string response { get; set; }
    [XmlElement("responsecode")]
    public string responsecode { get; set; }
    [XmlElement("responsetext")]
    public string responsetext { get; set; }
    [XmlElement("trans_id")]
    public string trans_id { get; set; }
}

[XmlRoot("response"), Serializable]
public class response
{
    [XmlElement("requestid")]
    public string requestid { get; set; }
    [XmlElement("enrollmentstatus")]
    public string enrollmentstatus { get; set; }
    [XmlElement("bouncerURL")]
    public string bouncerURL { get; set; }
}

[XmlRoot("result"), Serializable]
public class result
{
    [XmlElement("requestid")]
    public string requestId { get; set; }
    [XmlElement("authenticationstatus")]
    public string authenticationstatus { get; set; }
    [XmlElement("eci")]
    public string eci { get; set; }
    [XmlElement("xid")]
    public string xid { get; set; }
    [XmlElement("cavv")]
    public string cavv { get; set; }
}

[XmlRoot("blacklist"), Serializable]
public class blacklist
{
    [XmlElement("response")]
    public string response { get; set; } 
}

[XmlRoot("whitelist"), Serializable]
public class whitelist
{
    [XmlElement("response")]
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
    public inpay_bank[] banks { get; set; }
    public string binaries_revision { get; set; }
}

[Serializable]
public class instructions
{
    public inpay_bank[] banks { get; set; }
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

[XmlRoot("airlinetrans"), Serializable]
public class airlinetrans
{
    [XmlElement("num_records")]
    public string num_records { get; set; }
    [XmlArrayItem("airlinedata", typeof(airlinedata))]
    public airlinedata[] airlinedata { get; set; }
}

[XmlRoot("failure"), Serializable]
public class failure
{
    [XmlArray("errors")]
    [XmlArrayItem("error", typeof(error))]
    public error[] errors { get; set; }
}


public class APIResponses
{
    public orders resp_orders;
    public failure resp_failure;
    public decline resp_decline;
    public settle resp_settle;
    public credit resp_credit;
    public cft resp_cft;
    public _void resp_void;
    public payout resp_payout;
    public upgrade resp_upgrade;
    public cancelrebill resp_cancelrebill;
    public response resp_response;
    public result resp_result;
    public blacklist resp_blacklist;
    public whitelist resp_whitelist;
    public string resp_xml;

  	public APIResponses(string responseXml)
	{
        // Take a copy of the xml - this can be presented if the deserialize fails
        resp_xml = String.Copy(responseXml);

        // Determine the type of response - this will be the first xml type after the header
        int headerStart = responseXml.IndexOf('>');
        headerStart += responseXml.Substring(headerStart).IndexOf('<') + 1;
        int typeEnd = responseXml.Substring(headerStart).IndexOf('>');
        if (typeEnd == 0)
            return;
        string respType = responseXml.Substring(headerStart, typeEnd);
        XmlSerializer ser;
        try
        {
            switch (respType)
            {
                case "orders":
                    ser = new XmlSerializer(typeof(orders));
                    resp_orders = (orders)ser.Deserialize(new StringReader(responseXml));
                    break;
                case "failure":
                    ser = new XmlSerializer(typeof(failure));
                    resp_failure = (failure)ser.Deserialize(new StringReader(responseXml));
                    break;
                case "decline":
                    ser = new XmlSerializer(typeof(decline));
                    resp_decline = (decline)ser.Deserialize(new StringReader(responseXml));
                    break;
                case "settle":
                    ser = new XmlSerializer(typeof(settle));
                    resp_settle = (settle)ser.Deserialize(new StringReader(responseXml));
                    break;
                case "credit":
                    ser = new XmlSerializer(typeof(credit));
                    resp_credit = (credit)ser.Deserialize(new StringReader(responseXml));
                    break;
                case "cft":
                    ser = new XmlSerializer(typeof(cft));
                    resp_cft = (cft)ser.Deserialize(new StringReader(responseXml));
                    break;
                case "void":
                    ser = new XmlSerializer(typeof(_void));
                    resp_void = (_void)ser.Deserialize(new StringReader(responseXml));
                    break;
                case "payout":
                    ser = new XmlSerializer(typeof(payout));
                    resp_payout = (payout)ser.Deserialize(new StringReader(responseXml));
                    break;
                case "upgrade":
                    ser = new XmlSerializer(typeof(upgrade));
                    resp_upgrade = (upgrade)ser.Deserialize(new StringReader(responseXml));
                    break;
                case "cancelrebill":
                    ser = new XmlSerializer(typeof(cancelrebill));
                    resp_cancelrebill = (cancelrebill)ser.Deserialize(new StringReader(responseXml));
                    break;
                case "response":
                    ser = new XmlSerializer(typeof(response));
                    resp_response = (response)ser.Deserialize(new StringReader(responseXml));
                    break;
                case "result":
                    ser = new XmlSerializer(typeof(result));
                    resp_result = (result)ser.Deserialize(new StringReader(responseXml));
                    break;
                case "blacklist":
                    ser = new XmlSerializer(typeof(blacklist));
                    resp_blacklist = (blacklist)ser.Deserialize(new StringReader(responseXml));
                    break;
                case "whitelist":
                    ser = new XmlSerializer(typeof(whitelist));
                    resp_whitelist = (whitelist)ser.Deserialize(new StringReader(responseXml));
                    break;

                default:
                    // not found - unhandled
                    break;
            }
        }
        catch (Exception ex)
        {
            // log any exception
            string logString = "Exception: " + ex.Message;
        }

        return;
	}
}
