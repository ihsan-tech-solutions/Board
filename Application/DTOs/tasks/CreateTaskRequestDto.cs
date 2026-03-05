using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Tasks
{
    public class CreateTaskRequestDto
    {
        [Required()]
        [Length(4, 30, ErrorMessage = "Title should be minium 4 and maxinum 30 characters")]
        public string Title { get; set; } = string.Empty;
        [Required()]
        [StringLength(50, MinimumLength = 16)]
        public string Description { get; set; } = string.Empty;
        [Required()]
        public DateTime DueDate { get; set; }
        [Range(1, 8, ErrorMessage = "Prority should be between 1 and 8")]
        public int Priority { get; set; }
    }

    // 1. Data Annotations => Above validation attributes is of this type.
    // 2. FluentValidation,
    // 3. Custom validation filters.
}