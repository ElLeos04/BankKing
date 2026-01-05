using System.ComponentModel;

namespace BankKingData.Entry;

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
