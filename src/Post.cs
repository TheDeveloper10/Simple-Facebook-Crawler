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
    public class Post
    {
        #region Properties
        protected int reactions;
        protected int comments;
        protected string text;
        protected string publisher;


        /// <summary>
        /// Returns/Sets the amount of reactions(likes & other emojis) that post has
        /// </summary>
        public int Reactions { get { return reactions; } set { if (value >= 0) reactions = value; } }

        /// <summary>
        /// Returns/Sets the amount of comments that post has
        /// </summary>
        public int Comments { get { return comments; } set { if (value >= 0) comments = value; } }

        /// <summary>
        /// Returns/Sets the text on the post
        /// </summary>
        public string Text { get { return text; } set { if (value != null) text = value; } }

        /// <summary>
        /// Returns/Sets the name of the person that published the post
        /// </summary>
        public string Publisher { get { return publisher; } set { if (value != null) publisher = value; } }
        #endregion

        public override string ToString()
        {
            return "Publisher: " + publisher + "  Reactions: " + reactions + "  Comments: " + comments + "  Text: " + text;
        }
    }
}
