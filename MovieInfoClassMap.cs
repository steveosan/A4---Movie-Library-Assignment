using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace csvhelperprogram
{
    public class MovieInfoClassMap : ClassMap<MovieInfo>
    {
        public MovieInfoClassMap()
        {
            Map(m => m.MovieId).Name("movieId");
            Map(m => m.Title).Name("title");
            Map(m => m.Genres).Name("genres");

        }
    }
}