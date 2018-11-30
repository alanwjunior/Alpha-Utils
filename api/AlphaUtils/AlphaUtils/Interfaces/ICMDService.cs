using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaUtils.Interfaces
{
    public interface ICMDService
    {
        void RunCommandLine(string command);
        void RunCommandLine(string command, string path);
    }
}
