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
using HtmlAgilityPack;
using System.Net;
namespace CWTLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static String consumerKey = "UvKoV2nIz8nW6WT9PA0DUc9Dk";
        public static String consumerSecret = "GpBTIFj7stWViRUZNnf1oAAjbmy80M421QNcsH5GOPRznW2ixW";
        TwitterService service = new TwitterService(consumerKey, consumerSecret);
        OAuthRequestToken toke;
        public OAuthRequestToken login()
        {

            OAuthRequestToken g = service.GetRequestToken();
            var gelen = service.GetAuthenticationUrl(g);
            webBrowser1.Navigate(gelen.ToString());

            return g;
        }

        public void verify(OAuthRequestToken requestToken, string verifier)
        {         
            OAuthAccessToken access = service.GetAccessToken(requestToken, verifier);
            MessageBox.Show(access.ScreenName);    
            service.AuthenticateWith(access.Token, access.TokenSecret);
        }
 
        public void tLogin()
        {
            webBrowser1.Document.GetElementById("username_or_email").SetAttribute("value", "usernameoremail");
            webBrowser1.Document.GetElementById("password").SetAttribute("value","password");
            webBrowser1.Document.GetElementById("allow").InvokeMember("click");
        }
        private void Form1_Load(object sender, EventArgs e)
        {        
           toke= login();
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            string html=webBrowser1.Document.Body.InnerText;
            string pin="";
            char[] karakter = html.ToCharArray();
            for (int i = 0; i < html.Length; i++)
            {
                if (Char.IsNumber(karakter[i]))
                {
                    pin+=karakter[i];
                }
            }
            pin = pin.Substring(2,7);
            textBox1.Text = pin;
            string verifier = textBox1.Text;
            verify(toke,verifier);
        }
        int c = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (c==1)
            {
                tLogin();
            }
            if (c==2)
            {
                string html=webBrowser1.Document.Body.InnerText;
            string pin="";
            char[] karakter = html.ToCharArray();
            for (int i = 0; i < html.Length; i++)
            {
                if (Char.IsNumber(karakter[i]))
                {
                    pin+=karakter[i];
                }
            }
            pin = pin.Substring(2,7);
            textBox1.Text = pin;
            string verifier = textBox1.Text;
            verify(toke,verifier);
            }
            c++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tLogin();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        //    webBrowser1.Document.GetElementById("session[username_or_email]").SetAttribute("value", "usernameoremail");
        //    this.textBox2.Text = webBrowser1.Document.GetElementById("session[username_or_email]").GetAttribute("value");

        //    webBrowser1.Document.GetElementById("session[password]").SetAttribute("value", "password");
        //    this.textBox3.Text = webBrowser1.Document.GetElementById("session[password]").GetAttribute("value");

        //    HtmlElementCollection htmlcol = ((WebBrowser)sender).Document.GetElementsByTagName("input");
        //    for (int i = 0; i < htmlcol.Count; i++)
        //    {
        //        if (htmlcol[i].GetAttribute("type")=="submit")
        //        {
        //            htmlcol[i].InvokeMember("click");
        //           // MessageBox.Show(htmlcol[i].GetAttribute("value")+"  "+i.ToString());
        //        }
        //    }

        }

    }
    
}
