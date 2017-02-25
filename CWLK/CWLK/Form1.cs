using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TweetSharp;
using System.Collections;
namespace CWLK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static String consumerKey = "UvKoV2nIz8nW6WT9PA0DUc9Dk";
        public static String consumerSecret = "GpBTIFj7stWViRUZNnf1oAAjbmy80M421QNcsH5GOPRznW2ixW";
        public static String accesToken = "user-accesToken";
        public static String tokensec = "user-tokensec";
        public static ArrayList tweetID = new ArrayList();
        public void listtweet(TwitterService service)
        {
            ArrayList user = new ArrayList();
            foreach (var item in richTextBox1.Lines)
            {
                user.Add(item);
            }
            foreach (string username in user)
            {
                int count = 0;
                var twt = service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions { });
                while (count != 15)
                {
                    var tweet = service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions
                    {
                        ScreenName = username,
                        Count = 200,
                        MaxId = twt.Last().Id
                    });
                    twt = tweet;
                    foreach (var item in tweet)
                    {

                        int index = tweetID.IndexOf(item);
                        if (index == -1)
                        {
                            tweetID.Add(item.Id);
                        }
                        else
                        {
                            tweetID.RemoveAt(index);
                        }

                    }
                    count++;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            var service = new TwitterService(consumerKey, consumerSecret);
            service.AuthenticateWith(accesToken, tokensec);
            listtweet(service);
            for (int i = 0; i < tweetID.Count; i++)
            {
                service.FavoriteTweet(new FavoriteTweetOptions
                {
                   Id = long.Parse(tweetID[i].ToString())

                });
                a++;
                label1.Text = a.ToString();
            }
            
        }
    }
}
