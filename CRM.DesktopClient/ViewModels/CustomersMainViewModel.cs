using System.Windows.Input;
using CRM.DesktopClient.Commands;

namespace CRM.DesktopClient.ViewModels
{
    public class CustomersMainViewModel : BaseViewModel
    {
        private BaseViewModel _currentCustomerViewModel;
        private readonly AddCustomerViewModel _addCustomerViewModel;
        private readonly CustomerDetailViewModel _customerDetailViewModel;
        private readonly CustomerListViewModel _customerListViewModel;

        public CustomersMainViewModel()
        {
            _customerDetailViewModel = new CustomerDetailViewModel();
            _customerListViewModel = new CustomerListViewModel();
            _addCustomerViewModel = new AddCustomerViewModel(ChangeToMainViewModel,_customerListViewModel.AddCustomer);
            CurrentCustomerViewModel = _customerListViewModel;
        }

        public ICommand ChangeToDetailViewCommand
        {
            get { return new BaseCommand(p => ChangeToDetailView(), p => CanChangeToDetailPageView()); }
        }

        public BaseViewModel CurrentCustomerViewModel
        {
            get => _currentCustomerViewModel;
            set
            {
                _currentCustomerViewModel = value;
                OnPropertyChanged(nameof(CurrentCustomerViewModel));
            }
        }

        public ICommand AddCustomerCommand
        {
            get { return new BaseCommand(p => ChangeToAddCustomerView(), p => true); }
        }


        private bool CanChangeToDetailPageView() => _customerListViewModel.SelectedCustomer != null;

        private void ChangeToDetailView()
        {
            CurrentCustomerViewModel = _customerDetailViewModel;
        }

        public void ChangeToMainViewModel()
        {
            CurrentCustomerViewModel = _customerListViewModel;
        }


        private void ChangeToAddCustomerView()
        {
            CurrentCustomerViewModel = _addCustomerViewModel;
        }
    }
}