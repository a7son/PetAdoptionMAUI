using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Mobile.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        protected async Task GoToAsync(ShellNavigationState state) => await Shell.Current.GoToAsync(state);

        protected async Task GoToAsync(ShellNavigationState state, bool animate) => await Shell.Current.GoToAsync(state, animate);

        protected async Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters) => await Shell.Current.GoToAsync(state, parameters);
        protected async Task GoToAsync(ShellNavigationState state, bool animate, IDictionary<string, object> parameters) => await Shell.Current.GoToAsync(state, animate, parameters);

        protected async Task ShowToastAsync(string message) => await Toast.Make(message).Show();

        protected async Task ShowAlertAsync(string title, string message, string buttonText = "OK") => await App.Current.MainPage.DisplayAlert(title, message, buttonText);

        protected async Task ShowConfirmAsync(string title, string message, string okButtonText, string cancelButtonText) => await App.Current.MainPage.DisplayAlert(title, message, okButtonText, cancelButtonText);
    }
}
