using Graduation_Project.Data.Dtos.SystemDto;

namespace Graduation_Project.Services.Interfaces
{
    public interface ISystemsService
    {
        Task Add(SystemRequestDto systemRequestDto);
        Task<IEnumerable<GetSystemDto>> GetAll();
        Task<GetSystemDetailsDto?> GetById(int id);
    }
}