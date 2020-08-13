using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Slack.Client;
using Slack.Client.entity;

namespace SideB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> WebhookReceiverResult()
        {
            string requestJson;

            using (TextReader reader = new StreamReader(Request.Body))
            {
                requestJson = await reader.ReadToEndAsync();
            }

            var slackClient = new SlackClient("https://hooks.slack.com/services/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");

           

            slackClient.Send(requestJson.ToString());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            return Ok();
        }
    }
}
