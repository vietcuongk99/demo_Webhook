using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SideA.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        [HttpPost]
        [Route("webhook")]

        public async Task<HttpResponseMessage> WebhookSenderActionASync<T>(string webhookUri, T dataEvent)
        {
            var client = new HttpClient();
            var WebhookUri = new Uri(webhookUri);

            var content = new StringContent(JsonConvert.SerializeObject(dataEvent), Encoding.UTF8, "application/json");

            return await client.PostAsync(WebhookUri, content);
        }
    }
}
