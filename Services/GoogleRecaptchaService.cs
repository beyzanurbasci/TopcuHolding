using Newtonsoft.Json;

namespace TopcuHolding.Services
{
    public class GoogleRecaptchaService
    {
        private readonly string _secret;

        public GoogleRecaptchaService(IConfiguration config)
        {
            _secret = config["GoogleReCaptcha:SecretKey"];
        }

        public async Task<bool> VerifyAsync(string token)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(
                $"https://www.google.com/recaptcha/api/siteverify?secret={_secret}&response={token}",
                null);

            var json = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(json);
            return result.success == true;
        }
    }
}
