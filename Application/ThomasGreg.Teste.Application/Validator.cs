namespace ThomasGreg.Teste.Application
{
    public abstract class Validator
    {
        public static bool Email(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}