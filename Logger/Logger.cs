
using System.Threading;
using log4net;

namespace Logger
{
    public static class Logger
    {
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


    }
}
