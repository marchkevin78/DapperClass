﻿using System;
using System.Collections.Generic;

namespace DapperClass
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
    }
}
