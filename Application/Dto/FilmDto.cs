using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class FilmDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ExtendendFilmDto : FilmDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        public int Duration { get; set; }
        public string Language { get; set; }
        public string Author { get; set; }
        public IEnumerable<CategoryDto> Category { get; set; }

    }
    public class CreateFilmDto : FilmDto
    {
        public string? PathName { get; set; }
        public string Description { get; set; }

        public int Duration { get; set; }
        public string Language { get; set; }
        public int AuthorId { get; set; }
        public IEnumerable<int> FilmCategoryIds { get; set; }



    }
    public class UpdateFilmDto : CreateFilmApiDto
    {
        public int? Id { get; set; }
    }

    public class CreateFilmApiDto : CreateFilmDto
    {
        public IFormFile? File { get; set; }
    }
}
