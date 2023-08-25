using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Film : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public int AuthorId { get; set; }
        public decimal Price { get; set; }
        public string Language { get; set; }
        public Author Author { get; set; }
        public virtual ICollection<CategoryFilm> CategoryFilms { get; set; } = new List<CategoryFilm>();
        public virtual ICollection<FilmImage> FilmImages { get; set; } = new List<FilmImage>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }   
}
