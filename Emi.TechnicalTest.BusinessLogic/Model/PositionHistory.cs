using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emi.TechnicalTest.BusinessLogic.Model
{
    public class PositionHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionHistoryId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsManager { get; set; }
        public Employee Employee { get; set; }

        [Required]
        [MaxLength(100)]
        public string Position { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
