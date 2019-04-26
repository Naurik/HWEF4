using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groups
{
    public class ProfileBand
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ProfileMusicGroups { get; set; }
        public string TextMusic { get; set; }
        public long TimesSounding { get; set; }
        public int Rating { get; set; }

        public Guid GroupId { get; set; }
        public virtual ICollection<MusicianGroup> Band { get; set; }

        
    }
}
