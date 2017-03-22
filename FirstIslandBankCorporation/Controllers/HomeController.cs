using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObject;
using Facade;
using FirstIslandBankCorporation.Models;

namespace FirstIslandBankCorporation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MiniStatementModel model = new MiniStatementModel();

            if (Session["UID"] != null)
            {
                var userId = (Int32)Session["UID"];
                var userEmail = Convert.ToString(Session["Email"]);
                var totalAvaialbeBalance = decimal.Zero;
                MiniStatementFacade _miniStatementFacade = new MiniStatementFacade();
                totalAvaialbeBalance = _miniStatementFacade.GetCurrentAvailableBalanceByUserid(userId);

                IList<UserTransactionsData> userTransactions = _miniStatementFacade.GetUserTransactionsByUserId(userId);
                var savingActBalance = GetAccountBalance(userTransactions.Where(x => x.AccountId == 1).ToList());
                var currentActBalance = GetAccountBalance(userTransactions.Where(x => x.AccountId == 2).ToList());
                var seniorCitizenActBalance = GetAccountBalance(userTransactions.Where(x => x.AccountId == 3).ToList());
                var user = _miniStatementFacade.FindUserByEmail(userEmail);

                model.UserId = userId;
                model.TotalAvaialbeBalance = totalAvaialbeBalance;
                model.SavingAccountBalance = savingActBalance;
                model.CurrentAccountBalance = currentActBalance;
                model.SeniorCitizenAccountBalance = seniorCitizenActBalance;
                model.SavingAccountTransactionCount = userTransactions.Where(x => x.AccountId == 1).Count();
                model.CurrentAccountTransactionCount = userTransactions.Where(x => x.AccountId == 2).Count();
                model.SeniorCitizenTransactionCount = userTransactions.Where(x => x.AccountId == 3).Count();
                model.HasSavingsAccount = user.HasSavingsAccount;
                model.HasCurrentAccount = user.HasCurrentAccount;
                model.HasSeniorCitizenAccount = user.HasSeniorCitizenAccount;
                model.SavingsAccountNumber = user.SavingsAccountNumber;
                model.CurrentAccountNumber = user.CurrentAccountNumber;
                model.SeniorCitizenAccountNumber = user.SeniorCitizenAccountNumber;
            }
            else
            {
                return RedirectToRoute("Default");
            }
            return View(model);
        }

        private decimal GetAccountBalance(IList<UserTransactionsData> transactions)
        {
            var balance = decimal.Zero;
            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;
            }
            return balance;
        }
    }
}