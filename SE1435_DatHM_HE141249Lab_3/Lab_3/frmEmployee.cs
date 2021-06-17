using Lab_3.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }
        private void RefreshDvgEmployee()
        {
            dgvEmployee.DataSource = null;
            dgvEmployee.DataSource = DALEmployee.GetEmployees();

            // thay đổi tên cột cho datagridview
            dgvEmployee.Columns[1].HeaderText = "EmployeeID";
            dgvEmployee.Columns[2].HeaderText = "FirstName";
            dgvEmployee.Columns[3].HeaderText = "BirthDate";
            dgvEmployee.Columns[4].HeaderText = "ReportTo";
        }
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn select = new DataGridViewCheckBoxColumn();
            select.Name = "Select Column";
            select.HeaderText = "Select";
            select.ValueType = typeof(bool);
            dgvEmployee.Columns.Add(select);
            RefreshDvgEmployee();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdd().ShowDialog();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            string id = "";
            DialogResult msg = MessageBox.Show("Do you want to delete this record?", "Warning",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (msg == DialogResult.OK)
            {
                foreach (DataGridViewRow r in dgvEmployee.Rows)
                {
                    DataGridViewCheckBoxCell chk = r.Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(chk.Value) == true)
                    {
                        id = r.Cells[1].Value.ToString();
                        int EmployeeID = Convert.ToInt32(id);
                        count = DALEmployee.DeleteEmployeeByID(EmployeeID);
                    }
                }

            }
            if (count > 0)
            {
                MessageBox.Show("Delete Successfully");

            }
            if (count == 0)
            {
                MessageBox.Show("That Employee Can Not Be Deleted ");
            }else { }
            RefreshDvgEmployee();

        }
            
            }
        }
    

