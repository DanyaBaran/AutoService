using AuthService.Api.Interfaces;
using AutoService.Shared.Models;

namespace AuthService.Api.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AuthenticateUser(string username, string password)
        {
            return _userRepository.GetUserByNameAndPassword(username, password);
        }

        public bool RegisterUser(string username, string password)
        {
            if (_userRepository.GetUserByName(username) != null)
            {
                return false;
            }

            var newUser = new User { Name = username, Password = password, IsAdmin = false };
            _userRepository.Add(newUser);
            return true;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id) => _userRepository.GetById(id);

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.Delete(userId);
        }
    }
}
