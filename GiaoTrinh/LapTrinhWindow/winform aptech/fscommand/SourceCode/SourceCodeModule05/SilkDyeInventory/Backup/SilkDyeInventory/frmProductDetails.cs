/*
 * frmProductDetails.cs
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
    /// Class frmProductDetails is used to demonstrate how to create custom dialog box.
    /// 
    /// Class frmProductDetails accepts the details of order.
    /// </summary>
    public partial class frmProductDetails : Form
    {
        /// <summary>
        /// Constructor without parameters to initialize the
        /// controls for displaying the frmProductDetails form. 
        /// </summary>
        public frmProductDetails()
        {
            InitializeComponent();
        }

        // Validates the controls and calculates the amount
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "" || txtQuantity.Text == "0")
            {
                txtTotalAmount.Text = "0";
                btnOK.Enabled = false;
            }
            else
                CalculateAmount();
        }

        // Validates the controls and calculates the amount
        private void CalculateAmount()
        {
            int price = 0;
            int quantity = 0;
            int totalAmount = 0;
            if (cboProduct.Text == "")
            {
                MessageBox.Show("Please select the product.", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboProduct.Focus();
            }
            else
            {
                try
                {
                    price = Convert.ToInt32(txtPrice.Text);
                    quantity = Convert.ToInt32(txtQuantity.Text);
                    totalAmount = price * quantity;
                    txtTotalAmount.Text = totalAmount.ToString();
                    btnOK.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please enter positive quantity.", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTotalAmount.Text = "0";
                    txtQuantity.Text = "";
                    txtQuantity.Focus();
                    btnOK.Enabled = false;
                }
            }
        }

        // Selects the product and displays the rate
        private void cboProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cboProduct.SelectedIndex)
            {
                case 0:
                    txtPrice.Text = "1500";
                    break;
                case 1:
                    txtPrice.Text = "2000";
                    break;
                case 2:
                    txtPrice.Text = "1450";
                    break;
                case 3:
                    txtPrice.Text = "1700";
                    break;
                default:
                    txtPrice.Text = "0";
                    break;
            }
        }
    }
}