/*
	This file deals with accessing the OMDB API through an API class and storing movie data through a movie class. 

	Movie class:
		The Movie class is used for storing data on a Movie. It has the following data, all as strings: Poster, Title, Year, imdbID, Type.
	API class:
	The API class holds no data but provides access to OMDB API functions.
	These functions are as follows:
		search(searchType, userInput) - Returns List of type Movie returned from the search 'userInput'. searchType is a string either "title" for searching by title or "id" for searching by IMDB ID. If no data is found then it will return false.
*/

using System.Net;
using System.Collections.Generic;
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
            JObject json;

            switch (searchType)
            {
                case "title":
                    jsonString = web.DownloadString("http://www.omdbapi.com/?s=" + userInput + "&apikey=ffa0df85");

                    json = JObject.Parse(jsonString);

                    foreach (var result in json["Search"])
                    {
                        Movie movTitle = new Movie();
                        movTitle.Poster = result["Poster"].ToString();
                        movTitle.Title = result["Title"].ToString();
                        movTitle.Year = result["Year"].ToString();
                        movTitle.imdbID = result["imdbID"].ToString();
                        movTitle.Type = result["Type"].ToString();
                        results.Add(movTitle);
                    }

                    break;

                case "id":
                    jsonString = web.DownloadString("http://www.omdbapi.com/?i=" + userInput + "&apikey=ffa0df85");

                    json = JObject.Parse(jsonString);

                    Movie movID = new Movie();
                    movID.Poster = json["Poster"].ToString();
                    movID.Title = json["Title"].ToString();
                    movID.Year = json["Year"].ToString();
                    movID.imdbID = json["imdbID"].ToString();
                    movID.Type = json["Type"].ToString();
                    results.Add(movID);
                    break;

                default:
                    //error
                    break;
            }
        }
        return results;
	}
}
