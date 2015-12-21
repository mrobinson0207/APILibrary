﻿using System;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Xml.Resolvers;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Reflection;

public class UnitTests
{
    string genericHdr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
    public class orderResponses
    {
        public string orderSearchStr = "<orders><num_records>2</num_records><order><order_id>1393262</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 06:20:25</order_datetime><order_total>2.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james%40test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1407252</id><code>rbtest2</code><name>Rebill Test 2 - Rebill every week</name><description>A test rebilling item, rebilling every week</description><qty>1</qty><digital>1</digital><discount>0</discount><rebill><rebill_id>1407252</rebill_id><rebill_period>7</rebill_period><rebill_count>10</rebill_count><rebill_count>10</rebill_count><rebills_remaining>10</rebills_remaining><initial_price>0.00</initial_price><next_due>2015-12-21</next_due></rebill></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214150352</trans_id><account_id>4003144</account_id></transaction></order><order><order_id>1393252</order_id><order_reference>12315</order_reference><order_datetime>2015-12-14 06:11:41</order_datetime><order_total>1.00</order_total><order_currency>USD</order_currency><test_transaction>1</test_transaction><order_status>Pending</order_status><customer_first_name/><customer_last_name/><customer_company/><customer_address/><customer_city/><customer_state/><customer_postcode/><customer_country/><customer_email>james@test.com</customer_email><customer_phone/><shipping_first_name/><shipping_last_name/><shipping_company/><shipping_address/><shipping_city/><shipping_state/><shipping_postcode/><shipping_country/><items><item><id>1407242</id><code>rbtest1</code><name>Rebill Test 1 - Rebill every Day</name><description>A test rebill item, rebilling every day</description><qty>1</qty><digital>1</digital><discount>0</discount><rebill><rebill_id>1407242</rebill_id><rebill_period>1</rebill_period><rebill_count>12</rebill_count><rebill_count>12</rebill_count><rebills_remaining>10</rebills_remaining><initial_price>1.00</initial_price><next_due>2015-12-17</next_due></rebill></item></items><transaction><type>auth</type><response>A</response><response_code>OP000</response_code><response_text>ApproveTEST</response_text><trans_id>214150222</trans_id><account_id>4003144</account_id></transaction></order></orders>";
        public orders orderSearchObj= new orders
        {
            num_records = "2",
            order = new order[] { 
            new order { order_id = "1393262",  order_reference = "12315", order_datetime = "2015-12-14 06:20:25", order_total = "2.00", order_currency = "USD",
            test_transaction = "1", order_status = "Pending", customer_email = "james%40test.com",
            items = new item[] { new item { id = "1407252", code = "rbtest2", name = "Rebill Test 2 - Rebill every week", 
                description = "A test rebilling item, rebilling every week", qty = "1", digital = "1", discount = "0",
                rebill = new rebill { rebill_id = "1407252", rebill_period = "7", rebill_count = "10", rebills_remaining ="10", initial_price = "0.00", next_due = "2015-12-21"}}}},
            new order { order_id = "1393252", order_reference = "12315", order_datetime = "2015-12-14 06:11:41", order_total = "1.00", order_currency = "USD",
            test_transaction = "1", order_status = "Pending", customer_email = "james@test.com",
            items = new item[] { new item { id = "1407242", code = "rbtest1", name = "Rebill Test 1 - Rebill every Day", 
                description = "A test rebill item, rebilling every day", qty = "1", digital = "1", discount = "0", 
                rebill = new rebill { rebill_id = "1407242", rebill_period = "1", rebill_count = "12", rebills_remaining ="10", initial_price = "1.00", next_due = "2015-12-17"}}}},
            }
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

    
    public void CompareProperties(object prop1, object prop2, List<PropertyInfo>diffList)
    {
        int len1 = prop1.GetType().GetProperties().Length;
        int len2 = prop2.GetType().GetProperties().Length;
        int propCount = 0;
        object testProp = (len2 > len1) ? prop2 : prop1;
        int testLen = (len2 > len1) ? len2 : len1;
        PropertyInfo[] propInfo1 = prop1.GetType().GetProperties();
        PropertyInfo[] propInfo2 = prop2.GetType().GetProperties();
        while (propCount < testLen)
        {
            if (propCount > len1 && propCount <= len2)
            {
                PropertyInfo property = propInfo2[propCount];
                diffList.Add(property);
                propCount++;
                continue;
            }
            else if (propCount > len2 && propCount <= len1)
            {
                PropertyInfo property = propInfo1[propCount];
                diffList.Add(property);
                propCount++;
                continue;
            }

            PropertyInfo pInfo1 = propInfo1[propCount];
            PropertyInfo pInfo2 = propInfo2[propCount];
            object value1 = pInfo1.GetValue(prop1, null);
            object value2 = pInfo2.GetValue(prop2, null);
            if (value1 != null && value2 != null)
            {
                int numProps = value1.GetType().GetProperties().Length;
                if (numProps > 2)
                {
                    CompareProperties(value1, value2, diffList);
                }
                else
                {
                    if (!value1.Equals(value2))
                    {
                        diffList.Add(propInfo1[propCount]);
                    }
                }
            }
            propCount++;
        }
    }

    public bool CompareOrder(order orderA, order orderB)
    {
        if (orderA != null && orderB != null)
        {
            if (orderA.order_id != orderB.order_id)
            {
                return false;
            }
            if (orderA.order_reference != orderB.order_reference)
            {
                return false;
            }
            if (orderA.order_datetime != orderB.order_datetime)
            {
                return false;
            }
            if (orderA.order_total != orderB.order_total)
            {
                return false;
            }
            if (orderA.order_currency != orderB.order_currency)
            {
                return false;
            }
            if (orderA.test_transaction != orderB.test_transaction)
            {
                return false;
            }
            if (orderA.order_status != orderB.order_status)
            {
                return false;
            }
            // compare customer/shipping/items/rebill/transaction (more?)
            return true;
        }
        return false;
    }
    public bool CompareCustomer(order orderA, order orderB)
    {
        if (orderA != null && orderB != null)
        {
            if (orderA.customer_first_name != orderB.customer_first_name)
            {
                return false;
            }
            if (orderA.order_reference != orderB.order_reference)
            {
                return false;
            }
            if (orderA.order_datetime != orderB.order_datetime)
            {
                return false;
            }
            if (orderA.order_total != orderB.order_total)
            {
                return false;
            }
            if (orderA.order_currency != orderB.order_currency)
            {
                return false;
            }
            if (orderA.test_transaction != orderB.test_transaction)
            {
                return false;
            }
            if (orderA.order_status != orderB.order_status)
            {
                return false;
            }
            // compare customer/shipping/items/rebill/transaction (more?)
            return true;
        }
        return false;
    }
    public bool CompareShipping(order orderA, order orderB)
    {
        if (orderA != null && orderB != null)
        {
            if (orderA.order_id != orderB.order_id)
            {
                return false;
            }
            if (orderA.order_reference != orderB.order_reference)
            {
                return false;
            }
            if (orderA.order_datetime != orderB.order_datetime)
            {
                return false;
            }
            if (orderA.order_total != orderB.order_total)
            {
                return false;
            }
            if (orderA.order_currency != orderB.order_currency)
            {
                return false;
            }
            if (orderA.test_transaction != orderB.test_transaction)
            {
                return false;
            }
            if (orderA.order_status != orderB.order_status)
            {
                return false;
            }
            // compare customer/shipping/items/rebill/transaction (more?)
            return true;
        }
        return false;
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
                    {
                        orderResponses orderResp = new orderResponses();
                        apiResp = new APIResponses(String.Concat(testString, orderResp.orderSearchStr));
                        orders resp = apiResp.resp_orders;
                        orders comp = orderResp.orderSearchObj;
                        // Compare orders fields here
                        if (resp.num_records == comp.num_records)
                        {
                            int order_count = Convert.ToInt32(resp.num_records);
                            for (int el = 0; el < order_count; el++)
                            {
                                order respOrder = resp.order[el];
                                order compOrder = comp.order[el];
                                testPassed = CompareOrder(respOrder, compOrder);
                                if (!testPassed)
                                    break;
                            }
                        }
                        break;
                    }
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
