using DevFreela.API.Models;
using DevFreela.Application.InputModels.User;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.User;
using DevFreela.Core.Entities;
using DevFreela.CORE.Repositories;
using DevFreela.CORE.Services;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _context;
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public UserService(DevFreelaDbContext context, IAuthService authService, IUserRepository userRepository)
        {
            _context = context;
            _authService = authService;
            _userRepository = userRepository;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var passwordHash = _authService.ComputeSha256Hash(inputModel.Password);

            var user = new User(inputModel.FullName,
                                inputModel.Email,
                                inputModel.BirthDate,
                                inputModel.Role,
                                passwordHash);

            _context.Users.Add(user);

            _context.SaveChanges();

            return user.Id;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel(user.FullName, user.Email);
        }

        public async Task<LoginUserViewModel> Login(LoginInputModel loginInputModel)
        {
            var passwordHash = _authService.ComputeSha256Hash(loginInputModel.PassWord);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(loginInputModel.Email, passwordHash);

            if (user == null)
            {
                return null;
            }

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            var loginUserViewModel = new LoginUserViewModel(user.Email, token);

            return loginUserViewModel;
        }      
    }
}
