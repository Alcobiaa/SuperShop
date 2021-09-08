using Prism.Navigation;
using SuperShop.Prism.Helpers;

namespace SuperShop.Prism.ViewModels
{
    public class ShowCarPageViewModel : ViewModelBase
    {
        public ShowCarPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.ShowShoppingCar;
        }
    }
}
