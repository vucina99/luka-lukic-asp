
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public ICollection<Film> Films { get; set; }= new List<Film>();
    }
}
