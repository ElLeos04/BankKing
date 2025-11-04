using BankKing.Data.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankKing.Data.Account
{
    class Account
    {
        public required string Name { get; set; }
        public double Balance { get; set; }
        public List<AccountEntry> Entries { get; set; }

        public Account()
        {
            Entries = [];
        }
    }
}
