using Application;

namespace Presentation.PL.Auth
{
    public class JwtUser : IApplicationUser
    {
        public string Identity { get; set; }

        public int Id { get; set; }

        public string Email { get; set; }

        public IEnumerable<int> UseCaseIds { get; set; } = new List<int> { };
    }
}
