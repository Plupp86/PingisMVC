using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PingisMVC.Models;
using PingisMVC.Models.Entities;
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

		public IActionResult PlayerStats(int id)
		{
			return PartialView("PlayStats", new PlayerStatsVM()
			{
				recentMatches = rep.GetMatchesById(id)
			});
		}

		[HttpGet]
		public IActionResult AddPlayer()
		{
			var teams = rep.GetTeams();
			var model = new AddPlayerVM
			{
				TeamDropList = new SelectListItem[teams.Length]
			};

			for (int i = 0; i < teams.Length; i++)
			{
				model.TeamDropList[i] = new SelectListItem { Value = teams[i].Id.ToString(), Text = teams[i].ClassName };
			}
			return View(model);
		}

		[HttpPost]
		public IActionResult AddPlayer(AddPlayerVM model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			rep.AddPlayer(new Player(model.Name, model.TeamId));
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult AddMatch()
		{
			var players = rep.GetPlayers();
			var model = new AddMatchVM()
			{
				ListOfPlayers = new SelectListItem[players.Length],
				Sets = new SelectListItem[3]
			};

			model.Sets[0] = new SelectListItem { Value = "0", Text = "0" };
			model.Sets[1] = new SelectListItem { Value = "1", Text = "1" };
			model.Sets[2] = new SelectListItem { Value = "2", Text = "2" };



			for (int i = 0; i < players.Length; i++)
			{
				var teamname = rep.GetTeamName(players[i].TeamId);
				var text = $"{teamname} - {players[i].Name}";
				model.ListOfPlayers[i] = new SelectListItem { Value = players[i].Id.ToString(), Text = text };
			}
			return View(model);
		}

		[HttpPost]
		public IActionResult AddMatch(AddMatchVM model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			model.NewMatch.Date = DateTime.Now;
			rep.AddMatch(model.NewMatch);
			return RedirectToAction(nameof(Index));
		}
	}
}
