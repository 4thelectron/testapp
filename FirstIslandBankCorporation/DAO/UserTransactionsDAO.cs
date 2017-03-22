using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObject;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAO
{
    /// <summary>
    /// UserTransaction DAO
    /// </summary>
    public static class UserTransactionsDAO
    {
        /// <summary>
        /// Gets user transactions by userid and account id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountId"></param>
        /// <returns>Trasaction collection</returns>
        public static IList<UserTransactionsData> GetUserTransactionsByAccountId(int userId, int accountId)
        {
            List<UserTransactionsData> list = new List<UserTransactionsData>();
            try
            {
                var connectionString = "Data Source = .; Initial Catalog = master; Integrated Security = True";
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "GetUserTransactionsByAccountId";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@UserId", userId));
                    command.Parameters.Add(new SqlParameter("@AccountId", accountId));
                    
                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        UserTransactionsData userTransactionsData = new UserTransactionsData();
                        userTransactionsData.Id = Convert.ToInt32(dataTable.Rows[i]["Id"]);
                        userTransactionsData.UserId = Convert.ToInt32(dataTable.Rows[i]["UserId"]);
                        userTransactionsData.AccountId = Convert.ToInt32(dataTable.Rows[i]["AccountId"]);
                        userTransactionsData.AccountNumber = Convert.ToString(dataTable.Rows[i]["AccountNumber"]);
                        userTransactionsData.TransactionDate = Convert.ToDateTime(dataTable.Rows[i]["TransactionDate"]);
                        userTransactionsData.Description = Convert.ToString(dataTable.Rows[i]["Description"]);
                        userTransactionsData.Amount = Convert.ToDecimal(dataTable.Rows[i]["Amount"]);
                        userTransactionsData.TransactionType = Convert.ToString(dataTable.Rows[i]["TransactionType"]);
                        list.Add(userTransactionsData);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        /// <summary>
        /// Gets user transactions by userid and account number.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountNumber"></param>
        /// <returns>Trasaction collection</returns>
        public static DataTable GetUserTransactionsForExport(int userId, string accountNumber)
        {
            var connectionString = "Data Source = .; Initial Catalog = master; Integrated Security = True";
            DataTable dataTable = new DataTable();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "GetUserTransactionsForExport";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@UserId", userId));
                    command.Parameters.Add(new SqlParameter("@AccountNumber", accountNumber));
                    dataTable.TableName = "Transactions";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                }
            }
            catch (Exception)
            {
            }
            return dataTable;
        }

        /// <summary>
        /// Gets user by email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User Data</returns>
        public static User GetUserByEmail(string email)
        {
            var connectionString = "Data Source = .; Initial Catalog = master; Integrated Security = True";
            User user = new User();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "GetUserByEmail";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@email", email));
                    SqlDataReader dr = command.ExecuteReader();
                    while(dr.Read())
                    {
                        user.Id = Convert.ToInt32(dr[0]);
                        user.Email = Convert.ToString(dr[1]);
                        user.Password = Convert.ToString(dr[2]);
                        user.SavingsAccountNumber = Convert.ToString(dr[3]);
                        user.CurrentAccountNumber = Convert.ToString(dr[4]);
                        user.SeniorCitizenAccountNumber = Convert.ToString(dr[5]);
                        user.HasSavingsAccount = Convert.ToBoolean(dr[6]);
                        user.HasCurrentAccount = Convert.ToBoolean(dr[7]);
                        user.HasSeniorCitizenAccount = Convert.ToBoolean(dr[8]);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return user;
        }

        /// <summary>
        /// Gets Current Available Balance by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Current Available Balance</returns>
        public static decimal GetCurrentAvailableBalanceByUserid(int userId)
        {
            var currentAvailableBalance = decimal.Zero;
            try
            {
                var connectionString = "Data Source = .; Initial Catalog = master; Integrated Security = True";
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "GetCurrentAvailableBalanceByUserid";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@userId", userId));
                    currentAvailableBalance = (decimal)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
            }
            return currentAvailableBalance;
        }

        /// <summary>
        /// Gets user transactions by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Trasaction collection</returns>
        public static IList<UserTransactionsData> GetUserTransactionsByUserId(int userId)
        {
            List<UserTransactionsData> list = new List<UserTransactionsData>();
            try
            {
                var connectionString = "Data Source = .; Initial Catalog = master; Integrated Security = True";
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "GetUserTransactionsByUserId";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@UserId", userId));

                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        UserTransactionsData userTransactionsData = new UserTransactionsData();
                        userTransactionsData.Id = Convert.ToInt32(dataTable.Rows[i]["Id"]);
                        userTransactionsData.UserId = Convert.ToInt32(dataTable.Rows[i]["UserId"]);
                        userTransactionsData.AccountId = Convert.ToInt32(dataTable.Rows[i]["AccountId"]);
                        userTransactionsData.AccountNumber = Convert.ToString(dataTable.Rows[i]["AccountNumber"]);
                        userTransactionsData.TransactionDate = Convert.ToDateTime(dataTable.Rows[i]["TransactionDate"]);
                        userTransactionsData.Description = Convert.ToString(dataTable.Rows[i]["Description"]);
                        userTransactionsData.Amount = Convert.ToDecimal(dataTable.Rows[i]["Amount"]);
                        userTransactionsData.TransactionType = Convert.ToString(dataTable.Rows[i]["TransactionType"]);
                        list.Add(userTransactionsData);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }
    }
}
