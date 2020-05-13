using System;
using CRM.Data.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CRM.DesktopClient.ViewModels
{
    public class CustomersMainViewModel : ViewModelBase
    {
        private readonly AddCustomerViewModel _addCustomerViewModel;
        private readonly CustomerDetailViewModel _customerDetailViewModel;
        private readonly CustomerListViewModel _customerListViewModel;
        private ViewModelBase _currentCustomerViewModel;

        public CustomersMainViewModel()
        {
            _customerDetailViewModel = new CustomerDetailViewModel();
            _customerListViewModel = new CustomerListViewModel();
            _addCustomerViewModel = new AddCustomerViewModel(ChangeToMainViewModel, _customerListViewModel.AddCustomer);
            CurrentCustomerViewModel = _customerListViewModel;
            AddCustomerCommand = new RelayCommand(ChangeToAddCustomerView);
            ChangeToDetailViewCommand = new RelayCommand<Customer>(ChangeToDetailView,CanChangeToDetailPageView());
        }

        public RelayCommand<Customer> ChangeToDetailViewCommand { get; }
        public RelayCommand AddCustomerCommand { get; }
        
        private void Test(string s)
        {
            throw new NotImplementedException();
        }

        public ViewModelBase CurrentCustomerViewModel
        {
            get => _currentCustomerViewModel;
            set { Set(() => CurrentCustomerViewModel, ref _currentCustomerViewModel, value); }
        }


        private bool CanChangeToDetailPageView()
        {
            return _customerListViewModel.SelectedCustomer != null;
        }

        private void ChangeToDetailView(Customer c)
        {
            CurrentCustomerViewModel = _customerDetailViewModel;
            _customerDetailViewModel.SelectedCustomer = c;
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