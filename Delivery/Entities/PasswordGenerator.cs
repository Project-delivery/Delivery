using System.Reflection.Emit;
using System.Text;

namespace Delivery.Entities
{
    public class PasswordGenerator
    {
        private const string Characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private Random random;

        public PasswordGenerator()
        {
            random = new Random();
        }

        public string GeneratePassword()
        {
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < 16; i++)
            {
                int index = random.Next(0, Characters.Length);
                password.Append(Characters[index]);
            }

            return password.ToString();
        }
    }
}

//пример использования класса
//PasswordGenerator generator = new PasswordGenerator();
//string password = generator.GeneratePassword();