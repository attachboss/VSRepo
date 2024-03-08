using HtmlAgilityPack;
using csharp1.Common;
using csharp1.Model;
using csharp1;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;

namespace Common.http
{
    public class HttpHelper
    {
        static Logger logger = new Logger(typeof(HttpHelper));
        //当前页索引值
        static int index = 1;
        static string host = "www.metalkingdom.net";

        static readonly HttpClient client = new HttpClient();
        public static async Task<string> Crawler(string url, Encoding encode)
        {
            string html = null;
            try
            {
                //client.Timeout = new TimeSpan(0, 1, 0);
                //client.DefaultRequestHeaders.Add("Cookie", "buvid3=BB79FFC4-4B3E-8631-9F5B-50C9F57D8F9386540infoc; i-wanna-go-back=-1; buvid_fp_plain=undefined; rpdid=|(J~R~|~RJ~l0J'uYR~)J~RlJ; LIVE_BUVID=AUTO3116479926232248; nostalgia_conf=-1; hit-dyn-v2=1; b_ut=5; fingerprint=d506d284be346178181f4bf15b68b3d7; DedeUserID=690442472; DedeUserID__ckMd5=148f036b9d7fd66b; blackside_state=0; CURRENT_QUALITY=116; b_nut=100; go_old_video=-1; CURRENT_BLACKGAP=0; _uuid=10A65B293-742E-E982-3F10D-898104C10ADA3C05330infoc; buvid4=C00E7888-9B2A-1B08-33F2-245C7DEF30E005412-022092510-xREVEdt9gFxNhN+xDmTuPg%3D%3D; buvid_fp=9f3234c1a75142c03a669904b00e6cc2; bp_video_offset_690442472=712278364382036000; innersign=0; SESSDATA=3b98a091%2C1681558429%2C8e759%2Aa2; bili_jct=fd6c4c4809bfa651fc43923d9d2b9f78; CURRENT_FNVAL=16; sid=6vzjpt7f");
                client.DefaultRequestHeaders.Host = host;
                client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Add("accept-language", "zh-CN,zh;q=0.9");

                //HttpResponseMessage res = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url));
                HttpResponseMessage res = await client.GetAsync(url);
                res.EnsureSuccessStatusCode();
                string lastHtml = html;
                html = await res.Content.ReadAsStringAsync();

                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                //只有第一次进入
                if (index == 1)
                {
                    //如果页面上有总页数
                    //string totalPagesPath = "//*[@id='main-content-new']/div/div[8]/span[15]/a";
                    //HtmlNode totalPagesNode = htmlDoc.DocumentNode.SelectSingleNode(totalPagesPath);
                    //if (totalPagesNode == null)
                    //{
                    //    throw new Exception("没有找到总页数!");
                    //}
                    //int.TryParse(totalPagesNode.InnerText, out int totalPagesCount);

                    //递归页数
                    //因为不能直接获取
                    for (int i = 1; i < 9999 + 1; i++)
                    {
                        index++;
                        new Task(async () => { await Crawler($"{url}/{i}", encode); });
                    }
                }
                else if (lastHtml == html)
                    return null;

                Console.WriteLine(url);
                DownLoadResource(htmlDoc);
                return html;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void DownLoadResource(HtmlDocument htmlDoc)
        {
            string xpath = "//*[@id='talt']/tbody/tr";
            //匹配所有符合的节点
            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes(xpath);
            if (nodes != null)
            {
                HtmlDocument outerDoc = new HtmlDocument();
                HtmlNodeCollection outerNodes;
                HtmlNode outerNode;
                List<Album> albums = new List<Album>();
                //遍历每一页的数据
                foreach (HtmlNode node in nodes)
                {
                    Album album = new Album();
                    string outerHtml = node.OuterHtml;
                    outerDoc.LoadHtml(outerHtml);

                    string imgPath = "//tr/td/a/img";
                    //获取内层节点，匹配单个节点
                    outerNode = outerDoc.DocumentNode.SelectSingleNode(imgPath);
                    if (outerNode != null)
                    {
                        if (outerNode.Attributes["data-src"] != null)
                        {
                            album.ImgUrl = outerNode.Attributes["data-src"].Value;
                        }
                        else if (outerNode.Attributes["data-lazy-img"] != null)
                        {
                            //匹配懒加载属性
                            album.ImgUrl = outerNode.Attributes["data-lazy-img"].Value;
                        }
                        if (album.ImgUrl != null && album.ImgUrl.StartsWith("/"))
                        {
                            //给数据添加标头
                            album.ImgUrl = $"https://www.metalkingdom.net{album.ImgUrl}";
                        }
                    }

                    if (!long.TryParse(Path.GetFileNameWithoutExtension(album.ImgUrl), out long id))
                        throw new Exception("id写入出现错误");
                    album.Id = id;
                    outerNode = outerDoc.DocumentNode.SelectSingleNode("//tr/td/strong/span");
                    if (!int.TryParse(outerNode.InnerText, out int rankId))
                        throw new Exception("没有RankId");
                    album.RankId = rankId;
                    outerNodes = outerDoc.DocumentNode.SelectNodes("//tr/td/div/a/strong/span");
                    album.BandName = outerNodes[0].InnerText.Trim();
                    outerNode = outerDoc.DocumentNode.SelectSingleNode("//tr/td/div[2]");
                    album.Name = outerNode.InnerText.Trim().Split('(')[0];
                    //请求子页面
                    try
                    {
                        string[] sub = DownLoadSub($"http://{host}/album/{album.BandName.ToLower()}-{string.Join('-', album.Name.ToLower().Split(' '))}{album.Id}").Result;
                        if (sub != null)
                        {
                            album.Type = sub[1];
                            album.ReleaseTime = DateTime.Parse(sub[2]);
                            album.Genres = sub[3].Trim().Split(',');
                            album.Label = sub[4];
                            album.Format = sub[5];
                            if (sub[6].LastIndexOf(':')==2)
                            {
                                sub[6] = $"00:{sub[6]}";
                            }
                            album.TotalLength = TimeSpan.Parse(sub[6]);
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }



                    albums.Add(album);
                }
            }
        }

        private static async Task<string[]> DownLoadSub(string url)
        {
            Console.WriteLine(url);
            HttpResponseMessage res = await client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            string html = await res.Content.ReadAsStringAsync();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//*[@class='album-info-table']//tr/td");
            string[] sub = new string[nodes.Count];
            for (int i = 0; i < nodes.Count; i++)
            {
                while (nodes[i].HasChildNodes)
                {
                    //LINQ判断子节点中是否存在同级节点
                    if (nodes[i].Descendants()
                        .GroupBy(x => x.Name)
                        .Where(name => name
                        .Count() > 1)
                        .ToList().Count > 1)
                    {
                        HtmlNodeCollection broNodes = nodes[i].ChildNodes;
                        for (int j = 0; j < broNodes.Count; j++)
                        {
                            sub[i] += $"{broNodes[j].InnerText}";
                            nodes[i].RemoveChild(broNodes[j]);
                        }
                    }
                    else
                        nodes[i] = nodes[i].FirstChild;
                }
                sub[i] += nodes[i].InnerText;
            }
            return sub;
        }
    }
}
