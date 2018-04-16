using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("tblUserProfiles")]
    public class UserProfile
    {
        [ForeignKey("ApplicationUser"), Key]
        public int Id { get; set; }
        [StringLength(maximumLength:128)]
        public string Image { get; set; }
        [Required, StringLength(maximumLength:50)]
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
