using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CRM.DesktopClient.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentPageViewModel;

        public MainViewModel()
        {
            PageViewModels = new List<ViewModelBase>
            {
                new CustomersMainViewModel()
            };
            CurrentPageViewModel = PageViewModels[0];
            ChangeCurrentViewCommand = new RelayCommand(ChangeCustomerViewModel, CanChangePageView);
        }

        public List<ViewModelBase> PageViewModels { get; set; }

        public ViewModelBase CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set { Set(() => CurrentPageViewModel, ref _currentPageViewModel, value); }
        }

        public RelayCommand ChangeCurrentViewCommand { get; }


        public bool CanChangePageView => true;


        private void ChangeCustomerViewModel()
        {
            var cur = (CustomersMainViewModel) CurrentPageViewModel;
            cur?.ChangeToMainViewModel();
            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm is CustomersMainViewModel);
        }
    }
}