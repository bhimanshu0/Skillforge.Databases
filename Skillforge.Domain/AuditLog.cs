using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skillforge.Domain;

[Table("AuditLog")]
public class AuditLog
{
    [Key]
    public string? AuditID{get; set;}

    [Column(TypeName ="CHAR(5)")]
    public string? UserID { get; set; }

    [ForeignKey("UserID")] 
    public virtual User? UserIdNavigation { get; set; }

    [Column(TypeName ="VARCHAR(20)")]
    public string? Action{get; set;}

    [Column(TypeName ="VARCHAR(255)")]
    public string? Resource{get; set;}

    [Column(TypeName ="datetime2")]
    public DateTime Timestamp{get; set;}

}
