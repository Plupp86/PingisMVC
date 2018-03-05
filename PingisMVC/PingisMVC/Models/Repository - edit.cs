using Microsoft.EntityFrameworkCore;
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
		public void AddPlayer(Player newPlayer)
		{
			context.Player
				.Add(newPlayer);
			context.SaveChanges();
		}

		public void RemovePlayer(int id)
		{
			var playerToRemove = GetPlayerById(id);
			context.Player
				.Remove(playerToRemove);
			context.SaveChanges();
		}

		public void AddTeam(string TeamName)
		{
			context.Team
				.Add(new Team
				{
					ClassName = TeamName
				});
			context.SaveChanges();
		}

		public void AddMatch(Match newMatch)
		{
			if (newMatch.Player1Sets > newMatch.Player2Sets)
				UppdatePlayers(newMatch.Player1Id, newMatch.Player2Id);
			else
				UppdatePlayers(newMatch.Player2Id, newMatch.Player1Id);

			context.Match
				.Add(newMatch);
			context.SaveChanges();
		}

		public void UppdatePlayers(int winner, int loser)
		{
			// Logic to uppdate player rankings and stuff goes here!
		}

    }
}
