using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TI_Projekt.Models
{
    [Table("Videos")]
    public class VideoModel
    {
        [Key]
        public int VideoId { get; set; }
        [Required]
        [MaxLength(100), MinLength(2)]
        public string VideoName { get; set; }
        [Required]
        public string VideoSrc { get; set; }
        [ForeignKey("Trips")]
        [Required]
        public int TripId { get; set; }
        [Required]
        public virtual TripModel Trips { get; set; }
    }
}