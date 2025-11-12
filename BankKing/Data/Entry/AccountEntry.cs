using System;
using System.Collections.Generic;
using System.Text;

namespace BankKing.Data.Entry
{
    public class AccountEntry
    {
        public required EntryCategory Category { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
