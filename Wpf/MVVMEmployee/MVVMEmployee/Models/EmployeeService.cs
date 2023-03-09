﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMEmployee.Models
{
    public class EmployeeService
    {
        MvvmDemoDbContext ObjContext;
        public EmployeeService()
        {
            ObjContext = new MvvmDemoDbContext();
        }

        public List<EmployeeDTO> GetAll()
        {
            List<EmployeeDTO> ObjEmployeesList = new List<EmployeeDTO>();
            try
            {
                var ObjQuery = from obj in ObjContext.Employees
                               select obj;
                foreach (var employee in ObjQuery)
                {
                    ObjEmployeesList.Add(new EmployeeDTO { Id = employee.Id, Name = employee.Name, Age = employee.Age });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjEmployeesList;
        }

        public bool Add(EmployeeDTO objNewEmployee)
        {
            bool IsAdded = false;
            //Age must be between 21 and 58
            if (objNewEmployee.Age < 21 || objNewEmployee.Age > 58)
                throw new ArgumentException("Invalid age limit for employee");

            try
            {
                var ObjEmployee = new Employee();
                ObjEmployee.Id = objNewEmployee.Id;
                ObjEmployee.Name = objNewEmployee.Name;
                ObjEmployee.Age = objNewEmployee.Age;

                ObjContext.Employees.Add(ObjEmployee);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return IsAdded;
        }

        public bool Update(EmployeeDTO objEmployeeToUpdate)
        {
            bool IsUpdated = false;

            try
            {
                var ObjEmployee = ObjContext.Employees.Find(objEmployeeToUpdate.Id);
                ObjEmployee.Name = objEmployeeToUpdate.Name;
                ObjEmployee.Age = objEmployeeToUpdate.Age;
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsUpdated = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsUpdated;
        }

        public bool Delete(int id)
        {
            bool IsDeleted = false;
            try
            {
                var ObjEmployeeToDelete = ObjContext.Employees.Find(id);
                ObjContext.Employees.Remove(ObjEmployeeToDelete);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return IsDeleted;
        }

        public EmployeeDTO Search(int id)
        {
            EmployeeDTO ObjEmployee = null;

            try
            {
                var ObjEmployeeToFind = ObjContext.Employees.Find(id);
                if (ObjEmployeeToFind != null)
                {
                    ObjEmployee = new EmployeeDTO()
                    {
                        Id = ObjEmployeeToFind.Id,
                        Name = ObjEmployeeToFind.Name,
                        Age = ObjEmployeeToFind.Age
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjEmployee;
        }
    }
}
