using Lab_3.BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lab_3.DAL
{
    class DALEmployee
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> listE = new List<Employee>();
            DataTable dataTable = Database.GetDataBySQL("select * from Employees");
            foreach (DataRow row in dataTable.Rows)
            {
                int ID = Convert.ToInt32(row["EmployeeID"].ToString());
                string FirstName = row["FirstName"].ToString();
                DateTime BirthDate = DateTime.Parse(row["BirthDate"].ToString()).Date;
                int ReportsTo = Convert.ToInt32(row["ReportsTo"].ToString());
                Employee employee = new Employee(ID, FirstName, BirthDate, ReportsTo);
                listE.Add(employee);
            }
            return listE;
        }

        public static DataTable GetEmployeeByID(int ID)
        {
            DataTable dataTable = Database.GetDataBySQL("select*from Employees where EmployeeID = '" + ID + "'");

            return dataTable;
        }

        public static DataTable GetOrderbyEmployeeID(int ID)
        {
            DataTable dataTable = Database.GetDataBySQL("select * from  [Orders] where EmployeeID = '" + ID + "'");

            return dataTable;
        }

        public static DataTable GetEmployeeTerritoriesByEmployeeID(int ID)
        {
            DataTable dataTable = Database.GetDataBySQL("select * from  EmployeeTerritories where EmployeeID = '" + ID + "'");

            return dataTable;
        }

        public static DataTable GetManagersByEmployeeID(int ID)
        {
            DataTable dataTable = Database.GetDataBySQL("select*from Employees where ReportsTo = '" + ID + "'");

            return dataTable;
        }

        public static int DeleteEmployeeByID(int ID)
        {
            int rs = 0;
            if(GetOrderbyEmployeeID(ID).Rows.Count > 0
                || GetEmployeeTerritoriesByEmployeeID(ID).Rows.Count > 0)
            {
                rs = 0;
            }else if(GetManagersByEmployeeID(ID).Rows.Count > 0)
            {
                rs = 0;
            }
            else
            {
                string sql = "DELETE Employees WHERE EmployeeID = @EmpolyeeID";
                SqlParameter sqlParameters = new SqlParameter("@EmpolyeeID", SqlDbType.Int); ;
                sqlParameters.Value = ID;
                rs = Database.ExecuteSQL(sql, sqlParameters);
            }
            return rs;
        }

        public static int AddEmployee(ArrayList arrayList)
        {
            string sql = "INSERT INTO Employees(FirstName,BirthDate ,ReportsTo) VALUES ( @FirstName ,  @BirthDate, @ReportsTo)";

            SqlParameter[] sqlParameters = new SqlParameter[]{
            new SqlParameter("@FirstName ", SqlDbType.NVarChar),
           new SqlParameter("@BirthDate", SqlDbType.DateTime),
            new SqlParameter("@ReportsTo", SqlDbType.Int),
            };
            for (int i = 0; i < arrayList.Count; i++)
            {
                sqlParameters[i].Value = arrayList[i];
            }
            return Database.ExecuteSQL(sql, sqlParameters);
        }


        public static DataTable GetEmployeeByDataTable()
        {
            DataTable dataTable = Database.GetDataBySQL("select * from  Employees");

            return dataTable;
        }
    }
}
