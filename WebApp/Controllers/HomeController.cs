using Business;
using Newtonsoft.Json;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        RateBusiness rateBusiness = new RateBusiness();
        TransactionBusiness transactionBusiness = new TransactionBusiness();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Abount GNB";

            return View();
        }

        public ActionResult Rates()
        {
            var rates = rateBusiness.GetRates();
            var jsonRates = JsonConvert.SerializeObject(rates);
            var ratesViewModel = new RatesViewModel() { JsonRates = jsonRates };
            return View(ratesViewModel);
        }

        public ActionResult Transactions()
        {
            var transactions = transactionBusiness.GetTransactions();
            var jsonTransactions = JsonConvert.SerializeObject(transactions);
            var transactionsViewModel = new TransactionsViewModel() { JsonTransactions = jsonTransactions };
            return View(transactionsViewModel);
        }

        public ActionResult Sku(string sku)
        {
            var transactions = transactionBusiness.GetTransactions(sku);
            var transactionsSkuViewModel = new TransactionsSkuViewModel() { JsonTransactionsSku = string.Empty };
            if (!transactionBusiness.IsValidSku(sku)) return View(transactionsSkuViewModel);

            var transactionsSku = rateBusiness.GetTransactionsSku(transactions);
            var jsonTransactionsSku = JsonConvert.SerializeObject(transactionsSku);
            transactionsSkuViewModel = new TransactionsSkuViewModel() { JsonTransactionsSku = jsonTransactionsSku };
            return View(transactionsSkuViewModel);
        }

    }
}