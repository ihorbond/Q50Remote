using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Q50Remote.Services
{
    public class AutoPiService
    {
        HttpClient _httpClient;
        public AutoPiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task SendCommand()
        {
            await Task.Delay(3000);
        }
    }
}
