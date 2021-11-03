using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class CommunityMembership
    {
      
       
        public int StudentId { get; set; }
 
        public string CommunityId { get; set; }
        
        public virtual Community Community { get; set; }
        public virtual Student Student { get; set; }
        


    }
}
