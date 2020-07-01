# Simple-Facebook-Crawler
Make your life easier with Facebook Crawler and don't use Facebook API

### REQUIREMENTS
```
Selenium.WebDriver <- nuget package
```

### ALL METHODS
```
LogIn()
LogOut()
GetAllJoinedGroups()
GetProfile(url of person)
GetGroupInfo(url of group)
GetGroupPosts(url of group, posts to load)
LoadFriends(friends to load)
PostTextToURL(url, message)
PostTextInGroup(url of group, message)
PostTextInTimeline(message)
SendFriendRequest(url of person)
```

### EXAMPLE - Get joined groups and post in them
```csharp
FacebookCrawler crawler = new FacebookCrawler(new ChromeDriver());
crawler.LogIn(email: "", password: "", message: "Hello there :D");

string[] urls = crawler.GetAllJoinedGroups();
foreach(string url in urls)
    crawler.PostTextInGroup(url, message);

crawler.LogOut();
```

### NOTES ABOUT THE CODE
  - The algorithms in this repository weren't made to be fast(some of them may take up to 10/20 seconds)! They were made to work!
  - If you have fast internet you can decrease the waiting times from **WaitTimes.cs**
  - Selenium requires try-catch in order to check if an element exists(that slows down even more).
  - Selenium opens an "automated software driven" window.
  - If you are going to post emojis you shouldn't choose a ChromeDriver because it doesn't allow emojis!

### LICENSE: Apache License 2.0
#
#
▁▂▅▆▇ 📲 Social Media and Contacts 📲 ▇▆▅▂▁ <br>
➡ WEBSITE - https://thedevelopers.tech <br>
📌YOUTUBE - https://www.youtube.com/channel/UCwO0k5dccZrTW6-GmJsiFrg <br>
📘FACEBOOK - https://www.facebook.com/VicTor-372230180173180 <br>
📒INSTAGRAM - https://www.instagram.com/thedeveloper10/ <br>
💎TWITTER - https://twitter.com/the_developer10 <br>
✶LINKEDIN - https://www.linkedin.com/company/65346254
