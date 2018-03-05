using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PingisMVC.Models;
using PingisMVC.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PingisMVC.Controllers
{
    public class HomeController : Controller
    {
		private readonly Repository rep;

		public HomeController(Repository rep)
		{
			this.rep = rep;
		}


		// GET: /<controller>/
		public IActionResult Index()
        {
            return View(rep.GetLeagueTable());
        }

		public IActionResult RecentGames()
		{

			return View(new AllMatchesVM()
			{
				recentMatches = rep.GetRecentMatches()
			});
		}

		public IActionResult PlayerStats()
		{
			return View(new AllMatchesVM()
			{
				recentMatches = rep.GetMatchesById(1007)
			});
		}
	}
}
