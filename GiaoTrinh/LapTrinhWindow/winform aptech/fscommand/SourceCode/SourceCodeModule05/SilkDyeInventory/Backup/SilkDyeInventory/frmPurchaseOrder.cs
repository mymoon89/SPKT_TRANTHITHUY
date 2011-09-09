/*
 * frmPurchaseOrder.cs
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

namespace SilkDyeInventory
{
    /// <summary>
    /// Class frmPurchaseOrder is used to demonstrate how to create custom dialog box.
    /// 
    /// Class frmPurchaseOrder accepts the customer details and displays a custom dialog box.
    /// </summary>
    public partial class frmPurchaseOrder : Form
    {
        /// <summary>
        /// Constructor without parameters to initialize the
        /// controls for displaying the frmPurchaseOrder form. 
        /// </summary>
        public frmPurchaseOrder()
        {
            InitializeComponent();
        }

        // Validates and displays the custom dialog box
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            int itemNumber = 0;
            double totalAmount = 0.0;
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter the customer name.", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Please enter the customer address.", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
            }
            else if (txtContactNo.Text == "")
            {
                MessageBox.Show("Please enter the customer contact number.", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNo.Focus();
            }
            else
            {
                frmProductDetails frmPD = new frmProductDetails();
                if (frmPD.ShowDialog() == DialogResult.OK)
                {
                    itemNumber = lvwOrderDetails.Items.Count + 1;
                    lvwOrderDetails.Items.Add(itemNumber.ToString());
                    lvwOrderDetails.Items[itemNumber - 1].SubItems.Add(frmPD.Controls["grpProductDetails"].Controls["cboProduct"].Text);
                    lvwOrderDetails.Items[itemNumber - 1].SubItems.Add(frmPD.Controls["grpProductDetails"].Controls["txtPrice"].Text);
                    lvwOrderDetails.Items[itemNumber - 1].SubItems.Add(frmPD.Controls["grpProductDetails"].Controls["txtQuantity"].Text);
                    lvwOrderDetails.Items[itemNumber - 1].SubItems.Add(frmPD.Controls["grpProductDetails"].Controls["txtTotalAmount"].Text);
                }
                for (itemNumber = 0; itemNumber < lvwOrderDetails.Items.Count; itemNumber++)
                {
                    totalAmount = totalAmount + Convert.ToDouble(lvwOrderDetails.Items[itemNumber].SubItems[4].Text);
                    txtTotalAmount.Text = totalAmount.ToString();
                }
            }
        }

        // Closes the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}