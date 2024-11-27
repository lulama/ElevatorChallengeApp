namespace ElevatorChallengAPI.Shared
{
    public class AuditDetails
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime DateModified { get; set; }
    }
}
