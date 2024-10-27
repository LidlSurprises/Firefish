using FirefishTechnicalTaskAPI.Entities;
using FirefishTechnicalTaskAPI.Interfaces.Repositories;
using FirefishTechnicalTaskAPI.Interfaces.Services;

namespace FirefishTechnicalTaskAPI.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        public CandidateService(ICandidateRepository candidateRepository) 
        {
            _candidateRepository = candidateRepository;
        }
        public async Task<Result<Candidate?>> AddCandidateAsync(Candidate candidate)
        {
            return _candidateRepository.AddCandidateAsync(candidate);
        }

        public Task DeleteCandidateAsync(int id)
        {
            _candidateRepository.DeleteCandidateAsync(id);
            return Task.CompletedTask;
        }

        public async Task<Result<List<Candidate>>> GetCandidatesAsync()
        {
            return _candidateRepository.GetCandidatesAsync();
        }

        public async Task<Result<Candidate?>> GetCandidateAsync(int id)
        {
            return _candidateRepository.GetCandidateAsync(id);
        }

        public async Task<Result<Candidate?>> UpdateCandidateAsync(int id, Candidate candidate)
        {
            return _candidateRepository.UpdateCandidateAsync(id, candidate);
        }
    }
}
