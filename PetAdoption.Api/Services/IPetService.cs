using PetAdoption.Shared.Dtos;

namespace PetAdoption.Api.Services
{
    public interface IPetService
    {
        Task<ApiResponse<PetListDto[]>> GetAllPetAsync();
        Task<ApiResponse<PetListDto[]>> GetNewlyAddedPets(int count);
        Task<ApiResponse<PetDetailDto>> GetPetDetailAsync(int petId);
        Task<ApiResponse<PetListDto[]>> GetPopularPetAsync(int count);
        Task<ApiResponse<PetListDto[]>> GetRandomPetAsync(int count);
    }
}