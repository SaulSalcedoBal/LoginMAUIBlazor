using LoginMAUIBlazor.Helpers;
using LoginMAUIBlazor.Interfaces;
using LoginMAUIBlazor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LoginMAUIBlazor.Services
{
    internal class LoginService : ILogin
    {
        System.Net.Http.HttpClient client;
        string WebAPIurl = string.Empty;
        public LoginService()
        {
            client = new System.Net.Http.HttpClient();
        }
        public async Task<LoginMAUIBlazor.Models.Login> Authenticate(UserMin user)
        {
            await Task.Delay(1000);
            user.Password = Functions.GetSHA256(user.Password).ToUpper();

            //throw new Exception();
            //user.Password = Functions.GetSHA256(user.Password).ToUpper();
            WebAPIurl = "AQUI PONER API DE LOGIN";

            var uri = new Uri(WebAPIurl);
            try
            {
                HttpContent _content = new StringContent
                    (JsonConvert.SerializeObject(user));
                _content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await client.PostAsync(uri, _content);

                if (response.IsSuccessStatusCode)
                {
                    LoginMAUIBlazor.Models.Login _login = new LoginMAUIBlazor.Models.Login();
                    var content = await response.Content.ReadAsStringAsync();
                    _login = JsonConvert.DeserializeObject<LoginMAUIBlazor.Models.Login>(content);
                    return _login;
                }
                {

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex);
            }
            return null;
        }
    }
}
