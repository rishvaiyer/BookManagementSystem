using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Utilities;
using BookLibrary;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;

namespace Lab2RishIyer3342
{
    public partial class Bookstore : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        ArrayList arrListBooks = new ArrayList();
        Calculate calc = new Calculate();
        Updating up = new Updating();
        
               
        protected void Page_Load(object sender, EventArgs e)
        {
          
            lblYourOrder.Visible = false;
            lblgvMRTitle.Visible = false;
            gvMR.Visible = false;
            btnManagementReport.Visible = true;
            btnSelectMore.Visible = false;
            gvOrder.Visible = false;
            if (!IsPostBack)
            {

                DataSet myDS;
                String strSQL = "SELECT * FROM Books";


                //performs a SQL query  & display results in gv
                myDS = objDB.GetDataSet(strSQL);

                gvBooks.DataSource = myDS;
                gvBooks.DataBind();

            }
        }
        protected void btnOrder_Click(object sender, EventArgs e)
        {
            gvOrder.Visible = false;
            lblgvMRTitle.Visible = false;
            int count = 0;
            lblError.Visible = true;
            lblPhoneNumberError.Visible = true;
            lblStudentIDError.Visible = true;
            lblNameError.Visible = true;
            lblAddressError.Visible = true;
            lblPhoneNumberError.Visible = true;
            lblBasicInfoHeader.Visible = true;

            string textName = Request["txtName"];
            string textAddress = Request["txtAddress"];
            string textID = Request["txtStudentID"];
            string textPhoneNumber = Request["txtPhoneNumber"];
            string textCampus = Request["ddlCampus"];

            if (textName == "")
            {
                lblNameError.Text = "Please Enter a valid name";

            }
            else
            {
                lblNameError.Text = "";

            }

            if (textAddress == "")
            {
                lblAddressError.Text = "Please Enter a valid address";

            }
            else
            {
                lblAddressError.Text = "";

            }

            if (textID == "")
            {
                lblStudentIDError.Text = "Please Enter a valid ID";

            }
            else
            {
                lblStudentIDError.Text = "";
            }
            if (textPhoneNumber == "")
            {
                lblPhoneNumberError.Text = "Please Enter a valid phone number";

            }
            else
            {
                lblPhoneNumberError.Text = "";

            }

            if (textAddress != "" && textPhoneNumber != "" && textID != "" && textName != "")
            {

                for (int row = 0; row < gvBooks.Rows.Count; row++)
                {

                    Book book = new Book();
                    CheckBox Cbox;
                    DropDownList DDLType;
                    DropDownList DDLROB;
                    TextBox Tbox;

                    Cbox = (CheckBox)gvBooks.Rows[row].FindControl("chkSelect");
                    book.ISBN = Cbox.Text;

                    if (Cbox.Checked)
                    {


                        count++;


                        DDLType = (DropDownList)gvBooks.Rows[row].FindControl("ddlType");
                        DDLROB = (DropDownList)gvBooks.Rows[row].FindControl("ddlRentOrBuy");
                        Tbox = (TextBox)gvBooks.Rows[row].FindControl("TxtQuantity");

                        int quantity;
                        if (int.TryParse(Tbox.Text, out quantity) != true)
                        {

                            lblError.Text = "Please enter a valid quantity.";
                            gvOrder.Visible = false;
                            lblReciept.Visible = false;
                            txtAddress.Visible = true;
                            txtPhoneNumber.Visible = true;
                            txtStudentID.Visible = true;
                            lblCampus.Visible = true;
                            ddlCampus.Visible = true;
                            txtName.Visible = true;
                            lblYourOrder.Visible = false;
                            lblBasicInfoHeader.Visible = true;


                            lblError.Visible = true;
                            lblPhoneNumberError.Visible = true;
                            lblStudentIDError.Visible = true;
                            lblNameError.Visible = true;
                            lblAddressError.Visible = true;
                            lblPhoneNumberError.Visible = true;
                            btnOrder.Visible = true;
                            gvBooks.Visible = true;
                            return;
                        }
                        else
                        {
                            int.TryParse(Tbox.Text, out quantity);
                            lblReciept.Visible = true;
                        }

                        book.Title = gvBooks.Rows[row].Cells[1].Text;
                        book.Authors = gvBooks.Rows[row].Cells[2].Text;
                        book.ISBN = gvBooks.Rows[row].Cells[3].Text;
                        book.Type = DDLType.SelectedValue;
                        book.RentOrBuy = DDLROB.SelectedValue;
                        book.Quantity = quantity.ToString();
                        book.BasePrice = gvBooks.Rows[row].Cells[4].Text;


                        int price;

                        int.TryParse(book.BasePrice, out price);
                        double totalPrice = calc.getPrice(book.ISBN, book.Type, book.RentOrBuy, book.Quantity);



                        book.TotalPrice = totalPrice.ToString();


                        lblOrderError.Text = " ";
                        lblYourOrder.Visible = true;
                        lblReciept.Text = "Thank you for your order:  " + textName + "<br>"
                     + "Student ID: " + textID + "<br>" + "Address:  " + textAddress +
                     "<br>" + "Phone Number:  " + textPhoneNumber + "<br>" + "Campus:  " + textCampus;

                        arrListBooks.Add(book);
                        if (arrListBooks.Count == 0)
                        {
                            lblError.Text = "You must select atleast one book ";
                        }

                        else
                        {
                            up.updateTheDB(book.ISBN, book.Type, book.RentOrBuy, book.Quantity, totalPrice);


                        }


                        gvOrder.DataSource = arrListBooks;
                        gvOrder.DataBind();

                        string footerTotal;
                        int runningTotal = 0;
                        int runningTotal2 = 0;



                        foreach (GridViewRow gvr in gvOrder.Rows)
                        {

                            for (int i = 5; i < 6; i++)
                            {

                                String cellText = gvr.Cells[i].Text;
                                int total = int.Parse(cellText);
                                runningTotal += total;
                                footerTotal = runningTotal.ToString();

                                gvOrder.Columns[0].FooterText = "Total:";

                                gvOrder.Columns[5].FooterText = footerTotal;
                                //  gvOrder.DataBind();
                            }
                        }

                        foreach (GridViewRow gvr2 in gvOrder.Rows)
                        {
                            for (int j = 6; j < 7; j++)
                            {
                                String cellText2 = gvr2.Cells[j].Text.Trim();
                                string[] arraySubStrings = cellText2.Split('$');
                                int total2 = int.Parse(arraySubStrings[1]);
                                runningTotal2 += total2;
                                footerTotal = runningTotal2.ToString();



                                gvOrder.Columns[6].FooterText = "$" + footerTotal;
                                gvOrder.DataBind();
                            }
                        }

                        lblStudentIDError.Visible = false;
                        lblPhoneNumberError.Visible = false;
                        lblAddressError.Visible = false;
                        lblNameError.Visible = false;
                        lblgvMRTitle.Visible = false;
                        gvBooks.Visible = false;
                        gvOrder.Visible = true;
                        txtAddress.Visible = false;
                        txtStudentID.Visible = false;
                        txtPhoneNumber.Visible = false;
                        txtName.Visible = false;
                        ddlCampus.Visible = false;
                        lblBasicInfoHeader.Visible = false;
                        lblCampus.Visible = false;
                        lblError.Visible = false;
                        btnOrder.Visible = false;
                        btnSelectMore.Visible = true;
                        btnManagementReport.Visible = true;

                    }

                    if (count == 0)
                    {

                        lblOrderError.Text = "";
                        lblError.Text = "You must select atleast one book before ordering.";
                    }






                }
            }
        }

        
        protected void btnSelectMore_Click(object sender, EventArgs e)
        {
            gvBooks.Visible = true;
            lblYourOrder.Visible = false;
            lblReciept.Visible = false;
            lblError.Visible = false;
            txtAddress.Visible = true;
            txtStudentID.Visible = true;
            txtPhoneNumber.Visible = true;
            txtName.Visible = true;
            ddlCampus.Visible = true;
            lblBasicInfoHeader.Visible = true;

            lblCampus.Visible = true;
            btnOrder.Visible = true;
            lblReciept.Visible = false;
            gvOrder.Visible = false;
        }

