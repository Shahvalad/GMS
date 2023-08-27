using GMS.Application.Common.Errors;
using GMS.Application.Common.Interfaces.Persistance;
using GMS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Infrastructure.Persistance
{
    public class GroupRepository : IGroupRepository
    {
        public static List<Group> groups = new();

        public void AddGroup(Group group)
        {
            groups.Add(group);
        }

        public IEnumerable<Group> GetAll()
        {
            return groups;
        }

        public Group? GetGroupByName(string name)
        {
            return groups.SingleOrDefault(g=>string.Equals(g.Name,name,StringComparison.OrdinalIgnoreCase)); 
        }


        public Group? UpdateGroup(string name, string newName, int newCapacity)
        {
            var existingGroup = GetGroupByName(name);
            if(existingGroup is null) 
            {
                throw new GroupDoesntExistException();
            }
            existingGroup.Name = newName;
            existingGroup.Capacity = newCapacity;
            return existingGroup;
        }

        public void RemoveGroup(string name)
        {
            var existingGroup = GetGroupByName(name);
            if(existingGroup is null)
            {
                throw new GroupDoesntExistException();
            }
            groups.Remove(existingGroup);
        }
    }
}
