using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PatentProj.Models
{
    //[Table("owner")]
    public class Owner
    {
        //public Guid OwnerId { get; set; }
        public long OwnerId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? Name { get; set; }

        //public string? Password { get; set; }

        //[Required(ErrorMessage = "Date of birth is required")]
        public DateTime? DateOfBirth { get; set; }

        //[Required(ErrorMessage = "Address is required")]
        //[StringLength(100, ErrorMessage = "Address cannot be loner then 100 characters")]
        //public string? Address { get; set; }

        //public ICollection<GIForm>? GIForms { get; set; }
        [JsonIgnore]
        public List<GIForm>? GIForms { get; set; }
        [JsonIgnore]
        public List<DesignForm>? DesignForms { get; set; }
        //public ICollection<DesignForm>? DesignForms { get; set; }
    }
}