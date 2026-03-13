using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skillforge.Domain;

public class Certification
{
    [Key]
    [Column(TypeName = "INT")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int CertificationID { get; set; }

    [Required]
    [Column(TypeName = "CHAR(5)")]
    public string EmployeeID { get; set; }

    [ForeignKey("EmployeeID")]
    public virtual User UserRoleEmployee { get; set; }

    [Required]
    [Column(TypeName = "CHAR(5)")]
    public string CourseID { get; set; }

    [ForeignKey("CourseID")]
    public virtual Course Course { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime IssueDate { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime ExpiryDate { get; set; }

    [Column(TypeName = "VARCHAR(20)")]
    public string Status { get; set; }
}
