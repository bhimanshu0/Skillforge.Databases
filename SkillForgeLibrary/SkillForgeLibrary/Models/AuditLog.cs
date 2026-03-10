using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillForgeLibrary.Models;

[Table("AuditLog")]
public class AuditLog
{
    [Key]
    public string? AuditID{get; set;}

    [ForeignKey("UserIdNavigation")]
    [Column(TypeName ="VARCHAR(5)")]
    public string? UserID{get; set;}

    [Column(TypeName ="VARCHAR(20)")]
    public string? Action{get; set;}

    [Column(TypeName ="VARCHAR(255)")]
    public string? Resource{get; set;}

    [Column(TypeName ="datetime2")]
    public DateTime Timestamp{get; set;}

    public virtual User? UserIdNavigation{set; get;}

}
