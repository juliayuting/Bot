using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        const string channelAccessToken = "i/4x4GM5nwwiiW5X1IAxc1vLmO9ZAe/Lh68Kndst4l2cm/N8mEE+QZQh+EO/MjPjxhExb/gv/JSKvhFb0/sSspqGK4cRaWtMYlG7AbD1FFl+h9v79TexteocZRYj68C6QN18b4rMB9yeib4XVZ9wvwdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId = "Ud8d2d1618f09feb42ea4407cb5807a3e";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot("i/4x4GM5nwwiiW5X1IAxc1vLmO9ZAe/Lh68Kndst4l2cm/N8mEE+QZQh+EO/MjPjxhExb/gv/JSKvhFb0/sSspqGK4cRaWtMYlG7AbD1FFl+h9v79TexteocZRYj68C6QN18b4rMB9yeib4XVZ9wvwdB04t89/1O/w1cDnyilFU=");

            //bot.PushMessage("Ud8d2d1618f09feb42ea4407cb5807a3e", "#@#FRG");
            
            //抓取用戶身分
            var UserInfo = bot.GetUserInfo("Ud8d2d1618f09feb42ea4407cb5807a3e");
            Response.Write(UserInfo.displayName + "<br/>" + UserInfo.statusMessage);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //建立Bot instance
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot("i/4x4GM5nwwiiW5X1IAxc1vLmO9ZAe/Lh68Kndst4l2cm/N8mEE+QZQh+EO/MjPjxhExb/gv/JSKvhFb0/sSspqGK4cRaWtMYlG7AbD1FFl+h9v79TexteocZRYj68C6QN18b4rMB9yeib4XVZ9wvwdB04t89/1O/w1cDnyilFU=");
            //建立actions，作為ButtonTemplate的用戶回覆行為
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.MessageAction() { label = "標題-文字回覆", text = "回覆文字" });
            //actions.Add(new isRock.LineBot.UriAction() { label = "標題-開啟URL", uri = new Uri("http://www.google.com") });
            actions.Add(new isRock.LineBot.DateTimePickerAction() { label = "請選擇時間", mode = "date" });
            actions.Add(new isRock.LineBot.PostbackAction() { label = "標題-發生postack", data = "abc=aaa&def=111" });
            //單一Button Template Message
            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
            {
                text = "ButtonsTemplate文字訊息",
                title = "ButtonsTemplate標題",
                //設定圖片
                thumbnailImageUrl = new Uri("https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/d9f94328920441.55d941e2eb7a7.jpg"),
                actions = actions//設定回覆動作
            };
            //發送
            bot.PushMessage(AdminUserId, ButtonTemplate);
        }
    }
}