using System;
namespace VegaIT.Data.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        public string Phone { get; set; }

        public UserEntity() { }

        public UserEntity(string FirstName, string LastName, string Username, string Email, string Password, string Phone)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
            this.Phone = Phone;
        }
    }
}
