using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Group:BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateOnly BeginDate { get; set; }
        public DateOnly EndDate { get; set; } 
        public ICollection<Student> Students { get; set; }

    }
}
