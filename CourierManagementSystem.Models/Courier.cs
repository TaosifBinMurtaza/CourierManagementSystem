using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Models
{
    public class Courier
    {
        [Key]
        [DisplayName("Consignment Number")]
        public string Id { get; set; }= Guid.NewGuid().ToString();

        [DisplayName("Parcel Weight(In kg)")]
        public float ParcelWeight { get; set; }

        [DisplayName("Current Location")]
        public string Location { get; set; }

        public string Status { get; set; } = "Not Delivered";

        [DisplayName("Order Placing Date")]

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [DisplayName("Probably Delivery Date")]
        public DateTime PDate { get; set; }

        [DisplayName("Deliverd Date")]

        public DateTime? FinalDate { get; set; }

        [Required]
        [DisplayName("Customer Name")]
        public string CName { get; set; }
        [Required]
        [DisplayName("Customer Phone Number")]
        public string CPhoneNo { get; set; }
        [Required]
        [DisplayName("Customer Address")]
        public string CAddress { get; set; }

        [Required]
        [DisplayName("Receiver Name")]
        public string RName { get; set; }
        [Required]
        [DisplayName("Receiver Phone")]
        public string RPhoneNo { get; set; }
        [Required]
        [DisplayName("Receiver Address")]
        public string RAddress { get; set; }

    }
}
