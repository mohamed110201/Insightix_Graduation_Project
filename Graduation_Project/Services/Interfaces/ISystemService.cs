using Graduation_Project.Data.Dtos.SystemDto;

namespace Graduation_Project.Services.Interfaces
{
    public interface ISystemService
    {
        GetSystemDto AddSystem(SystemRequestDto systemRequestDto);
        IEnumerable<GetSystemDto> GetAllSystems();
        GetSystemDetailsDto? GetSystemById(int id);

    }
}
