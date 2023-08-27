using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Domain.Entites
{
    public class Group
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Capacity { get; set; }

        public List<Member> Members { get; set; } = new List<Member>();
    }
}
