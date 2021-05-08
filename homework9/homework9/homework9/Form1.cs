using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework9
{
    public partial class Form1 : Form
    {
        BindingSource resultBindingSourse = new BindingSource();
        Crawler crawler = new Crawler();
        public Form1()
        {
            InitializeComponent();
            resultGrid.DataSource = resultBindingSourse;
            crawler.PageDownloaded += Crawler_PageDownloaded;
            crawler.stopping += Crawlwer_CrawlerStopped;
        }

        private void Crawlwer_CrawlerStopped(Crawler c)
        {
            Action action = () => info.Text = "停止爬行";
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void Crawler_PageDownloaded(Crawler c,string url,string str)
        {
            var pageInfo = new { Index = resultBindingSourse.Count + 1, URL = url, Status = str };
            Action action = () => { resultBindingSourse.Add(pageInfo); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }

        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            resultBindingSourse.Clear();
            crawler.StartURL = URLText.Text;

            Match match = Regex.Match(crawler.StartURL, Crawler.urlParseRegex);
            if (match.Length == 0) return;
            string host = match.Groups["host"].Value;
            crawler.HostFilter = "^" + host + "$";
            crawler.FileFilter = "((.html?|.jsp|.php)$|^[^.]+$)";
            new Thread(crawler.Start).Start();
            info.Text = "启动爬虫";
        }
    }
}
