using PingisMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingisMVC.Models.ViewModels
{
    public class MatchesVM
    {
		public string[] PlayerNames { get; set; }
		public int[] PlayerId { get; set; }
		public Match[] Matches { get; set; }
	}
}
