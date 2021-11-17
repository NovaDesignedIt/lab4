using Lab5;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public enum Question { Earth , Computer }
    public class AnswerImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AnswerImageId { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("File Name")]
        public string FileName { get; set; }

        [Required]
        [StringLength(150)]
        public string Url
        {
            get; set;
        }

        [Required]
        public Question Question{ get; set;}


    }
}
