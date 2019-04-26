using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groups
{
    public class MusicianGroup
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NameOfGroup { get; set; }
        
    }
}
