using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Skillforge.Domain;

[Table("ComplianceRecord")]
public class ComplianceRecord
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ComplianceID { get; set; }

    [Required]
    public string EmployeeID { get; set; }

    [Required]
    public int CertificationID { get; set; }

    [MaxLength(20)]
    public string Status { get; set; }

    public DateTime Date { get; set; }

    [ForeignKey("EmployeeID")]
    public virtual User Employee { get; set; }

    [ForeignKey("CertificationID")]
    public virtual Certification Certification { get; set; }
}
