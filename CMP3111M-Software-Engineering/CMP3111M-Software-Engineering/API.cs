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
using Newtonsoft.Json;
using System.Xml;

public class Movie // the movie class for containing information about a movie
{
	public string Title { get; set; }
	public string Year { get; set; }
	public string imdbID { get; set; }
	public string Type { get; set; }
	public string Poster { get; set; } // this is a URL
}

public class API
{
	public API()
	{

	}

	public List<Movie> getSearch(string searchType, string userInput)
	{
		List<Movie> result = new List<Movie>();
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

		XmlDocument xmlResult = new XmlDocument();

		xmlResult.Load("https://www.omdbapi.com/?s=" + userInput + "&apikey=ffa0df85&r=xml");
		XmlNodeList nodes = xmlResult.DocumentElement.SelectNodes("/result");

		foreach (XmlNode node in nodes)
		{
			Movie movie = new Movie();
			movie.Title = node.Attributes["Title"].Value;
			movie.Year = node.Attributes["Year"].Value;
			movie.imdbID = node.Attributes["imdbID"].Value;
			movie.Type = node.Attributes["Type"].Value;
			movie.Poster = node.Attributes["Poster"].Value;

			result.Add(movie);
		}
		return result;
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
