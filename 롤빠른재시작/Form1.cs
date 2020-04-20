using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace 롤빠른재시작
{
    public partial class Form1 : Form
    {
        static String PROCESS_NAME = "LeagueClientUxRender";
        public Form1()
        {
            InitializeComponent();
            MinimizeBox = false;
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            refresh();

            Process[] pname = Process.GetProcessesByName(PROCESS_NAME);
            if (pname.Length == 0)
                pname = Process.GetProcessesByName(PROCESS_NAME + ".exe");
            for (int i = 0; i < pname.Length; i++)
            {
                pname[i].Kill();
            }

            refresh();

        }


        private void refresh()
        {
            Process[] pname = Process.GetProcessesByName(PROCESS_NAME);
            if (pname.Length == 0)
                pname = Process.GetProcessesByName(PROCESS_NAME + ".exe");

            if (pname.Length == 0)
            {
                toolStripStatusLabel1.Text = "✖ Lol 클라이언트 꺼짐";
                toolStripStatusLabel1.ForeColor = Color.DarkRed;
                button1.Enabled = false;
                button1.Text = "기다리는 중...";
            }
            else
            {
                toolStripStatusLabel1.Text = "✔ Lol 클라이언트 실행중";
                toolStripStatusLabel1.ForeColor = Color.ForestGreen;
                button1.Enabled = true;
                button1.Text = "클라이언트 종료";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refresh();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }


        private void 만든이에게ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/jhleee/Lol-quick-restart");

        }

        private void 종료ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }


}
