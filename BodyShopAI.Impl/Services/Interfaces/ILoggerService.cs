using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyShopAI.Impl.Services.Interfaces
{
    public interface ILoggerService
    {
        public Task AddLog(Exception ex);
    }
}
