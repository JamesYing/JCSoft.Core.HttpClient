using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace JCSoft.Core.HttpClient
{
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) : this(obj, Encoding.UTF8)
        {
        }

        public JsonContent(object obj, Encoding encoding) : this(obj, encoding, "application/json")
        {
        }

        public JsonContent(object obj, Encoding encoding, string mediaType) : base(JsonConvert.SerializeObject(obj), encoding, mediaType)
        {
        }
    }
}
