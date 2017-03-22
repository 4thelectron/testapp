using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObject;
using Facade;
using FirstIslandBankCorporation.Models;
using System.IO;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;
using System.Data.SqlClient;

namespace FirstIslandBankCorporation.Controllers
{
    /// <summary>
    /// Mini Statement Controller
    /// </summary>
    public partial class MiniStatementController : Controller
    {
        public MiniStatementController()
        {
        }

        /// <summary>
        /// User mini statement view controller
        /// Entry Criteria : userid and accountid shouldnt be null. 
        /// Responsibility : Display user mini statement
        /// Success Criteria : Fetchs users transactions from DB displays to user
        /// Exception condition: Fail when the database call fails for any exception.
        /// @return
        /// @throws SQLException
        /// @throws ClassNotFoundException
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountId"></param>
        /// <returns>UserTransactionsModel</returns>
        public ActionResult ViewMiniStatement(int userId, int accountId)
        {
            MiniStatementFacade _miniStatementFacade = new MiniStatementFacade();
            UserTransactionsModel userTransactionsModel = new UserTransactionsModel();
            try
            {
                IList<UserTransactionsData> transactions = _miniStatementFacade.GetUserTransactionsByAccountId(userId, accountId);
                if (transactions.Count > 0)
                {
                    userTransactionsModel.AccountType = _miniStatementFacade.GetAccountTypeByAccountId(transactions.FirstOrDefault().AccountId);
                    userTransactionsModel.AccountNumber = transactions.FirstOrDefault().AccountNumber;
                }
                userTransactionsModel.UserTransactions = transactions;
                ViewBag.accountBalance = GetAccountBalance(transactions);
            }
            catch (Exception)
            {
            }
            return View(userTransactionsModel);
        }
        
        /// <summary>
        /// Export user transactions controller
        /// Entry Criteria : userid and accountnumber shouldnt be null. 
        /// Responsibility : Exports user transactions to excel 
        /// Success Criteria : Fetchs users transactions from DB and exports to excel
        /// Exception condition: Fail when the database call fails for any exception.
        /// @return
        /// @throws SQLException
        /// @throws ClassNotFoundException
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountNumber"></param>
        public ActionResult ExportData(int userId, string accountNumber)
        {
            MiniStatementFacade _miniStatementFacade = new MiniStatementFacade();
            try
            {
                DataTable transactions = _miniStatementFacade.FindUserTransactionsForExport(userId, accountNumber);

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(transactions);
                    wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    wb.Style.Font.Bold = true;

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename= EmployeeReport.xlsx");

                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            catch (Exception)
            {
            }
            return RedirectToAction("ViewMiniStatement", "MiniStatement");
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
 