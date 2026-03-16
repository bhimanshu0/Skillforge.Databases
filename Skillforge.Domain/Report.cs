using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skillforge.Domain;


[Table("Report")]
public class Report
{
    [Key]
    public int ReportID { get; set; }

    [Required]
    public ReportScope Scope { get; set; }

    [ForeignKey("CourseIDNavigation")]
    public string CourseID { get; set; }

    [ForeignKey("EmployeeIDNavigation")]
    public string EmployeeID { get; set; }

    [Required]
    public string Metrics { get; set; }
    [Required]
    public DateTime GeneratedDate { get; set; } = DateTime.Now;

    
        
    
    public virtual Course CourseIDNavigation { get; set; }

    
    public virtual User EmployeeIDNavigation { get; set; }


}
