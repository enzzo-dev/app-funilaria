using BodyShopAI.Impl.Services.Interfaces;
using BodyShopAI.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyShopAI.Impl.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IErrorRepository _errorRepository;

        public LoggerService(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository ?? throw new ArgumentNullException(nameof(errorRepository));
        }

        public async Task AddLog(Exception ex)
        {
            if (ex is null)
                throw new ArgumentNullException("Exception does not exist");

            await _errorRepository.LogError(ex, ex.Message);
        }
    }
}
