using System;
using System.Threading.Tasks;
using Payroll_System.DTO_s.CadreLevelDto;

namespace Payroll_System.Interface.Services
{
    public interface ICadreLevelService
    {
        Task<CreateCadreLevelResponseModel> CreateCadreLevel(CreateCadreLevelRequestModel model);
        Task<CadreLevelResponseModel> GetById(Guid id);
        Task<CadreLevelsResponseModel> ViewAllCadreLevels();
    }
}
