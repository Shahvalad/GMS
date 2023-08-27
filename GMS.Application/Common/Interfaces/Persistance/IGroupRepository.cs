using GMS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Application.Common.Interfaces.Persistance
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetAll();
        Group? GetGroupByName(string name);
        void AddGroup(Group group);
        Group? UpdateGroup(string name, string newName, int newCapacity);
        void RemoveGroup(string name);
    }
}
