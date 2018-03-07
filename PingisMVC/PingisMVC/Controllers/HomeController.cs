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
			return View(rep.PopulateLists());
		}

		[HttpPost]
		public IActionResult AddMatch(AddMatchVM model)
		{
			if (model.SelectedPlayer1Id == model.SelectedPlayer2Id)
			{
				ModelState.AddModelError("SelectedPlayer2Id", "Players cannot be the same!");
			}

			if (model.SelectedPlayer1Sets == model.SelectedPlayer2Sets || (model.SelectedPlayer1Sets < 2 && model.SelectedPlayer2Sets < 2))
			{
				ModelState.AddModelError("SelectedPlayer2Sets", "Incorrect Result! Matches are played in best of 3 sets.");
			}

			if (!ModelState.IsValid)
			{
				return View(rep.PopulateLists());
			}

			Match newMatch = new Match()
			{
				Player1Id = model.SelectedPlayer1Id,
				Player2Id = model.SelectedPlayer2Id,
				Player1Sets = model.SelectedPlayer1Sets,
				Player2Sets = model.SelectedPlayer2Sets,
				Date = DateTime.Now
			};
			
			rep.AddMatch(newMatch);
			return RedirectToAction(nameof(Index));
		}
	}
}
