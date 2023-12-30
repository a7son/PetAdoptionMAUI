using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Mobile.ViewModels
{
    [QueryProperty(nameof(PetId),nameof(PetId))]
    public partial class DetailsViewModel : BaseViewModel
    {
        public DetailsViewModel(IPetApi petApi)
        {
            _petApi = petApi;
        }
        [ObservableProperty]
        private int _petId;

        [ObservableProperty]
        private PetDetailDto _petDetail = new();

        private readonly IPetApi _petApi;

        async partial void OnPetIdChanging(int value)
        {
            // fetch the pet details from the API
            IsBusy  = true;
            try
            {
                var apiResponse = await _petApi.GetPetDetailAsync(value);
                if(apiResponse.IsSucess)
                {
                    PetDetail = apiResponse.Data;
                }
                else
                {
                    await ShowAlertAsync("Error in fetching pet details", apiResponse.Message);
                }
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Error in fetching pet details", ex.Message);
            }
            finally { IsBusy = false; }
        }
    }
}
