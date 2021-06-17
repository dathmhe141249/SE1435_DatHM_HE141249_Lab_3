using Lab_3.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class frmAdd : Form
    {
        public frmAdd()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            cbReportsTo.DataSource = DALEmployee.GetEmployeeByDataTable();
            cbReportsTo.DisplayMember = "FirstName";
            cbReportsTo.ValueMember = "EmployeeID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           string FirstName = txtFirstName.Text.Trim();
           DateTime BirthDate = dpBirthDate.Value;
           int ReportsTo = Convert.ToInt32(cbReportsTo.SelectedValue.ToString());
            Regex regex = new Regex("^[a-zA-Z]+$");
            if(FirstName.Length == 0)
            {
                MessageBox.Show("First Name can not be empty");
            }
            else if(!regex.IsMatch(FirstName)) {
                MessageBox.Show("First Name is Invalid");
            }
            else
            {
                ArrayList arrayList = new ArrayList() { FirstName, BirthDate, ReportsTo };
                if (DAL.DALEmployee.AddEmployee(arrayList) > 0)
                {
                    MessageBox.Show("Add Succesfully!");
                    this.Hide();
                    new frmEmployee().ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Add Failed!");
                }
            }
        }
        }
    }

