using PetAdoption.Shared.Dtos;
using Refit;

namespace PetAdoption.Mobile.Services
{
    public interface IPetApi
    {
        [Get("/api/pets")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetAllPetAsync();
        [Get("/api/pets/new/{count}")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetNewlyAddedPets(int count);

        [Get("/api/pets/popular/{count}")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetPopularPetAsync(int count);

        [Get("/api/pets/random/{count}")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetRandomPetAsync(int count);

        [Get("/api/pets/{petId}")]
        Task<Shared.Dtos.ApiResponse<PetDetailDto>> GetPetDetailAsync(int petId);
    }
}
