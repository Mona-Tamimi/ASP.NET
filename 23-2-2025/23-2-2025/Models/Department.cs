
using System;
using System.Collections.Generic;

namespace _23_2_2025.Models
{
    public partial class Department
    {
        public int Id { get; set; }

        public string? DepName { get; set; }

        public string? Location { get; set; }

        public int? EmployeesNum { get; set; }

        public int? Since { get; set; }
    }
}