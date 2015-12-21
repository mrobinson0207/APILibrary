using System;
using System.Xml;
using System.IO;
// Response classes

[Serializable]
public class order
{
    // Common Fields - order
    public string order_id { get; set; }
    public string order_reference { get; set; }
    public string order_datetime { get; set; }
    public string order_total { get; set; }
    public string order_currency { get; set; }
    public string order_status { get; set; }
    public string test_transaction { get; set; }
    public string trans_id { get; set; }
    public string account_id { get; set; }
    public string resp_code { get; set; }
    public string resp_text { get; set; }
    public string redirect_url { get; set; }
    public cart[] carts { get; set; }
    public transaction[] transactions { get; set; }
    public avs_response avs_response { get; set; }
    public string customer_first_name { get; set; }
    public string customer_last_name { get; set; }
    public string customer_company { get; set; }
    public string customer_address { get; set; }
    public string customer_city { get; set; }
    public string customer_phone { get; set; }
    public string shipping_first_name { get; set; }
    public string shipping_last_name { get; set; }
    public string shipping_company { get; set; }
    public string shipping_address { get; set; }
    public string shipping_city { get; set; }
    public string shipping_state { get; set; }
    public string shipping_postcode { get; set; }
    public string shipping_country { get; set; }
    public item[] items { get; set; }
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
    public string id { get; set; }
    public string code { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string qty { get; set; }
    public string digital { get; set; }
    public string discount { get; set; }
    public string predefined { get; set; }
    public string realm_name { get; set; }
}

[Serializable]
public class cart
{
    // Cart items
    public item [] items  { get; set; }
}

[Serializable]
public class providers
{
    public Trans Trans { get; set; }
}

[Serializable]
public class transaction
{
    public string type { get; set; }
    public string response { get; set; }
    public string response_code { get; set; }
    public string response_text { get; set; }
    public string trans_id { get; set; }
    public string account_id { get; set; }
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
    public URL bouncerURL { get; set; }
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

public class APIResponses
{
    // Response types
    string order_resp = "order";
    string errors_resp = "errors";
    string decline_resp = "decline";

    // Common Fields - order
    string order_id = "order_id";
    string order_datetime = "order_datetime";
    string order_total = "order_total";
    string order_status = "order_status";
    string test_transaction = "test_transaction";
    string trans_id = "trans_id";
    string account_id = "account_id";
    string resp_code = "response_code";
    string resp_text = "response_text";
    string redirect_url = "redirect_url";

    // Cart fields
    string cart_enc = "cart";
    string cart_item = "item";
    string cart_code = "code";
    string cart_name = "name";
    string cart_qty = "qty";
    string cart_digital = "digital";
    string cart_discount = "discount";
    string cart_predefined = "predefined";
    string cart_desc = "description";

    // Transaction fields
    string trans_enc = "transaction";
    string trans_type = "type";

    // Error response
    string error_code = "code";
    string error_text = "text";

    // Decline response - do we need this???
    string decline_type = "type";
    string decline_code = "response_code";
    string decline_text = "response_text";

    // ukash fields
    string ukash_voucher = "ukash_voucher";
    string u_number = "number";
    string u_value = "value";
    string change_voucher = "changevoucher";
    string currency = "currency";
    string amount = "amount";
    string useby = "usebydate";

    // inpay fields
    string inpay_inv = "inpay_invoice";
    string inpay_bank = "inpay_bank";

    // inpay invoice
    string inpay_inv_fields = {"status", "transfer-amount", "is-third-party", "buyer-email", "order-id", "reference", "merchant", "transfer-amount-with-currency",
                              "transfer-currency", "bank-id", "amount", "order-text", "buyer-address", "invoice-comment", "buyer-submitted-details", "delay", "currency"};

    // inpay bank
    string inpay_bank_fields = {"owner-address", "bank-address", "online-bank-url", "logo", "inpay_bank_account", "url", "name", "country", "id", "payment-instructions"};

    // UATP 
    string uatp_avs = "avs_response";
    string uatp_fields = {"acquirer_approvalcode", "acquirer_actioncode", "acquirer_description", "iso_actioncode"};

    // Bank transfer
    string bank_transfer = "payment_instructions";
    string bank_trans_fields = {"reference", "amount", "currency", "bank_name", "account_name", "account_country", "iban", "bic", "sort_code", "account_number"};

    // iSign 
    string isign_type = "isignthis_instructions";
    string isign_fields = {"redirect_url", "mode"};

