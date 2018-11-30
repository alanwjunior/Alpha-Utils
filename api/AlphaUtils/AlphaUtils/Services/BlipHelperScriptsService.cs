using AlphaUtils.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaUtils.Services
{
    public class BlipHelperScriptsService : IBlipHelperScriptsService
    {
        private readonly ICMDService _commandLineService;
        private readonly string scriptsPath;
        private IConfiguration _configuration;

        public BlipHelperScriptsService(ICMDService CMDService, IConfiguration configuration)
        {
            _commandLineService = CMDService;
            _configuration = configuration;
            scriptsPath = _configuration.GetSection("BlipHelperScripts").GetSection("Path").Value;
        }
        public string AddChatBaseIntegration(string fileName)
        {
            string command = "node addchatbaseintegrationscripts.js " + fileName;
            _commandLineService.RunCommandLine(command, scriptsPath);
            return fileName;
        }
        
        public string AddExtras(string fileName, string optionalFlags)
        {
            string command = "node addextrastoscripts.js " + fileName + " " + optionalFlags;
            _commandLineService.RunCommandLine(command, scriptsPath);
            return fileName;
        }

        public string AddLastState(string fileName)
        {
            string command = "node addlaststatescript.js " + fileName;
            _commandLineService.RunCommandLine(command, scriptsPath);
            return fileName;
        }

        public string AddSessionId(string fileName)
        {
            string command = "node addsessionidscripts.js " + fileName;
            _commandLineService.RunCommandLine(command, scriptsPath);
            return fileName;
        }

        public string AddStandardTrackings(string fileName, string optionalFlag)
        {
            string command = "node addstandardtrackingscripts.js " + fileName + " " + optionalFlag;
            _commandLineService.RunCommandLine(command, scriptsPath);
            return fileName;
        }

        public string AddTrackingAndSession(string fileName, string optionalFlag)
        {
            string command = "node Addtrackingandsessionscripts.js " + fileName + " " + optionalFlag;
            _commandLineService.RunCommandLine(command, scriptsPath);
            return fileName;
        }

        public string ClearBot(string fileName)
        {
            string command = "node clearbotscript.js " + fileName + " ";
            _commandLineService.RunCommandLine(command, scriptsPath);
            return fileName;
        }

        public string Regexifybot(string fileName)
        {
            string command = "node regexifybot.js " + fileName + " ";
            _commandLineService.RunCommandLine(command, scriptsPath);
            return fileName;
        }
    }
}
