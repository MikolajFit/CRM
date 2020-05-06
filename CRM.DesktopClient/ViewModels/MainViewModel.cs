using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CRM.DesktopClient.Commands;

namespace CRM.DesktopClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _changeCurrentCustomerViewCommandName;
        private BaseViewModel _currentCustomerViewModel;

        public MainViewModel()
        {
            CustomerPageViewModels = new List<BaseViewModel>
            {
                new CustomerListViewModel(), new CustomerDetailViewModel()
            };
            CurrentCustomerViewModel = CustomerPageViewModels[0];
        }

        public List<BaseViewModel> CustomerPageViewModels { get; set; }

        public BaseViewModel CurrentCustomerViewModel
        {
            get => _currentCustomerViewModel;
            set
            {
                if (_currentCustomerViewModel == value)
                    return;
                _currentCustomerViewModel = value;
                OnPropertyChanged(nameof(CurrentCustomerViewModel));
            }
        }

        public ICommand ChangeCurrentCustomerViewCommand
        {
            get { return new BaseCommand(p => ChangeCustomerViewModel(), p => CanChangeCustomerView); }
        }

        public bool CanChangeCustomerView =>
            (CurrentCustomerViewModel as CustomerListViewModel)?.SelectedCustomer != null ||
            CurrentCustomerViewModel is CustomerDetailViewModel;

        public string ChangeCurrentCustomerViewCommandName
        {
            get => _changeCurrentCustomerViewCommandName ?? (ChangeCurrentCustomerViewCommandName = "Details");
            set
            {
                if (_changeCurrentCustomerViewCommandName == value)
                    return;
                _changeCurrentCustomerViewCommandName = value;
                OnPropertyChanged(nameof(ChangeCurrentCustomerViewCommandName));
            }
        }


        private void ChangeCustomerViewModel()
        {
            CurrentCustomerViewModel = CustomerPageViewModels.FirstOrDefault(vm => vm != CurrentCustomerViewModel);
            ChangeCurrentCustomerViewCommandName = CurrentCustomerViewModel is CustomerListViewModel ? "Details" : "Go back";
        }
    }
}