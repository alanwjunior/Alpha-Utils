using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AlphaUtils.Interfaces;
using AlphaUtils.Model;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AlphaUtils.Controllers
{
    [Route("api/[controller]")]
    public class BlipHelperScriptsController : Controller
    {
        private readonly IBlipHelperScriptsService _blipHelperScriptsService;
        private readonly string path;
        private IConfiguration _configuration;

        public BlipHelperScriptsController(IBlipHelperScriptsService blipHelperScriptsService, IConfiguration configuration)
        {
            _blipHelperScriptsService = blipHelperScriptsService;
            _configuration = configuration;
            path = _configuration.GetSection("BlipHelperScripts").GetSection("Path").Value + "\\";
        }

        [HttpPost]
        [Route("regexify")]
        [DisableCors]
        public void Regexify([FromBody]JsonDTO json)
        {
            System.IO.File.WriteAllText(path + "teste1.json", json.Data);
            _blipHelperScriptsService.Regexifybot("teste1.json");
        }


        [HttpPost]
        [Route("addtrackingandsession")]
        public void AddTrackingAndSession([FromBody]JsonDTO json)
        {
            System.IO.File.WriteAllText(path + "teste1.json", json.Data);
            _blipHelperScriptsService.AddTrackingAndSession("teste1.json", json.OptionalFlag);
        }

        [HttpPost]
        [Route("addextras")]
        public void AddExtras([FromBody]JsonDTO json)
        {
            System.IO.File.WriteAllText(path + "teste1.json", json.Data);
            _blipHelperScriptsService.AddExtras("teste1.json", json.OptionalFlag);
        }

        [HttpPost]
        [Route("addstandardtracking")]
        public void AddStandardTracking([FromBody]JsonDTO json)
        {
            System.IO.File.WriteAllText(path + "teste1.json", json.Data);
            _blipHelperScriptsService.AddStandardTrackings("teste1.json", json.OptionalFlag);
        }

        [HttpPost]
        [Route("addsessionid")]
        public void AddSessionId([FromBody]JsonDTO json)
        {
            System.IO.File.WriteAllText(path + "teste1.json", json.Data);
            _blipHelperScriptsService.AddSessionId("teste1.json");
        }

        [HttpPost]
        [Route("addlaststate")]
        public void AddLastState([FromBody]JsonDTO json)
        {
            System.IO.File.WriteAllText(path + "teste1.json", json.Data);
            _blipHelperScriptsService.AddLastState("teste1.json");
        }

        [HttpPost]
        [Route("addchatbaseintegration")]
        public void AddChatBaseIntegration([FromBody]JsonDTO json)
        {
            System.IO.File.WriteAllText(path + "teste1.json", json.Data);
            _blipHelperScriptsService.AddChatBaseIntegration("teste1.json");
        }

        [HttpPost]
        [Route("clearbot")]
        public void ClearBot([FromBody]JsonDTO json)
        {
            System.IO.File.WriteAllText(path + "teste1.json", json.Data);
            _blipHelperScriptsService.ClearBot("teste1.json");
        }
    }
}
