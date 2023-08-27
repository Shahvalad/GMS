using GMS.Application.Common.Errors;
using GMS.Application.Common.Interfaces.Persistance;
using GMS.Domain.Entites;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace GMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IGroupRepository _groupRepository;
        
        public MemberController(IMemberRepository memberRepository, IGroupRepository groupRepository)
        {
            _memberRepository = memberRepository;
            _groupRepository = groupRepository;
        }



        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_memberRepository.GetAll());
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(string groupName, string gender, int age) 
        {

            var group = _groupRepository.GetGroupByName(groupName);

            if(group == null)
            {
                throw new GroupDoesntExistException();
            }

            if (group.Members.Count + 1 > group.Capacity)
            {
                throw new GroupIsFullException();
            }

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var firstName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;
            var surname = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var member = new Member
            {
                Id = Guid.Parse(userId),
                FirstName = firstName,
                LastName = surname,
                Email = email,
                Password = "test", //Bura deyisecek
                Gender = gender,
                Age = age,
                GroupId = group.Id,
            };

            group.Members.Add(member);
            return Ok(member);
        }

        [HttpGet]
        public IActionResult GetUserData()
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var firstName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;
            var surname = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            return Ok(email);
        }
    }
}
