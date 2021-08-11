﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String  Author { get; set; }
        public String Genre { get; set; }

        public String Image { get; set; }
        public int NumberofCopies { get; set; }
    }
}
