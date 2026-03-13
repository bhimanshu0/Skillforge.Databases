using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Skillforge.Domain;
[Table("Course")]
public class Course
{
    [Key]
    [Column (TypeName ="char(5)")]
    public string CourseID {get; set;}
    [Column (TypeName ="char(20)")]
    [Required]
    public string Title {get; set;}
    [Column (TypeName ="char(50)")]
    [Required]
    public string Description {get; set;}
    [Column (TypeName ="char(5)")]
    [ForeignKey("UserIDNavigation")]
    public string TrainerID {get; set;}
    [Required]
    public int Duration {get; set;}
    [Column (TypeName ="char(10)")]
    
    public string Status {get; set;}

    public virtual ICollection<Module> Modules {get; set;}= new List<Module>();
    public virtual User UserIDNavigation {get; set;}
}
