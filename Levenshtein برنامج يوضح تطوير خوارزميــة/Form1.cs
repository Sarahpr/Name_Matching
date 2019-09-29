using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Levenshtein_برنامج_يوضح_تطوير_خوارزميــة
{
    public partial class Form1 : Form
    {
        OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\desktob_new\مشروع التخرج\مشروع التخرج\الجزء العملي\البرنامج الخاص بالمشروع\Levenshtein برنامج يوضح تطوير خوارزميــة\Project for improve Levenshtain1.accdb");
     
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit1 ex = new exit1();
            ex.StartPosition = FormStartPosition.CenterParent;
            ex.ShowDialog();
        }

        private void varibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frvarible frv = new Frvarible();
            frv.StartPosition = FormStartPosition.CenterParent;
            frv.ShowDialog();
        }

        private void التشابهالشكلـــيToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void التشابهالصوتـــيToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void بـإستخدامقانونإقليدسToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void بـإستخدامقانونمنهاتينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void dataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.StartPosition = FormStartPosition.CenterParent;
           db.ShowDialog();

        }

        private void tabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void meanToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void التشابهالشكلـــيToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Similarity sm = new Similarity();
            sm.StartPosition = FormStartPosition.CenterParent;
            sm.ShowDialog();
        }

        private void التشابهالصوتـــيToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            soundex so = new soundex();
            so.StartPosition = FormStartPosition.CenterParent;
            so.ShowDialog();

        }

        private void بـإستخدامقانونإقليدسToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            key_eqcs ke = new key_eqcs();
            ke.StartPosition = FormStartPosition.CenterParent;
            ke.ShowDialog();

        }

        private void بـإستخدامقانونمنهاتينToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            keymn km = new keymn();
            km.StartPosition = FormStartPosition.CenterParent;
            km.ShowDialog();
        }

        private void خوارزميةليفنشتاينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            levenshtein1 f = new levenshtein1();
            f.Show();
        }

        private void مقارنةالنتائجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void الخوارزميةالمطورة1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            le_im_1 f = new le_im_1();
            f.Show();
        }

        private void الخوارزميةالمطـــــورة2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            le_im_2 f = new le_im_2();
            f.Show();
        }

        private void مسافةإقليدسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            le_im_3 f = new le_im_3(1);
            f.Show();
        }

        private void مسافةمنهاتينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            le_im_3 f = new le_im_3(2);
            f.Show();
        }

        private void مسافةإقليدسToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Le_IM_a f = new Le_IM_a(1);
            f.ShowDialog();

           
        }

        private void مسافةمنهاتينToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Le_IM_a f = new Le_IM_a(2);
            f.ShowDialog();
        }

        private void مسافةإقليدسToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            le_im_5 f = new le_im_5(1);
            f.ShowDialog();
        }

        private void مسافةمنهاتينToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            le_im_5 f = new le_im_5(2);
            f.ShowDialog();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void اقليدسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main min1 = new main(1);
            min1.StartPosition = FormStartPosition.CenterParent;
            min1.ShowDialog();
        }

        private void منهاتنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main min1 = new main(2);
            min1.StartPosition = FormStartPosition.CenterParent;
            min1.ShowDialog();
        }
    }
}
