using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace homework9
{
    public class Crawler
    {
        public event Action<Crawler> stopping;
        public event Action<Crawler, int, string, string> PageDownloaded;

        //待下载网页
        private ConcurrentQueue<string> waitingURL = new ConcurrentQueue<string>();
        //已下载
        public ConcurrentDictionary<string, bool> DownloadedPages { get; } = new ConcurrentDictionary<string, bool>();
        //URL检测表达式，用于在HTML文本中查找URL
        public static readonly string UrlDetectRegex = @"(href|HREF)[]*=[]*[""'](?<url>[^""'#>]+)[""']";
        //URL解析表达式
        public static readonly string urlParseRegex = @"^(?<site>(?<protocal>https?)://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
        //主机过滤规则
        public string HostFilter { get; set; }
        //文件过滤规则
        public string FileFilter { get; set; }
        //最大下载数量
        public int MaxPage { get; set; }
        //起始网址
        public string StartURL { get; set; }
        //网页编码
        public Encoding HtmlEncoding { get; set; }

        public Crawler()
        {
            MaxPage = 50;
            HtmlEncoding = Encoding.UTF8;
        }

        public void Start()
        {
            DownloadedPages.Clear();
            waitingURL = new ConcurrentQueue<string>();
            waitingURL.Enqueue(StartURL);

            List<Task> tasks = new List<Task>();
            int completedCount = 0;  // 已完成的任务数
            PageDownloaded += (crawlwe, index, url, info) => { completedCount++; };

            while (tasks.Count < MaxPage)
            {
                if(!waitingURL.TryDequeue(out string url))
                {
                    if (completedCount < tasks.Count) continue;
                    else break;
                }
                int index = tasks.Count;
                Task task = Task.Run(() => DownloadAndParse(url, index));
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());  //等待剩余任务执行完毕
            stopping(this);            
        }

        //url:待处理的网址  index: 任务序号
        private void DownloadAndParse(string url,int index)
        {
            try
            {
                string html = DownLoad(url, index);
                DownloadedPages[url] = true;
                Parse(html, url);  //解析，并加入新的链接
                PageDownloaded(this, index, url, "success");
            }catch(Exception ex)
            {
                PageDownloaded(this, index, url, "Error:" + ex.Message);
            }
        }

        //url:待处理的网址  index: 任务序号
        public string DownLoad(string url,int index)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                File.WriteAllText(index+".html", html, Encoding.UTF8);
                return html;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html, string pageUrl)
        {
            var matches = new Regex(UrlDetectRegex).Matches(html);
            foreach(Match match in matches)
            {
                string linkURL = match.Groups["url"].Value;   //查找到的URL
                if (linkURL == null || linkURL == "" || linkURL.StartsWith("javascript:")) continue;
                linkURL = FixUrl(linkURL, pageUrl);   //转绝对路径
                //解析出host和file两个部分，进行过滤
                Match linkUrlMatch = Regex.Match(linkURL, urlParseRegex);
                string host = linkUrlMatch.Groups["host"].Value;
                string file = linkUrlMatch.Groups["file"].Value;
                if (file == "") file = "index.html";
                if(Regex.IsMatch(host,HostFilter)&&Regex.IsMatch(file,FileFilter)
                    && !DownloadedPages.ContainsKey(linkURL))
                {
                    waitingURL.Enqueue(linkURL);
                    DownloadedPages.TryAdd(linkURL, false);
                }
            }
        }

        //将非完整路径转为完整路径   url: 待转地址   baseUrl：当前页面地址
        static private string FixUrl(string url, string pageUrl)
        {
            if (url.Contains("://"))
            { //完整路径
                return url;
            }
            if (url.StartsWith("//"))
            {
                Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
                string protocal = urlMatch.Groups["protocal"].Value;
                return protocal + ":" + url;
            }
            if (url.StartsWith("/"))
            {
                Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
                String site = urlMatch.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }

            if (url.StartsWith("../"))
            {
                url = url.Substring(3);
                int idx = pageUrl.LastIndexOf('/');
                return FixUrl(url, pageUrl.Substring(0, idx));
            }

            if (url.StartsWith("./"))
            {
                return FixUrl(url.Substring(2), pageUrl);
            }
            //非上述开头的相对路径
            int end = pageUrl.LastIndexOf("/");
            return pageUrl.Substring(0, end) + "/" + url;
        }

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        
        
        
    }
}
