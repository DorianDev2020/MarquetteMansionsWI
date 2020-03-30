using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marquette_Mansions.Data;
using Marquette_Mansions.Models;
using Stripe;
using Stripe.Checkout;
using Microsoft.AspNetCore.Authorization;

namespace Marquette_Mansions.Controllers
{
    [Authorize(Roles = "Tennant")]
    public class PaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Payments
        public ActionResult Index()
        {
            // Set your secret key. Remember to switch to your live secret key in production!
            // See your keys here: https://dashboard.stripe.com/account/apikeys
            StripeConfiguration.ApiKey = "sk_test_Ecr51dB2P6POTJ0dtUr48frT00NrTbCQzP";

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> {
                 "card",
            },
                LineItems = new List<SessionLineItemOptions>
            {
                //Products
                 new SessionLineItemOptions {
                 Name = "Rent",
                 Description = "Monthly Rent Payment",
                 Amount = 600,
                 Currency = "usd",
                 Quantity = 1,
                },
            },
                SuccessUrl = "https://example.com/success?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "https://example.com/cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return View(session);
        }

      
    }
}
