using HtmlAgilityPack;
using MyNote;
using System.Text;

namespace Common.http
{
    public class HttpHelper
    {
        static Logger logger = new Logger(typeof(HttpHelper));

        static readonly HttpClient client = new HttpClient();
        public static async Task<string> DownLoadHtml(string url, Encoding encode)
        {
            string html = String.Empty;
            try
            {
                client.Timeout = new TimeSpan(0, 1, 0);
                client.DefaultRequestHeaders.Add("Cookie", "buvid3=53D8D3F2-D917-A88F-225A-980924873FBE69286infoc; i-wanna-go-back=-1; _uuid=10FCC2781-A646-C125-77EA-4107BC7D3683E70396infoc; buvid4=4744AF35-DF09-F676-21D5-FA74D696846470908-022051509-xREVEdt9gFzKy/bzU5HMYw%3D%3D; buvid_fp_plain=undefined; DedeUserID=187824639; DedeUserID__ckMd5=a8a19309b955bf36; nostalgia_conf=-1; CURRENT_BLACKGAP=0; rpdid=|(J~R~|~Rl)m0J'uYlkl~~ku|; b_ut=5; hit-dyn-v2=1; LIVE_BUVID=AUTO2616530427835091; fingerprint=a7a83d4edb5394aeab1be0ef03e503b8; SESSDATA=07da25b3%2C1670940862%2Cf21f2%2A61; bili_jct=9c19b61b964bc43b568f402c8e78aceb; sid=7vcbwy6l; buvid_fp=a7a83d4edb5394aeab1be0ef03e503b8; blackside_state=0; Hm_lvt_8a6e55dbd2870f0f5bc9194cddf32a02=1661331037; CURRENT_QUALITY=80; b_nut=100; PVID=1; bp_video_offset_187824639=713156135438254100; innersign=1; CURRENT_FNVAL=4048; theme_style=light");
                //HttpResponseMessage res = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
                HttpResponseMessage res = await client.GetAsync(url);
                res.EnsureSuccessStatusCode();
                html = await res.Content.ReadAsStringAsync();
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);
                string xpath = "//*[@class=\"bili-video-card__stats--text\"]";
                HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes(xpath);
                if (nodes != null)
                {
                    foreach (HtmlNode node in nodes)
                    {

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
