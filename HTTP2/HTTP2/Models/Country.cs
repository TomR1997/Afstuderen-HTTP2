using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTP2.Models
{
	public class Country
	{
		public string Name { get; set; }
		public List<Location> Locations { get; set; }

	}
}
