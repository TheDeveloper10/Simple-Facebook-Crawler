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
    public class Group
    {
        protected string name = "";
        protected string groupId = "";
        protected string description = "";
        protected int members = 0;


        /// <summary>
        /// Returns/Sets the name of the group
        /// </summary>
        public string Name { get { return name; } set { if (value != null) name = value; } }

        /// <summary>
        /// Returns/Sets the id of the group
        /// </summary>
        public string GroupID { get { return groupId; } set { if (value != null) groupId = value; } }

        /// <summary>
        /// Returns/Sets the description of the group
        /// </summary>
        public string Description { get { return description; } set { if (value != null) description = value; } }

        /// <summary>
        /// Returns/Sets the amount of members in the group
        /// </summary>
        public int Members { get { return members; } set { if (value >= 0) members = value; } }

        public override string ToString()
        {
            return "Group Name: " + name + "  ID: " + groupId + "  Members: " + members + "  Description: " + description;
        }
    }
}
