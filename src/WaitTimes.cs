/*
===========================================================================================
            █▀▀ ▄▀█ █▀▀ █▀▀ █▄▄ █▀█ █▀█ █▄▀   █▀▀ █▀█ ▄▀█ █ █ █ █   █▀▀ █▀█
            █▀  █▀█ █▄▄ ██▄ █▄█ █▄█ █▄█ █ █   █▄▄ █▀▄ █▀█ ▀▄▀▄▀ █▄▄ ██▄ █▀▄
===========================================================================================
        █▀▀█ █  █ ▄ 　 ▀▀█▀▀ █  █ █▀▀ 　  █▀▀▄ █▀▀ ▀█ █▀ █▀▀ █   █▀▀█ █▀▀█ █▀▀ █▀▀█ 
        █▀▀▄ █▄▄█   　   █   █▀▀█ █▀▀ 　  █  █ █▀▀  █▄█  █▀▀ █   █  █ █  █ █▀▀ █▄▄▀ 
        █▄▄█ ▄▄▄█ ▀ 　   █   ▀  ▀ ▀▀▀ 　  █▄▄▀ ▀▀▀   ▀   ▀▀▀ ▀▀▀ ▀▀▀▀ █▀▀▀ ▀▀▀ ▀ ▀▀
===========================================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Facebook
{
    /// <summary>
    /// This class contains the sleep times for all operations.
    /// There are some of default settings which you can change.
    /// Note: All of the times are in milliseconds!
    /// </summary>
    public static class WaitTimes
    {
        public static int afterLogin = 5000;
        public static int afterURLChange = 2000;
        public static int afterScroll = 1500;
    }
}
