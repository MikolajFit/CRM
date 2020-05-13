using System;
using CRM.Data.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CRM.DesktopClient.ViewModels
{
    public class CustomersMainViewModel : ViewModelBase
    {
        private readonly CustomerViewModel _customerViewModel;
        private readonly CustomerDetailViewModel _customerDetailViewModel;
        private readonly CustomerListViewModel _customerListViewModel;
        private ViewModelBase _currentCustomerViewModel;

        public CustomersMainViewModel()
        {
            _customerDetailViewModel = new CustomerDetailViewModel();
            _customerListViewModel = new CustomerListViewModel();
            _customerViewModel = new CustomerViewModel(ChangeToMainViewModel, _customerListViewModel.AddCustomer);
            CurrentCustomerViewModel = _customerListViewModel;
            UpdateCustomerCommand = new RelayCommand<Customer>(ChangeToCustomerView);
            ChangeToDetailViewCommand = new RelayCommand<Customer>(ChangeToDetailView,CanChangeToDetailPageView());
        }

        public RelayCommand<Customer> ChangeToDetailViewCommand { get; }
        public RelayCommand<Customer> UpdateCustomerCommand { get; }
        

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

        private void ChangeToCustomerView(Customer customer)
        {
            CurrentCustomerViewModel = _customerViewModel;
            if (customer != null)
            {
                _customerViewModel.CurrentMode = Mode.Edit;
                _customerViewModel.SelectedCustomer = customer;
            }
            else
            {
                _customerViewModel.CurrentMode = Mode.Add;
            }
                
        }
    }
}