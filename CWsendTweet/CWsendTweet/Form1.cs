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
namespace CWsendTweet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static String consumerKey = "UvKoV2nIz8nW6WT9PA0DUc9Dk";
        public static String consumerSecret = "GpBTIFj7stWViRUZNnf1oAAjbmy80M421QNcsH5GOPRznW2ixW";
        public static String accesToken = "3397054054-CT2W0fYiH2skxCRxUkp7zpaunNPtiXOs2mbJLxs";
        public static String tokensec = "4MvgJ9ZEgiDnTcvoFpEXrKFb4zebvwbmCnTcW6kX4qCpJ";
        private void button1_Click(object sender, EventArgs e)
        {
            int count =int.Parse(textBox1.Text);
            Random rnd = new Random();
           
            var service = new TwitterService(consumerKey, consumerSecret);
            service.AuthenticateWith(accesToken, tokensec);

            ArrayList tweets = new ArrayList();
            foreach (var item in richTextBox1.Lines)
            {
                tweets.Add(item);
            }

            for (int i = 0; i < count;i++ )
            {
                int indx = rnd.Next(0, richTextBox1.Lines.Length);
                string tweet = tweets[indx].ToString();
                MessageBox.Show(tweet);
                service.SendTweet(new SendTweetOptions
                {
                    Status = tweet
                });
            }
        }
    }
}
