using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RatesTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Rates() as ViewResult;
            var model = (RatesViewModel) result.Model;
            var rates = JsonConvert.DeserializeObject<List<Rate>>(model.JsonRates);
            Assert.IsTrue(rates.Count > 0);
        }

        [TestMethod]
        public void TransactionsTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Transactions() as ViewResult;
            var model = (TransactionsViewModel) result.Model;
            var transactions = JsonConvert.DeserializeObject<List<Transaction>>(model.JsonTransactions);
            Assert.IsTrue(transactions.Count > 0);
        }

        [TestMethod]
        public void SkuTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Sku("T2006") as ViewResult;
            var model = (TransactionsSkuViewModel) result.Model;
            var transactionSku = JsonConvert.DeserializeObject<TransactionsSku>(model.JsonTransactionsSku);
            Assert.IsTrue(transactionSku.Transactions.Count > 0);
            Assert.IsTrue(transactionSku.Total == (decimal) 14.99);
            Assert.IsTrue(transactionSku.Transactions[0].SKU == "T2006");
        }
    }
}
