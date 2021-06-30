using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Web.Data
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Description { get; set; }

        public DateTime? Done { get; set; }

        public Author? Author { get; set; }
    }
}
