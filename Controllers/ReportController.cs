using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coursework.Data;
using coursework.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using coursework.Models;
using Microsoft.AspNetCore.Authorization;

namespace coursework.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StockListReport(string search)
        {
            List<ItemStockViewModel> lstData = new List<ItemStockViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand()) {
                command.CommandText = "SELECT i.ID as ItemId, ItemName, Quantity from Item i inner join Stock st on i.ID=st.ItemID";
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
            if (search == null)
            {
                return View(lstData.OrderBy(x => x.ItemName));
            }
            else
            {
                return View(lstData.OrderBy(x => x.ItemName).Where(x => x.ItemName.Contains(search)).ToList());
            }
            
        }

        public IActionResult OutOfStockReport()
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
            //if (sort == "1")
            //{
            //    return View(lstData.OrderBy(x => x.ItemName).Where(x => x.ItemName.Contains(sort)).ToList());
            //}
            //if (sort == "2")
            //{ 
            //    return View(lstData.OrderByDescending(y => y.Quantity).Where(x => x.Quantity.Contains(sort)).ToList());
            //}
            //if (sort == "3")
            //{
            //    return View(lstData);
            //}
            //else
            //{
            //    return View(lstData);
            //}
        }

        public IActionResult CustomerPurchaseReport(string search)
        {
            List<CustomerPurchaseViewModel> lstData = new List<CustomerPurchaseViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select c.Id as CustomerId, c.CustomerName, c.CustomerCode, s.Date, s.BillNumber, sd.Quantity, sd.Amount from Customer c inner join Sales s on c.Id=s.CustomerId inner join SalesDetails sd on s.Id=sd.SalesID where s.date >= CURRENT_TIMESTAMP -31";
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    CustomerPurchaseViewModel data;
                    while (result.Read())
                    {
                        data = new CustomerPurchaseViewModel();
                        data.CustomerId = result.GetInt32(0);
                        data.CustomerName = result.GetString(1);
                        data.CustomerCode = result.GetString(2);
                        data.Date = result.GetDateTime(3);
                        data.BillNumber = result.GetString(4);
                        data.Quantity = result.GetString(5);
                        data.Amount = result.GetString(6);
                        lstData.Add(data);
                    }
                }
            }
            if (search == null)
            {
                return View(lstData.OrderBy(x => x.CustomerName));
            }
            else
            {
                return View(lstData.OrderBy(x => x.CustomerName).Where(x => x.CustomerName.Contains(search)).ToList());
            }
        }
    }
}
