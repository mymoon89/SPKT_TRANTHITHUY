/*
 * frmLogin.cs
 * 
 * Copyright © 2007 Aptech Software Limited. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookStore
{
    /// <summary>
    /// Class frmLogin is used to demonstrate the use of custom control.
    /// </summary>
    public partial class frmLogin : Form
    {
        /// <summary>
        /// Constructor without parameters to initialize the
        /// controls for displaying the frmLogin form. 
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
        }

        // Validates the user id and password.
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "")
            {
                btnOK.BorderColor = Color.Red;
                MessageBox.Show("Enter the user id.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnOK.BorderColor = Color.Navy;
                txtUserID.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                btnOK.BorderColor = Color.Red;
                MessageBox.Show("Enter the password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnOK.BorderColor = Color.Navy;
                txtPassword.Focus();
                return;
            }

            if (txtUserID.Text != "admin" || txtPassword.Text != "administrator")
            {
                btnOK.BorderColor = Color.Red;
                MessageBox.Show("Either user id or password is incorrect.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnOK.BorderColor = Color.Navy;
                txtUserID.Focus();
                return;
            }
            else
            {
                this.Hide();
                frmBookDetails frmBookDet = new frmBookDetails();
                frmBookDet.Show();
            }
        }

        // Closes the application.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}