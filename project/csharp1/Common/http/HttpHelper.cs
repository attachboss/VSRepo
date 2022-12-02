using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace MyNote.http
{
    public class HttpHelper
    {
        public static string DownLoadHtml(string url, Encoding encode)
        {
            string html = String.Empty;
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
                req.Timeout = 60000;
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36";
                req.ContentType = "text/html; charset=utf-8";
                req.Host = "www.bilibili.com";
                //添加Cookie
                req.Headers.Add("Cookie", "buvid3=53D8D3F2-D917-A88F-225A-980924873FBE69286infoc; i-wanna-go-back=-1; _uuid=10FCC2781-A646-C125-77EA-4107BC7D3683E70396infoc; buvid4=4744AF35-DF09-F676-21D5-FA74D696846470908-022051509-xREVEdt9gFzKy/bzU5HMYw%3D%3D; buvid_fp_plain=undefined; DedeUserID=187824639; DedeUserID__ckMd5=a8a19309b955bf36; nostalgia_conf=-1; CURRENT_BLACKGAP=0; rpdid=|(J~R~|~Rl)m0J'uYlkl~~ku|; b_ut=5; hit-dyn-v2=1; LIVE_BUVID=AUTO2616530427835091; fingerprint=a7a83d4edb5394aeab1be0ef03e503b8; SESSDATA=07da25b3%2C1670940862%2Cf21f2%2A61; bili_jct=9c19b61b964bc43b568f402c8e78aceb; sid=7vcbwy6l; buvid_fp=a7a83d4edb5394aeab1be0ef03e503b8; blackside_state=0; Hm_lvt_8a6e55dbd2870f0f5bc9194cddf32a02=1661331037; CURRENT_QUALITY=80; b_nut=100; PVID=1; bp_video_offset_187824639=713156135438254100; innersign=1; CURRENT_FNVAL=4048; theme_style=light");
                req.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                req.Headers.Add("Accept-encoding", "gzip, deflate, br");
                using (HttpWebResponse res = req.GetResponse() as HttpWebResponse)
                {
                    if (res.StatusCode != HttpStatusCode.OK)
                    {

                    }
                    else
                    {
                        using (StreamReader sr = new StreamReader(res.GetResponseStream(), encode))
                        {
                            html = sr.ReadToEnd();
                        }
                    }
                }
                return html;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
