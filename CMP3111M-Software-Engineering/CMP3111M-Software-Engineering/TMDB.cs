using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;

namespace MovieDatabase
{
	class TMDB : IAPI
	{
		//Default Constructor
		public TMDB() { }

		public List<Movie> search(string searchType, string userInput)
		{
			List<Movie> results = new List<Movie>();

			using (WebClient web = new WebClient())
			{
				string jsonString = "";
				JObject json;
				JObject idResponse;

				try
				{
					switch (searchType)
					{
						case "Title":
							jsonString = web.DownloadString("https://api.themoviedb.org/3/search/movie?api_key=ce3d10763b9e4dc46748c25948f710bc&query=" + userInput + "&page=1");

							json = JObject.Parse(jsonString);

							foreach (var result in json["results"])
							{
								Movie movTitle = new Movie();
								movTitle.Poster = "https://image.tmdb.org/t/p/w200" + result["poster_path"].ToString();
								movTitle.Title = result["title"].ToString();
								movTitle.Year = result["release_date"].ToString();

								string tmdbID = result["id"].ToString();
								string jsonTMDB = web.DownloadString("https://api.themoviedb.org/3/movie/" + tmdbID + "?api_key=ce3d10763b9e4dc46748c25948f710bc");
								idResponse = JObject.Parse(jsonTMDB);
								movTitle.imdbID = idResponse["imdb_id"].ToString();


								movTitle.Type = "Movie";
								results.Add(movTitle);
							}

							break;

						case "IMDb ID":
							jsonString = web.DownloadString("https://api.themoviedb.org/3/find/" + userInput + "?api_key=ce3d10763b9e4dc46748c25948f710bc&external_source=imdb_id");

							json = JObject.Parse(jsonString);

							foreach (var result in json["movie_results"])
							{
								Movie movID = new Movie();
								movID.Poster = "https://image.tmdb.org/t/p/w200" + result["poster_path"].ToString();
								movID.Title = result["title"].ToString();
								movID.Year = result["release_date"].ToString();
								movID.imdbID = userInput;
								movID.Type = "Movie";
								results.Add(movID);
							}

							break;

						default:
							//error
							break;
					}
				}
				catch(WebException)
				{
					MessageBox.Show("No movies were returned using this criteria.\nDid you enter the Movie or ID correctly?");
				}
				catch (NullReferenceException)
				{
					MessageBox.Show("No movies were returned using this criteria.\nDid you enter the Movie or ID correctly?");
				}
			}
			return results;
		}
	}
}
