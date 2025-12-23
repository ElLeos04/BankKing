using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BankKing.Data.Entry;

public enum EntryType
{
    None,
    [Description("Dépense")]
    Expense,
    [Description("Revenu")]
    Income,
    [Description("Dépense ou Revenu")]
    ExpenseAndIncome
}
