using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Web.Data
{
    public class TodoItem
    {
        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public DateTime? Done { get; set; }

        [Required]
        public Author Author { get; set; }
    }
}
