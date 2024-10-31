using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseProject.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int cateId { get; set; }
        public cate cate { get; set; }
        public int Amount { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Note { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;

    }
}
