using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseProject.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Please select a category")]
        public int cateId { get; set; }
        public cate? cate { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be more than 0")]

        public int Amount { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Note { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;

        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return cate == null ? "" : cate.img + " " + cate.Title;   
            }
        }
        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((cate == null || cate.Type=="expense")? "- " : "+ ")  + Amount.ToString("C0");
            }
        }
    }
}
