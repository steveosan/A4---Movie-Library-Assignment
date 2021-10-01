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
    
    public class MovieInfo
    {

        public int MovieId {get; set;}
        public string Title {get; set;}
        public string Genres {get; set;}

    }
}