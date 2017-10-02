using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genre
    {
        public byte GenreId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}