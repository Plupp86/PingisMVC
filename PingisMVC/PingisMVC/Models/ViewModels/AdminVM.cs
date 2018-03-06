using Microsoft.AspNetCore.Mvc.Rendering;
using PingisMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PingisMVC.Models.ViewModels
{
    public class AdminVM
    {

		[Display(Name = "Team")]
		public SelectListItem[] TeamDropList { get; set; }


		[Display(Name = "Team")]
		public SelectListItem[] PlayerDropList { get; set; }

		public Team newTeam { get; set; }


	}
}
