using BankKing.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankKing.Services;

public interface IDialogService
{
    bool ShowDialog(FormViewModel viewModel);
}
