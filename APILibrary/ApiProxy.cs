using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http; 
using System.Net.Http.Formatting;
using System.Collections.Specialized;
using System.Web;

public class MyFormatter : BufferedMediaTypeFormatter
{ 
    public MyFormatter()
    {
        SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
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
        string queryPart = request.RequestUri.Query;
        UriBuilder forwardUri = new UriBuilder("https://my.ipgholdings.net/service/idealbn/getbanks");
        //strip off the proxy port and replace with an Http port
        if (queryPart.StartsWith("?"))
            forwardUri.Query = queryPart.Substring(1);
        else
            forwardUri.Query = queryPart;
         

        /*NameValueCollection nv = new NameValueCollection();
        nv.Add("client_id", "4003124");
        nv.Add("api_key", "oVGGWa1kr83aeRhBNE3B");
        nv.Add("test_transaction", "1");
        forwardUri.Query = CreateQueryString(nv);*/


        //send it on to the requested URL
        request.RequestUri = forwardUri.Uri;
        HttpClient client = new HttpClient();
        var response = await client.PostAsync(forwardUri.Uri, forwardUri.Query, new MyFormatter());
        // HttpResponseMessage response = await client.PostAsync(forwardUri.Uri, forwardUri.Uri.Content);
        return response;
    }

    private string CreateQueryString(NameValueCollection nvc)
    {
        var array = (from key in nvc.AllKeys
                     from value in nvc.GetValues(key)
                     select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
            .ToArray();
        return "?" + string.Join("&", array);
    }
}
