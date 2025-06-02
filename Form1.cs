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

        private void changeQuestionImg(int computerTurn)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                switch (computerTurn)
                {
                    case 0:
                        ms.Write(Properties.Resources.option__1, 0, Properties.Resources.option__1.Length);
                        this.pBoxQuestion.Image = Image.FromStream(ms);
                        break;
                    case 1:
                        ms.Write(Properties.Resources.option__2, 0, Properties.Resources.option__2.Length);
                        this.pBoxQuestion.Image = Image.FromStream(ms);
                        break;
                    case 2:
                        ms.Write(Properties.Resources.option__3, 0, Properties.Resources.option__3.Length);
                        this.pBoxQuestion.Image = Image.FromStream(ms);
                        break;
                }
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

        private void resetAll()
        {
            using (var ms = new System.IO.MemoryStream())
            {
                ms.Write(Properties.Resources.question2, 0, Properties.Resources.question2.Length);
                this.pBoxQuestion.Image = Image.FromStream(ms);
            }
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
