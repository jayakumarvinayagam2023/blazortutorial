using System.ComponentModel.DataAnnotations;

namespace DirtyForm
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "First Name is Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid First Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Middle Name is Required")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Enter Valid First Name")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string? Address { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Enter valid Email Id")]
        [Required(ErrorMessage = "EmailId is Required")]
        public string? EmailId { get; set; }

        [Display(Name = "MobileNo")]
        [RegularExpression(@"^[7-9][0-9]{9}$", ErrorMessage = "Enter Mobile No.")]
        [Required(ErrorMessage = "MobileNo Required")]
        public string? MobileNo { get; set; }
    }
}
