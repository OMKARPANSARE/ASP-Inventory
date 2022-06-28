using DAL2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllData();
            }
        }


        protected void BtnAdd_Onclick(object sender, EventArgs e)
        {
            InsertData();
            GetAllData();

        }

        protected void BtnDelete_Onclick(object sender, EventArgs e)
        {
            try
            {
                RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
                int ID = Convert.ToInt32((item.FindControl("lblId") as Label).Text);
                DeleteData(ID);
                GetAllData();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void btnEdit_Onclick(object sender, EventArgs e)
        {
            ClareTextbox();
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            int ID = Convert.ToInt32((item.FindControl("lblId") as Label).Text);
            GetDataByID(ID);
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            

        }

        protected void BtnUpdate_Onclick(object sender, EventArgs e)
        {
           UpdateData(Convert.ToInt32(hifildID.Value));
            GetAllData();
        }

        
        private void InsertData()
        {
            try
            {

                clsItem obj = new clsItem();
                obj.Name = Convert.ToString(txtName.Text);
                obj.Description = Convert.ToString(txtDiscription.Text);
                obj.Quntity = Convert.ToDouble(txtQuntity.Text);
                obj.Price = Convert.ToDouble(txtPrice.Text);
                obj.SupplierName = Convert.ToString(txtSupplier.Text);
                obj.InsertDetails();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                ClareTextbox();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteData(int ID)
        {
            try
            {
                clsItem obj = new clsItem();
                obj.DeletDetails(ID);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Delete Successfully')", true);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void UpdateData(int ID)
        {
            try
            {
                clsItem obj = new clsItem();
                obj.Name = Convert.ToString(txtName.Text);
                obj.Description = Convert.ToString(txtDiscription.Text);
                obj.Quntity = Convert.ToDouble(txtQuntity.Text);
                obj.Price = Convert.ToDouble(txtPrice.Text);
                obj.SupplierName = Convert.ToString(txtSupplier.Text);
                obj.UpdateDetails(ID);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Update Successfully')", true);
                btnUpdate.Visible = false;
                btnAdd.Visible = true;
                ClareTextbox();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetAllData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllItem");
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dtDetails = Class1.GetData(cmd);
                rptItem.DataSource = dtDetails;
                rptItem.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetDataByID(int ID)
        {
            try
            {
                clsItem obj = new clsItem();
                obj.GetDataByID(ID);
                hifildID.Value = obj.ID.ToString();
                txtName.Text = obj.Name.ToString();
                txtDiscription.Text = obj.Description.ToString();
                txtQuntity.Text = obj.Quntity.ToString();
                txtPrice.Text = obj.Price.ToString();
                txtSupplier.Text = obj.SupplierName.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClareTextbox()
        {
            txtName.Text = "";
            txtDiscription.Text = "";
            txtQuntity.Text = "";
            txtPrice.Text = "";
            txtSupplier.Text = "";
        }



        ////<asp:Button ID = "btnSelectEmp" runat="server" Text="Select" OnClick="btnSelectJob_OnClick"/>

        //protected void btnSelectJob_OnClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        btnAddEmployee.Visible = false;
        //        RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
        //        txtFullName.Text = (item.FindControl("lblEmpName") as Label).Text;
        //        txtEmpID.Text = (item.FindControl("lblEmpID") as Label).Text;
        //        txtEmpContactNo.Text = (item.FindControl("lblEmpMobileNo") as Label).Text;
        //        txtEmpEmailID.Text = (item.FindControl("lblEmpEmailID") as Label).Text;
        //        txtSelectedEmpID.Text = (item.FindControl("lblID") as Label).Text.Trim();
        //        ddlDepartment.SelectedValue = (item.FindControl("lblEmpDepartmentID") as Label).Text.Trim();
        //        if (Convert.ToInt32((item.FindControl("lblActviationState") as Label).Text.Trim()) == 1)
        //        {
        //            SelectStatus.SelectedIndex = 1;
        //        }
        //        else
        //        {
        //            SelectStatus.SelectedIndex = 0;
        //        }
        //        int isRepoingHead = Convert.ToInt32((item.FindControl("lblisRepotingHead") as Label).Text.Trim());
        //        if (isRepoingHead == 1)
        //        {
        //            chkRepotingHead.Checked = true;
        //        }
        //        else
        //        {
        //            chkRepotingHead.Checked = false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



    }
}