﻿using Microsoft.EntityFrameworkCore;
using PingisMVC.Models.Entities;
using PingisMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PingisMVC.Models.ViewModels.PlayedMatch;

namespace PingisMVC.Models
{
	public partial class Repository
	{
		private readonly PingisContext context;

		public Repository(PingisContext context)
		{
			this.context = context;
		}

		public LeagueTableVM GetLeagueTable()
		{
			return new LeagueTableVM()
			{
				Players = context.Player
					.OrderByDescending(p => p.Elo)
					.ThenByDescending(p => p.MatchesWon)
					.ToArray()
			};
		}

		public Player GetPlayerById(int id)
		{
			return context.Player
				.Single(p => p.Id == id);
		}

		public PlayedMatch[] GetRecentMatches()
		{
			return context.Match
				.Include(m => m.Player1)
				.Include(m => m.Player2)
				.OrderBy(m => m.Date)
				.Select(m => new PlayedMatch
				{
					PlayerOne = m.Player1.Name,
					PlayerTwo = m.Player2.Name,
					SetsOne = m.Player1Sets,
					SetsTwo = m.Player2Sets,
					DatePlayed = m.Date
				})
				.Take(10)
				.ToArray();
		}

		public PlayedMatch[] GetMatchesById(int id)
		{
			return context.Match
				.Include(m => m.Player1)
				.Include(m => m.Player2)
				.OrderBy(m => m.Date)
				.Where(m => m.Player1Id == id || m.Player2Id == id)
				.Select(m => new PlayedMatch
				{
					PlayerOne = m.Player1.Name,
					PlayerTwo = m.Player2.Name,
					SetsOne = m.Player1Sets,
					SetsTwo = m.Player2Sets,
					DatePlayed = m.Date
				})
				.Take(5)
				.ToArray();
		}

		public Team[] GetTeams() => context.Team
				.ToArray();

		public Player[] GetPlayers()
		{
			return context.Player
				.OrderBy(p => p.TeamId)
				.ThenBy(p => p.Name)
				.ToArray();
		}

		public string GetTeamName(int id)
		{
			return context.Team
				.Single(t => t.Id == id)
				.ClassName;
				
		}
	}
}
