using System;
using System.Collections.Generic;

namespace PingisMVC.Models.Entities
{
    public partial class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public int SetsWon { get; set; }
        public int SetsLost { get; set; }
        public int SetDifference { get; set; }
        public int? Elo { get; set; }
        public int Class { get; set; }
    }
}
