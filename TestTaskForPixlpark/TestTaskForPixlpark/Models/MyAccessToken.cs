using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTaskForPixlpark.Models
{
    public class MyAccessToken
    {
        public string RequestToken { get; set; }
        public string AccessToken { get; set; }
        public string Expires { get; set; }
        public string RefreshToken { get; set; }
        public string Scope { get; set; }
        public string Error { get; set; }
        public string Success { get; set; }
        public string RequireSsl { get; set; }
    }
}