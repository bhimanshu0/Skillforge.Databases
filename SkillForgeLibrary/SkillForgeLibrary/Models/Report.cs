using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillForgeLibrary.Models;


[Table("Report")]
public class Report
{
    [Key]
    public int ReportID { get; set; }

    [Required]
    public ReportScope Scope { get; set; }

    [ForeignKey("CourseIDNavigation")]
    public int? CourseID { get; set; }

    [ForeignKey("EmployeeIDNavigation")]
    public int? EmployeeID { get; set; }

    [Required]
    public string Metrics { get; set; }
    [Required]
    public DateTime GeneratedDate { get; set; } = DateTime.Now;

    
        
    
    public virtual Course? CourseIDNavigation { get; set; }

    
    public virtual User? EmployeeIDNavigation { get; set; }


}

