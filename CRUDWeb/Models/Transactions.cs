using NpgsqlTypes;
using System.ComponentModel.DataAnnotations;

namespace CRUDWeb.Models
{
    public class Transactions
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage ="Card Number should be 16 digits.")]
        public string? CardNumber { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Terminal ID should be 8 characters.")]
        public string? TID { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Card Number should be 15 characters.")]
        public string? MID { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Batch No. must be exactly 6 digits.")]
        public int? Batch { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Invoice No. must be exactly 6 digits.")]
        public int? Invoice { get; set; }

        [Required(ErrorMessage ="Required field.")]
        [Range(1, 200000, ErrorMessage = "Transactions should be no more than 2,00,000 INR.")]
        public decimal? Amount { get; set; }

        public DateTime TransactionDateTime { get; set; } = DateTime.UtcNow;
    }
}
