using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTaskForPixlpark.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }

        public Shipping()
        {
            Id = 0;
            Title = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            Type = string.Empty;
        }
    }
}