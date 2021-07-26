using ABCD.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace ABCD.Service
{
    public class ProductServices
    {
        public string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;

        public IList<Product> GetProductList()
        { 

            IList<Product> products = new List<Product>();
            _ds = new DataSet();

                using(SqlConnection con = new SqlConnection(connect))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("ProductViewOrInsert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "GetProductList");

                    _adapter = new SqlDataAdapter(cmd);
                    _adapter.Fill(_ds);

                    if (_ds.Tables.Count > 0)
                {
                    for (int i = 0; i< _ds.Tables[0].Rows.Count; i++)
                    {
                        Product obj = new Product();

                        obj.ProductID = Convert.ToInt32(_ds.Tables[0].Rows[0]["ProductID"]);
                        obj.ProductName = Convert.ToString(_ds.Tables[0].Rows[0]["ProductName"]);
                        obj.BrandName = Convert.ToString(_ds.Tables[0].Rows[0]["BrandName"]);
                        obj.Price = Convert.ToString(_ds.Tables[0].Rows[0]["Price"]);

                        products.Add(obj);
                    }

                }




                }


                return products;
            

        }


        public void InsertProduct(Product model)
        {

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProductViewOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddProduct");
                cmd.Parameters.AddWithValue("@sname", model.ProductName);
                cmd.Parameters.AddWithValue("@bname", model.BrandName);
                cmd.Parameters.AddWithValue("@price", model.Price);

                cmd.ExecuteNonQuery();


            }


        }


        public Product GetEditByID(int ProductID)
        {

            var model = new Product();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProductViewOrInsert", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetProductByID");
                cmd.Parameters.AddWithValue("@sid", ProductID);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                     
                    model.ProductID = Convert.ToInt32(_ds.Tables[0].Rows[0]["ProductID"]);
                    model.ProductName = Convert.ToString(_ds.Tables[0].Rows[0]["ProductName"]);
                    model.BrandName = Convert.ToString(_ds.Tables[0].Rows[0]["BrandName"]);
                    model.Price = Convert.ToString(_ds.Tables[0].Rows[0]["Price"]);
                }

            }

            return model;

        }



        public void UpdateProduct(Product model)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProductViewOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdateProduct");
                cmd.Parameters.AddWithValue("@pname", model.ProductName);
                cmd.Parameters.AddWithValue("@bname", model.BrandName);
                cmd.Parameters.AddWithValue("@price", model.Price);
                cmd.ExecuteNonQuery();

            }


        }



        public void DeleteProduct(int ProductID)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProductViewOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "DeleteProduct");
                cmd.Parameters.AddWithValue("pid", ProductID);
                cmd.ExecuteNonQuery();
            }
        }


    }
}