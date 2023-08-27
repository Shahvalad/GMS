using GMS.Application.Services.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Services.Authentication.Command.Register
{
    public record RegisterCommand(string FirstName, string LastName, string Email, string Password):IRequest<AuthenticationResult>;
}
