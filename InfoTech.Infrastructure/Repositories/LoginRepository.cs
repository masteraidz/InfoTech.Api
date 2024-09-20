using InfoTech.Core.Entities;
using InfoTech.Core.Interfaces;
using InfoTech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InfoTech.Infrastructure.Repositories
{
    public class LoginRepository(InfoTechDbContext dbContext) : ILoginRepository
    {
        public async Task<IEnumerable<LoginEntity>> GetLogins()
        {
            return await dbContext.Logins.ToListAsync();
        }

        public async Task<LoginEntity> GetLoginByIdAsync(Guid id)
        {
            return await dbContext.Logins.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<LoginEntity> AddLoginAsync(LoginEntity entity)
        {
            entity.Id = Guid.NewGuid();
            dbContext.Logins.Add(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<LoginEntity> UpdateLoginAsync(Guid loginId, LoginEntity entity)
        {
            var login = await dbContext.Logins.FirstOrDefaultAsync(x => x.Id == loginId);

            if (login is not null) 
            {
                login.Username = entity.Username;
                login.Password = entity.Password;

                await dbContext.SaveChangesAsync();
                return login;
            }

            return entity;
        }

        public async Task<bool> DeleteLoginAsync(Guid loginId)
        {
            var login = await dbContext.Logins.FirstOrDefaultAsync(x => x.Id == loginId);

            if (login is not null)
            {
                dbContext.Logins.Remove(login);

                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
