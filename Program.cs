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
    class Program
    {
        static void Main(string[] args)
        {

            // string file = "test.csv";
            string choice;
            string displayRecords;
            string sortChoice;
            string sortChoiceMovieId;
            string sortChoiceMovieTitle;
            string sortChoiceMovieGenres;

            do
            {
                // ask user a question
                Console.WriteLine("#####################################");
                Console.WriteLine("#   1) Read Movie data from file?   #");
                Console.WriteLine("#   2) Add new Movie data?          #");
                Console.WriteLine("#  Enter any other key to exit.     #");
                Console.WriteLine("#####################################");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {

                    using (var streamReader = new StreamReader("movies.csv"))
                    {
                        using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                        {
                            csvReader.Context.RegisterClassMap<MovieInfoClassMap>();
                            var records = csvReader.GetRecords<MovieInfo>().ToList();

                            System.Console.WriteLine("There are " + records.Count + " records. would you like to display them all? \nType 1 for yes" 
                             + " or 2 to sort");

                            displayRecords = Console.ReadLine();

                            if (displayRecords == "1")
                            {
                                    foreach (var record in records)
                                        {
                                            System.Console.WriteLine(record.MovieId + " " + record.Title + " " + record.Genres);
                                            
                                        }System.Console.WriteLine();
                            }else if (displayRecords == "2")
                            {
                                System.Console.WriteLine("How would you like to sort the records?");
                                System.Console.WriteLine("#######################################");
                                System.Console.WriteLine(" 1) Sort by movie ID?");
                                System.Console.WriteLine(" 2) Sort by movie Title?");
                                System.Console.WriteLine(" 3) Sort by move Genre?");

                                sortChoice = Console.ReadLine();

                                if (sortChoice == "1")
                                {
                                    System.Console.WriteLine("Please enter the Movie ID # and press enter to continue.");
                                    sortChoiceMovieId = Console.ReadLine();
                                    
                                    foreach (var record in records)
                                    {
                                        if (record.MovieId == int.Parse(sortChoiceMovieId))
                                        {

                                            System.Console.WriteLine(record.MovieId + " " + record.Title + " " + record.Genres);

                                        }

                                    }
                                }else if (sortChoice == "2")
                                {
                                    System.Console.WriteLine("Please enter the Movie Title and press enter to continue.");
                                    sortChoiceMovieTitle = Console.ReadLine();
                                    foreach (var record in records)
                                    {
                                        if (record.Title.ToUpper().Contains(sortChoiceMovieTitle.ToUpper()))
                                        {
                                            System.Console.WriteLine(record.MovieId + " " + record.Title + " " + record.Genres);
                                        }
                                    }                                    
                                }else if (sortChoice == "3")
                                {
                                    System.Console.WriteLine("Please select Genre = Adventure|Action|Crime|Thriller|Animation|Children|Comedy|Fantasy|Drama|Romance|Sci-Fi.");
                                    sortChoiceMovieGenres = Console.ReadLine();
                                    foreach (var record in records)
                                    {
                                        if (record.Genres.ToUpper().Contains(sortChoiceMovieGenres.ToUpper()))
                                        {
                                            System.Console.WriteLine(record.MovieId + " " + record.Title + " " + record.Genres);
                                        }
                                    }   
                                }
                            }

                        }
                    }
                }else if (choice == "2")
                {
                        System.Console.WriteLine("Enter movie Id Number");
                        string NewMovieId = Console.ReadLine();

                        System.Console.WriteLine("Enter movie title");
                        string NewTitle = Console.ReadLine();

                        System.Console.WriteLine("Enter movie Genre");
                        string NewGenre = Console.ReadLine();

                        var records = new List<MovieInfo>
                        {
                        };
                        records = new List<MovieInfo>
                        {

                            new MovieInfo { MovieId = int.Parse(NewMovieId), Title = NewTitle , Genres = NewGenre},
                        };
                        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            // Don't write the header again.
                            HasHeaderRecord = false,
                        };
                        using (var stream = File.Open("movies.csv", FileMode.Append))
                        using (var writer = new StreamWriter(stream))
                        using (var csv = new CsvWriter(writer, config))
                        {
                            csv.WriteRecords(records);
                        }
                        System.Console.WriteLine();
                        System.Console.WriteLine();
                        System.Console.WriteLine("Movie Information updated");
                        System.Console.WriteLine();
                        System.Console.WriteLine();
                }

            } while (choice == "1" || choice == "2");  

        }
    }
}


//          WRITE NEW FILE 
//          ---------------
// var records = new List<MovieInfo>
// {
//     new MovieInfo { MovieId = 30, Title = "one", Genres = "Action" },
// };

// using (var writer = new StreamWriter("test.csv"))
// using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
// {
//     csv.WriteRecords(records);
// }

