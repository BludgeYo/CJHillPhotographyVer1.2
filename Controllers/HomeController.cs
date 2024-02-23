using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CJHillPhotography.Models;


namespace CJHillPhotography.Controllers
{
    public class HomeController : Controller
    {
        private YourDbContext db = new YourDbContext();

        public ActionResult Index()
        {
            var images = db.Images.ToList(); // Retrieve a list of Image objects from the database
            return View(images);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Action to display the shopping cart
        public ActionResult Cart()
        {
            // Retrieve cart items from the database or session, depending on your implementation
            var cartItems = db.CartItems.ToList(); // Example: Retrieve cart items from the database

            return View(cartItems);
        }

        // Action for the Models page
        public ActionResult Models()
        {
            var images = db.Images.ToList(); // Retrieve a list of Image objects from the database
            return View(images);
        }

        // Action for the Landscapes page
        public ActionResult Landscapes()
        {
            var images = db.Images.ToList(); // Retrieve a list of Image objects from the database
            return View(images);
        }

        public ActionResult Shop()
        {
            var images = db.Images.ToList(); // Retrieve a list of Image objects from the database
            return View(images);
        }

        public ActionResult GetImage(int id)
        {
            var image = db.Images.FirstOrDefault(i => i.ImageID == id);
            if (image != null)
            {
                return File(image.ImageData, "image/jpeg"); // Adjust the content type as per your image type
            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: /Home/SignUp
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Home/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Add user to the database
                db.Users.Add(user);
                db.SaveChanges();

                // Set success message
                TempData["SuccessMessage"] = "Registration successful!";
                return RedirectToAction("Index"); // Redirect to home page after sign-up
            }
            return View(user); // If model state is not valid, return the sign-up view with errors
        }

        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var authenticatedUser = db.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (authenticatedUser != null)
            {
                // Set authentication cookie and redirect to home page
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult AddToCart(int imageId, int quantity)
        {
            try
            {
                // Check if the item already exists in the cart
                var existingCartItem = db.CartItems.FirstOrDefault(c => c.ImageId == imageId);

                if (existingCartItem != null)
                {
                    // If the item already exists, update its quantity
                    existingCartItem.Quantity += quantity;
                }
                else
                {
                    // If the item doesn't exist, create a new cart item
                    var cartItem = new CartItem { ImageId = imageId, Quantity = quantity };
                    db.CartItems.Add(cartItem);
                }

                // Save changes to the database
                db.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Handle the exception
                return Json(new { success = false, message = ex.Message });
            }
        }

        public ActionResult DeleteFromCart(int itemId)
        {
            // Find the cart item by its ID in the database
            var cartItem = db.CartItems.Find(itemId);

            // If the cart item is found, remove it from the database
            if (cartItem != null)
            {
                db.CartItems.Remove(cartItem);
                db.SaveChanges(); // Save changes to the database
            }

            // Redirect back to the cart page
            return RedirectToAction("Cart");
        }

        public ActionResult UpdateQuantity(int itemId, int quantity)
        {
            // Find the cart item by its ID in the database
            var cartItem = db.CartItems.Find(itemId);

            // If the cart item is found, update its quantity and save changes
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                db.SaveChanges();
            }

            // Redirect back to the cart page
            return RedirectToAction("Cart");
        }
    }
}