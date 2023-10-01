using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockPaperScissors {
    public partial class Form1 : Form {
        Random rnd = new Random();
        int computerTurn;
        string btnClicked = "";
        int playerScore = 0, computerScore = 0;
        string pWin = "";
        int maxScore = 5;
        public Form1() {
            InitializeComponent();
        }
        private int generateComputerTurn() {
            computerTurn = rnd.Next(0, 3);
            return computerTurn;
        }

        private void changeQuestionImg(int computerTurn) {
            switch (computerTurn) {
                case 0: {
                    this.pBoxQuestion.Image = Image.FromFile("C:\\Users\\kenth\\source\\repos\\RockPaperScissors\\images\\option--1.png");
                    break;
                }
                case 1: {
                    this.pBoxQuestion.Image = Image.FromFile("C:\\Users\\kenth\\source\\repos\\RockPaperScissors\\images\\option--2.png");
                    break;
                }
                case 2: {
                    this.pBoxQuestion.Image = Image.FromFile("C:\\Users\\kenth\\source\\repos\\RockPaperScissors\\images\\option--3.png");
                    break;
                }
                default:
                break;
            }
        }

        private string playerWin() {
            if ((btnClicked.Equals("btnRock") && computerTurn == 2) || (btnClicked.Equals("btnPaper") && computerTurn == 0) || (btnClicked.Equals("btnScissors") && computerTurn == 1)) {
                pWin = "p1Win";
            } else if ((btnClicked.Equals("btnRock") && computerTurn == 1) || (btnClicked.Equals("btnPaper") && computerTurn == 2) || (btnClicked.Equals("btnScissors") && computerTurn == 0)) {
                pWin = "p2Win";
            } else {
                pWin = "draw";
            }
            return pWin;
        }




        private void checkWinner(string pWin) {
            if (pWin.Equals("p1Win")) {
                playerScore++;
                this.lblPlayerScoreValue.Text = playerScore.ToString();
            }
            if (pWin.Equals("p2Win")) {
                computerScore++;
                this.lblComputerScoreValue.Text = computerScore.ToString();
            }
            checkEndGame();
        }

        private void resetAll() {
            this.pBoxQuestion.Image = Image.FromFile("C:\\Users\\kenth\\source\\repos\\RockPaperScissors\\images\\question2.png");
            playerScore = 0;
            this.lblPlayerScoreValue.Text = playerScore.ToString();
            computerScore = 0;
            this.lblComputerScoreValue.Text = computerScore.ToString();
        }

        private void checkEndGame() {
            if (playerScore == maxScore)
            {
                MessageBox.Show("PLAYER WINS!");
                resetAll();
            }
            if (computerScore == maxScore)
            {
                MessageBox.Show("COMPUTER WINS!");
                resetAll();
            }
        }
        private void process() {
            changeQuestionImg(generateComputerTurn());
            checkWinner(playerWin());
        }


        private void btnRock_Click(object sender, EventArgs e) {
            btnClicked = "btnRock";
            process();
        }

        private void btnPaper_Click(object sender, EventArgs e) {
            btnClicked = "btnPaper";
            process();
        }
        private void btnScissors_Click(object sender, EventArgs e) {
            btnClicked = "btnScissors";
            process();
        }

        private void btnReset_Click(object sender, EventArgs e) {
           resetAll();
        }
    }
}
