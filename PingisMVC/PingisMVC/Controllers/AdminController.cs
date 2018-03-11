//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace PingisMVC.Controllers
//{
//	[Authorize]
//	public class AdminController : Controller
//	{
//		// GET: /<controller>/
//		public IActionResult Index()
//		{
//			return View();
//		}

//		[AllowAnonymous]
//		[HttpGet]
//		public IActionResult Login()
//		{
//			return View();
//		}

//		[AllowAnonymous]
//		[HttpPost]
//		public IActionResult Login(LoginVM model)
//		{
//			if (!ModelState.IsValid)
//			{
//				return View();
//			}

//			if (!await RedirectPermanent.TryLogin(model))
//			{
//				return Content("Login failed");
//			}

//			if (string.IsNullOrEmpty(Redirect)
//			{

//			}
//			{

//			}
//			return View();
//		}
//	}
//}
