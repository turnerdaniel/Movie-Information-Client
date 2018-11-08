/*
	This class deals with accessing the OMDB API. 
	Functions are as follows:
		getSearch( searchType, userInput ) - Returns a string array with the first 8 movies returned from the search 'userInput'. searchType is a string either "title" for searching by title or "id" for searching by IMDB ID. If no data is found then it will return [1]="false"
*/

using System;

public class API
{
	public API()
	{

	}

	public string[] getSearch(string searchType, string userInput)
	{
		string[] result = new string[8];

		if (searchType == "title")
		{

		}
		else if (searchType == "id")
		{

		}
	}
}
