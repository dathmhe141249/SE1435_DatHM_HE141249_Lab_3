using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_3.BLL
{
    class Employee
    {
        private int EmployeeID;
        private string FirstName;
        private DateTime BirthDate;
        private int ReportsTo;

        public Employee()
        {
        }

        public Employee(int employeeID, string firstName, DateTime birthDate, int reportsTo)
        {
            EmployeeID1 = employeeID;
            FirstName1 = firstName;
            BirthDate1 = birthDate;
            ReportsTo1 = reportsTo;
        }

        public int EmployeeID1 { get => EmployeeID; set => EmployeeID = value; }
        public string FirstName1 { get => FirstName; set => FirstName = value; }
        public DateTime BirthDate1 { get => BirthDate; set => BirthDate = value; }
        public int ReportsTo1 { get => ReportsTo; set => ReportsTo = value; }
    }
}
