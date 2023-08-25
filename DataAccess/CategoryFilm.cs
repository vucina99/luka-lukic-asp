﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CategoryFilm
    {
        public int FilmId { get; set; }
        public int CategoryId { get; set; }

        public Film Film { get; set; }
        public Category Category { get; set; }
    }
}
