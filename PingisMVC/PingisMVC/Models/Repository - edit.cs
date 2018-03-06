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
				UppdatePlayers(newMatch.Player1Id, newMatch.Player2Id, newMatch.Player1Sets, newMatch.Player2Sets);
			else
				UppdatePlayers(newMatch.Player2Id, newMatch.Player1Id, newMatch.Player2Sets, newMatch.Player1Sets);

			context.Match
				.Add(newMatch);
			context.SaveChanges();
		}

		public void UppdatePlayers(int winner, int loser, int winnerSets, int loserSets)
		{
			var winningPlayer = context.Player
				.Single(p => p.Id == winner);

			var losingPlayer = context.Player
				.Single(p => p.Id == loser);

			winningPlayer.MatchesWon++;
			winningPlayer.MatchesPlayed++;
			winningPlayer.SetsWon += winnerSets;
			winningPlayer.SetsLost += loserSets;
			winningPlayer.SetDifference += (winnerSets - loserSets);

			losingPlayer.MatchesLost++;
			losingPlayer.MatchesPlayed++;
			losingPlayer.SetsWon += loserSets;
			losingPlayer.SetsLost += winnerSets;
			losingPlayer.SetDifference += (loserSets - winnerSets);



			double ratingWinner = Math.Pow(10, Convert.ToDouble(winningPlayer.Elo) / 400);
			double ratingLoser = Math.Pow(10, Convert.ToDouble(losingPlayer.Elo) / 400);

			double rateChange = 1 - ratingWinner / (ratingWinner + ratingLoser);

			winningPlayer.Elo += Convert.ToInt32(32 * rateChange);
			losingPlayer.Elo -= Convert.ToInt32(32 * rateChange);

			context.SaveChanges();
		}
	}
}
