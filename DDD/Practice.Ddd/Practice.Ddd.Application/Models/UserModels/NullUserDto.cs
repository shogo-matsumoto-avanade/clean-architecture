namespace Practice.Ddd.Application.Models.UserModels
{
    internal class NullUserDto : IUserDto
    {
        public string UserName => "Unknown";

        public string Email => "Unknown Mail";
    }
}
