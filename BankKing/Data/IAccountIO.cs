using BankKing.Data.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankKing.Data
{
    public interface IAccountIO
    {
        void SaveAccount(BankAccount account);
    }
}
