using PetAdoption.Shared.Dtos;

namespace PetAdoption.Mobile.Services
{
    public class AuthService
    {
        private readonly CommonService _commonService;
        private readonly IAuthApi _authApi;

        public AuthService(CommonService commonService, IAuthApi authApi)
        {
            _commonService = commonService;
            _authApi = authApi;
        }

        public async Task<bool> LoginRegisterAsync(LoginRegisterModel model)
        {
            Shared.Dtos.ApiResponse<AuthResponseDto> apiReponse = null;

            try
            {
                if (model.IsNewUser)
                {
                    // RegisterApi
                    apiReponse = await _authApi.RegisterAsync(new RegisterRequestDto
                    {
                        Email = model.Email,
                        Name = model.Name,
                        Password = model.Password,
                    });
                }
                else
                {
                    // Login Api

                    apiReponse = await _authApi.LoginAsync(new LoginRequestDto
                    {
                        Email = model.Email,
                        Password = model.Password,
                    });
                }
            }
            catch (Refit.ApiException ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }

            if(!apiReponse.IsSucess)
            {
                await App.Current.MainPage.DisplayAlert("Error", apiReponse.Message, "Ok");
                return false;
            }

            var user = new LoggedInUser(apiReponse.Data.UserId, apiReponse.Data.Name, apiReponse.Data.Token);
            SetUser(user);
            _commonService.SetToken(apiReponse.Data.Token);
            return true;
        }


        private void SetUser(LoggedInUser user) => Preferences.Default.Set(UIConstants.UserInfo, user.ToJson());

        public async Task Logout()
        {
            _commonService.SetToken(null);
            Preferences.Default.Remove(UIConstants.UserInfo);
        }

        public LoggedInUser GetUser()
        {
            var userJson = Preferences.Default.Get(UIConstants.UserInfo, string.Empty);
            return LoggedInUser.LoadFromJson(userJson);
        }

        public bool IsLoggedIn => Preferences.Default.ContainsKey(UIConstants.UserInfo);
    }
}
