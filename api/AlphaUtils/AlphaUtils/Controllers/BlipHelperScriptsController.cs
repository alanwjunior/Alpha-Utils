using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AlphaUtils.Interfaces;
using AlphaUtils.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AlphaUtils.Controllers
{
    [Route("api/[controller]")]
    public class BlipHelperScriptsController : Controller
    {
        private readonly IBlipHelperScriptsService _blipHelperScriptsService;

        public BlipHelperScriptsController(IBlipHelperScriptsService blipHelperScriptsService)
        {
            _blipHelperScriptsService = blipHelperScriptsService;
        }

        [HttpPost]
        [Route("regexify")]
        public void Regexify(string fileName)
        {
            _blipHelperScriptsService.Regexifybot(fileName);
        }


        [HttpPost]
        [Route("addtrackingandsession")]
        public void AddTrackingAndSession(string fileName, string optionalFlag)
        {
            _blipHelperScriptsService.AddTrackingAndSession(fileName, optionalFlag);
        }

        [HttpPost]
        [Route("addextras")]
        public void AddExtras(string fileName, string optionalFlag)
        {
            _blipHelperScriptsService.AddExtras(fileName, optionalFlag);
        }

        [HttpPost]
        [Route("addstandardtracking")]
        public void AddStandardTracking(string fileName, string optionalFlag)
        {
            _blipHelperScriptsService.AddStandardTrackings(fileName, optionalFlag);
        }

        [HttpPost]
        [Route("addsessionid")]
        public void AddSessionId(string fileName)
        {
            _blipHelperScriptsService.AddSessionId(fileName);
        }

        [HttpPost]
        [Route("addlaststate")]
        public void AddLastState(string fileName)
        {
            _blipHelperScriptsService.AddLastState(fileName);
        }

        [HttpPost]
        [Route("addchatbaseintegration")]
        public void AddChatBaseIntegration(string fileName)
        {
            _blipHelperScriptsService.AddChatBaseIntegration(fileName);
        }

        [HttpPost]
        [Route("clearbot")]
        public void ClearBot(string fileName)
        {
            _blipHelperScriptsService.ClearBot(fileName);
        }
    }
}
