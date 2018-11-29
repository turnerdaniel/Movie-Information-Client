using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
	public interface IAPI
	{
		List<Movie> search(string searchType, string userInput);
	}
}
