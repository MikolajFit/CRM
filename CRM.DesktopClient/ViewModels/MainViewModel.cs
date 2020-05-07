using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CRM.DesktopClient.Commands;

namespace CRM.DesktopClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentPageViewModel;

        public MainViewModel()
        {
            PageViewModels = new List<BaseViewModel>
            {
                new CustomersMainViewModel()
            };
            CurrentPageViewModel = PageViewModels[0];
        }

        public List<BaseViewModel> PageViewModels { get; set; }

        public BaseViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set
            {
                if (_currentPageViewModel == value)
                    return;
                _currentPageViewModel = value;
                OnPropertyChanged(nameof(CurrentPageViewModel));
            }
        }

        public ICommand ChangeCurrentViewCommand
        {
            get { return new BaseCommand(p => ChangeCustomerViewModel(), p => CanChangePageView); }
        }

        public bool CanChangePageView => true;


        private void ChangeCustomerViewModel()
        {
            var cur = (CustomersMainViewModel)CurrentPageViewModel;
            cur?.ChangeToMainViewModel();
            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm is CustomersMainViewModel);
            
        }
    }
}