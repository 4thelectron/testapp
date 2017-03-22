using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string SavingsAccountNumber { get; set; }

        public string CurrentAccountNumber { get; set; }

        public string SeniorCitizenAccountNumber { get; set; }

        public bool HasSavingsAccount { get; set; }

        public bool HasCurrentAccount { get; set; }

        public bool HasSeniorCitizenAccount { get; set; }
    }
}
