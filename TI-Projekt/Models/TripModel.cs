using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TI_Projekt.Models
{
    [Table("Trips")]
    public class TripModel
    {
        [Key]
        public int TripId { get; set; }
        [Required]
        [MaxLength(100), MinLength(3)]
        public string Title { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [MaxLength(100), MinLength(3)]
        public string StartPlace { get; set; }
        [Required]
        [MaxLength(100), MinLength(3)]
        public string DestinationPlace { get; set; }
        [Required]
        [Range(1, 1000)]
        public int Distance { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual ICollection<PhotoModel> Photos { get; set; }
        public virtual ICollection<VideoModel> Videos { get; set; }
    }
}