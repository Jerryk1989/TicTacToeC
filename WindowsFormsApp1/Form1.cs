using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static string PlayersTurn;
        public static int count = 0;
        //Creating an array of buttons that will populate the application game area
        public static Button[] buttonArray = new Button[9];
        public static StringBuilder check = new StringBuilder();

        public Form1()
        {
            InitializeComponent();
            CreateButtons();
            StartGame();

        }

        private void CreateButtons()
        {
            

            //This is the starting postion (top-left corner) of the first box.
            int vertical = 66;
            int horizontal = 16;

            for (int x = 0; x < buttonArray.Length; x++)
            {
                //we are going through the array of buttons here and creating all of the buttons.
                //This creates the first button before getting to the others.
                buttonArray[x] = new Button();
                buttonArray[x].Size = new Size(93, 72);
                buttonArray[x].Location = new Point(horizontal, vertical);
                buttonArray[x].Font = new Font("Microsoft Sans Serif", 15F);
                buttonArray[x].Name = "button"+(x + 1);

                //This creates the buttons click functionality.  It calls the method buttonClicked
                //which controls what the button actually does.
                buttonArray[x].Click += new EventHandler(buttonClicked);   

                //This adds the button to the screen.
                this.Controls.Add(buttonArray[x]);

                //This tells moves the boxes horizontally or vertically to make sure the
                //buttons show up on the screen in a 3x3 pattern
                //The horizontal is reset when the vertical is changed to realign the boxes.
                if(x+1 == 3 || x+1 == 6)
                {
                    horizontal = 16;
                    vertical += 78;
                }
                else
                {
                    horizontal += 99;
                }
            }
        }

        void buttonClicked(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (PlayersTurn == "X" && b.Text == "")
            {
                b.Text = "X";
                StartGame();
            } else if (b.Text == "")
            {
                b.Text = "O";
                StartGame();
            } else
            {
                label2.Text = "Invalid selection.";
            }
            
        }

        private void StartGame()
        {
            PlayersTurn = TurnCounter();
            //checkWinCondition();

            if (PlayersTurn == "Game Over.")
            {
                label2.Text = PlayersTurn;

                return;
            }
            else
            {
                label2.Text = PlayersTurn;
            }
        }

        //private string checkWinCondition()
        //{
        //    //THIS IS WHERE YOU LEFT OFF.
        //    if(buttonArray[0].Text == "X")

        //    return "win";
        //}

        private string TurnCounter()
        {


            //This is an empty variable set in the if statement.  It is passed
            //back to the PlayertTurn method.
            string PlayersTurn;

            int count = Counter();

            //With this method X is odd turns O is even.
            if (count % 2 == 0 && count <= 9)
            {
                PlayersTurn = "O";
                return PlayersTurn;
            }
            else if (count % 2 != 0 && count <= 9)
            {
                PlayersTurn = "X";
                return PlayersTurn;
            }
            else
            {
                return "Game Over.";
            }


        }

        //This is a simple counting method used for the players turn switching
        //it also keeps track of when the game is over due to a full board.
        private int Counter()
        {
            count = count + 1;
            return count;
        }




    }
}
