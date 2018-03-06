using Microsoft.AspNetCore.Mvc.Rendering;
using PingisMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PingisMVC.Models.ViewModels
{
    public class AddMatchVM
    {
		//public AddMatchVM()
		//{
		//	SelectListItem[] Sets = new SelectListItem[3];
		//	Sets[0] = new SelectListItem { Value = "1", Text = "1" };
		//	Sets[1] = new SelectListItem { Value = "2", Text = "2" };
		//	Sets[2] = new SelectListItem { Value = "3", Text = "3" };
		//}

		[Display(Name = "Player")]
		public SelectListItem[] ListOfPlayers { get; set; }


		public SelectListItem[] Sets { get; set; }
		

		public Match NewMatch { get; set; }


	}
}
