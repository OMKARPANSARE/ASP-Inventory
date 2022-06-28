using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using DAL2;

namespace BAL
{
   public  class clsItem
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Quntity { get; set; }
        public double Price { get; set; }
        public string SupplierName { get; set; }
        public int IsActive { get; set; }




        public clsItem()
        {
            Initialvalues();
        }
        public void Initialvalues()
        {
            ID = 0;
            Name = "";
            Description = "";
            Quntity =0;
            Price = 0;
            SupplierName = "";
            IsActive = 0;
        }

        public clsItem(string IFSC)
        {
            clsItem objMICR = new clsItem();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_GetBankDetailsByIFSCCode");
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@MICR", MICRCode);
                cmd.Parameters.AddWithValue("@IFSC", IFSC);
                DataTable dtDetails = Class1.GetData(cmd);
                LoadDetails(dtDetails);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public clsItem(DataTable dtDetails)
        {

            if (dtDetails.Rows.Count > 0)
            {
                LoadDetails(dtDetails);
            }


        }
        public void LoadDetails(DataTable dtdetails)
        {
            try
            {
                if (dtdetails.Rows.Count > 0)
                {
                    ID = Convert.ToInt32(dtdetails.Rows[0]["ID"]);
                    Name = Convert.ToString(dtdetails.Rows[0]["Name"]);
                    Description = Convert.ToString(dtdetails.Rows[0]["Description"]);
                    Quntity = Convert.ToDouble(dtdetails.Rows[0]["Quntity"]);
                    Price = Convert.ToDouble(dtdetails.Rows[0]["Price"]);
                    SupplierName = Convert.ToString(dtdetails.Rows[0]["SupplierName"]);
                    IsActive = Convert.ToInt32(dtdetails.Rows[0]["IsActive"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetDataByID(int ItemID)
        {
                      
            try
            {
                SqlCommand cmd = new SqlCommand("GetItemByID");
                cmd.CommandType = CommandType.StoredProcedure;    
                cmd.Parameters.AddWithValue("@ID", ItemID);
                DataTable dtDetails = Class1.GetData(cmd);
                LoadDetails(dtDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }         
        }

        public bool InsertDetails()
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("AddNewItem");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Quntity", Quntity);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@SupplierName", SupplierName);

                Class1.Execute(cmd);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;


        }

        public bool UpdateDetails(int itemID)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateItem");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Quntity", Quntity);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@SupplierName", SupplierName);
                cmd.Parameters.AddWithValue("@ID", itemID);
                Class1.Execute(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;


        }

        public bool DeletDetails(int itemID)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteItemByID");
                cmd.CommandType = CommandType.StoredProcedure;             
                cmd.Parameters.AddWithValue("@ID", itemID);
                Class1.Execute(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;


        }
    }

}



