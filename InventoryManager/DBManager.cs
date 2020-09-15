using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    static class DBManager
    {
        private const string connString = "Host=127.0.0.1;Username=postgres;Password=Password1;Database=VirtualInventoryManagerDB";

        static public List<Employee> returnAllEmployees()
        {
            DataSet ds = new DataSet();
            var resultList = new List<Employee>();

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();
            // quite complex sql statement
            string sql = "SELECT * FROM employees";
            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            // i always reset DataSet before i do
            // something with it.... i don't know why :-)
            ds.Reset();
            // filling DataSet with result from NpgsqlDataAdapter
            da.Fill(ds);
            // since it C# DataSet can handle multiple tables, we will select first

            for(int i=0; i< ds.Tables[0].Rows.Count; i++)
            {
                var rand = ds.Tables[0].Rows[i].ItemArray;
                Employee emp = new Employee();

                emp.employeeId = Convert.ToInt32(rand[0].ToString());
                emp.firstName = rand[1].ToString();
                emp.lastName = rand[2].ToString();
                emp.phoneNum = rand[3].ToString();
                emp.eMail = rand[4].ToString();
                emp.adress = rand[5].ToString();

                resultList.Add(emp);
            }

            conn.Close();
            return resultList;
        }

        static public List<Device> returnAllDevices()
        {
            return null;
        }

        static public bool AddEmployee(Employee newEmployee)
        {
            return false;
        }

        static public bool AddDevice(Device newDevice)
        {
            return false;
        }

        static public bool EditEmployee(Employee editedEmployee)
        {
            return false;
        }

        static public bool EditDevice(Device editedDevice)
        {
            return false;
        }

        static public bool DeleteEmployee(int employeeId)
        {
            return false;
        }

        static public bool DeleteDevice(int id)
        {
            return false;
        }

    }
}
