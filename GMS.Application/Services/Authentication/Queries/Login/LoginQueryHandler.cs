using DocumentFormat.OpenXml.Spreadsheet;
using GMS.Application.Common.Errors;
using GMS.Application.Common.Interfaces.Authentication;
using GMS.Application.Common.Interfaces.Persistance;
using GMS.Application.Services.Authentication.Common;
using GMS.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Services.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                throw new WrongLoginInputError();
            }

            if (user.Password != query.Password)
            {
                throw new WrongLoginInputError();
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token
                );
        }
    }
}
