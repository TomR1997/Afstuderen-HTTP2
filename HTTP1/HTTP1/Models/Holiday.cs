using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTP1.Models
{
	public class Holiday
	{
		public int Id { get; set; }
		public Country Country { get; set; }
		public Location Location { get; set; }
		public decimal Price { get; set; }
		public DateTime Date { get; set; }
		public List<string> Images { get; set; }
	}
}
