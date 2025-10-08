using IKEA.DAL.Models.Employee;
using IKEA.DAL.Models.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace IKEA.PL.ViewModels
{
    public class EmployeeEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string Name { get; set; } = null!;

        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65")]
        public int Age { get; set; }

        public string? Address { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public decimal Salary { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Enter a valid phone number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        public DateOnly HiringDate { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Employee type is required")]
        [Display(Name = "Employee Type")]
        public EmployeeType EmployeeType { get; set; }

        // Audit fields
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
