using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

/// <summary>
/// A rock, paper, scissors game that utilizes basic methods
/// for repetitive tasks.
/// </summary>

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, cpuChoice;

        int choice;
        int wins = 0;
        int losses = 0;
        int ties = 0;

        Random randGen = new Random();
        int randValue;

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        Image rockImage = Properties.Resources.rock168x280;
        Image paperImage = Properties.Resources.paper168x280;
        Image scissorImage = Properties.Resources.scissors168x280;
        Image winImage = Properties.Resources.winTrans;
        Image loseImage = Properties.Resources.loseTrans;
        Image tieImage = Properties.Resources.tieTrans;
        public Form1()
        {
            InitializeComponent();
        }
        private void rockButton_Click(object sender, EventArgs e)
        {
            playerChoice = "rock";
            playerImage.Image = rockImage;
            randValue = randGen.Next(1, 4);
            GetComputerChoice();
            choiceInter();
            determine();
            resetInter();
        }
        private void paperButton_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            playerImage.Image = paperImage;
            randValue = randGen.Next(1, 4);
            GetComputerChoice();
            choiceInter();
            determine();
            resetInter();
        }
        private void scissorsButton_Click(object sender, EventArgs e)
        {
            playerChoice = "scissor";
            playerImage.Image = scissorImage;
            randValue = randGen.Next(1, 4);
            GetComputerChoice();
            choiceInter();
            determine();
            resetInter();
        }
        public void GetComputerChoice()
        {
            switch (randValue)
            {
                case 1:
                    cpuChoice = "rock";
                    cpuImage.Image = rockImage;
                    break;
                case 2:
                    cpuChoice = "paper";
                    cpuImage.Image = paperImage;
                    break;
                case 3:
                    cpuChoice = "scissor";
                    cpuImage.Image = scissorImage;
                    break;
            }
        }
        public void choiceInter()
        {
            jabPlayer.Play();
            Refresh();
            Thread.Sleep(1000);
            gongPlayer.Play();
        }
        public void resetInter()
        {
            Refresh();
            Thread.Sleep(2000);
            playerImage.Image = null;
            cpuImage.Image = null;
            resultImage.Image = null;
        }
        public void determine()
        {
            if (playerChoice == "rock" && cpuChoice == "scissor" || playerChoice == "paper" && cpuChoice == "rock" || playerChoice == "scissor" && cpuChoice == "paper")
            {
                resultImage.Image = winImage;
                wins++;
                winsLabel.Text = $"Wins: {wins}";
            }
            else if (playerChoice == "scissor" && cpuChoice == "rock" || playerChoice == "rock" && cpuChoice == "paper" || playerChoice == "paper" && cpuChoice == "scissor")
            {
                resultImage.Image = loseImage;
                losses++;
                lossesLabel.Text = $"Losses {losses}";
            }
            else
            {
                resultImage.Image = tieImage;
                ties++;
                tiesLabel.Text = $"Ties: {ties}";
            }
        }
    }
}