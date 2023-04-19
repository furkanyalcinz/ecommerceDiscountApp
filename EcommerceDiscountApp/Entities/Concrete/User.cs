using Entities.Abstract;
using Entities.Enums;

namespace Entities.Concrete
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; } = Roles.User;
    }
}
