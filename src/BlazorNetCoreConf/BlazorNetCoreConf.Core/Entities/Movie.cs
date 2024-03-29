﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorNetCoreConf.Core.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public bool Liked { get; set; }
    }
}
