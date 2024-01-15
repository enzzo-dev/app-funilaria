using BodyShopAI.Domain.Entities;
using BodyShopAI.Infra.Context;
using BodyShopAI.Infra.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Criar um service para logar

namespace BodyShopAI.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IErrorRepository _loggerService;
        private readonly EFContext _Context;

        public UserRepository(IErrorRepository logger, EFContext context)
        {
            _loggerService = logger ?? throw new ArgumentNullException(nameof(logger));
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(User user)
        {
            try
            {

                await _Context.Users.AddAsync(user);
                await _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               await _loggerService.LogError(ex, ex.Message);
            }
        }

        public async Task DeleteAsync(Guid idUser)
        {
            try
            {
                var userToDelete = await _Context.Users.FindAsync(idUser);

                if (userToDelete is null)
                    throw new ArgumentNullException("any user don't exist's with this id");

                 _Context.Users.Remove(userToDelete);
                await _Context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                await _loggerService.LogError(ex, ex.Message);
            }
        }

        public async Task<User> GetUserById(Guid idUser) => await _Context.Users.FindAsync(idUser);

        public Task<List<User>> ListUsersAsync(Func<User, User> filter)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User userUpdated, Func<User, bool> filter)
        {
            throw new NotImplementedException();
        }
    }
}
