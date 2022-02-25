using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web
{
    public partial class Browser : Form
    {
        private LinkedList<Uri> history = new LinkedList<Uri>();
        private LinkedListNode<Uri> uri;
        public Browser()
        {
            InitializeComponent();
        }

        private void OpenTable(object sender, EventArgs e)
        {
            Table table = Table.GetInstance();
            table.Show();
        }

        private void OpenHomePage(object sender, EventArgs e)
        {
            Uri google = new Uri("https://www.google.com/");
            if (history.Count == 0) history.AddFirst(google);
            else if (!history.Last.Value.Equals(google))
                history.AddLast(google);
            uri = history.Last;
            webBrowser1.Url = uri.Value;
        }

        private void GoBack(object sender, EventArgs e)
        {
            if (uri.Previous != null)
            {
                uri = uri.Previous;
                webBrowser1.Url = uri.Value;
            }
        }
        private void GoNext(object sender, EventArgs e)
        {
            if (uri.Next != null)
            {
                uri = uri.Next;
                webBrowser1.Url = uri.Value;
            }
        }

        private void OpenSite(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (history.Count == 0)
                        history.AddFirst(new Uri(textBox1.Text));
                    else history.AddLast(new Uri(textBox1.Text));
                    uri = history.Last;
                    webBrowser1.Url = uri.Value;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}
