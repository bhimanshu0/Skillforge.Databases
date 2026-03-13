using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skillforge.Domain
{
    [Table("SkillGap")]
    public class SkillGap
    {
        [Key]
        public int SkillGapID { get; set; }

        [Required]
        [Column(TypeName = "CHAR(5)")]
        public string EmployeeID { get; set; }

        [Required]
        public int CompetencyID { get; set; }

        [Required]
        public int GapLevel { get; set; }

        [Required]
        public DateTime DateIdentified { get; set; } = DateTime.Now;

        [ForeignKey("EmployeeID")]
        public virtual User Employee { get; set; }

        [ForeignKey("CompetencyID")]
        public virtual Competency Competency { get; set; }
    }
}