using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HTTP1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HTTP1.Controllers
{
    public class HolidayController : Controller
    {
		private List<Holiday> holidays;
		private List<Country> countries;
		private List<string> images;
		private IHostingEnvironment env;

		public HolidayController(IHostingEnvironment env)
		{
			this.env = env;
			Init();
		}
		public IActionResult Holiday()
		{
			return View(holidays);
		}

		public IActionResult Detail(int id)
		{
			var holiday = holidays.FirstOrDefault(h => h.Id == id);
			if (holiday == null)
			{
				return NotFound();
			}

			return View(holiday);
		}
		private void InitHolidays()
		{
			holidays = new List<Holiday>();
			var random = new Random();

			for (int i = 0; i < 25; i++)
			{
				var country = countries[random.Next(0, countries.Count)];
				holidays.Add(new Holiday
				{
					Id = i,
					Country = country,
					Location = country.Locations[random.Next(0, country.Locations.Count)],
					Date = DateTime.Now,
					Price = new decimal(random.Next(50, 1000)),
					Images = images
				});
			}
		}

		private void Init()
		{
			InitImages();
			InitCountries();
			InitHolidays();
		}

		private void InitImages()
		{
			var rootImages = Directory.GetFiles(Path.Combine(env.WebRootPath, "images")).ToList();
			images = new List<string>();

			foreach (var t in rootImages)
			{
				images.Add("/images/" + Path.GetFileName(t));
			}
		}

		private void InitCountries()
		{
			countries = new List<Country>
			{
				new Country { Name = "Netherlands", Locations = new List<Location>
					{
						new Location { Name = "Eindhoven" },
						new Location { Name = "Tilburg" }
					}
				},
				new Country { Name = "Spain", Locations = new List<Location>
					{
						new Location { Name = "Mallorca" },
						new Location { Name = "Madrid" }
					}
				},
				new Country { Name = "Turkey", Locations = new List<Location>
					{
						new Location { Name = "Ozdere" },
						new Location { Name = "Lara" }
					}
				},
				new Country { Name = "Belgium", Locations = new List<Location>
					{
						new Location { Name = "Brussels" },
						new Location { Name = "Liege" }
					}
				},
				new Country { Name = "France", Locations = new List<Location>
					{
						new Location { Name = "Paris" },
						new Location { Name = "Lyon" }
					}
				},
				new Country { Name = "Croatia", Locations = new List<Location>
					{
						new Location { Name = "Zagreb" },
						new Location { Name = "Omis" }
					}
				},
				new Country { Name = "Germany", Locations = new List<Location>
					{
						new Location { Name = "Berlin" },
						new Location { Name = "Munich" }
					}
				},
				new Country { Name = "Sweden", Locations = new List<Location>
					{
						new Location { Name = "Stockholm" },
						new Location { Name = "Goteborg" }
					}
				},
				new Country { Name = "Finland", Locations = new List<Location>
					{
						new Location { Name = "Helsinki" },
						new Location { Name = "Vantaa" }
					}
				},
				new Country { Name = "Norway", Locations = new List<Location>
					{
						new Location { Name = "Oslo" },
						new Location { Name = "Bergen" }
					}
				}
			};
		}
	}
}