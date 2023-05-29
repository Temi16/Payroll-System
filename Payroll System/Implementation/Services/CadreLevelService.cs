using System.Linq;
using System.Threading.Tasks;
using Payroll_System.DTO_s.CadreLevelDto;
using Payroll_System.DTO_s.DeductionsDto;
using Payroll_System.DTO_s.EarningsDto;
using Payroll_System.Entities;
using Payroll_System.Interface.Repositories;
using Payroll_System.Interface.Services;

namespace Payroll_System.Implementation.Services
{
    public class CadreLevelService : ICadreLevelService
    {
        private readonly ICadreLevelRepository _cadreLevelRepository;
        private readonly IEarningsRepository _earningsRepository;
        private readonly IDeductionRepository _deductionsRepository;
        public CadreLevelService(ICadreLevelRepository cadreLevelRepository, IEarningsRepository earningsRepository, IDeductionRepository deductionsRepository)
        {
            _cadreLevelRepository = cadreLevelRepository;
            _earningsRepository = earningsRepository;
            _deductionsRepository = deductionsRepository;
        }

       

        public async Task<CreateCadreLevelResponseModel> CreateCadreLevel(CreateCadreLevelRequestModel model)
        {
            CreateCadreLevelResponseModel createCadreLevelResponseModel = new();
            var checkCadreLevelExist = await _cadreLevelRepository.ExistsAsync<CadreLevel>(cl => cl.CadreName == model.CadreName);
            if (checkCadreLevelExist)
            {
                createCadreLevelResponseModel.Status = false;
                createCadreLevelResponseModel.Message = "CadreLevel already exist";
                createCadreLevelResponseModel.ValidationResults.Add("CadreLevel already exist");

                return createCadreLevelResponseModel;

            }
            var earnings = new Earnings(model.Earnings.BasicPay, model.Earnings.Transport, model.Earnings.Housing, model.Earnings.Medical);
            var earningsId = await _earningsRepository.CreateAsync<Earnings>(earnings);
            await _earningsRepository.SaveChangesAsync();
            var deductions = new Deductions(model.Deductions.Pension, model.Deductions.Tax, model.Deductions.Insurance, model.Deductions.ChildSupport);
            var deductionsId = await _deductionsRepository.CreateAsync<Deductions>(deductions);
            await _deductionsRepository.SaveChangesAsync();
            var cadreLevel = new CadreLevel(model.CadreName, earningsId, deductionsId, model.Salary);
            var cadreLevelId = await _cadreLevelRepository.CreateAsync<CadreLevel>(cadreLevel);
            await _cadreLevelRepository.SaveChangesAsync();
            createCadreLevelResponseModel.Status = true;
            createCadreLevelResponseModel.Message = "CadreLevel created successfully";
            createCadreLevelResponseModel.ValidationResults.Add("CadreLevel created successfully");
            createCadreLevelResponseModel.CadreLevelId = cadreLevelId;

            return createCadreLevelResponseModel;

        }

        public async Task<CadreLevelResponseModel> GetById(System.Guid id)
        {
            CadreLevelResponseModel cadreLevelResponseModel = new();
            var cadreLevel = await _cadreLevelRepository.GetCadreLevel(c => c.Id == id);
            if (cadreLevel == null)
            {
                cadreLevelResponseModel.Status = false;
                cadreLevelResponseModel.Message = "No CadreLevel available";
                return cadreLevelResponseModel;
            };
            CadreLevelDto cadreLevelDto = new();
            cadreLevelDto.Id = cadreLevel.Id;
            cadreLevelDto.CadreName = cadreLevel.CadreName;
            cadreLevelDto.Earnings = new EarningDto
            {
                Id = cadreLevel.EarningsId,
                BasicPay = cadreLevel.Earnings.BasicPay,
                Transport = cadreLevel.Earnings.Transport,
                Housing = cadreLevel.Earnings.Housing,
                Medical = cadreLevel.Earnings.Medical,
            };
            cadreLevelDto.Deductions = new DeductionDto
            {
                Id = cadreLevel.DeductionsId,
                Tax = cadreLevel.Deductions.Tax,
                Pension = cadreLevel.Deductions.Pension,
                Insurance = cadreLevel.Deductions.Insurance,
                ChildSupport = cadreLevel.Deductions.ChildSupport,
            };
            cadreLevelDto.Salary = cadreLevel.Salary;
            cadreLevelResponseModel.Status = true;
            cadreLevelResponseModel.Message = "CadreLevel available";
            cadreLevelResponseModel.CadreLevel = cadreLevelDto;
            return cadreLevelResponseModel;
        }

        public async Task<CadreLevelsResponseModel> ViewAllCadreLevels()
        {
            CadreLevelsResponseModel cadreLevelsResponseModel = new();
            var cadreLevels = await _cadreLevelRepository.GetAllCadreLevel();
            if (cadreLevels.Count() < 0)
            {
                cadreLevelsResponseModel.Status = false;
                cadreLevelsResponseModel.Message = "No CadreLevel available";
                return cadreLevelsResponseModel;
            };
            cadreLevelsResponseModel.Status = true;
            cadreLevelsResponseModel.Message = "CadreLevel available";
            cadreLevelsResponseModel.CadreLevels = cadreLevels.Select(c => new CadreLevelDto
            {
                Id = c.Id,
                CadreName = c.CadreName,
                Earnings = new EarningDto
                {
                    Id = c.Earnings.Id,
                    BasicPay = c.Earnings.BasicPay,
                    Transport = c.Earnings.Transport,
                    Housing = c.Earnings.Housing,
                    Medical = c.Earnings.Medical
                },
                Deductions = new DeductionDto
                {
                    Id = c.Deductions.Id,
                    Pension = c.Deductions.Pension,
                    Tax = c.Deductions.Tax,
                    Insurance = c.Deductions.Insurance,
                    ChildSupport = c.Deductions.ChildSupport
                },
                Salary = c.Salary
               
            }).ToList();

            return cadreLevelsResponseModel;
        }
    }
}
