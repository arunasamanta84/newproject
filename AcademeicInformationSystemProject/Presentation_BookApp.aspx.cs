using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_BookApp;
using BLL_BookApp;
using System.Data;

namespace AcademeicInformationSystemProject
{
    public partial class Presentation_BookApp : System.Web.UI.Page
    {
        #region "Create and Initialize the object"
        BookDetails_BEL objBookDetailsBEL = new BookDetails_BEL();
        BookDetails_BLL objBookDetailsBLL = new BookDetails_BLL();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindBookRecordGridView();
            }
        }

        private void BindBookRecordGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objBookDetailsBLL.GetBookRecords();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdBookDetails.DataSource = ds;
                    grdBookDetails.DataBind();
                }
                else
                {
                    grdBookDetails.DataSource = null;
                    grdBookDetails.DataBind();
                }

            }
            catch (Exception ex)
            {

                Response.Write("Error Raised" + ex.Message.ToString());
            }
            finally
            {
                objBookDetailsBEL = null;
                objBookDetailsBLL = null;
            }

        }

        protected void grdBookDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdBookDetails.EditIndex = e.NewEditIndex;
            BindBookRecordGridView();
        }

        protected void grdBookDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            grdBookDetails.EditIndex = -1;
            BindBookRecordGridView();
        }

        protected void grdBookDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            objBookDetailsBEL.BookId = Convert.ToInt32(grdBookDetails.DataKeys[e.RowIndex].Value);
            objBookDetailsBEL.BookName = ((TextBox)(grdBookDetails.Rows[e.RowIndex].FindControl("txtBookNameEdit"))).Text.Trim();
            objBookDetailsBEL.Author = ((TextBox)(grdBookDetails.Rows[e.RowIndex].FindControl("txtAuthorEdit"))).Text.Trim();
            objBookDetailsBEL.Publisher = ((TextBox)(grdBookDetails.Rows[e.RowIndex].FindControl("txtPublisherEdit"))).Text.Trim();
            objBookDetailsBEL.Price = Convert.ToDecimal((TextBox)(grdBookDetails.Rows[e.RowIndex].FindControl("txtPriceEdit")));


            try {
                 int retVal = objBookDetailsBLL.UpdateBookRecord(objBookDetailsBEL);

                if(retVal > 0)
                {
                     lblStatus.Text = "Book Details Updated Successfully";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    grdBookDetails.EditIndex = -1;
                    BindBookRecordGridView();
                }

                else{
                    lblStatus.Text = "Book details Updated successfully";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch(Exception ex)
            {
            
                Response.Write("Error Raised" +ex.Message.ToString());
            }
            finally {
                 objBookDetailsBEL = null;
                objBookDetailsBLL = null;
            }
        }

        // Delete Book Record
        protected void grdBookDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Book_Id = Convert.ToInt32(grdBookDetails.DataKeys[e.RowIndex].Value);
            objBookDetailsBEL.BookId = Book_Id;

            try
            {

                int revValue = objBookDetailsBLL.DeleteBookRecords(objBookDetailsBEL);

                if (revValue > 0)
                {
                    lblStatus.Text = "Book Details Deleted Successfully";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    BindBookRecordGridView();
                }
                else
                {
                    lblStatus.Text = "Book Details couldn't be deleted";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error occured" + ex.Message.ToString());

            }
            finally
            {
                objBookDetailsBEL = null;
                objBookDetailsBLL = null;
            }
        }

        //Paging In GridView
        protected void grdBookDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBookDetails.PageIndex = e.NewPageIndex;
            BindBookRecordGridView();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objBookDetailsBEL.BookName = txtBookName.Text.Trim();
            objBookDetailsBEL.Author = txtAuthorName.Text.Trim();
            objBookDetailsBEL.Publisher = txtPublisherName.Text.Trim();
            objBookDetailsBEL.Price = Convert.ToDecimal(txtPrice.Text);

            try
            {
                int retval = objBookDetailsBLL.SaveBookDetails(objBookDetailsBEL);
                if (retval > 0)
                {
                    lblStatus.Text = "Book Saved Successfully";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    BindBookRecordGridView();
                }
                else
                {
                    lblStatus.Text = "Book details couldn't be saved";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error Raised" + ex.Message.ToString());
            }
            finally
            {
                objBookDetailsBEL = null;
                objBookDetailsBLL = null;
            }
        }

        //Clear and Reset Control
       
    }
}