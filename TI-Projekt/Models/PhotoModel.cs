using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TI_Projekt.Models
{
    [Table("Photos")]
    public class PhotoModel
    {
        [Key]
        public int PhotoId { get; set; }
        [Required]
        [MaxLength(100), MinLength(2)]
        public string PhotoName { get; set; }
        [Required]
        public string PhotoSrc { get; set; }
        [ForeignKey("Trips")]
        [Required]
        public int TripId { get; set; }
        [Required]
        public virtual TripModel Trips { get; set; }
    }
}