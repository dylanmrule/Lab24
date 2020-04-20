using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DunkinDonuts.Models;
using Microsoft.AspNetCore.Http;
using DunkinDonuts.DAL;
using DunkinDonuts.DAL.EntityModels;

namespace DunkinDonuts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DunkinDonutsContext _context = new DunkinDonutsContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.IsAvailable)
            {
                ViewBag.Name = HttpContext.Session.GetString("UserFName");
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginUser(LoginViewModel model)
        {
            var user = _context.Users.Where(x => x.Email == model.Email).FirstOrDefault();
            if (!ReferenceEquals(user, null))
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserFName", user.FName);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeNewUser([Bind("FName,LName,Email,UserName,AccountBalance")] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new DunkinDonutsContext())
                {
                    var user = new User()
                    {
                        FName = model.FName,
                        LName = model.LName,
                        Email = model.Email,
                        UserName = model.UserName,
                        AccountBalance = model.AccountBalance
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return RedirectToAction("Register");
        }
        public IActionResult Items()
        {
            var items = _context.Items.ToList();
            List<ItemViewModel> itemsToView = new List<ItemViewModel>();
            int UserId = 0;

            if  (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserFName")))
            {
                UserId = (int)(HttpContext.Session.GetInt32("UserId"));


                var user = _context.Users.Find(UserId);
                foreach (var item in items)
                {
                    var tempItem = new ItemViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        QuantityAvailable = item.QuantityAvailable,
                        UserId = UserId,
                        RemainingBalance = user.AccountBalance
                    };
                    itemsToView.Add(tempItem);
                    ViewBag.Name = HttpContext.Session.GetString("UserFName");
                }

                
            }
            else
            {
                foreach (var item in items)
                {
                    var tempItem = new ItemViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        QuantityAvailable = item.QuantityAvailable,

                    };
                    itemsToView.Add(tempItem);

                }
            }
            return View(itemsToView);
        }
        public IActionResult Buy(int? itemid, int? userid)
        {
            var user = _context.Users.Find(userid);
            var item = _context.Items.Find(itemid);
            if (item.Price < user.AccountBalance && item.QuantityAvailable > 0)
            {
                user.AccountBalance = user.AccountBalance - item.Price;
                item.QuantityAvailable--;
                var userItem = new UserItem()
                {
                    UserId = user.Id,
                    ItemId = item.Id
                };
                _context.Users.Update(user);
                _context.UserItems.Add(userItem);
                _context.SaveChanges();
                return RedirectToAction("Items");
            }
            else 
            {
                return RedirectToAction("InsufficientFunds");
            }
        }
        public IActionResult UserItems()
        {
            int userId = 0;
            if (HttpContext.Session.IsAvailable)
            {
                userId = (int)(HttpContext.Session.GetInt32("UserId"));
            }
            var userItems = _context.UserItems.Where(x => x.UserId == userId).ToList();
            List<Item> items = new List<Item>();
            foreach (var id in userItems)
            {
                var tempItem = _context.Items.Find(id.ItemId);
                items.Add(tempItem);
            }
            List<UserItemViewModel> itemsToView = new List<UserItemViewModel>();
            foreach (var item in items)
            {
                var model = new UserItemViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price
                };
                itemsToView.Add(model);
            }

            return View(itemsToView);
        }
        public IActionResult InsufficientFunds()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
