using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do.Models
{
    [Table("task_items")]
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        public string Title {get; set;}

        [Required]
        [Column("description")]
        public string Description {get; set;}

        [Required]
        [Column("due_date")]
        public DateOnly DueDate {get; set;}

        [Required]
        [Column("priority")]
        public int Priority {get; set;} // 1 - low, 2 - medium, 3 - high

        [Required]
        [Column("is_completed")]
        public bool IsCompleted {get; set;} = false;

        [Required]
        [Column("cerate_at")]
        public DateTime CreateAt {get; set;} = DateTime.UtcNow;

        [Required]
        [Column("update_at")]
        public DateTime UpdateAt {get; set;}
    }
}