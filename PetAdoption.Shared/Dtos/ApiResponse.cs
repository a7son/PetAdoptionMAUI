using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoption.Shared.Dtos
{
    public record ApiResponse(bool IsSucess, string? Message = null)
    {
        public static ApiResponse Success() => new(true, null);
        public static ApiResponse Fail(string? message) => new(false, message);
    }

    public record ApiResponse<TData>(bool IsSucess, TData Data, string? Message)
    {
        public static ApiResponse<TData> Success(TData Data) => new(true, Data, null);
        public static ApiResponse<TData> Fail(string? message) => new(false, default!, message);
    }
}
