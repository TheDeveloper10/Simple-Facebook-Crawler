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
    public class Profile
    {
        protected string name = "";
        protected string link = "";
        protected Dictionary<string, string> properties;


        /// <summary>
        /// Returns/Sets the name of the profile
        /// </summary>
        public string Name { get { return name; } set { if (value != null) name = value; } }

        /// <summary>
        /// Returns/Sets a link to this profile
        /// </summary>
        public string Link { get { return link; } set { if (value != null) link = value; } }

        /// <summary>
        /// Returns/Sets a Dictionary(string, string) filled with properties.
        /// Possible keys: Current City, Home Town, Birthday, etc. -> only the ones the person has written.
        /// See more in the examples
        /// </summary>
        public Dictionary<string, string> Properties { get { return properties; } set { if (value != null) properties = value; } }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("Name: " + name + "  Link: " + link);

            if (properties != null)
            {
                string[] keys = properties.Keys.ToArray();
                for (int i = 0; i < properties.Count; ++i)
                    output.Append("  " + keys[i] + ": " + properties[keys[i]]);
            }

            string output_ = output.ToString();
            output.Clear();
            return output_;
        }
    }
}
