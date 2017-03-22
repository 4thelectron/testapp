using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObject;
using DAO;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic
{
    /// <summary>
    /// MiniStatement Business Logic
    /// </summary>
    public class MiniStatement
    {
        /// <summary>
        /// Find user transactions by accountid and userid
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountId"></param>
        /// <returns>List of transactions</returns>
        public static IList<UserTransactionsData> FindUserTransactionsByAccountId(int userId, int accountId)
        {
            return UserTransactionsDAO.GetUserTransactionsByAccountId(userId, accountId);
        }

        /// <summary>
        /// Find user transactions for export by userid and account number
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountNumber"></param>
        /// <returns>Transactions collection</returns>
        public static DataTable FindUserTransactionsForExport(int userId, string accountNumber)
        {
            return UserTransactionsDAO.GetUserTransactionsForExport(userId, accountNumber);
        }

        /// <summary>
        /// Find user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User data</returns>
        public static User GetUserByEmail(string email)
        {
            return UserTransactionsDAO.GetUserByEmail(email);
        }

        /// <summary>
        /// Gets Current Available Balance by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Current Available Balance</returns>
        public static decimal GetCurrentAvailableBalanceByUserid(int userId)
        {
            return UserTransactionsDAO.GetCurrentAvailableBalanceByUserid(userId);
        }

        /// <summary>
        /// Gets user transactions by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Trasaction collection</returns>
        public static IList<UserTransactionsData> GetUserTransactionsByUserId(int userId)
        {
            return UserTransactionsDAO.GetUserTransactionsByUserId(userId);
        }
    }
}
