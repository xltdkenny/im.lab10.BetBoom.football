using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10.BetBoom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double RussiaLambda = 2.3;
        const double PortugalLambda = 2.1;
        const double BritainLambda = 1.9;
        const double GermanyLambda = 2.1;
        const double CroatiaLambda = 2;
        const double SwedenLambda = 2;
        const double SpanishLambda = 1.8;
        const double FranceLambda = 1.7;
        public int GetScore(double lambda) //Пуассон
        {
            Random random = new Random();
            double S = 0;
            int score = 0;
            while (S >= -lambda)
            {
                S += Math.Log(random.NextDouble());
                score++;
            }

            return score;
        }

        private double PlayMatch(double lambdaT1, double lambdaT2, PictureBox team1, PictureBox team2, PictureBox winner, Label text1, Label text2)
        {
            int t1Score = GetScore(lambdaT1);
            int t2Score = GetScore(lambdaT2);
            double winlambda = 0;
            while (t1Score == t2Score)
            {
                t1Score = GetScore(lambdaT1);
                t2Score = GetScore(lambdaT2);
            }
            text1.Text = t1Score.ToString();
            text2.Text = t2Score.ToString();
            if (t1Score > t2Score)
            {
                winner.Image = team1.Image;
                winlambda = lambdaT1;
            }
            else
            {
                winner.Image = team2.Image;
                winlambda = lambdaT2;
            }

            return winlambda;
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            double quarterfinals1 = PlayMatch(PortugalLambda, BritainLambda, t1Box, t2Box, pf1, label7, label8);
            double quarterfinals2 = PlayMatch(SwedenLambda, SpanishLambda, t3Box, t4Box, pf2, label9, label10);
            double quarterfinals3 = PlayMatch(GermanyLambda, RussiaLambda, t5Box, t6Box, pf3, label11, label12);
            double quarterfinals4 = PlayMatch(FranceLambda, CroatiaLambda, t7Box, t8Box, pf4, label13, label14);
            double semifinal1 = PlayMatch(quarterfinals1, quarterfinals2, pf1, pf2, final1, label15, label16);
            double semifinal2 = PlayMatch(quarterfinals3, quarterfinals4, pf3, pf4, final2, label17, label18);

            double final = PlayMatch(semifinal1, semifinal2, final1, final2, winnerBox, label19, label20);
        }
    }
}
