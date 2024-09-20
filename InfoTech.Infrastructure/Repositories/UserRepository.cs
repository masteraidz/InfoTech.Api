using InfoTech.Core.Entities;
using InfoTech.Core.Interfaces;
using InfoTech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfoTech.Infrastructure.Repositories
{
    public class UserRepository(InfoTechDbContext dbContext) : IUserRepository
    {
        public async Task<IEnumerable<UserEntity>> GetUsers()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<UserEntity> GetUsersByIdAsync(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<UserEntity> AddUserAsync(UserEntity entity)
        {
            entity.Id = Guid.NewGuid();
            dbContext.Users.Add(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<UserEntity> UpdateUserAsync(Guid userId, UserEntity entity)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is not null) 
            {
                user.Username = entity.Username;
                user.Password = entity.Password;

                await dbContext.SaveChangesAsync();
                return user;
            }

            return entity;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is not null)
            {
                dbContext.Users.Remove(user);

                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }

        public Task<UserEntity> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
