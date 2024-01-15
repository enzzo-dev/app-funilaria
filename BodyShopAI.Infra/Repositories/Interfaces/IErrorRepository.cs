using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyShopAI.Infra.Repositories.Interfaces
{
    public interface IErrorRepository
    {
        public Task LogError(Exception ex, string Mensagem);
    }
}