    // Order Settle - common for order credit, order CFT, order void, payout (except ukash: add voucher), rebill instant upgrade
    string settle_type = {"settle", "credit", "cft", "void", "payout", "upgrade"};
    string settle_fields = {"response", "responsecode", "responsetext", "trans_id"};

    // Order Payout - CFT without previous order
    string payout_type = "payout";
    string payout_fields = {"response", "responsecode", "responsetext", "trans_id", "order_id"};

    // Order Rebill-cancel
    string settle_type = {"cancelrebill"};
    string settle_fields = {"response", "responsecode", "responsetext"};

    // VBV/3D Secure Authen
    string vbv_auth_type = "response";
    string vbv_auth_fields = {"requestid", "enrollmentstatus", "bouncerURL"};

    // VBV/3D retrieval
    string vbv_retrieval_type = "result";
    string vbv_retrieval_fields = {"requestId", "authenticationstatus", "eci", "xid", "cavv"};

    // Add/remove Blacklist, Whitelist
    string blacklist_type = {"blacklist", "whitelist"};
    string blacklist_fields = {"response"};

    // Create/update customer
    string customer_type = "customer";
    string customer_fields = {"customer_id", "name", "email"};

    // Get Customer Cards
    string cards_type = "cards";
    string cards_fields = {"num_records", "card"};
    string card_fields = {"order_id", "type", "card_number", "exp_month", "exp_year"};

    // Phone Verify
    string phone_type = "phoneverify";
    string phone_fields = {"response", "responsecode", "phoneverify_id"};

    // INPay Get banks
    string banks_type = "banks_info";
    string banks_fields = {"banks", "binaries-revision"};
    string banks_subfield = "bank";
    string bank_fields = {"owner-address", "bank-address", "online-bank-url", "logo", "inpay-bank-account", "url", "name", "id"};
    string inpay_bank_account_fields = {"date-format", "account", "swift", "iban", "money-format", "currency"};

    // INPay getinstructions
    string get_instructions_type = "instructions";
    string get_instructions_fields = {"inpay_bank"};
    string inpay_bank_fields = {"online-bank-url", "logo", "inpay-bank-account", "id", "payment-instructions"};
    string payment_instructions_fields = {"binaries-revision", "account-details"};
    string account_details = "fields";
    string account_details_fields = "field";
    string account_details_fields_field = {"label", "transfer-route", "value", "label-value"};

    // iDEAL Getbanks
    string ideal_banks_type = "banks";
    string ideal_banks_field = "bank";
    string ideal_banks_bank = { "id", "name", "country" };

	public void APIResponses(string responseXml)
	{
        XDocument xResp = XDocument.Parse(responseXml);

        // Create the response elements
        var orders = (from x in xResp.Descendants("order")
                      select new Order
                      {
                          order_id = x.Element("order_id").Value,
                          order_reference = x.Element("order_reference").Value,
                          order_datetime = x.Element("order_datetime").Value,
                          order_total = x.Element("order_total").Value,
                          order_currency = x.Element("order_currency").Value,
                          order_status = x.Element("order_status").Value,
                          test_transaction = x.Element("test_transaction").Value,
                          trans_id = x.Element("trans_id").Value,
                          account_id = x.Element("account_id").Value,
                          resp_code = x.Element("resp_code").Value,
                          resp_text = x.Element("resp_text").Value,
                          redirect_url = x.Element("redirect_url").Value,
                          // carts TBD
                          // transactions TBD
                          // avs_response
                          customer_first_name = x.Element("customer_first_name").Value,
                          customer_last_name = x.Element("customer_last_name").Value,
                          customer_company = x.Element("customer_company").Value,
                          customer_address = x.Element("customer_address").Value,
                          customer_city = x.Element("customer_city").Value,
                          customer_phone = x.Element("customer_phone").Value,
                          shipping_first_name = x.Element("shipping_first_name").Value,
                          shipping_last_name = x.Element("shipping_last_name").Value,
                          shipping_company = x.Element("shipping_company").Value,
                          shipping_address = x.Element("shipping_address").Value,
                          shipping_city = x.Element("shipping_city").Value,
                          shipping_state = x.Element("shipping_state").Value,
                          shipping_postcode = x.Element("shipping_postcode").Value,
                          shipping_country = x.Element("shipping_country").Value
                          // items TBD
                      });

        return;
	}
}
