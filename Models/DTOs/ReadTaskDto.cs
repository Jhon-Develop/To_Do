using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do.Models.DTOs
{
    public class ReadTaskDto
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Due Date")]
        public DateOnly DueDate { get; set; }

        [Display(Name = "Priority")]
        public int Priority { get; set; } // 1 - low, 2 - medium, 3 - high

        [Display(Name = "Is Completed")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Create At")]
        public DateTime CreateAt { get; set; }
        
        [Display(Name = "Update At")]
        public DateTime UpdateAt { get; set; }
    }
}