using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;

namespace MovieDatabase
{
	class OMDB : IAPI
	{
		//Default Constructor
		public OMDB() { }

		public List<Movie> search(string searchType, string userInput)
		{
			List<Movie> results = new List<Movie>();

			using (WebClient web = new WebClient())
			{
				string jsonString = "";
				JObject json;

				try
				{
					switch (searchType)
					{
						case "Title":
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

						case "IMDb ID":
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
				catch (NullReferenceException)
				{
					MessageBox.Show("There was an error performing this operation.\nDid you enter the Movie or ID correctly?");
				}
			}
			return results;
		}
	}
}
