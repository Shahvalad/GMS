using GMS.Application.Common.Errors;
using GMS.Application.Common.Interfaces.Persistance;
using GMS.Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Infrastructure.Persistance
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;

        private static List<Member> _members = new();
        public MemberRepository(IUserRepository userRepository, IGroupRepository groupRepository)
        {
            _userRepository = userRepository;
            _groupRepository = groupRepository;
        }

        public void Add(string name, int age, string gender)
        {
            var users = _userRepository.GetUserByName(name);
        }

        public void Delete(string name)
        {
            var existingMember = GetMemberByName(name);
            if (existingMember is null) 
            {
                throw new GroupDoesntExistException();
            }
            _members.Remove(existingMember);
        }

        public IEnumerable<Member> GetAll()
        {
            return _members;
        }

        public Member? GetMemberByName(string name)
        {
            return _members.SingleOrDefault(m => String.Equals(m.FirstName, name, StringComparison.OrdinalIgnoreCase));
        }

        public void Update(string name, Member member)
        {
            var existingMember = GetMemberByName(name);
            if(existingMember is null)
            {
                throw new GroupDoesntExistException();
            }
            existingMember.FirstName = member.FirstName;
            existingMember.LastName = member.LastName;
            existingMember.Email = member.Email;
            existingMember.Age = member.Age;
            existingMember.Password = member.Password;

        }


        public void AddMemberToGroup(string GroupName, Member member)
        {
            var Group = _groupRepository.GetGroupByName(GroupName);

            if(Group is null)
            {
                throw new GroupDoesntExistException();
            }

            Group.Members.Add(member);
        }
    }
}
