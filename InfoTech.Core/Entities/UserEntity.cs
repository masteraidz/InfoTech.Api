using InfoTech.Core.Common;

namespace InfoTech.Core.Entities
{
    public class UserEntity : BaseEntity
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
