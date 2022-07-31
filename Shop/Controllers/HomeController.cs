using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System.Diagnostics;
using Shop.Databases;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public static bool CartEntered = false;
        public static bool ifLoggedIn = false;
        public static decimal costs = 0;
        public static List<ItemModel> Cart = new List<ItemModel>();
        public static List<ItemModel> items = new List<ItemModel>();
        private readonly ILogger<HomeController> _logger;
        public static int NumberOfItemsTaken = 1;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ItemDAO itemDAO = new ItemDAO();
            if (items.Count == 0)
            {
                itemDAO.PopulateList(items);
            }




            return View();
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
        public IActionResult Shop()
        {


            return View("Shop", items);
        }


        public void AddToCart(int id)
        {
            bool itemInCart = false;
            foreach (var item in Cart)
            {
                if (items.ElementAt(id - 1) == item)
                {
                    itemInCart = true;
                }
            }
            if (itemInCart == false)
            {
                items[id - 1].ItemsTaken += 1;
                Cart.Add(items.ElementAt(id - 1));
                
            }
            else
            {
                items[id - 1].ItemsTaken += 1;
            }
            
        }
        public void AddToCartMany(int id,int amount)
        {

            bool itemInCart = false;
            foreach (var item in Cart)
            {
                if (items.ElementAt(id - 1) == item)
                {
                    itemInCart = true;
                }
            }
            if (itemInCart == false)
            {
                items[id - 1].ItemsTaken += amount;
                Cart.Add(items.ElementAt(id - 1));

            }
            else
            {
                items[id - 1].ItemsTaken += amount;
            }

        }
        public IActionResult OpenCart()
        {
            if (CartEntered == false)
            {
               
                foreach (var item in Cart)
                {
                    costs += (item.Price * item.ItemsTaken);
                }

                CartEntered = true;
            }
            return View("Cart", Cart);
        }

        [HttpPost]
        public void AddCostsToBill(int id)
        {
            costs += items.ElementAt(id - 1).Price;
            items.ElementAt(id - 1).Checked = true;
        }

        [HttpPost]
        public void SubstractCostsFromBill(int id)
        {
            costs -= items.ElementAt(id - 1).Price;
            items.ElementAt(id - 1).Checked = false;
        }
        public IActionResult PartialBill()
        {

            return PartialView("_Bill");
        }
        public IActionResult FinalizeShopping()
        {


            if (ifLoggedIn == true)
            {
                return View("ShoppingEnd");
            }
            else
            {
                return View("CustomersThings");
            }

        }
        public IActionResult EndShopping()
        {
            return View("ShoppingEnd");
        }
        public IActionResult BuyWithoutAccount()
        {
            return View("CustomersData");
        }

        public IActionResult SearchForItem(string searchTerm)
        {
            ItemDAO itemDAO = new ItemDAO();
            List<ItemModel> itemsSearched = itemDAO.Search(searchTerm);
            return View("Shop", itemsSearched);
        }
        public IActionResult SearchForItemByCategory(string searchTerm)
        {
            ItemDAO itemDAO = new ItemDAO();
            List<ItemModel> itemsSearched = itemDAO.SearchByCategory(searchTerm);
            return View("Shop", itemsSearched);
        }



        public IActionResult ShowItemView(int Id)
        {
            //NumberOfItemsTaken = 1;
            return View("ItemView", items[Id]);
        }

        public void IncrementNumberOfItemsTaken(int id,int maxVal)
        {
            int Id = id - 1;
            if (items[Id].ItemsTaken < maxVal)
            {
                items[Id].ItemsTaken++;
                costs += items[Id].Price;
            }



        }
        public void SubstractFromNumberOfItemsTaken(int id)
        {
            int Id = id - 1;
            if (items[Id].ItemsTaken > 0)
            {
                items[Id].ItemsTaken--;
                costs -= items[Id].Price;
            }



        }
        
        public ActionResult ItemAmountPartialView(int id)
        {
            int Id = id - 1;
            return PartialView("_ItemAmountView", items[Id]);
        }
        public ActionResult PartialItemsTakenLabel(int id)
        {
            int Id = id - 1;
            return PartialView("_ItemsTakenLabel", items[Id]);
        }

        public ActionResult DetectInputtedValue(string value, string id)
        {
            int Value = int.Parse(value);
            int Id = int.Parse(id) - 1;
            items[Id].ItemsTaken = Value;
            return PartialView("_ItemsTakenLabel", items[Id]);

        }
    }
}