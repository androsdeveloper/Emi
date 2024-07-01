
namespace Emi.TechnicalTest.BusinessLogic.Dto
{
    public class UserRegister
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Admin" o "User"
    }
}
