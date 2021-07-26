using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ABCD.Models
{
    public class Product
    {
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Brand Name is required.")]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price")]
        public string Price { get; set; }
    }
}