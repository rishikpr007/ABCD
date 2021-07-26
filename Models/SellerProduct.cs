using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace ABCD.Models
{
    public class SellerProduct
    {
        [Display(Name = "Product Seller ID")]
        public int SellProID { get; set; }

        [Required(ErrorMessage = "Seller name is required.")]
        [Display(Name = "Seller Name")]
        public virtual Seller Seller { get; set; }

        [Display(Name = "Product Name")] 
        public virtual Product Product { get; set; }

    }
}