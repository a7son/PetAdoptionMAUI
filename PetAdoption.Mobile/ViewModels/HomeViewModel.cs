namespace PetAdoption.Mobile.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly IPetApi _petsApi;
        public HomeViewModel(IPetApi petsApi)
        {
            _petsApi = petsApi;
        }
        [ObservableProperty]
        private IEnumerable<PetListDto> _newlyAdded = Enumerable.Empty<PetListDto>();
        [ObservableProperty]
        private IEnumerable<PetListDto> _popular = Enumerable.Empty<PetListDto>();
        [ObservableProperty]
        private IEnumerable<PetListDto> _random = Enumerable.Empty<PetListDto>();

        [ObservableProperty]
        private string _userName = "Stranger";

        private bool _isInitialized;
        public async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            _isInitialized = true;
            IsBusy = true;
            try
            {
                await Task.Delay(100);
                var newlyAddedTask = _petsApi.GetNewlyAddedPets(5);
                var popularPetsTask = _petsApi.GetPopularPetAsync(10);
                var randomPetsTask = _petsApi.GetRandomPetAsync(6);

                NewlyAdded = (await newlyAddedTask).Data;
                Popular = (await popularPetsTask).Data;
                Random = (await randomPetsTask).Data;
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Error", ex.Message);
                //throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
