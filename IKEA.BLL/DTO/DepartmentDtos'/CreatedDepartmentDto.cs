using System;
using System.ComponentModel.DataAnnotations;

namespace IKEA.BLL.DTO.DepartmentDTO
{
    public class CreatedDepartmentDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateOnly? DateOfCreation { get; set; }
    }
}
