
namespace Emi.TechnicalTest.BusinessLogic.Model
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }

    }
}
