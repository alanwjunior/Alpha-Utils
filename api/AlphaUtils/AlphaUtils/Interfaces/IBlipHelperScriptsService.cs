using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaUtils.Interfaces
{
    public interface IBlipHelperScriptsService
    {
        string Regexifybot(string fileName);
        string AddTrackingAndSession(string fileName, string optionalFlag);
        string AddExtras(string fileName, string optionalFlags);
        string AddSessionId(string fileName);
        string AddLastState(string fileName);
        string AddChatBaseIntegration(string fileName);
        string ClearBot(string fileName);
        string AddStandardTrackings(string fileName, string optionalFlag);
    }
}
