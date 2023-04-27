using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Forms
    {
        [Key]
        public int FormId { get; set; }
        public int createdBy { get; set; }
        [Required(ErrorMessage = "FormName boş bırakılamaz")]
        public string FormName { get; set; }
        [Required(ErrorMessage = "Description boş bırakılamaz")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
    }
}
