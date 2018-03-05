using Microsoft.EntityFrameworkCore;
using PingisMVC.Models.Entities;
using PingisMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PingisMVC.Models.ViewModels.MatchesVM;

namespace PingisMVC.Models
{
	public class Repository
	{
		private readonly PingisContext context;

		public Repository(PingisContext context)
		{
			this.context = context;
		}

		public LeagueTableVM GetLeagueTable() => new LeagueTableVM()
		{
			Players = context.Player
				.OrderBy(p => p.Elo)
				.ThenBy(p => p.MatchesWon)
				.ToArray()
		};

		public Player GetPlayerById(int id) => context.Player
				.Single(p => p.Id == id);

		public MatchesVM[] GetRecentMatches()
		{
			return context.Match
				.Include(m => m.Player1)
				.Include(m=> m.Player2)
				.OrderBy(m => m.Date)
				.Select(m => new MatchesVM
				{
					PlayerOne = m.Player1.Name,
					PlayerTwo = m.Player2.Name,
					SetsOne = m.Player1Sets,
					SetsTwo = m.Player2Sets,
					DatePlayed = m.Date
				})
				.ToArray();
		}
	}
}
