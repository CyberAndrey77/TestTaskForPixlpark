using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TestTaskForPixlpark.Models
{
    public class Order
    {
        private DeliveryAddress _deliveryAddress;
        private Shipping _shipping;
        public string Id { get; set; }
        public int PhotolabId { get; set; }
        public string CustomId { get; set; }
        public string SourceOrderId { get; set; }
        public string ManagerId { get; set; }
        public string AssignedToId { get; set; }
        public string Title { get; set; }
        public string TrackingUrl { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
        public string RenderStatus { get; set; }
        public string PaymentStatus { get; set; }

        [JsonProperty("DeliveryAddress")]
        public DeliveryAddress DeliveryAddress 
        {
            get
            {
                return _deliveryAddress;
            } 
            set 
            {
                if (value == null)
                {
                    _deliveryAddress = new DeliveryAddress();
                    return;
                }
                _deliveryAddress = value;
            } 
        }

        [JsonProperty("Shipping")]
        public Shipping Shipping 
        {
            get
            {
                return _shipping;
            }
            set 
            {
                if (value == null)
                {
                    _shipping = new Shipping();
                    return;
                }
                _shipping = value;
            } 
        }
        public int CommentsCount { get; set; }
        public string DownloadLink { get; set; }
        public string PreviewImageUrl { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public double DeliveryPrice { get; set; }
        public double TotalPrice { get; set; }
        public double PaidPrice { get; set; }
        public int UserId { get; set; }
        public string UserCompanyAccountId { get; set; }
        public string DiscountTitle { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string DatePaid { get; set; }
        public string DateReady { get; set; }
        public string LastDownloadedPaymentDocument { get; set; }
        public string PaymentSystemUniqueId { get; set; }
        public string GoogleClientId { get; set; }
        public string ContractorOrderNumber { get; set; }
        public double ContractorOrderTotalPrice { get; set; }
    }
}