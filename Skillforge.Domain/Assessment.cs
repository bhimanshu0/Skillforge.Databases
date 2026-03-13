using System;
// using Microsoft.EntityFrameworkCore.;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Skillforge.Domain;

public class Assessment
{
    [Key]
    [Column(TypeName = "INT")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AssessmentID { get; set; }

    [Column(TypeName = "CHAR(5)")]
    public string CourseID { get; set; }

    [ForeignKey("CourseID")]
    public virtual Course Course { get; set; }

    [Column(TypeName = "VARCHAR(20)")]
    public string Type { get; set; }

    [Column(TypeName = "DECIMAL(4,1)")]
    public decimal MaxScore { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime Date { get; set; }

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
