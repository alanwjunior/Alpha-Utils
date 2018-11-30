using AlphaUtils.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaUtils.Services
{
    public class CMDService : ICMDService
    {
        private IConfiguration configuration;

        public CMDService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public void RunCommandLine(string command)
        {
            try
            {
                var processInfo = new ProcessStartInfo("cmd.exe", "/K " + command);
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = true;
                processInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to run the command: " + "command");
            }
        }

        public void RunCommandLine(string command, string path)
        {
            try
            {
                var processInfo = new ProcessStartInfo("cmd.exe", "/K " + command);
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = true;
                processInfo.WorkingDirectory = path;
                processInfo.WindowStyle = ProcessWindowStyle.Hidden;

                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to run the command: " + "command");
            }
        }
    }
}
