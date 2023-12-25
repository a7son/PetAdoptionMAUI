using PetAdoption.Shared.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Mobile.Services
{
    public interface IAuthApi
    {
        [Post("/api/auth/login")]
        Task<Shared.Dtos.ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto dto);
        [Post("/api/auth/register")]
        Task<Shared.Dtos.ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto);
    }
}
