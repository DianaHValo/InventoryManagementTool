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
        private static DataSet GetData(string querySql)
        {
            DataSet ds = new DataSet();

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();

            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(querySql, conn);
            // i always reset DataSet before i do
            // something with it.... i don't know why :-)
            ds.Reset();
            // filling DataSet with result from NpgsqlDataAdapter
            da.Fill(ds);
            // since it C# DataSet can handle multiple tables, we will select first
            conn.Close();

            return ds;
        }
        static public List<Employee> returnAllEmployees()
        {
            DataSet ds = new DataSet();

            var resultList = new List<Employee>();

            ds = GetData("SELECT * FROM employees");

            for (int i=0; i< ds.Tables[0].Rows.Count; i++)
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
            return resultList;
        }

        static public List<Device> returnAllDevices()
        {
            DataSet ds = new DataSet();

            var resultList = new List<Device>();

            ds = GetData("SELECT * FROM devices");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                var rand = ds.Tables[0].Rows[i].ItemArray;
                Device dev = new Device();

                dev.id = Convert.ToInt32(rand[0].ToString());
                dev.itemName = rand[1].ToString();
                dev.itemModel = rand[2].ToString();
                dev.itemLocation = rand[3].ToString();
                dev.itemStatus = rand[4].ToString();
                dev.inventoryNum = rand[5].ToString();

                resultList.Add(dev);
            }
            return resultList;
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

        static public bool Delete_Device(int id)
        {
            return false;
        }

    }

   

    
}
