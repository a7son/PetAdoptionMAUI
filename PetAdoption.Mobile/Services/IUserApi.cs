using PetAdoption.Shared.Dtos;
using Refit;

namespace PetAdoption.Mobile.Services
{
    [Headers("Authorization: Bearer")]
    public interface IUserApi
    {
        [Post("/api/user/adopt/{petId:int}")]
        Task<ApiResponse> AdoptPetAsync(int petId);

        [Get("/api/user/adoptions")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetUserAdoptionsAsync();

        [Get("/api/user/favorites")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetUserFavoritesAsync();

        [Post("/api/user/favorites/{petId:int}")]
        Task<ApiResponse> ToggleFavoritesAsync(int petId);
    }
}
