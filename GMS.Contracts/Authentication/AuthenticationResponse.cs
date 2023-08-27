using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Contracts.Authentication
{
    public record AuthenticationResponse(Guid Id, string Firstname, string Lastname, string Email, string Token);
}
