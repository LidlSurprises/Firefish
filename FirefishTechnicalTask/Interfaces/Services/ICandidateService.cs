using FirefishTechnicalTaskAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FirefishTechnicalTaskAPI.Interfaces.Services
{
    public interface ICandidateService
    {
        public Task<Result<List<Candidate>>> GetCandidatesAsync();

        public Task<Result<Candidate?>> GetCandidateAsync(int id);

        public Task<Result<Candidate?>> AddCandidateAsync(Candidate candidate);

        public Task<Result<Candidate?>> UpdateCandidateAsync(int id, Candidate candidate);

        public Task DeleteCandidateAsync(int id);
    }
}
