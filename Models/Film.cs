﻿using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace Mission6.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string Category {  get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [StringLength(25)]
        public string? Notes { get; set; }
    }
}
