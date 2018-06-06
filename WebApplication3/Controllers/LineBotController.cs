using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication3.Controllers
{
    public class LineBotController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "i/4x4GM5nwwiiW5X1IAxc1vLmO9ZAe/Lh68Kndst4l2cm/N8mEE+QZQh+EO/MjPjxhExb/gv/JSKvhFb0/sSspqGK4cRaWtMYlG7AbD1FFl+h9v79TexteocZRYj68C6QN18b4rMB9yeib4XVZ9wvwdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId = "Ud8d2d1618f09feb42ea4407cb5807a3e";

        [Route("api/LineBot")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event(範例，只取第一個)
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
                if (LineEvent.type == "message")
                {
                    if (LineEvent.message.type == "text") //收到文字
                        this.ReplyMessage(LineEvent.replyToken, "你說了:" + LineEvent.message.text);
                    if (LineEvent.message.type == "sticker") //收到貼圖
                        this.ReplyMessage(LineEvent.replyToken, 1, 2);
                    if (LineEvent.message.type == "location") //收到GPS
                        this.ReplyMessage(LineEvent.replyToken,
                        $"你的位置在 \n {LineEvent.message.latitude},{LineEvent.message.longitude},{LineEvent.message.address}");
                    if (LineEvent.message.type == "image") //收到圖片
                    {
                        //取得圖片Bytes
                        var bytes = this.GetUserUploadedContent(LineEvent.message.id);
                        //儲存為圖檔
                        var guid = Guid.NewGuid().ToString();
                        var filename = $"{guid}.png";
                        var path = System.Web.Hosting.HostingEnvironment.MapPath("~/temp/");
                        System.IO.File.WriteAllBytes(path + filename, bytes);
                        //取得base URL
                        var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
                        //組出外部可讀取的檔名
                        var url = $"{baseUrl}/temp/{filename}";
                        this.ReplyMessage(LineEvent.replyToken,$"你的圖片位於 \n {url} ");
                    }                       
                    //replyToken只能發一次
                    //this.ReplyMessage(LineEvent.replyToken, "Hello, 你的UserId是：" + LineEvent.source.userId);
                }
                //回覆訊息
                if(LineEvent.type == "postback")
                {
                    //var data = LineEvent.postback.data;
                    //this.ReplyMessage(LineEvent.replyToken, $"觸發了postback \n 資料為：{data}");
                    var data = LineEvent.postback.data;
                    var dt = LineEvent.postback.Params.date;
                    this.ReplyMessage(LineEvent.replyToken, $"觸發了postback \n 資料為：{data} \n 選擇結果：{dt}");
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin.
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}
