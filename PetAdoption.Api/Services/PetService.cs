using Microsoft.EntityFrameworkCore;
using PetAdoption.Api.Data;
using PetAdoption.Api.Extensions;
using PetAdoption.Shared.Dtos;

namespace PetAdoption.Api.Services
{
    public class PetService : IPetService
    {
        private readonly PetContext _context;

        public PetService(PetContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<PetListDto[]>> GetNewlyAddedPets(int count)
        {
            var pets = await _context.Pets
                            .Select(Selectors.PetToPetListDto)
                            .OrderByDescending(p => p.Id)
                            .Take(count)
                            .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);

        }

        public async Task<ApiResponse<PetListDto[]>> GetPopularPetAsync(int count)
        {
            var pets = await _context.Pets
                            .OrderByDescending(p => p.Views)
                            .Take(count)
                            .Select(Selectors.PetToPetListDto)
                            .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);

        }

        public async Task<ApiResponse<PetListDto[]>> GetRandomPetAsync(int count)
        {
            var pets = await _context.Pets
                            .OrderByDescending(_ => Guid.NewGuid())
                            .Take(count)
                            .Select(Selectors.PetToPetListDto)
                            .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);

        }


        public async Task<ApiResponse<PetListDto[]>> GetAllPetAsync()
        {
            var pets = await _context.Pets
                            .OrderByDescending(p => p.Id)
                            .Select(Selectors.PetToPetListDto)
                            .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);
        }

        public async Task<ApiResponse<PetDetailDto>> GetPetDetailAsync(int petId)
        {
            var petDetails = await _context.Pets
                                        .AsTracking()
                                        .FirstOrDefaultAsync(p => p.Id == petId);

            if (petDetails is not null)
            {
                petDetails.Views++;
                _context.SaveChanges();
            }

            var petDto = petDetails!.MapToPetDetailsDto();
            return ApiResponse<PetDetailDto>.Success(petDto);

        }
    }
}
