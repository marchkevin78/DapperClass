using System;
using System.Collections.Generic;

namespace DapperClass
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();
        public void InsertDepartment(string newDepartmentName);
        public void UpdateDepartment(string updatedName, int id);
        public void DeleteDepartment(int id);
    }
}
