using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstIslandBankCorporation.Models
{
    public class MiniStatementModel
    {
        public int UserId { get; set; }

        public decimal TotalAvaialbeBalance { get; set; }

        public decimal SavingAccountBalance { get; set; }

        public decimal CurrentAccountBalance { get; set; }

        public decimal SeniorCitizenAccountBalance { get; set; }

        public bool HasSavingsAccount { get; set; }

        public bool HasCurrentAccount { get; set; }

        public bool HasSeniorCitizenAccount { get; set; }

        public int SavingAccountTransactionCount { get; set; }

        public int CurrentAccountTransactionCount { get; set; }

        public int SeniorCitizenTransactionCount { get; set; }

        public string SavingsAccountNumber { get; set; }

        public string CurrentAccountNumber { get; set; }

        public string SeniorCitizenAccountNumber { get; set; }
    }
}