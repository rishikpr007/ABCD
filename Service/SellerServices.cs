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
    public class SellerServices
    {
        public string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;


        public IList<Seller> GetSellerList()
        {

            IList<Seller> getSellerList = new List<Seller>();

            _ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connect))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SellerViewOrInsert",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetSellerList");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);

                if (_ds.Tables.Count>0)
                {
                    for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        Seller obj = new Seller();
                     //   obj.SellerID = Convert.ToInt32(_ds.Tables[0].Rows[i]["SellerId"]);
                        obj.SellerName = Convert.ToString(_ds.Tables[0].Rows[i]["SellerName"]);
                        obj.OwnerName = Convert.ToString(_ds.Tables[0].Rows[i]["OwnerName"]);

                        getSellerList.Add(obj);
                    }
                }

            }



                return getSellerList;

        }


        public void InsertSeller(Seller seller)
        {

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SellerViewOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddSeller");
                cmd.Parameters.AddWithValue("@sname", seller.SellerName);
                cmd.Parameters.AddWithValue("@oname", seller.OwnerName);
                cmd.ExecuteNonQuery();


            }


        }


        public Seller GetEditByID (int Id)
        {

            var seller = new Seller();

            using(SqlConnection con = new SqlConnection(connect) )
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SellerViewOrInsert",con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetSellerByID");
                cmd.Parameters.AddWithValue("@sid", Id);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if(_ds.Tables.Count>0 && _ds.Tables[0].Rows.Count>0)
                {

                    seller.SellerID = Convert.ToInt32(_ds.Tables[0].Rows[0]["SellerID"]);
                    seller.SellerName = Convert.ToString(_ds.Tables[0].Rows[0]["SellerName"]);
                    seller.OwnerName = Convert.ToString(_ds.Tables[0].Rows[0]["OwnerName"]);

                }

            }

            return seller;

        }

        public void UpdateSeller(Seller seller)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SellerViewOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdateSeller");
                cmd.Parameters.AddWithValue("@sid", seller.SellerID);
                cmd.Parameters.AddWithValue("@sname", seller.SellerName);
                cmd.Parameters.AddWithValue("@oname", seller.OwnerName);
                cmd.ExecuteNonQuery();




            }


        }


        public void DeleteSeller(int Id)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SellerViewOrInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "DeleteSeller");
                cmd.Parameters.AddWithValue("sid", Id);
                cmd.ExecuteNonQuery();
            }
        }


    }
}