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
namespace CWMessages
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
            var service = new TwitterService(consumerKey, consumerSecret);
            service.AuthenticateWith(accesToken, tokensec);

            ArrayList user = new ArrayList();
            foreach (var item in richTextBox2.Lines)
            {
                user.Add(item);
            }
            foreach (string username in user)
            {

                service.SendDirectMessage(new SendDirectMessageOptions
                {
                    ScreenName = username,
                    Text = richTextBox1.Text
                });
            }
        }
    }
}
