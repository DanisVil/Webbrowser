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
    public partial class Table : Form
    {
        private static Table instance;
        private Table()
        {
            InitializeComponent();
        }
        public static Table GetInstance()
        {
            if (instance == null) instance = new Table();
            return instance;
        }

        private void ProperClose(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }
    }
}
