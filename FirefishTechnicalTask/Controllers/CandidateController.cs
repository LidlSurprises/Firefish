using Microsoft.AspNetCore.Mvc;
using FirefishTechnicalTaskAPI.Entities;
using FirefishTechnicalTaskAPI.Interfaces.Services;
namespace FirefishTechnicalTaskAPI.Controllers
{
    [ApiController]
    [Route("candidates")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ILogger<CandidateController> logger, ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> GetAllCandidatesAsync()
        {
            var result = await _candidateService.GetCandidatesAsync();

            return result.Match<ActionResult>(
                Ok,
                BadRequest
                );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> GetCandidateAsync(int id)
        {
            var result = await _candidateService.GetCandidateAsync(id);

            return result.Match<ActionResult>(
                Ok,
                BadRequest
                );
        }


        [HttpPost(Name = "AddCandidate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> AddCandidateAsync(Candidate candidate)
        {
            if (candidate == null)
                throw new NullReferenceException(nameof(candidate));

            var result = await _candidateService.AddCandidateAsync(candidate);

            if (result.IsFaulted || result.value == null)
                return BadRequest();

            Candidate newCandidate = result.value;

            return Created($"/candidates/{newCandidate.Id}", newCandidate);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> UpdateCandidateAsync(Candidate candidate)
        {
            var result = await _candidateService.UpdateCandidateAsync(1, candidate);

            return result.Match<ActionResult>(
                (candidate) => candidate is null ? NotFound() : Ok(candidate),
                (error) => BadRequest(error)
                );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> DeleteCandidateAsync(int id)
        {
            await _candidateService.DeleteCandidateAsync(id);

            return Ok();
        }
    }
}