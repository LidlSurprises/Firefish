using FirefishTechnicalTaskAPI.Entities;

namespace FirefishTechnicalTaskAPI.Interfaces.Repositories
{
    public interface ICandidateRepository
    {
        public List<Candidate> GetCandidatesAsync();

        public Candidate GetCandidateAsync(int id);

        public Candidate AddCandidateAsync(Candidate candidate);

        public Candidate UpdateCandidateAsync(int id, Candidate candidate);

        public void DeleteCandidateAsync(int id);
    }
}