        protected void gvOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvMR_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnManagementReport_Click(object sender, EventArgs e)
        {
            txtAddress.Visible = false;
            txtStudentID.Visible = false;
            txtPhoneNumber.Visible = false;
            txtName.Visible = false;
            ddlCampus.Visible = false;
            lblBasicInfoHeader.Visible = false;


            lblCampus.Visible = false;
            lblError.Visible = false;
            lblPhoneNumberError.Visible = false;
            lblStudentIDError.Visible = false;
            lblNameError.Visible = false;
            lblAddressError.Visible = false;
            lblPhoneNumberError.Visible = false;
            btnOrder.Visible = false;
            btnSelectMore.Visible = true;
            btnManagementReport.Visible = true;
            lblgvMRTitle.Visible = true;
            lblReciept.Visible = false;
            lblError.Visible = false;
            gvOrder.Visible = false;
            btnOrder.Visible = false;
            btnSelectMore.Visible = true;
            gvBooks.Visible = false;
            gvMR.Visible = true;

            DataSet MRds;
            String getMR = "SELECT ISBN, Title, TotalQuantityRented, TotalQuantitySold, TotalSales FROM Books ORDER BY TotalSales DESC";
            MRds = objDB.GetDataSet(getMR);

            gvMR.DataSource = MRds;
            gvMR.DataBind();
        }
    }
}



            
        
            

        

      
    

      

    
