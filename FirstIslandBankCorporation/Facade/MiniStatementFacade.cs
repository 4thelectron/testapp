using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObject;
using BusinessLogic;
using System.Data;
using System.Data.SqlClient;

namespace Facade
{
    /// <summary>
    /// Mini Statement Facade
    /// </summary>
    public partial class MiniStatementFacade
    {
        /// <summary>
        /// Get user transactions by accountId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountId"></param>
        /// <returns>List transactions</returns>
        public IList<UserTransactionsData> GetUserTransactionsByAccountId(int userId, int accountId)
        {
            return MiniStatement.FindUserTransactionsByAccountId(userId, accountId);
        }

        /// <summary>
        /// Get account type by accountid
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>Account Type</returns>
        public String GetAccountTypeByAccountId(int accountId)
        {
            var result = String.Empty;
            switch (accountId)
            {
                case 1:
                    result = "Savings Account";
                    break;
                case 2:
                    result = "Current Account";
                    break;
                case 3:
                    result = "Senior Citizen Account";
                    break;
            }
            return result;
        }

        /// <summary>
        /// Find user transactions for export
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountNumber"></param>
        /// <returns>Transaction Collection</returns>
        public DataTable FindUserTransactionsForExport(int userId, string accountNumber)
        {
            return MiniStatement.FindUserTransactionsForExport(userId, accountNumber);
        }

        /// <summary>
        /// Find user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Transaction Collection</returns>
        public User FindUserByEmail(string email)
        {
            return MiniStatement.GetUserByEmail(email);
        }

        /// <summary>
        /// Gets Current Available Balance by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Current Available Balance</returns>
        public decimal GetCurrentAvailableBalanceByUserid(int userId)
        {
            return MiniStatement.GetCurrentAvailableBalanceByUserid(userId);
        }

        /// <summary>
        /// Gets user transactions by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Trasaction collection</returns>
        public IList<UserTransactionsData> GetUserTransactionsByUserId(int userId)
        {
            return MiniStatement.GetUserTransactionsByUserId(userId);
        }
    }
}
