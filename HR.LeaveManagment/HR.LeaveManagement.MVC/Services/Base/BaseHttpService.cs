using HR.LeaveManagement.MVC.Contracts;
using System.Net.Http.Headers;

namespace HR.LeaveManagement.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly ILocalStorageService _localStorage;
        protected readonly IClient _client;

        public BaseHttpService(ILocalStorageService localStorage, IClient client)
        {
            _localStorage = localStorage;
            _client = client;
        }

        //exception
        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            return null;
        }
        protected void AddBearerToken()
        {
            if (_localStorage.Exists("token"))
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _localStorage.GetStorageValue<string>("token"));

        }
    }
}
