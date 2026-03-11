using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;

namespace SkillForgeLibrary.Models;

[Table("User")]
public class User
{
    [Key]
    [Column(TypeName = "CHAR(5)")]
    public string? UserID { get; set; }

    [Column(TypeName = "CHAR(20)")]
    [Required]
    public string? Name { get; set; }

    [Column(TypeName = "CHAR(20)")]
    [Required]
    public string? Role { get; set; }

    [Column(TypeName = "CHAR(50)")]
    [Required, RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
    ErrorMessage = "Invalid email address format.")]
    public string? Email { get; set; }

    [Column(TypeName = "CHAR(10)")]
    [Required, RegularExpression(@"^\d{10}$", ErrorMessage = "Phone must be exactly 10 digits.")]
    public string? Phone { get; set; }

    [Column(TypeName = "CHAR(15)")]
    [Required]
    public string? Status { get; set; }
    //public virtual ICollection<AuditLog> AuditLogs{get; set;}=new List<AuditLog>();
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
    public virtual ICollection<Certification> Certifications { get; set; } = new List<Certification>();
}