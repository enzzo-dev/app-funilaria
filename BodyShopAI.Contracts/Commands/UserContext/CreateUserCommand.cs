using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyShopAI.Contracts.Commands.UserContext
{

    #region Enumerators

    enum Response
    {
        Successful = 0,
        Error = 1
    }

    #endregion

    public class CreateUserCommand : IRequest<Response>
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
    }
}
