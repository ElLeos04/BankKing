using BankKing.Data.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankKing.Data.Account
{
    public class BankAccount
    {
        public required string Name { get; set; }
        public decimal Balance { get; set; }
        public List<AccountEntry> Entries { get; set; }

        public BankAccount()
        {
            Entries = [];
        }
    }
}
