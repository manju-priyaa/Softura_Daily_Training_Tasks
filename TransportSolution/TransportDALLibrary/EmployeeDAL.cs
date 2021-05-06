using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace TransportDALLibrary
{
    public class EmployeeDAL
    {
        SqlConnection conn;
        SqlCommand cmd;
        String strConnection;
        public EmployeeDAL()
        {
            strConnection = @"server=DESKTOP-L4O7HT2;Integrated security= true; Initial catalog=dbSoftTransport";
            conn = new SqlConnection(strConnection);
        }
        public bool AddEmployee(Employee employee)
        {
            //instead of giving the query we give stored procedure
            cmd = new SqlCommand("proc_InsertEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //these are the parameters inside the stored procedure
                cmd.Parameters.AddWithValue("@eName", employee.Name);
                cmd.Parameters.AddWithValue("@ePassword", employee.Password);
                cmd.Parameters.AddWithValue("@eLocation", employee.Location);
                cmd.Parameters.AddWithValue("@ePhone", employee.Phone);
                //to check if there is any connection already open if so then close it
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                //Execute Non Quey will return an ineger --we use this because we are inserting value
                int result = cmd.ExecuteNonQuery();
                //since inset returns 1 if row is affected so the beloew if..else..
                if (result > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                conn.Close();
            }

            
        }
        public bool UpdatePassword(Employee employee)
        {
            //instead of giving the query we give stored procedure
            cmd = new SqlCommand("proc_UpdatePassword", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //these are the parameters inside the stored procedure
                cmd.Parameters.AddWithValue("@eid", employee.Id);
                cmd.Parameters.AddWithValue("@ePassword", employee.Password);
                //to check if there is any connection already open if so then close it
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                //Execute Non Quey will return an ineger --we use this because we are inserting value
                int result = cmd.ExecuteNonQuery();
                //since inset returns 1 if row is affected so the beloew if..else..
                if (result > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                conn.Close();
            }


        }
        public ICollection<Employee> SelectAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            //This says the abpove command is sql procedure because procedure is always executed diff
            SqlCommand cmd = new SqlCommand("proc_GetAllEmployees");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            //DataAdapter is a dissconnected database type here we will get all the detials from the database and close the datbase and read them
            //whereas in connected databse like DataReader we open the databse read them and close the connection
            SqlDataAdapter daEmployee = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();//dataset is a collection of datatable
            //datable is a collection of rows
            //row is a collection of column
            try
            {
                daEmployee.Fill(ds, "Employee");//connect-->Fetch the data->put it in the dataset->give the name provided->disconnected from db
                Employee employee;
                //since dataset is acollection of table table[0] iterated to entirs table of first row
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    employee = new Employee();
                    employee.Id = Convert.ToInt32(dr[0]);
                    employee.Name = dr[1].ToString();
                    employee.Password = dr[2].ToString();
                    employee.Location = dr[3].ToString();
                    employee.Phone = dr[4].ToString();
                    employee.VehicleNumber = dr[5].ToString();
                    employees.Add(employee);


                }
                return employees;



            }
            catch (Exception e)
            {

                throw e;

            }
            return employees;
        }

    }
}
