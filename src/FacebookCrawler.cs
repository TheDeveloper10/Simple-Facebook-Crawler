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
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Automation.Facebook
{
    /// <summary>
    /// <para> A simple facebook "crawler" that is able to do many things! Here are all of the methods:</para>
    /// <para> LogIn, LogOut, GetGroupInfo, PostTextToURL, PostTextInGroup, PostTextInTimeline, GetAllJoinedGroups, SendFriendRequest, GetProfile, GetGroupPosts, LoadFriends</para>
    /// <para> Note: this "crawler" is developed to automate basic & repetative tasks and collect information without using Facebook API. </para>
    /// <para> You can only post in groups that you have joined in with your profile and not your page. </para>
    /// <para> Also if your profile is not in English many of the functions may not work properly!</para>
    /// </summary>
    public class FacebookCrawler
    {
        private IWebDriver webDriver;

        /// <summary>
        /// Creates a FacebookCrawler
        /// </summary>
        /// <param name="webDriver_"> If you want to post emojis please do not select ChromeDriver because it doesn't allow sending emojis(but it's faster) </param>
        public FacebookCrawler(IWebDriver webDriver_)
        {
            if (webDriver_ == null)
                throw new Exception("Web driver must not be null!");
            webDriver = webDriver_;
        }

        private void GetToURL(string url)
        {
            webDriver.Url = URLtoFCBmbasic(url);
            Thread.Sleep(WaitTimes.afterURLChange);
        }

        private static string URLtoFCBmbasic(string url)
        {
            return url.Replace("m.facebook.com", "mbasic.facebook.com").Replace("www.facebook.com", "mbasic.facebook.com").Replace("d.facebook.com", "mbasic.facebook.com");
        }

        /// <summary>
        /// This method fixed 1.2k, 1k, 1.0m, 4.3b, (4,025), etc.
        /// </summary>
        private static int ConvertStringToInt(string str)
        {
            // Don't mind the bad written code I don't know if there's a function that automatically does that for you :D
            str = str.ToLower().Replace(",", "").Replace(" ", ""); // to remove the ',' in 4,025 and become 4025
            int ret = 0;
            if (int.TryParse(str, out ret))
                return ret;
            else
            {
                // there must be k/m/b/.
                char mult = ' ';
                for (int i = 0; i < str.Length; ++i)
                {
                    if (str[i] == 'k' || str[i] == 'm' || str[i] == 'b')
                    {
                        mult = str[i];
                        break;
                    }
                }

                if (mult != ' ')
                {
                    switch (mult)
                    {
                        case 'k':
                            ret = 1000;
                            break;
                        case 'm':
                            ret = 1000000;
                            break;
                        case 'b':
                            ret = 1000000000;
                            break;
                    }
                    ret = (int)(ret * double.Parse(str.Replace(mult.ToString(), "")));
                }
                else
                    ret = int.Parse(str.Replace(".", ""));
            }

            return ret;
        }

        /// <summary>
        /// Logs into your profile
        /// </summary>
        /// <param name="email"> The email that the profile is registered to </param>
        /// <param name="password"> The password of the profile </param>
        public bool LogIn(string email, string password)
        {
            GetToURL("https://mbasic.facebook.com");

            IWebElement email_element = webDriver.FindElement(By.Name("email"));
            email_element.SendKeys(email);
            IWebElement password_element = webDriver.FindElement(By.Name("pass"));
            password_element.SendKeys(password);
            password_element.SendKeys(Keys.Enter);
            Thread.Sleep(WaitTimes.afterLogin);
            try
            {
                webDriver.FindElement(By.Name("xc_message"));
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Logs out of your profile
        /// </summary>
        public bool LogOut()
        {
            try
            {
                webDriver.FindElement(By.XPath("//a[@id='mbasic_logout_button']")).Click();
                Thread.Sleep(WaitTimes.afterURLChange);

                //webDriver.FindElement(By.XPath("//input[@value='Don\'t Save and Log Out']")).Click();
                // ^^^ it doesn't work for some reason ^^^
                webDriver.FindElements(By.TagName("input")).First(x => x.GetAttribute("value") == "Don't Save and Log Out").Click();

                return true;
            }
            catch { return false; }
        }

        #region DataGathering
        /// <summary>
        /// Returns information about a user profile
        /// </summary>
        public Profile GetProfile(string personURL)
        {
            Profile profile = new Profile();
            profile.Link = personURL;

            GetToURL(personURL);

            try
            {
                IWebElement[] strongs = webDriver.FindElements(By.ClassName("strong")).ToArray();

                for (int i = 0; i < strongs.Length; ++i)
                {
                    if (!strongs[i].Text.StartsWith("Groups"))
                    {
                        profile.Name = strongs[i].Text;
                        break;
                    }
                }
            }
            catch { }

            try
            {
                Dictionary<string, string> properties = new Dictionary<string, string>();
                char[] emptySymbolsToRemove = { '\r', '\n' };
                // the tags of each row is the same but the class names(on those tags) in different profiles are different(which I don't know why happens) 
                foreach (IWebElement row in webDriver.FindElements(By.XPath("//table[@cellspacing='0']")))
                {
                    string[] splitted = row.Text.Split(emptySymbolsToRemove, StringSplitOptions.RemoveEmptyEntries);
                    properties.Add(splitted[0], splitted[1]);
                }
                profile.Properties = properties;
            }
            catch { }

            return profile;
        }

        private Post GetPostInfo(IWebElement articleEl)
        {
            Post post = new Post();
            try
            {
                post.Publisher = articleEl.FindElement(By.XPath(".//td[contains(@class, 't bm')]")).FindElements(By.XPath(".//*")).First(x => x.TagName == "a").Text;
            }
            catch { }

            try
            {
                post.Text = articleEl.FindElement(By.XPath(".//div[@data-ft='" + dataFt + "']")).Text;
            }
            catch { }

            try
            {
                post.Reactions = ConvertStringToInt(articleEl.FindElement(By.XPath(".//span[contains(@class, 'cp cq')]")).Text.ToLower().Replace(" · like · react", ""));
            }
            catch { }

            try
            {
                string[] arr = articleEl.FindElement(By.XPath(".//footer[@data-ft='" + dataFt2 + "']")).Text.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < arr.Length - 1; ++j)
                {
                    if (arr[j + 1] == "comments")
                    {
                        post.Comments = ConvertStringToInt(arr[j]);
                        break;
                    }
                }
            }
            catch { }
            return post;
        }
        // {"tn":"*s"}
        private const string dataFt = "{\"tn\":\"*s\"}";
        // {"tn":"*W"}
        private const string dataFt2 = "{\"tn\":\"*W\"";

        /// <summary>
        /// Returns the several of the last posts in the group
        /// </summary>
        /// <param name="groupURL"> The url address of the group </param>
        /// <param name="postsToLoad"> The amount of posts that will be returned </param>
        public Post[] GetGroupPosts(string groupURL, int postsToLoad = 50)
        {
            // The classes on the tags are different on each page so we use some consts

            List<Post> posts = new List<Post>(postsToLoad);

            GetToURL(groupURL);

            string postTagCombination = "da dc dm";

            try
            {
                postTagCombination = webDriver.FindElement(By.XPath("//article[@id='u_0_8' or @id='u_0_3' or @id='u_0_4' or @id='@u_0_7']")).GetAttribute("class");
            }
            catch { }

            int i = 0, loadedPosts = 0;
            for (;;)
            {
                try
                {
                    IWebElement[] postsOnThisPage = webDriver.FindElements(By.XPath("//article[contains(@class, '" + postTagCombination + "')]")).ToArray();
                    for (i = 0; i < postsOnThisPage.Length; ++i)
                    {
                        Post post = GetPostInfo(postsOnThisPage[i]);
                        try
                        {
                            IWebElement secondPostEl = postsOnThisPage[i].FindElement(By.XPath(".//article[contains(@class, '" + postTagCombination + "')]")); // if the person has shared that post
                            Post secondPost = GetPostInfo(secondPostEl);

                            post.Text = secondPost.Text;
                            ++i;
                        }
                        catch { }

                        if (!String.IsNullOrEmpty(post.Text) && !String.IsNullOrEmpty(post.Publisher))
                            posts.Add(post);
                        ++loadedPosts;
                        if (loadedPosts >= postsToLoad)
                            goto _exit;
                    }
                    webDriver.FindElement(By.XPath(".//span[contains(text(), 'See more posts')]")).Click();
                }
                catch { }
            }
        _exit:

            Post[] postsArr = posts.ToArray();
            posts.Clear();
            return postsArr;
        }

        /// <summary>
        /// Returns the several of the last posts in the group
        /// </summary>
        /// <param name="postsToLoad"> The amount of posts that will be returned </param>
        public Post[] GetGroupPosts(Group group, int postsToLoad = 50)
        {
            return GetGroupPosts("https://mbasic.facebook.com/groups/" + group.Name, postsToLoad);
        }

        /// <summary>
        /// Returns information about a group
        /// </summary>
        /// <param name="groupURL"> The url of the group </param>
        public Group GetGroupInfo(string groupURL)
        {
            int indx = groupURL.IndexOf("&refid=");
            if (indx != -1)
                groupURL = groupURL.Remove(indx);
            indx = groupURL.IndexOf("?refid=");
            if (indx != -1)
                groupURL = groupURL.Remove(indx);

            GetToURL(groupURL);

            Group g = new Group();
            int groupsIndx = groupURL.IndexOf("groups/") + "groups/".Length, lineIndx = groupURL.IndexOf("/", groupsIndx);
            if (lineIndx == -1)
                lineIndx = groupURL.Length;

            g.GroupID = groupURL.Substring(groupsIndx, lineIndx - groupsIndx);

            try
            {
                g.Name = webDriver.FindElement(By.XPath("//a[@href='#groupMenuBottom']")).FindElement(By.XPath(".//div")).Text;
            }
            catch { }

            try
            {
                IWebElement groupMenu = webDriver.FindElements(By.TagName("h3")).First(x => x.Text == "GROUP MENU").FindElement(By.XPath("following-sibling::ul"));
                foreach (IWebElement li in groupMenu.FindElements(By.XPath(".//li")))
                {
                    try
                    {
                        li.FindElement(By.XPath(".//ancestor::a[text()='Members']")); // if it doesn't find it's going to the try & catch
                        IWebElement span = li.FindElement(By.XPath(".//span"));
                        g.Members = ConvertStringToInt(span.Text);
                        break;
                    }
                    catch { }
                }
            }
            catch { }

            try
            {
                webDriver.Url = "https://www.facebook.com/groups/" + g.GroupID + "/about/";
                Thread.Sleep(WaitTimes.afterURLChange * 3); // because the normal facebook is really slow

                try
                {
                    IAlert alert = webDriver.SwitchTo().Alert();
                    alert.Dismiss();
                }
                catch { }

                IWebElement[] descriptiveEls = webDriver.FindElements(By.XPath("//div[@role='heading' and @aria-level='4']")).ToArray();
                indx = Array.FindIndex(descriptiveEls, x => x.Text.ToLower().CompareTo("description") == 0);
                if (indx != -1)
                {
                    try
                    {
                        descriptiveEls[indx + 1].FindElement(By.XPath(".//a[@title='See More']")).Click();
                        Thread.Sleep(WaitTimes.afterURLChange / 2);
                    }
                    catch { }

                    g.Description = descriptiveEls[indx + 1].Text;
                }
            }
            catch { }

            return g;
        }

        /// <summary>
        /// Returns the urls of all the groups that are in the current account
        /// </summary>
        public string[] GetAllJoinedGroups()
        {
            GetToURL("https://mbasic.facebook.com/groups/?seemore");

            IWebElement[] els;
            try
            {
                els = webDriver.FindElements(By.XPath("//table[@role='presentation']//ancestor::a")).ToArray();

                List<string> groups = new List<string>(els.Length);
                int indx;
                for (int i = 0; i < els.Length; ++i)
                {
                    groups.Add(els[i].GetAttribute("href"));
                    indx = groups[i].IndexOf("&refid=");
                    if (indx != -1)
                        groups[i] = groups[i].Remove(indx);
                    indx = groups[i].IndexOf("?refid=");
                    if (indx != -1)
                        groups[i] = groups[i].Remove(indx);
                }

                RemoveElementIfTextExists(groups, 0, "/home.php?ref_component");
                RemoveElementIfTextExists(groups, 0, "/groups/create");
                RemoveElementIfTextExists(groups, groups.Count - 1, "/login/save-password");
                RemoveElementIfTextExists(groups, groups.Count - 1, "/policies/?ref_component");
                RemoveElementIfTextExists(groups, groups.Count - 1, "/bugnub/?source=");
                RemoveElementIfTextExists(groups, groups.Count - 1, "/settings/?entry_point");
                RemoveElementIfTextExists(groups, groups.Count - 1, "/help/?ref_component");
                RemoveElementIfTextExists(groups, groups.Count - 1, "/pages/create/?");

                string[] groupsArr = groups.ToArray();
                groups.Clear();
                return groupsArr;
            }
            catch { return null; }
        }

        private void RemoveElementIfTextExists(List<string> strs, int indx, string text)
        {
            if (strs[indx].Contains(text))
                strs.RemoveAt(indx);
        }

        /// <summary>
        /// Returns the urls of the first several friends
        /// </summary>
        /// <param name="friendsToLoad"> The friends to load </param>
        public string[] LoadFriends(int friendsToLoad = 50)
        {
            GetToURL("https://mbasic.facebook.com");

            string userID = "";
            try
            {
                userID = webDriver.FindElement(By.XPath("//a[text()='Profile']")).GetAttribute("href");
            }
            catch { return null; }

            int startIndx = "https://mbasic.facebook.com/".Length, endIndx = userID.IndexOf('?', startIndx);
            if (endIndx == -1)
                endIndx = userID.Length;
            try
            {
                userID = userID.Substring(startIndx, endIndx - startIndx);

                webDriver.Url = "https://www.facebook.com/" + userID + "/friends";
                Thread.Sleep(WaitTimes.afterURLChange * 3); // because the normal facebook is really slow

                try
                {
                    IAlert alert = webDriver.SwitchTo().Alert();
                    alert.Dismiss();
                }
                catch { }

                IJavaScriptExecutor javaScriptExec = (IJavaScriptExecutor)webDriver;

                int i = 0;
                for (; i < friendsToLoad / 20; ++i)
                {
                    javaScriptExec.ExecuteScript("window.scroll(0, document.body.scrollHeight)");
                    Thread.Sleep(WaitTimes.afterScroll);
                }

                IWebElement[] aEls = webDriver.FindElements(By.XPath("//a[not(@tabindex) and @data-hovercard-prefer-more-content-show='1']")).ToArray();

                List<string> urlsList = new List<string>(friendsToLoad < aEls.Length ? friendsToLoad : aEls.Length);
                for (i = 0; i < aEls.Length && i < friendsToLoad; ++i)
                    urlsList.Add(aEls[i].GetAttribute("href"));

                string[] urls = urlsList.ToArray();
                urlsList.Clear();
                return urls;
            }
            catch { return null; }
        }
        #endregion

        #region Posting
        /// <summary>
        /// <para>Post anything to any url(fanpage, group, timeline).</para>
        /// <para>Note: The first link is going to be shown as an image/video...</para>
        /// </summary>
        public bool PostTextToURL(string url, string message)
        {
            try
            {
                GetToURL(url);
                IWebElement tf = webDriver.FindElement(By.Name("xc_message"));

                tf.SendKeys(message);
                webDriver.FindElement(By.Name("view_post")).SendKeys(Keys.Enter);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// <para>Post text in a group.</para>
        /// <para>Note: The first link is going to be shown as an image/video...</para>
        /// </summary>
        public bool PostTextInGroup(string groupURL, string message)
        {
            return PostTextToURL(groupURL, message);
        }

        /// <summary>
        /// <para>Post text in a group.</para>
        /// <para>Note: The first link is going to be shown as an image/video...</para>
        /// </summary>
        public bool PostTextInGroup(Group group, string message)
        {
            return PostTextInGroup("https://mbasic.facebook.com/groups/" + group.GroupID, message);
        }

        /// <summary>
        /// <para>Post text in a timeline.</para>
        /// <para>Note: The first link is going to be shown as an image/video...</para>
        /// </summary>
        public bool PostTextInTimeline(string message)
        {
            return PostTextToURL("https://mbasic.facebook.com/", message);
        }
        #endregion

        /// <summary>
        /// Sends a friend request to a person
        /// </summary>
        public bool SendFriendRequest(string personURL)
        {
            try
            {
                GetToURL(personURL);
                webDriver.FindElement(By.LinkText("Add Friend")).Click();
                return true;
            }
            catch { return false; }
        }
    }
}
