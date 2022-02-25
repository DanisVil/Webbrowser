using System.Windows.Forms;
using System;
using System.IO;

namespace Web
{
    public partial class Table : Form
    {
        Random random = new Random();
        private static Table instance;
        private Table()
        {
            InitializeComponent();
            InitializeTimer();
            InitializeTree();
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
        private void InitializeTimer()
        {
            // Call this procedure when the application starts.  
            // Set to 1 second.  
            timer1.Interval = 5000;
            timer1.Tick += new EventHandler(timer1_Tick);

            // Enable timer.  
            timer1.Enabled = true;
        }
        private void InitializeTree()
        {
            string[] names1 = File.ReadAllLines($"{Environment.CurrentDirectory}\\09-121.txt");
            string[] names2 = File.ReadAllLines($"{Environment.CurrentDirectory}\\09-122.txt");
            System.Windows.Forms.TreeNode[] groupNodes1 = new System.Windows.Forms.TreeNode[names1.Length],
                groupNodes2 = new System.Windows.Forms.TreeNode[names2.Length];
            for (int i = 0; i < names1.Length; i++)
            {
                groupNodes1[i] = new System.Windows.Forms.TreeNode(names1[i]);
            }
            for (int i = 0; i < names2.Length; i++)
            {
                groupNodes2[i] = new System.Windows.Forms.TreeNode(names2[i]);
            }
            System.Windows.Forms.TreeNode group1 = new System.Windows.Forms.TreeNode("09-121", groupNodes1);
            System.Windows.Forms.TreeNode group2 = new System.Windows.Forms.TreeNode("09-122", groupNodes2);
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            group1, group2});
        }
        private void timer1_Tick(object Sender, EventArgs e)
        {
            splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(random.Next(255), 
                random.Next(255), random.Next(255));
        }

    }
}
