using DB;
using Desarrolladores_UDC.Curstom;
using Desarrolladores_UDC.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Desarrolladores_UDC.Services
{
    public class UserService
    {
        private readonly DataBaseContext _context;
        private readonly ProfileService _profileService;
        private readonly SocialLinksService _socialLinksService;
        public List<string> Errors { get; }
        public UserService(DataBaseContext context,
                            ProfileService profileService,
                            SocialLinksService socialLinksService)
        {
            _context = context;
            _profileService = profileService;
            _socialLinksService = socialLinksService;
            Errors = new List<string>();
        }

        public async Task<User> CreateUser(UserAddDto userAddDto, Utilities utilities)
        {
            var user = new User
            {
                Name = userAddDto.Name,
                Email = userAddDto.Email,
                Password = utilities.encripterSHA256(userAddDto.Password),
                Role = userAddDto.Role,
            };
            await _context.Users.AddAsync(user);
            var profile = await _profileService.CreateProfile(user);
            _socialLinksService.CreateSocialLinks(profile);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Login(UserLoginDto userLoginDto, Utilities utilities)
        {
            var user = await _context.Users
                .Where(u => u.Email == userLoginDto.EmailAdress
                    && u.Password == utilities.encripterSHA256(userLoginDto.Password)
                    ).FirstOrDefaultAsync();
            return user;
        }
        public async Task<bool> EmailExists(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email == email);
        }
    }
}
