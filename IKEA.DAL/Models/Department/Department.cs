using IKEA.DAL.Models.Shared;
using System;

namespace IKEA.DAL.Models.Department
{
    public class Department : ModelBase
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
     
    }
}
