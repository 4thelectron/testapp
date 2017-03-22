using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObject;

namespace Facade
{
    public partial interface IMiniStatementFacade
    {
        IList<UserTransactionsData> GetUserTransactionsByAccountId(int userId, int accountId);

        String GetAccountTypeByAccountId(int accountId);
    }
}
