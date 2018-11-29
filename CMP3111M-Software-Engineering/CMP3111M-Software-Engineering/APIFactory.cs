using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
	class APIFactory
	{
		public IAPI createAPI(string apiName)
		{
			switch (apiName)
			{
				case "OMDB":
					return new OMDB();
				case "TMDB":
					return new TMDB();
				default:
					throw new ApplicationException("The " + apiName + "API cannot be created");
			}
		}
		}
}
