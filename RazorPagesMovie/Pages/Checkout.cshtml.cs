using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe;
using Stripe.Checkout;

namespace RazorPagesMovie.Pages
{
    public class CheckoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            // 1. Set your API Key
            StripeConfiguration.ApiKey = "sk_test_your_secret_key";

            // 2. Define session options
            var options = new SessionCreateOptions
            {
                // these would be success and cancel pages on your website
                SuccessUrl = "https://yourdomain.com/success",
                CancelUrl = "https://yourdomain.com/cancel",

                LineItems = new List<SessionLineItemOptions>
            {
                // item with a predefined price ID from your Stripe Dashboard
                new SessionLineItemOptions
                {
                    Price = "price_Hh1ZeCZ6qsJgnd", // Use a Price ID from your Dashboard
                    Quantity = 1,
                },

                // item where we generate a custom price on the fly
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = 127, // $1.27 in cents
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Custom Widget",
                        },
                    },
                    Quantity = 1,
                },
            },
                Mode = "payment", // "subscription" for recurring payments
            };

            // 3. Create the session
            var service = new SessionService();
            Session session = await service.CreateAsync(options);

            // 4. Redirect to the Stripe Checkout URL which is generated from the above function
            return Redirect(session.Url);
        }
    }
}
