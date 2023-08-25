using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CommentDto
    {
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public string Comment { get; set; }
    }
    public class GetCommentDto
    {
        public string User { get; set; }
        public string Film { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
