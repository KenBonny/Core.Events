using System;
using System.Runtime.CompilerServices;

namespace Kenbo.Core.Events.Tests
{
    public class TestBase
    {
        internal string Message([CallerMemberName] string caller = "")
        {
            var stripUnderscores = new Func<string, string>(x => x.Replace('_', ' ').ToLower());
            var message = $"{stripUnderscores(GetType().Name)} {stripUnderscores(caller)}.";
            return message;
        }
    }
}