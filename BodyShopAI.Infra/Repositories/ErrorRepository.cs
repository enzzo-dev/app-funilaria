using BodyShopAI.Domain.Entities;
using BodyShopAI.Infra.Context;
using BodyShopAI.Infra.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyShopAI.Infra.Repositories
{
    public class ErrorRepository : IErrorRepository
    {
        private readonly ILogger<ErrorRepository> _logger;
        private readonly EFContext _Context;

        public ErrorRepository(ILogger<ErrorRepository> logger, EFContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task LogError(Exception ex, string message)
        {
            _logger.LogError(ex, message);

            await _Context.Logs.AddAsync(Error.CreateLog(ex));
            await _Context.SaveChangesAsync();
        }   
    }
}
