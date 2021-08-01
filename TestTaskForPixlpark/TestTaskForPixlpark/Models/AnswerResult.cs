using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TestTaskForPixlpark.Models
{
    public class AnswerResult
    {
        public string ApiVersion;
        [JsonProperty("Result")]
        public List<Order> Orders = new List<Order>();
    }
}