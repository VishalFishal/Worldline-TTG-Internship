using NpgsqlTypes;
using System.ComponentModel.DataAnnotations;
namespace CRUDWeb.Models
{
    public class Accounts
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter an E-Mail ID.")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Password should be at least 5 characters.")]
        public string? Password { get; set; }

    }
}
