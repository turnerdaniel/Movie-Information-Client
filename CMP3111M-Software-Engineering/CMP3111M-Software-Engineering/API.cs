/*
	This file deals with accessing the OMDB API through an API class and storing movie data through a movie class. 

	Movie class:
		The Movie class is used for storing data on a Movie. It has the following data, all as strings: Poster, Title, Year, imdbID, Type.
	API class:
	The API class holds no data but provides access to OMDB API functions.
	These functions are as follows:
		search(searchType, userInput) - Returns List of type Movie returned from the search 'userInput'. searchType is a string either "title" for searching by title or "id" for searching by IMDB ID. If no data is found then it will return false.
*/

using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Movie // the movie class for containing information about a movie
{
    public string Poster { get; set; } //image URL (.jpg)
    public string Title { get; set; }
    public string Year { get; set; } //string because some dates are ranges
    public string imdbID { get; set; } //format: tt1234567
    public string Type { get; set; }
}

public class API
{
    //Default Constructor
	public API() {}

	public List<Movie> search(string searchType, string userInput)
	{
		List<Movie> results = new List<Movie>();

        using (WebClient web = new WebClient())
        {
            string jsonString = "";

            switch (searchType)
            {
                case "title":
                    jsonString = web.DownloadString("http://www.omdbapi.com/?s=" + userInput + "&apikey=ffa0df85");
                    break;

                case "id":
                    jsonString = web.DownloadString("http://www.omdbapi.com/?i=" + userInput + "&apikey=ffa0df85");
                    break;

                default:
                    //error
                    break;
            }

            JObject json = JObject.Parse(jsonString);

            foreach (var result in json["Search"])
            {
                Movie movie = new Movie();
                movie.Poster = result["Poster"].ToString();
                movie.Title = result["Title"].ToString();
                movie.Year = result["Year"].ToString();
                movie.imdbID = result["imdbID"].ToString();
                movie.Type = result["Type"].ToString();
                results.Add(movie);
            }
        }
        return results;
	}
}
