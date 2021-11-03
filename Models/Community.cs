using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class Community
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Registration Number")]
        [Required]
        public string Id {get;set;}

          
        [Range(3,50, ErrorMessage = "Value for {0} must be between{1} and {2}.")]
        [DisplayName("Title")]
        [Required(ErrorMessage = "A Name must be provided")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "A decimal number must be provided")]
        [DataType(DataType.Currency)]
        [Column(TypeName ="money")]
        [DisplayName("bugdet")]
        public decimal Budget { get; set; }

        public virtual ICollection<CommunityMembership> Membership { get; set; }

        

    }
}
