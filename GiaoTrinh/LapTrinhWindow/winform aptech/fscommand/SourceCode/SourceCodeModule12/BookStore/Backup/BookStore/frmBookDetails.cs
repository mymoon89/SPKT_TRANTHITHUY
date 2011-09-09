/*
 * frmBookDetails.cs
 * 
 * Copyright © 2007 Aptech Software Limited. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookStore
{
    /// <summary>
    /// Class frmBookDetails is used to demonstrate the use of DataSet Control.
    /// 
    /// Class frmBookDetails displays data from the database.
    /// </summary>
    public partial class frmBookDetails : Form
    {
        SqlConnection sqlconBookDetails;
        SqlCommand sqlcomBookDetails;
        SqlDataReader sqldreaderBookDetails;
        SqlDataAdapter sqldaBookDetails;
        DataSet dsetBookDetails;
        string operation;
        string addNewString;
        string record;

        /// <summary>
        /// Constructor without parameters to initialize the
        /// controls for displaying the frmBookDetails form. 
        /// </summary>
        public frmBookDetails()
        {
            InitializeComponent();
            sqlconBookDetails = new SqlConnection("Data Source=win2k\\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=SSPI");
            sqldaBookDetails = new SqlDataAdapter();
            dsetBookDetails = new DataSet();
        }

        // Loads data from the database
        private void frmBookDetails_Load(object sender, EventArgs e)
        {
            int rows = 0;
            lvwBookDetails.Items.Clear();
            if (sqlconBookDetails.State == ConnectionState.Open)
                sqlconBookDetails.Close();
            sqlconBookDetails.Open();
            dsetBookDetails.Clear();
            sqlcomBookDetails = sqlconBookDetails.CreateCommand();
            sqlcomBookDetails.CommandText = "SELECT * FROM BookMaster";
            sqldaBookDetails.SelectCommand = sqlcomBookDetails;
            sqldaBookDetails.Fill(dsetBookDetails, "BookMaster");
            for (rows = 0; rows < dsetBookDetails.Tables[0].Rows.Count; rows++)
            {
                lvwBookDetails.Items.Add(dsetBookDetails.Tables[0].Rows[rows].ItemArray[0].ToString());
                lvwBookDetails.Items[rows].SubItems.Add(dsetBookDetails.Tables[0].Rows[rows].ItemArray[1].ToString());
                lvwBookDetails.Items[rows].SubItems.Add(dsetBookDetails.Tables[0].Rows[rows].ItemArray[2].ToString());
                lvwBookDetails.Items[rows].SubItems.Add(dsetBookDetails.Tables[0].Rows[rows].ItemArray[3].ToString());
                lvwBookDetails.Items[rows].SubItems.Add(dsetBookDetails.Tables[0].Rows[rows].ItemArray[4].ToString());
            }
            ClearControls();
            sqldreaderBookDetails = sqlcomBookDetails.ExecuteReader();
            if (sqldreaderBookDetails.Read())
            {
                DisplayRecord();
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                txtSearch.Enabled = true;
                btnSearch.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                txtSearch.Enabled = false;
                btnSearch.Enabled = false;
            }
            operation = "";
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnAddNew.Enabled = true;
            DisableControls();
        }

        // Deletes the record
        private void btnDelete_Click(object sender, EventArgs e)
        {
            record = "Title: " + txtTitle.Text + "\nLanguage: " + txtLanguage.Text + "\nAuthor: " + txtAuthor.Text + "\nPages: " + txtPages.Text + "\nPrice: " + txtPrice.Text;
            addNewString = "DELETE FROM BookMaster WHERE Title='" + txtTitle.Text + "'";
            if (!sqldreaderBookDetails.IsClosed)
                sqldreaderBookDetails.Close();
            sqlcomBookDetails = sqlconBookDetails.CreateCommand();
            sqlcomBookDetails.CommandText = addNewString;
            sqlcomBookDetails.ExecuteNonQuery();
            MessageBox.Show("The record has been deleted sucessfully.\n" +
record, "Book Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmBookDetails_Load(null, null);
        }

        // Displays the record
        void DisplayRecord()
        {
            txtTitle.Text = sqldreaderBookDetails.GetString(0);
            txtLanguage.Text = sqldreaderBookDetails.GetString(1);
            txtAuthor.Text = sqldreaderBookDetails.GetString(2);
            txtPages.Text = sqldreaderBookDetails.GetInt32(3).ToString();
            txtPrice.Text = sqldreaderBookDetails.GetInt32(4).ToString();
        }

        // Clears the controls
        void ClearControls()
        {
            txtTitle.Text = "";
            txtLanguage.Text ="";
            txtAuthor.Text = "";
            txtPages.Text = "";
            txtPrice.Text = "";
        }

        // Adds a new record
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            operation = "insert";
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAddNew.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            txtSearch.Enabled = false;
            btnSearch.Enabled = false;
            EnableControls();
            txtTitle.Focus();
        }

        // Edits the record
        private void btnEdit_Click(object sender, EventArgs e)
        {
            operation = "update";
            btnAddNew.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            txtSearch.Enabled = false;
            btnSearch.Enabled = false;
            EnableControls();
            txtTitle.Focus();
        }

        // Validates and saves the record in the database.
        private void btnSave_Click(object sender, EventArgs e)
        {
            int index = 0;
            if(txtTitle.Text == "")
            {
                MessageBox.Show("Please enter the title.","Book Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitle.Focus();
                return;
            }
            else if(txtLanguage.Text == "")
            {
                MessageBox.Show("Please enter the language.", "Book Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLanguage.Focus();
                return;
            }
            else if(txtAuthor.Text == "")
            {
                MessageBox.Show("Please enter the author.", "Book Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAuthor.Focus();
                return;
            }
            else if(txtPages.Text == "")
            {
                MessageBox.Show("Please enter the pages.", "Book Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPages.Focus();
                return;
            }
            else if(txtPrice.Text == "")
            {
                MessageBox.Show("Please enter the price.", "Book Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrice.Focus();
                return;
            }
            
            if (txtPages.Text != "")
            {
                try
                {
                    index = Convert.ToInt32(txtPages.Text);
                    if (index < 0)
                    {
                        MessageBox.Show("Please enter a positive value for pages.", "Book Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPages.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please enter a numeric value for pages.", "Book Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPages.Focus();
                    return;
                }
            }
            
            if (txtPrice.Text != "")
            {
                try
                {
                    index = Convert.ToInt32(txtPrice.Text);
                    if (index < 0)
                    {
                        MessageBox.Show("Please enter a positive value for price.", "Book Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPrice.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please enter a numeric value for price.", "Book Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPrice.Focus();
                    return;
                }
            }
            
            if (operation == "insert")
                addNewString = "INSERT INTO BookMaster VALUES ('" + txtTitle.Text + "','" + txtLanguage.Text + "','" + txtAuthor.Text + "'," + txtPages.Text + "," + txtPrice.Text +")";
            else if (operation == "update")
                addNewString = "UPDATE BookMaster SET Language='" + txtLanguage.Text + "',Author='" + txtAuthor.Text + "',Pages=" + txtPages.Text + ",Price=" + txtPrice.Text + " where Title = '" + txtTitle.Text +"'";
            
            if(operation != "")
            {
                if (!sqldreaderBookDetails.IsClosed)
                    sqldreaderBookDetails.Close();
                sqlcomBookDetails = sqlconBookDetails.CreateCommand();
                sqlcomBookDetails.CommandText = addNewString;
                sqlcomBookDetails.ExecuteNonQuery();
                record = "Title: " + txtTitle.Text + "\nLanguage: " + txtLanguage.Text + "\nAuthor: " + txtAuthor.Text + "\nPages: " + txtPages.Text + "\nPrice: " + txtPrice.Text;
                MessageBox.Show("The following details have been saved successfully.\n" + record, "Book Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmBookDetails_Load(null, null);
            }
        }

        // Searches the record in the database
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                if (sqlconBookDetails.State == ConnectionState.Open)
                    sqlconBookDetails.Close();
                sqlconBookDetails.Open();
                dsetBookDetails.Clear();
                sqlcomBookDetails = sqlconBookDetails.CreateCommand();
                sqlcomBookDetails.CommandText = "SELECT * FROM BookMaster WHERE Title like '" + txtSearch.Text + "%'";
                sqldaBookDetails.SelectCommand = sqlcomBookDetails;
                sqldaBookDetails.Fill(dsetBookDetails, "BookMaster");
                ClearControls();
                sqldreaderBookDetails = sqlcomBookDetails.ExecuteReader();
                if (sqldreaderBookDetails.Read())
                    DisplayRecord();
                else
                    MessageBox.Show("No record is found.", "Book Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Text = "";
            }
            else
            {
                MessageBox.Show("Please enter the search text.","Book Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Focus();
            }
        }

        // Cancels the operation
        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmBookDetails_Load(null, null);
        }

        // Loads the data
        private void lvwBookDetails_Click(object sender, EventArgs e)
        {
            if (sqlconBookDetails.State == ConnectionState.Open)
                sqlconBookDetails.Close();
            sqlconBookDetails.Open();
            sqlcomBookDetails = sqlconBookDetails.CreateCommand();
            sqlcomBookDetails.CommandText = "SELECT * FROM BookMaster";
            sqldreaderBookDetails = sqlcomBookDetails.ExecuteReader();
            sqldreaderBookDetails.Read();
            while (sqldreaderBookDetails.GetString(0) != lvwBookDetails.SelectedItems[0].Text)
                sqldreaderBookDetails.Read();
            DisplayRecord();
        }

        // Disables the controls
        void DisableControls()
        {
            txtTitle.Enabled = false;
            txtLanguage.Enabled = false;
            txtAuthor.Enabled = false;
            txtPages.Enabled = false;
            txtPrice.Enabled = false;
        }

        // Enables the controls
        void EnableControls()
        {
            txtTitle.Enabled = true;
            txtLanguage.Enabled = true;
            txtAuthor.Enabled = true;
            txtPages.Enabled = true;
            txtPrice.Enabled = true;
        }

        // Exits the application
        private void frmBookDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }        
    }
}