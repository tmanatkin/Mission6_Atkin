using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace Mission6.Models
{
    public class Film
    {
        [Key]
        public int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId {  get; set; }
        public Category? CategoryName { get; set; }
        public string Title { get; set; }
        [Range(1888, int.MaxValue, ErrorMessage = "The Year field must be a valid year (after 1888).")]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        public bool CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }
}
