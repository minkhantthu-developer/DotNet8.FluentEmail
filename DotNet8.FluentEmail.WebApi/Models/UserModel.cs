namespace DotNet8.FluentEmail.WebApi.Models
{
    public class UserModel
    {
        public string? UserName { get; set; }

        public string? Email { get; set; }  

        public string? MemberType { get; set; }

        public UserModel(string userName, string email, string memberType)
        {
            UserName = userName;
            Email = email;
            MemberType = memberType;
        }
    }
}
