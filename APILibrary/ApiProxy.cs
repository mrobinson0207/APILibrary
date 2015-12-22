using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http; 
using System.Net.Http.Formatting;
using System.Collections.Specialized;
using System.Security;
using System.Web;
using System.IO;

public class MyFormatter : BufferedMediaTypeFormatter
{ 
    public MyFormatter()
    {
        SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded"));
        SupportedEncodings.Add(new System.Text.UTF8Encoding());
    }

    public override bool CanReadType(Type type)
    {
        return type == typeof(string);
    }

    public override bool CanWriteType(Type type)
    {
        return type == typeof(string);
    }

    public override void WriteToStream(Type type, object value, System.IO.Stream writeStream, HttpContent content)
    {
        System.Text.Encoding selectedEncoding = SelectCharacterEncoding(content.Headers);
        using (var writer = new System.IO.StreamWriter(writeStream, selectedEncoding))
        {
            writer.Write(value);
        }
    }
}


/// <summary>
/// Summary description for ApiProxy
/// </summary>
public class ApiProxy : DelegatingHandler
{
    protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    {
        string uriPart = "https://my.ipgholdings.net";

        
        if (request.RequestUri.Segments[1].Contains("test"))
        {
            string arg1 = request.RequestUri.Segments[2].Split('/')[0];
            string arg2 = (request.RequestUri.Segments.Length > 2) ? request.RequestUri.Segments[3] : null;
            UnitTests tests = new UnitTests(arg1, arg2);
            List<string> fails = tests.GetFailures();
            string testContent = "Unit tests for " + arg1 + "/" + arg2 + ":";
            if (fails.Count == 0)
            {
                testContent += " passed";
            }
            else
            {
                testContent += " failed - " + String.Concat(fails);
            }
            HttpResponseMessage testResp = new HttpResponseMessage
            {
                Content = new StringContent(
                             testContent,
                             System.Text.Encoding.UTF8,
                             "application/xml"),
                StatusCode = HttpStatusCode.OK
            };
            return testResp;
        }

        // Add in the rest of the request
        foreach (var part in request.RequestUri.Segments)
        {
            uriPart += part;
        }

        // Get the form data to pass
        NameValueCollection nv = new NameValueCollection();
        var context = (HttpContextWrapper)request.Properties["MS_HttpContext"];
        var formKeys = context.Request.Form.Keys;
        int keyIndex = 0;
        foreach (string key in formKeys)
        {
            string value = context.Request.Form.GetValues(keyIndex++)[0];
            nv.Add(key, value);
        }
        string query = CreateQueryString(nv);

        byte[] data = System.Text.Encoding.ASCII.GetBytes(query);

        // Create a request using a URL that can receive a post. 
        WebRequest wrequest = WebRequest.Create(uriPart);
        // Set the Method property of the request to POST.
        wrequest.Method = "POST";
        wrequest.ContentType = "application/x-www-form-urlencoded";
        wrequest.ContentLength = data.Length;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        APIResponses apiResp = null;
        WebResponse wresponse = null;
        string respContent = null;
        Stream dataStream;
        try
        {
            Stream reqStream = wrequest.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            reqStream.Close();
            
            // Get the response.
            wresponse = wrequest.GetResponse();
            // Get the stream containing content returned by the server.
            dataStream = wresponse.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader wreader = new StreamReader(dataStream);
            // Read the content.
            respContent = wreader.ReadToEnd();
            // Clean up the streams.
            wreader.Close();
            dataStream.Close();
            wresponse.Close();
            apiResp = new APIResponses(respContent);
        }
        catch (Exception ex)
        {
            string catching = "debug";
        }

        HttpResponseMessage httpResp = new HttpResponseMessage
        {
            Content = new StringContent(
                         respContent,
                         System.Text.Encoding.UTF8,
                         "application/xml"),
            StatusCode = HttpStatusCode.OK
        };
        return httpResp;
    }

    private string CreateQueryString(NameValueCollection nvc)
    {
        var array = (from key in nvc.AllKeys
                     from value in nvc.GetValues(key)
                     select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
            .ToArray();
        return string.Join("&", array);
    }
}
