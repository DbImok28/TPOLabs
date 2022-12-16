using TPO_WebTestFramework.Model;

namespace TPO_WebTestFramework.Service
{
    public class UserCreator
    {
        public static readonly string UserName = "ddh47ff2@yandex.by";
        public static readonly string Password = "Pasha714";

        public static User WithCredentialsFromProperty()
        {
            return new User(UserName, Password);
        }
        public override string ToString()
        {
            return $"User: {UserName}";
        }
    }
}
