using InfoTech.Core.Entities;

namespace InfoTech.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetUsers();
        Task<UserEntity> GetUserByIdAsync(Guid id);
        Task<UserEntity> AddUserAsync(UserEntity entity);
        Task<UserEntity> UpdateUserAsync(Guid userId, UserEntity entity);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}