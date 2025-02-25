using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _25_2_2025.Models;

public partial class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; }

    public decimal? Phone { get; set; }

    public string? Address { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
    public string? Password { get; set; }

    [NotMapped] // هذا يعني أن الحقل غير مرتبط بقاعدة البيانات
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string Rpassword { get; set; }
    public string? Role { get; set; }
}
