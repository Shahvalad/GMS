using GMS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Common.Interfaces.Persistance
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAll();
        void Add(string name, int age, string gender);
        void AddMemberToGroup(string GroupName, Member member);
        void Update(string name, Member member);
        void Delete(string name);
        Member? GetMemberByName (string name);
    }
}
