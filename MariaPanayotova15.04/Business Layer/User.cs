using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "First name cannot be more than 20 symbols!")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Last name cannot be more than 20 symbols!")]
        public string LastName { get; set; }

        [Required]
        [Range(18, 81, ErrorMessage = "Age must be in [18;81] years")]
        public int Age { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Username cannot be more than 20 symbols!")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(70, ErrorMessage = "Password cannot be more than 70 symbols!")]
        public string Password { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Email cannot be more than 20 symbols!")]
        public string Email { get; set; }
        
        public List<User> Friends { get; set; }
        public List<Hobby> Hobbies { get; set; }

        private User()
        { 

        }
        public User(string firstName, string lastName, int age, string userName)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            UserName = userName;
            Friends = new List<User>();
        }

    }
}
