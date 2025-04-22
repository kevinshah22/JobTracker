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
    [Route("api/[controller]")]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IMapper _mapper;
        private readonly IUserClaimService _userClaimService;
        public JobApplicationController(IJobApplicationRepository jobApplicationRepository, IMapper mapper,
            IUserClaimService userClaimService)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _mapper = mapper;
            _userClaimService = userClaimService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            return Ok(_mapper.Map<JobApplicationModel>(await _jobApplicationRepository.GetItem(x => x.Id == id && x.UserId == _userClaimService.UserId)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobApplicationModel jobApplication)
        {
            JobApplication createItem = _mapper.Map<JobApplication>(jobApplication);
            createItem.UserId = _userClaimService.UserId;
            return Ok(await _jobApplicationRepository.Create(createItem));
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            return Ok(_mapper.Map<List<JobApplicationModel>>(await _jobApplicationRepository.GetJobs(x => x.UserId == _userClaimService.UserId)));
        }

        [HttpPut]
        public async Task<IActionResult> Update(JobApplicationModel jobApplication)
        {
            if (ModelState.IsValid)
            {
                JobApplication dbItem = await _jobApplicationRepository.GetItem(x => x.Id == jobApplication.Id && x.UserId == _userClaimService.UserId);

                if (dbItem != null)
                {
                    dbItem.JobTitle = jobApplication.JobTitle;
                    dbItem.JobDescription = jobApplication.JobDescription;
                    dbItem.SalaryRange = jobApplication.SalaryRange;
                    dbItem.CompanyId = jobApplication.CompanyId;
                    dbItem.JobLink = jobApplication.JobLink;
                    dbItem.JobStatus = jobApplication.JobStatus;

                    return Ok(await _jobApplicationRepository.Update(dbItem));
                }

                return NotFound("Item not found");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(JobApplicationModel item)
        {
            JobApplication dbItem = await _jobApplicationRepository.GetItem(x => x.Id == item.Id);

            if (dbItem != null)
            {
                return Ok(await _jobApplicationRepository.Delete(dbItem));
            }

            return NotFound("Job not found");
        }
    }
}
