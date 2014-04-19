using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using model;

public partial class admin : System.Web.UI.Page
{
    Model model;

    protected void Page_Load(object sender, EventArgs e)
    {
        /* 
         @author Adrian Roy A Baguio
         @date 08/04/2014
         @description hide both divs when page loads.
         */
        HttpCookie objCookie = Request.Cookies["userInformation"];
        //loadlblHi.Text = objCookie.Values["name"].ToString();
        //lblLastLoginTime.Text = objCookie.Values["TimeLoggin"].ToString();
        addMovies.Visible = false;
        addPeople.Visible = true;

    }

    protected void drpDwnListOption_SelectedIndexChanged(object sender, EventArgs e)
    {
         switch (drpDwnListOption.SelectedValue)
        {
            case "addUsers":
                addMovies.Visible = false;
                addPeople.Visible = true;
                editUser.Visible = false;
                break;
            case "addMovies":
                addMovies.Visible = true;
                addPeople.Visible = false;
                editUser.Visible = false;
                break;
             case "editUsers":
                editUser.Visible = true;
                addMovies.Visible = false;
                addPeople.Visible = false;
                Model model = new Model();
                List<customer> customers = model.getAllCustomers();
                GridViewCustomers.DataSource = customers;
                GridViewCustomers.DataBind();

                foreach (customer cust in customers)
                {
                    ListItem item = new ListItem(cust.First_name + " " + cust.Last_name, Convert.ToString(cust.Customer_id), true);
                    drpDownListCustomers.Items.Add(item);
                }
                break;

            default:
                break;
        }
    }

    protected void btnAddMovie_Click(object sender, EventArgs e)
    {
        model = new Model();

        bool addMovieSuccess = model.addMovie(txtTitle.Text, txtCompany.Text, txtDirector.Text, txtEditor.Text);

        if (addMovieSuccess)
        {
            lblStatus.Text = "Movie Addition Successful!";
            clearMovieFields();
        }
        else
        {
            lblStatus.Text = "Movie Addition Failed! Contact admin for details!";
        }
        addMovies.Visible = true;

    }

    private void clearMovieFields()
    {
        txtTitle.Text = "";
        txtCompany.Text = "";
        txtDirector.Text = "";
        txtEditor.Text = "";
    }

    protected void btnIndex_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        model = new Model();
        bool status;

        switch (drpDwnListIsAdmin.SelectedIndex)
        {
            case 0:
                status = true;
                break;
            default:
                status = false;
                break;
        }

        bool registerPass = model.register(txtBoxFirstName.Text, txtBoxLastName.Text, txtBoxAddress1.Text, 
            txtBoxAddress2.Text, txtBoxCity.Text, txtBoxProvince.Text, txtBoxPostalCode.Text, txtBoxPhone.Text,
            txtBoxLogin.Text, txtBoxPassword.Text, status);
        if (registerPass)
        {
            lblStatus2.Text = "User Addition Successful!";
        }
        else
        {
            lblStatus2.Text = "User Addition Failed! Contact admin for details.";
        }

        addPeople.Visible = true;

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        editUser.Visible = true;
        addMovies.Visible = false;
        addPeople.Visible = false;
        int id = Convert.ToInt32(drpDownListCustomers.SelectedItem.Value);
        Model model = new Model();
        List<customer> customer = model.getAllCustomerById(id);
        GridViewCustomers.DataSource = customer;

        GridViewCustomers.DataBind();


    }

    public void GridViewCustomers_RowDeleting(Object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(e.Values[0].ToString());
        Model model = new Model();
        model.deleteCustomerById(id);
        Response.Redirect("admin.aspx");

    }
    public void GridViewCustomers_RowEditing(Object sender, GridViewEditEventArgs e)
    {
        //Set the edit index.
        GridViewCustomers.EditIndex = e.NewEditIndex;
        //Bind data to the GridView control.
        BindData();
    }

    public void GridViewCustomers_RowUpdating(Object sender, GridViewUpdateEventArgs e)
    {
        //Update the values.
        GridViewRow row = GridViewCustomers.Rows[e.RowIndex];
        int Customer_id;
        string First_name, Last_name, Address1, Address2, City, Province, Pcode, Phone, Login, Password;
        bool IsAdmin;

        Customer_id = Convert.ToInt32(((TextBox)(row.Cells[1].Controls[0])).Text);
        First_name = ((TextBox)(row.Cells[2].Controls[0])).Text;
        Last_name = ((TextBox)(row.Cells[3].Controls[0])).Text;
        Address1 = ((TextBox)(row.Cells[4].Controls[0])).Text;
        Address2 = ((TextBox)(row.Cells[5].Controls[0])).Text;
        City = ((TextBox)(row.Cells[6].Controls[0])).Text;
        Province = ((TextBox)(row.Cells[7].Controls[0])).Text;
        Pcode = ((TextBox)(row.Cells[8].Controls[0])).Text;
        Phone = ((TextBox)(row.Cells[9].Controls[0])).Text;
        Login = ((TextBox)(row.Cells[10].Controls[0])).Text;
        Password = ((TextBox)(row.Cells[11].Controls[0])).Text;
        var temp = ((CheckBox)(row.Cells[12].Controls[0]));
        if (temp.Checked)
        {
            IsAdmin = true;
        }
        else
        {
            IsAdmin = false;
        }
        Model model = new Model();
        model.editCustomerById(Customer_id, First_name, Last_name, Address1, Address2, City, Province, Pcode, Phone, Login, Password, IsAdmin);
        Response.Redirect("admin.aspx");
    }

    private void BindData()
    {
        Model model = new Model();
        List<customer> customers = model.getAllCustomers();
        GridViewCustomers.DataSource = customers;
        GridViewCustomers.DataBind();
    }

 
}