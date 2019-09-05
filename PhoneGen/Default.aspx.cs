using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhoneGen.AppLogic;

namespace PhoneGen
{

    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Bind the grid with the generated data.
        /// </summary>
        private void grdPhGridBind()
        {
            this.ltNumberOutput.Text = String.Empty;
            List<string> lstData = PhoneNumberGenerator.GeneratePhoneNumber(txtPhNum.Value);
            //Null value of the list indicates the phone number may have lost some validations checks in the business logic.
            if (lstData != null)
            {
                grdPhGrid.DataSource = lstData;
                grdPhGrid.DataBind();
                this.ltNumberOutput.Text = "The current combination has " + lstData.Count + " number of values generated for it.";
            }
        }

        /// <summary>
        /// used to clean the gridview of values.
        /// </summary>
        private void grdPhReset()
        {
            this.ltNumberOutput.Text = String.Empty;
            grdPhGrid.DataSource = null;
            grdPhGrid.DataBind();
        }

        public void btnSubmitClicked(object sender, EventArgs args)
        {
            if (Page.IsValid)
            {
                grdPhGridBind();
            }
            else
            {
                grdPhReset();
            }
        }

        /// <summary>
        /// Handles indexing events for the data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdPhGrid_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            grdPhGrid.PageIndex = e.NewPageIndex;
            grdPhGridBind();
        }
    }
}
