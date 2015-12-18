using System;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Xml.Resolvers;
using System.Collections.Generic;
using System.Xml.Serialization;

public class UnitTests
{
    string genericHdr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
    public class orderResponses
    {
        public string orderSearch = "<orders><num_records>2</num_records><order><order_id>1393262</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 06:20:25</order_datetime><order_total>2.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james%40test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1407252</id><code>rbtest2</code><name>Rebill Test 2 - Rebill every week</name><description>A test rebilling item, rebilling every week</description><qty>1</qty><digital>1</digital><discount>0</discount><rebill><rebill_id>1407252</rebill_id><rebill_period>7</rebill_period><rebill_count>10</rebill_count><rebill_count>10</rebill_count><rebills_remaining>10</rebills_remaining><initial_price>0.00</initial_price><next_due>2015-12-21</next_due></rebill></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214150352</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1393252</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 06:11:41</order_datetime><order_total>1.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1407242</id><code>rbtest1</code><name>Rebill Test 1 - Rebill every Day</name><description>A test rebill item, rebilling every day</description><qty>1</qty><digital>1</digital><discount>0</discount><rebill><rebill_id>1407242</rebill_id><rebill_period>1</rebill_period><rebill_count>12</rebill_count><rebill_count>12</rebill_count><rebills_remaining>10</rebills_remaining><initial_price>1.00</initial_price><next_due>2015-12-17</next_due></rebill></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214150222</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1393232</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 06:11:14</order_datetime><order_total>1.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1407222</id><code>TEST123</code><name>Test Product</name><description>Test</description><qty>1</qty><digital>1</digital><discount>0</discount><unit_price>1.00</unit_price></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214150202</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1393222</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 06:10:45</order_datetime><order_total>1.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1407212</id><code>rbtest1</code><name>Rebill Test 1 - Rebill every Day</name><description>A test rebill item, rebilling every day</description><qty>1</qty><digital>1</digital><discount>0</discount><rebill><rebill_id>1407212</rebill_id><rebill_period>1</rebill_period><rebill_count>12</rebill_count><rebill_count>12</rebill_count><rebills_remaining>10</rebills_remaining><initial_price>1.00</initial_price><next_due>2015-12-17</next_due></rebill></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214150182</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1393212</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 06:10:04</order_datetime><order_total>1.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1407202</id><code>rbtest1</code><name>Rebill Test 1 - Rebill every Day</name><description>A test rebill item, rebilling every day</description><qty>1</qty><digital>1</digital><discount>0</discount><rebill><rebill_id>1407202</rebill_id><rebill_period>1</rebill_period><rebill_count>12</rebill_count><rebill_count>12</rebill_count><rebills_remaining>10</rebills_remaining><initial_price>1.00</initial_price><next_due>2015-12-17</next_due></rebill></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214150172</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1393102</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 04:23:38</order_datetime><order_total>1.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1407092</id><code>TEST123</code><name>Test Product</name><description>Test</description><qty>1</qty><digital>1</digital><discount>0</discount><unit_price>1.00</unit_price></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214148992</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1393082</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 04:11:43</order_datetime><order_total>1.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1407072</id><code>TEST123</code><name>Test Product</name><description>Test</description><qty>1</qty><digital>1</digital><discount>0</discount><unit_price>1.00</unit_price></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214148852</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1393062</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 04:10:34</order_datetime><order_total>1.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1407052</id><code>TEST123</code><name>Test Product</name><description>Test</description><qty>1</qty><digital>1</digital><discount>0</discount><unit_price>1.00</unit_price></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214148822</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1393002</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 03:16:24</order_datetime><order_total>1.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1406992</id><code>TEST123</code><name>Test Product</name><description>Test</description><qty>1</qty><digital>1</digital><discount>0</discount><unit_price>1.00</unit_price></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214148222</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1392862</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 01:04:12</order_datetime><order_total>1.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1406852</id><code>TEST123</code><name>Test Product</name><description>Test</description><qty>1</qty><digital>1</digital><discount>0</discount><unit_price>1.00</unit_price></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214146762</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1392852</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 01:03:14</order_datetime><order_total>1.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1406842</id><code>TEST123</code><name>Test Product</name><description>Test</description><qty>1</qty><digital>1</digital><discount>0</discount><unit_price>1.00</unit_price></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214146742</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1392842</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 01:03:05</order_datetime><order_total>55.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1406832</id><code>1235123</code><name>testitenm</name><description/><qty>1</qty><digital>0</digital><discount>0</discount><unit_price>55.00</unit_price></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214146732</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1392822</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 00:58:39</order_datetime><order_total>1.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1406812</id><code>TEST123</code><name>Test Product</name><description>Test</description><qty>1</qty><digital>1</digital><discount>0</discount><unit_price>1.00</unit_price></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214146662</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1392772</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 00:12:24</order_datetime><order_total>1.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1406762</id><code>TEST123</code><name>Test Product</name><description>Test</description><qty>1</qty><digital>1</digital><discount>0</discount><unit_price>1.00</unit_price></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214146152</trans_id><account_id>4003144</account_id></transaction></order></orders>";
        public orders testSearch = new orders
        {
            num_records = "1",
            order = new order[] { 
            new order { order_id = "1393262",  order_reference = "12315", order_datetime = "2015-12-14 06:20:25", order_total = "2.00", order_currency = "USD",
            test_transaction = "1", order_status = "Pending", customer_email = "james%40test.com", 
            items = new item[] { new item { id = "1407252", code = "rbtest2", name = "Rebill Test 2 - Rebill every week", 
                description = "A test rebilling item, rebilling every week", qty = "1", digital = "1", discount = "0"}}}}
        };
    }
    public class payoutResponses
    { }
    public class vbvmc3dResponses
    { }
    public class blacklistResponses
    {
        public string blacklistStr = "<blacklist><response>A</response></blacklist>";
        public blacklist blacklistObj = new blacklist { response = "A" };
    }
    public class whitelistResponses
    {
        public string whitelistStr = "<whitelist><response>A</response></whitelist>";
        public whitelist whitelistObj = new whitelist { response = "A" };
    }
    public class customerResponses
    { }
    public class phoneVerifyResponses
    { }
    public class inpayResponses
    { }
    public class idealabnResponses
    { }
    public class transactionResponses
    { }
    public class riskResponses
    { }
    public class chargebackResponses
    { }
    public class airlineResponses
    { }
    public class failureResponses
    {
        public string failureStr = "<failure><errors><error><code>OP800</code><text>Invalid path. Requested method does not exist. Please see API documentation.</text></error></errors></failure>";
        public failure failureObj = new failure { errors = new error[] { new error { code = "OP800", text = "Invalid path. Requested method does not exist. Please see API documentation." } } };
    }
    public UnitTests(string testType, string subType)
    {
        // Construct tests
        string testString = genericHdr;
        APIResponses apiResp;
        bool testPassed = true;
        bool testAll = false;
        int index = 0;
        string[] testCases = { "order", "payout", "vbvmc3d", "blacklist", "whitelist", "customer", "phoneverify", "inpay", "idealabn", "transaction", "risk", "chargeback", "airline", "failure" };
        List<string> failCases = new List<string>();

        if (String.IsNullOrEmpty(testType) || (testType == "all"))
        {
            testType = "order";
            testAll = true;
        }

        while (true)
        {
            switch (testType)
            {
                case "order":
                    break;
                case "payout":
                    break;
                case "vbvmc3d":
                    break;
                case "blacklist":
                    {
                        blacklistResponses blkResp = new blacklistResponses();
                        apiResp = new APIResponses(String.Concat(testString, blkResp.blacklistStr));
                        blacklist blk = apiResp.resp_blacklist;
                        blacklist comp = blkResp.blacklistObj;
                        if (blk.response != comp.response)
                        {
                            testPassed = false;
                        }
                        break;
                    }
                case "whitelist":
                    {
                        whitelistResponses whiteResp = new whitelistResponses();
                        apiResp = new APIResponses(String.Concat(testString, whiteResp.whitelistStr));
                        whitelist blk = apiResp.resp_whitelist;
                        whitelist comp = whiteResp.whitelistObj;
                        if (blk.response != comp.response)
                        {
                            testPassed = false;
                        }
                        break;
                    }
                case "customer":
                    break;
                case "phoneverify":
                    break;
                case "inpay":
                    break;
                case "idealabn":
                    break;
                case "transaction":
                    break;
                case "risk":
                    break;
                case "chargeback":
                    break;
                case "airline":
                    break;
                case "failure":
                    {
                        failureResponses failResp = new failureResponses();
                        apiResp = new APIResponses(String.Concat(testString, failResp.failureStr));
                        failure fail = apiResp.resp_failure;
                        failure comp = failResp.failureObj;
                        if (fail.errors.Length == comp.errors.Length)
                        {
                            for (int i = 0; i < comp.errors.Length; i++)
                            {
                                if ((fail.errors[i].code != comp.errors[i].code) ||
                                    (fail.errors[i].text != comp.errors[i].text))
                                {
                                    testPassed = false;
                                    break;
                                }
                            }
                        }

                        break;
                    }
                default:
                    break;
            }

            if (!testPassed)
            {
                failCases.Add("testType");
                testPassed = true;
            }

            if (!testAll || (++index == testCases.Length))
            {
                testAll = false;
                break;
            }
            testType = testCases[index];
        }

        // If the failCases list has been populated, show the failures
        if (failCases.Count > 0)
        {
            System.Console.WriteLine("The following test cases failed:");
            foreach (var fail in failCases)
            {
                System.Console.WriteLine(fail);
            }
        }
    }

}
