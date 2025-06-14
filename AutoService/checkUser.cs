using AutoService.Shared.Models;

namespace AutoService
{
    public class CheckUser
    {
        public string Name { get; set; } 
        
        public bool IsAdmin { get; }


        public string Status => IsAdmin ? "Admin" : "User";

        public CheckUser(User user) 
        {
            Name = user.Name.Trim();
            IsAdmin = user.IsAdmin;
        }
    }
}
