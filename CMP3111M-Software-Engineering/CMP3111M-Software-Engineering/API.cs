/*
	This file deals with accessing the OMDB API through an API class and storing movie data through a movie class. 

	Movie class:
		The Movie class is used for storing data on a Movie. It has the following data, all as strings: Title, Year, imdbID, Type, Poster.
	API class:
	The API class holds no data but provides access to OMDB API functions.
	These functions are as follows:
		getSearch( searchType, userInput ) - Returns List of type Movie returned from the search 'userInput'. searchType is a string either "title" for searching by title or "id" for searching by IMDB ID. If no data is found then it will return false.
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
    public int Year { get; set; }
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
            string jsonString = web.DownloadString("http://www.omdbapi.com/?s=" + "Star Wars" + "&apikey=ffa0df85");

            JObject json = JObject.Parse(jsonString);

            foreach (var result in json["Search"])
            {
                Movie movie = new Movie();
                movie.Title = result["Title"].ToString();
                movie.Year = Int32.Parse(result["Year"].ToString());
                movie.imdbID = result["imdbID"].ToString();
                movie.Type = result["Type"].ToString();
                

                //movie.Title = node.Attributes["Title"].Value;
                //	movie.Year = node.Attributes["Year"].Value;
                //	movie.imdbID = node.Attributes["imdbID"].Value;
                //	movie.Type = node.Attributes["Type"].Value;
                //	movie.Poster = node.Attributes["Poster"].Value;

                results.Add(movie);
            }

        }


        return results;

		/*string jsonResult;

		if (searchType == "title") // check whether user has chosen to search by title or ID
		{
			jsonResult = Get(@"https://www.omdbapi.com/?s=" + userInput + "&apikey=ffa0df85"); // search by title
		}
		else if (searchType == "id")
		{
			jsonResult = Get(@"https://www.omdbapi.com/?i=" + userInput + "&apikey=ffa0df8"); // search by ID
		} else {
			jsonResult = Get(@"https://www.omdbapi.com/?i=111&apikey=ffa0df8"); // if function is misused this will happen... but it shouldn't
		}
		
		result = JsonConvert.DeserializeObject<List<Movie>>(jsonResult); // convert JSON to list
		*/

		//XmlDocument xmlResult = new XmlDocument();

		//xmlResult.Load("https://www.omdbapi.com/?s=" + userInput + "&apikey=ffa0df85&r=xml");
		//XmlNodeList nodes = xmlResult.DocumentElement.SelectNodes("/result");

		//foreach (XmlNode node in nodes)
		//{
		//	Movie movie = new Movie();
		//	movie.Title = node.Attributes["Title"].Value;
		//	movie.Year = node.Attributes["Year"].Value;
		//	movie.imdbID = node.Attributes["imdbID"].Value;
		//	movie.Type = node.Attributes["Type"].Value;
		//	movie.Poster = node.Attributes["Poster"].Value;

		//	result.Add(movie);
		//}
		//return result;
	}

	public string Get(string uri) // source: https://stackoverflow.com/questions/27108264/c-sharp-how-to-properly-make-a-http-web-get-request
	{
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

		using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
		using (Stream stream = response.GetResponseStream())
		using (StreamReader reader = new StreamReader(stream))
		{
			return reader.ReadToEnd();
		}
	}
}
