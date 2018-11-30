using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaUtils.Model
{
    public class ChatBase
    {
        public ChatBase()
        {

        }
        public string api_key { get; set; }
        public string type { get; set; }
        public string platform { get; set; }
        public string message { get; set; }
        public string not_handled { get; set; }
        public string user_id { get; set; }
        public string version { get; set; }
        public string session_id { get; set; }
    }
}
