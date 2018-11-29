using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
	abstract class APIFactory
	{
		public abstract IAPI createAPI(string apiName);
	}
}
