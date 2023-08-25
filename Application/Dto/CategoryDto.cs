using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
  
    public class CategoryDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
    public class FindCategoryDto : CategoryDto
    {
        public IEnumerable<CategoryDto> ChildCategories { get; set; }
        public IEnumerable<FilmDto> Films { get; set; }
    }
}