using DB;
using Desarrolladores_UDC.Curstom;
using Microsoft.AspNetCore.Mvc;

namespace Desarrolladores_UDC.Services
{
    public class ProfileService
    {
        private readonly DataBaseContext _context;
        public ProfileService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Profile> CreateProfile(User user)
        {
            var profile = new Profile { User = user };
            await _context.Profiles.AddAsync(profile);
            return profile;
        }
    }
}
