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
namespace CWFW
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
        private void button1_Click(object sender, EventArgs e)
        {
            var service = new TwitterService(consumerKey, consumerSecret);
            service.AuthenticateWith(accesToken, tokensec);
            ArrayList user = new ArrayList();
            foreach (var item in richTextBox1.Lines)
            {
                user.Add(item);
            }

            foreach (string item in user)
            {
                service.FollowUser(new FollowUserOptions
                {
                    ScreenName = item

                });
            }
        }
    }
}
