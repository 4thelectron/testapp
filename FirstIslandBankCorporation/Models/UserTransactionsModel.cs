using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObject;

namespace FirstIslandBankCorporation.Models
{
    public class UserTransactionsModel
    {
        public UserTransactionsModel()
        {
            UserTransactions = new List<UserTransactionsData>();
        }

        public string AccountType { get; set; }

        public string AccountNumber { get; set; }

        public IList<UserTransactionsData> UserTransactions { get; set; }
    }
}