using DB;

namespace Desarrolladores_UDC.Services
{
    public class SocialLinksService
    {
        private readonly DataBaseContext _context;
        public SocialLinksService(DataBaseContext context)
        {
            _context = context;
        }
        public async void CreateSocialLinks(Profile profile)
        {
            var socialLinks = new SocialLinks { Profile = profile };
            await _context.SocialLinks.AddAsync(socialLinks);
        }
    }
}
