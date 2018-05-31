using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot("i/4x4GM5nwwiiW5X1IAxc1vLmO9ZAe/Lh68Kndst4l2cm/N8mEE+QZQh+EO/MjPjxhExb/gv/JSKvhFb0/sSspqGK4cRaWtMYlG7AbD1FFl+h9v79TexteocZRYj68C6QN18b4rMB9yeib4XVZ9wvwdB04t89/1O/w1cDnyilFU=");
            bot.PushMessage("Ud8d2d1618f09feb42ea4407cb5807a3e", "你好");// /n換行
            bot.PushMessage("Ud8d2d1618f09feb42ea4407cb5807a3e",1,11);
            bot.PushMessage("Ud8d2d1618f09feb42ea4407cb5807a3e",new Uri("https://www.sbs.com.au/topics/sites/sbs.com.au.topics/files/deep_ocean.jpg"));
        }
    }
}