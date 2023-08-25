﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public Category ParentCategory { get; set; }
        //public virtual ICollection<Image> Images { get; set; } = new List<Image>();

        public virtual ICollection<CategoryFilm> CategoryFilms { get; set; } = new List<CategoryFilm>();
    }
}
