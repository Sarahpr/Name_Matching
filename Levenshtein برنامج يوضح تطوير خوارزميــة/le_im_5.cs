﻿using System;
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
    public partial class le_im_5 : Form
    {
        string source_word, target_word, v_1, v_2;
        double[,] cost;
        int row, col;
        //================================================

        OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\desktob_new\مشروع التخرج\مشروع التخرج\الجزء العملي\البرنامج الخاص بالمشروع\Levenshtein برنامج يوضح تطوير خوارزميــة\Project for improve Levenshtain1.accdb");
     
        OleDbDataAdapter dp;
        DataTable DT;
        OleDbCommand cmd;
        //=================================================
        /*=================function Members====================*/
        void filldat_1()
        {
            cmd = new OleDbCommand("select v_value from varibles", con1);
            con1.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            dr.Read();

            v_1 = dr[0].ToString();
            dr.Read();
            v_2 = dr[0].ToString();
            con1.Close();
        }
        /*__________function for ____________________*/
        //=============================================
        //this function for return the minimum element
        double minimumel(double x, double y, double z)
        {
            if (x < y && x < z)
                return x;
            else
                if (y < x && y < z)
                    return y;
                else return z;
        }
        //=================================================
        /*this function for compute sumtion for two number*/
        float sum(double x, double y)
        {
            float z = (float)x + (float)y; return z;
        }
        //====================================================
        //this function for return cost of insert & delete 
        double ins_del_cost(char a, char b)
        {
            double cost;
            if (a == ' ' || (a != b && a == 'ء') && (b == 'ا' || b == 'و' || b == 'ي'))
                cost = 0;
            else if (a == b)
                cost = Convert.ToDouble(v_2);
            else if (a != b && (a == 'ا' || a == 'و' || a == 'ي'))
                cost = Convert.ToDouble(v_1);
            else
                cost = 1;
            return cost;
        }
        //=============================================
        int max_L(string s_w, string T_w)
        {
            if (s_w.Length > T_w.Length)
                return s_w.Length;
            return T_w.Length;
        }
        //============================================================
        double similarity_R(string source_W, string Target_W, double cost)
        { return ((1 - (cost / (float)max_L(source_W, Target_W))) * 100); }
        //====================================================
        double keyboard_s(char a, char b)
        {

            for (int i = 1; i < dataGridView1.RowCount - 1; i++)
                if (Convert.ToChar(dataGridView1[i, 0].Value) == a)
                { row = i; break; }
            for (int i = 1; i < dataGridView1.ColumnCount; i++)
                if (Convert.ToChar(dataGridView1[0, i].Value) == b)
                { col = i; break; }
            return 1 - Convert.ToDouble(dataGridView1[row, col].Value);
        }
        //======================================
        //this function for return the sound similarity value
        double sound_s(char a, char b)
        {

            for (int i = 1; i < dataGridView4.RowCount - 1; i++)
                if (Convert.ToChar(dataGridView4[i, 0].Value) == a)
                { row = i; break; }
            for (int i = 1; i < dataGridView4.ColumnCount; i++)
                if (Convert.ToChar(dataGridView4[0, i].Value) == b)
                { col = i; break; }
            return 1 - Convert.ToDouble(dataGridView4[row, col].Value);
        }
        //=================================================
        //this function for return the form similarity value
        double form_s(char a, char b)
        {

            for (int i = 1; i < dataGridView3.RowCount - 1; i++)
                if (Convert.ToChar(dataGridView3[i, 0].Value) == a)
                { row = i; break; }
            for (int i = 1; i < dataGridView3.ColumnCount; i++)
                if (Convert.ToChar(dataGridView3[0, i].Value) == b)
                { col = i; break; }
            return 1 - Convert.ToDouble(dataGridView3[row, col].Value);
        }
        //========================================
        //this function for return the keyboard similarity value
        double minimum_s(char a, char b)
        {
            double value1, value2, value3, result;
            value1 = keyboard_s(a, b);
            value2 = sound_s(a, b);
            value3 = form_s(a, b);
            result = minimumel(value1, value2, value3);

            return result;

        }
        //==========================================
        //================================
        void filldgv4()
        {

            DT = new DataTable();
            dp = new OleDbDataAdapter("select * from Sound_Similarity", con1);
            dp.Fill(DT);
            dataGridView4.DataSource = DT;

        }
        void filldgv1()
        {

            DT = new DataTable();
            dp = new OleDbDataAdapter("select * from Keyboard_Similarity_EQ", con1);
            dp.Fill(DT);
            dataGridView1.DataSource = DT;

        }
        void filldgv6()
        {

            DT = new DataTable();
            dp = new OleDbDataAdapter("select * from Keyboard_Similarity", con1);
            dp.Fill(DT);
            dataGridView1.DataSource = DT;

        }
        void filldgv3()
        {

            DT = new DataTable();
            dp = new OleDbDataAdapter("select * from Form_Similarity", con1);
            dp.Fill(DT);
            dataGridView3.DataSource = DT;

        }
        //==================================
        double cul_destance_m(string source, string target)
        {
            source_word = source;
            target_word = target;
            char ch1, ch2;
            cost = new double[source_word.Length + 1, target_word.Length + 1];
            for (int i = 0; i <= source_word.Length; i++) cost[i, 0] = i;
            for (int i = 0; i <= target_word.Length; i++) cost[0, i] = i;
            for (int j = 1; j <= target_word.Length; j++)
                for (int i = 1; i <= source_word.Length; i++)
                {
                    if (i != 1)
                        ch1 = source_word[i - 2];
                    else ch1 = ' ';
                    if (j != 1)
                        ch2 = target_word[j - 2];
                    else ch2 = ' ';
                    cost[i, j] = minimumel(sum(cost[i - 1, j], ins_del_cost(source_word[i - 1], ch1)), sum(cost[i, j - 1], ins_del_cost(target_word[j - 1], ch2)), sum(cost[i - 1, j - 1], minimum_s(source_word[i - 1], target_word[j - 1])));

                }
            double Distance = cost[source_word.Length, target_word.Length];
            return Distance;

        }
        //==========================
        void filldata()
        {
            cmd = new OleDbCommand("select * from DataSet", con1);
            con1.Open();
            int row = 0;
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dataGridView2.Rows.Add();
                    dataGridView2[0, row].Value = dr[0].ToString();
                    dataGridView2[1, row].Value = dr[1].ToString();
                    double Distance;
                    double similarity;
                    Distance = cul_destance_m(dr[0].ToString(), dr[1].ToString());
                    similarity = similarity_R(source_word, target_word, Distance);
                    int s = Convert.ToInt16(similarity);
                    dataGridView2[2, row].Value = Distance.ToString();
                    dataGridView2[3, row].Value = s.ToString() + "%";


                    row++;
                }

            }
            con1.Close();
        }
        public le_im_5(int i)
        {
            InitializeComponent();
            filldat_1();
            if (i == 1)
            {
                filldgv1();
                filldgv3();
                filldgv4();
                filldata();
            }
            else
            {
                filldgv6();
                filldgv3();
                filldgv4();
                filldata();
                label4.Text = "LD_MAX_MAPالخوارزميــة";
                pictureBox2.Image = Image.FromFile(@"C:\Users\dell\Desktop\1212\LD_MAX_MAP.png");
                dataGridView2.Columns[2].HeaderText = "الخوارزميةLD_MAX_MAP";
                label3.Text = "تعد إحدى خوارزميات المطابقة\nالتي تستخدم للمطابقة بين السلسلتين وهي إحدى  الخوارزميات \nالتي قمنا بتطويرها نحن فريق العمل إعتماداً على \n القيمة الأكبر لمستويات التشابه الثلاثة   \nبواسطة إستخدام قانون منهاتن.";
            }
        }

        private void le_im_5_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
