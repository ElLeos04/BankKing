using System;
using System.Collections.Generic;
using System.Text;

namespace BankKing.Data.Entry
{
    class EntryCategory
    {
        public required string Name { get; set; }
        public EntryType Type { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
