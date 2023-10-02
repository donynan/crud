using System.ComponentModel.DataAnnotations;

namespace crud.Model
{
    public class employee

    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

   
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

     
        [EmailAddress]
        public string Email { get; set; }

     
        [Display(Name = "Username")]
        public string Username { get; set; }

   
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

    }
}
