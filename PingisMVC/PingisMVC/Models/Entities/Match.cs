using System;
using System.Collections.Generic;

namespace PingisMVC.Models.Entities
{
    public partial class Match
    {
        public int Id { get; set; }
        public int Player1 { get; set; }
        public int Player2 { get; set; }
        public int? Player1Sets { get; set; }
        public int? Player2Sets { get; set; }
        public DateTime? Date { get; set; }
    }
}
