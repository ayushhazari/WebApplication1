namespace WebApplication1.Models
{
    public class Login
    {
        public string Email { get; set; }   
        public string Password { get; set; }
    }

    public class PolicyDetail
    {
        public string? PolicyName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int? EmpId { get; set; }

        public string? InsurenceCompany { get; set; }

    }
}
    