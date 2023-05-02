using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using coursework.Models;
using coursework.ViewModels;
using coursework.Data;
using Microsoft.EntityFrameworkCore;

namespace coursework.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<ItemStockViewModel> lstData = new List<ItemStockViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT i.ID as ItemId, ItemName, Quantity from Item i inner join Stock st on i.ID=st.ItemID where CAST(st.Quantity AS int) < 10";
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    ItemStockViewModel data;
                    while (result.Read())
                    {
                        data = new ItemStockViewModel();
                        data.ItemID = result.GetInt32(0);
                        data.ItemName = result.GetString(1);
                        data.Quantity = result.GetString(2);
                        lstData.Add(data);
                    }
                }
            }
            return View(lstData);
        }

        public IActionResult Privacy()
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
