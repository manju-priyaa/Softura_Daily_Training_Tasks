using System;
using System.Collections.Generic;
using System.Linq;
using TransportDALLibrary;

namespace TransportBLLibrary
{
    public class EmployeeBL : IRepo<Employee>, IUserLogin<Employee>
    {
        EmployeeDAL dal;
        public EmployeeBL()
        {
            //craete an obj for employeedal and get the properties in dal
            dal = new EmployeeDAL();
        }
        public bool Add(Employee t)
        {
            try
            {
                //dal which contains all the properties for employeedal now go the function addemployee
                return dal.AddEmployee(t);

            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public ICollection<Employee> GetAll()
        {
            List<Employee> employees;
            try
            {
                //goes to the DAL employee method return as list and return the list employee
                employees = dal.SelectAllEmployees().ToList();
                return employees;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public bool Login(Employee t)
        {
            bool result = false;
            try
            {
                List<Employee> employees = GetAll().ToList();
                //select * from employees where id=@id and password=@password
                Employee employee = employees.Find(e => e.Id == t.Id && e.Password == t.Password);
                if (employee != null)
                    result = true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            return result;
        }

        public bool Update(Employee t)
        {
            try
            {
                return dal.UpdatePassword(t);
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }
    }
}
