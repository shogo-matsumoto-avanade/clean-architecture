namespace Practice.Ddd.Application.Models.UserModels
{
    internal class NullUserModel : IUserModel
    {
        public string UserName => "Unknown";

        public string Email => "Unknown Mail";
    }
}
