using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class Hobby
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Name cannot be more than 20 symbols!")]
        public string Name { get; set; }
        
        public List<User> Users { get; set; }

        public List<District> Districts { get; set; }

        private Hobby() { }
        public Hobby (string name)
        {
            Name = name;
            Users = new List<User>();
        }

    }
}
