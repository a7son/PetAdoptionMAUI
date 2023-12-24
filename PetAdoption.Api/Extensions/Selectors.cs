using PetAdoption.Api.Data.Entities;
using PetAdoption.Shared.Dtos;
using System.Linq.Expressions;

namespace PetAdoption.Api.Extensions
{
    public static class Selectors
    {
        public static Expression<Func<Pet, PetListDto>> PetToPetListDto =>
            p => new PetListDto
            {
                Id = p.Id,
                Breed = p.Breed,
                Image = p.Image,
                Name = p.Name,
                Price = p.Price,
            };
    }
}
