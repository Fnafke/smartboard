using System.ComponentModel.DataAnnotations;

namespace SmartboardApi.Modules.ProjectModule.Controllers.DTO
{
    public class CreateProjectDTO
    {
        [Required, MaxLength(30)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Description { get; set; }
    }
}
