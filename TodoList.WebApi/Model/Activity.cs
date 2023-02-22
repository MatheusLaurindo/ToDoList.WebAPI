using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoList.WebApi.Model
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 5)]
        [Display(Name = "Atividade")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        [Display(Name = "Descrição da Atividade")]
        public string Description { get; set; }

        [Required]
        public string ExecutionDate { get; set; }

        [Required]
        public string ExecutionTime { get; set; }
        public bool IsFinished { get; set; }
    }
}
