using Microsoft.AspNetCore.Mvc;
using PetAdoption.Api.Services;
using PetAdoption.Shared.Dtos;

namespace PetAdoption.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // api/pets
        [HttpGet("")]
        public async Task<ApiResponse<PetListDto[]>> GetAllPetAsync() => await _petService.GetAllPetAsync();

        // api/pets/new/5
        [HttpGet("new/{count:int}")]
        public async Task<ApiResponse<PetListDto[]>> GetNewlyAddedPets(int count) => await _petService.GetNewlyAddedPets(count);
        
        // api/pets/popular/5
        [HttpGet("popular/{count:int}")]
        public async Task<ApiResponse<PetListDto[]>> GetPopularPetAsync(int count) => await _petService.GetPopularPetAsync(count);

        // api/pets/random/5
        [HttpGet("random/{count:int}")]
        public async Task<ApiResponse<PetListDto[]>> GetRandomPetAsync(int count) => await _petService.GetRandomPetAsync(count);

        // api/pets/1
        [HttpGet("{petId:int}")]
        public async Task<ApiResponse<PetDetailDto>> GetPetDetailAsync(int petId) => await _petService.GetPetDetailAsync(petId);


    }
}
