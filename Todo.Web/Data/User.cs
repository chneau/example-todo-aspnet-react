using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Web.Data
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? Password { get; set; }
    }
}
