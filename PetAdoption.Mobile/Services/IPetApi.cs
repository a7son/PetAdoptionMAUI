using PetAdoption.Shared.Dtos;
using Refit;

namespace PetAdoption.Mobile.Services
{
    public interface IPetApi
    {
        [Get("/api/pets")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetAllPetAsync();
        [Get("/api/pets/new/{count:int}")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetNewlyAddedPets(int count);

        [Get("/api/pets/popular/{count:int}")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetPopularPetAsync(int count);

        [Get("/api/pets/random/{count:int}")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetRandomPetAsync(int count);

        [Get("/api/pets/{petId:int}")]
        Task<Shared.Dtos.ApiResponse<PetDetailDto>> GetPetDetailAsync(int petId);
    }
}
