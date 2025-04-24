using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseProject.Models
{
    public class cate
    {
        [Key]
        public int cateId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage="Title is required")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        public string Type { get; set; } = "expense";

        [Column(TypeName = "nvarchar(50)")]

        public string img { get; set; } = "";

        [NotMapped]
        public string? TitleWithIcon
        {
            get
            {
                return this.img + " " + this.Title;
            }
        }
    }
}