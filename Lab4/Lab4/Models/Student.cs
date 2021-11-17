using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("LastName")]
        public string LastName { get; set;}
        [Required]
        [StringLength(50)]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-mm-dd}",ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        
        [Required]
        [StringLength(100)]
        public string FullName
        {
            get { return FirstName + ", " + LastName; }
            
        }

        public  virtual ICollection<CommunityMembership> Membership  { get; set; }

    }
}
