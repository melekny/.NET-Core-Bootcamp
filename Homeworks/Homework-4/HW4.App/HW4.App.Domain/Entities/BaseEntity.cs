using System;
using System.ComponentModel.DataAnnotations;

namespace HW4.App.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required(ErrorMessage = "CreatedBy field is required!")]
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}