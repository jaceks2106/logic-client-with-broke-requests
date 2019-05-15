using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RequestSenderExample
{
    public static class HttpRequestMessageBreaker
    {
        public static void BreakHeaderContentType(this HttpRequestMessage request)
        {
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data");
        }

        public static void BreakHeaderContentDisposition(this HttpRequestMessage request)
        {
            request.Content.Headers.ContentDisposition = null;
        }
    }
}
