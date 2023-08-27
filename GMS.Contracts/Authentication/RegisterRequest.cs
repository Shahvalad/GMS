using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Contracts.Authentication
{
    public record RegisterRequest(string Firstname, string Lastname, string Email, string Password);
}
