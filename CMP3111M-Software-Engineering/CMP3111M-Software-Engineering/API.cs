/*
	This class deals with accessing the OMDB API. 
	Functions are as follows:
		getSearch( searchType, userInput ) - Returns a string array with the first 8 movies returned from the search 'userInput'. searchType is a string either "title" for searching by title or "id" for searching by IMDB ID. If no data is found then it will return false.
*/

using System;
using System.Net;

public class API
{
	public API()
	{

	}

	public string[] getSearch(string searchType, string userInput)
	{
		string[] result = new string[8];
		string jsonResult;

		if (searchType == "title")
		{
			jsonResult = Get("http://www.omdbapi.com/?s=" + userInput + "&apikey=ffa0df85");
		}
		else if (searchType == "id")
		{
			jsonResult = Get("http://www.omdbapi.com/?i=" + userInput + "&apikey=ffa0df8");
		}

		result = JsonConvert.DesiraliseObject<String>(jsonResult);

		if (result[1]["Response"] == "False")
		{
			return  false;
		} else
		{
			return result;
		}
	}

	public string Get(string uri) // source: https://stackoverflow.com/questions/27108264/c-sharp-how-to-properly-make-a-http-web-get-request
	{
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
		request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

		using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
		using (Stream stream = response.GetResponseStream())
		using (StreamReader reader = new StreamReader(stream))
		{
			return reader.ReadToEnd();
		}
	}
}
