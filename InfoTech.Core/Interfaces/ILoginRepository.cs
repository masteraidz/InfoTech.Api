using InfoTech.Core.Entities;

namespace InfoTech.Core.Interfaces
{
    public interface ILoginRepository
    {
        Task<IEnumerable<LoginEntity>> GetLogins();
        Task<LoginEntity> GetLoginByIdAsync(Guid id);
        Task<LoginEntity> AddLoginAsync(LoginEntity entity);
        Task<LoginEntity> UpdateLoginAsync(Guid loginId, LoginEntity entity);
        Task<bool> DeleteLoginAsync(Guid loginId);
    }
}
