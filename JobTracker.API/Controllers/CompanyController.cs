using AutoMapper;
using JobTracker.API.Services;
using JobTracker.Data.Models;
using JobTracker.Data.Repositories;
using JobTracker.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobTracker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserClaimService _userClaimService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyRepository companyRepository,
            IUserClaimService userClaimService,
            IMapper mapper)
        {
            _companyRepository = companyRepository;
            _userClaimService = userClaimService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            return Ok(_mapper.Map<List<CompanyModel>>(await _companyRepository.GetCompanies(x => x.UserId == _userClaimService.UserId)));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            return Ok(_mapper.Map<CompanyModel>(await _companyRepository.GetCompany(x => x.UserId == _userClaimService.UserId && x.Id == id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyModel company)
        {
            if (ModelState.IsValid)
            {
                Company _company = _mapper.Map<Company>(company);
                _company.UserId = _userClaimService.UserId;

                int companyId = await _companyRepository.Create(_company);

                company = _mapper.Map<CompanyModel>(_company);

                if (companyId > 0)
                {
                    return Ok(company);
                }
                else
                {
                    return StatusCode(500, "An error occurred while saving data.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompanyModel company)
        {
            if (ModelState.IsValid)
            {
                Company _company = await _companyRepository.GetCompany(x => x.Id == company.Id && x.UserId == _userClaimService.UserId);

                if (_company is not null)
                {
                    _company.Name = company.Name;
                    _company.Description = company.Description;

                    int companyId = await _companyRepository.Update(_company);

                    company = _mapper.Map<CompanyModel>(_company);

                    if (companyId > 0)
                    {
                        return Ok(company);
                    }
                    else
                    {
                        return StatusCode(500, "An error occurred while saving data.");
                    }
                }
                else {
                    return NotFound("Comapny record does not exists");
                }                
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
