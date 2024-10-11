using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do.Models.DTOs
{
    public class CreateTaskDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "The title must be less than 100 characters")]
        [MinLength(3, ErrorMessage = "The title must be more than 3 characters")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "The description must be less than 500 characters")]
        [MinLength(10, ErrorMessage = "The description must be more than 10 characters")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateOnly DueDate { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "The priority must be between 1 and 3")]
        [Display(Name = "Priority")]
        public int Priority { get; set; } // 1 - low, 2 - medium, 3 - high
    }
}