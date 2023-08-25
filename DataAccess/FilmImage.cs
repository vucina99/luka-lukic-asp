using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FilmImage : Entity
    {
        public string ContentType { get; set; }
        public string Path { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
