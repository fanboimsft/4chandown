using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        InvertText invert1 = new InvertText("NULL");
        InvertText invert2 = new InvertText("NULL");

        public Form1()
        {
            InitializeComponent();
            label1.Text = null;
            label2.Text = null;
           
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            invert1.settext(textBox1.Text);
            label2.Text = invert1.returntext();
            
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            invert2.settext(textBox2.Text);
            label1.Text = invert2.returntext();

            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HtmlWeb web1 = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument page1 = web1.Load(invert1.returntext());
            


            foreach (HtmlNode link in page1.DocumentNode.SelectNodes("//a[@class='fileThumb']"))
                {
                
               listBox1.Items.Add(link.GetAttributeValue("href",""));

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

          int items =listBox1.Items.Count;

            for (int i = 0; i < items; i++)
            {
                string URL = "https:" + listBox1.Items[i].ToString();
                string filename = listBox1.Items[i].ToString();
                string filename2 = Regex.Replace(filename,@"/","");
                label2.Text = "Downloading file:" + filename2+ "("+(i+1)+" of " +items+")";
                label2.Invalidate();
                label2.Update();
                string path = invert2.returntext();

                WebClient myclient = new WebClient();
                myclient.DownloadFile(URL, path + filename2);
                label2.Text = null;

            }

            label2.Text = "All Done!";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            
        }


    }
}