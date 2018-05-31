using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        const string channelAccessToken = "i/4x4GM5nwwiiW5X1IAxc1vLmO9ZAe/Lh68Kndst4l2cm/N8mEE+QZQh+EO/MjPjxhExb/gv/JSKvhFb0/sSspqGK4cRaWtMYlG7AbD1FFl+h9v79TexteocZRYj68C6QN18b4rMB9yeib4XVZ9wvwdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "Ud8d2d1618f09feb42ea4407cb5807a3e";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, $"測試 {DateTime.Now.ToString()} ! ");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, 1,2);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);

            //建立actions. 作為ButtonTemplate的用戶回覆行為
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.MessageAction() { label = "標題-文字回覆", text = "回覆文字" });
            actions.Add(new isRock.LineBot.UriAction() { label = "標題-開啟URL", uri = new Uri("http://www.google.com") });
            actions.Add(new isRock.LineBot.PostbackAction() { label = "標題-發生postack", data = "abc=aaa&def=111" });

            var ButtonTempalteMsg = new isRock.LineBot.ButtonsTemplate()
            {
                title = "選項",
                text = "擇一",
                altText = "用手機檢視",
                thumbnailImageUrl = new Uri("https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/d9f94328920441.55d941e2eb7a7.jpg"),
                actions = actions
            };
            bot.PushMessage(AdminUserId,ButtonTempalteMsg);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);

            //建立actions. 作為ButtonTemplate的用戶回覆行為
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.MessageAction() { label = "Yes", text = "Yes" });
            actions.Add(new isRock.LineBot.MessageAction() { label = "No", text = "No" });

            var ConfirmTemplate = new isRock.LineBot.ConfirmTemplate()
            {
                text = "擇一",
                altText = "用手機檢視",
                actions = actions
            };
            bot.PushMessage(AdminUserId, ConfirmTemplate);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }
    }
}