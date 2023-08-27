using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Domain.Entites
{
    public class Member : User
    {
        public Guid Id { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;

        public Guid GroupId { get; set; }

        public Group Group { get; set; }
    }
}
