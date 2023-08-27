using GMS.Application.Services.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Services.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<AuthenticationResult>;
}
