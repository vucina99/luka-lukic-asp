using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Comment : Entity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int FilmId { get; set; }
        public int UserId { get; set; }
        public Film Film { get; set; }
        public User User { get; set; }
    }
}
