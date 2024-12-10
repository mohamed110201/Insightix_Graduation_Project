using Graduation_Project.Data.Dtos.SystemDto;

namespace Graduation_Project.Services.Interfaces
{
    public interface ISystemsService
    {
        Task Add(AddSystemDto systemRequestDto);
        Task<IEnumerable<GetAllSystemsDto>> GetAll();
        Task<GetSystemByIdDto?> GetById(int id);
    }
}