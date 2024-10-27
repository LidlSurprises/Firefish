namespace FirefishTechnicalTaskAPI.Entities
{
    public class Candidate
    {
        public int Id { get; init; }
        public string Forename { get; init; } = string.Empty;
        public string Surname { get; init; } = string.Empty;
        public DateTime DateOfBirth { get; init; }
        public string Address1 {  get; init; } = string.Empty;
        public string Town { get; init; } = string.Empty;
        public string Country { get; init; } = string.Empty;
        public string PostCode { get; init; } = string.Empty;
        public string PhoneHome { get; init; } = string.Empty;
        public string PhoneMobile { get; init; } = string.Empty;
        public string PhoneWork { get; init; } = string.Empty;
    }
}
