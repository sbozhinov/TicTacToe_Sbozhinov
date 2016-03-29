//Author: Stan Bozhinov
// Assignment 4, Drawing (Tic Tac Toe)
//finding elements http://msdn.microsoft.com/en-us/library/bb979952%28v=vs.95%29.aspx
//positioning shapes http://stackoverflow.com/questions/5589256/how-to-specify-the-position-of-an-ellipse-shape-on-a-canvas-in-wpf
//array exists http://www.dotnetperls.com/array-exists
//window location to get previous form's window loc http://social.msdn.microsoft.com/Forums/en/wpf/thread/510c391c-09d4-4b3f-90e1-fb3abfed6365
//http://stackoverflow.com/questions/1111998/how-to-get-a-column-from-a-2d-java-array
//http://stackoverflow.com/questions/5775574/flip-a-coin-problem
//hardest part for me was the X pattern in 2d array.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe_Sbozhinov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string[,] gameArray = new string[,]
	{
	    {"", "", ""},
	    {"", "", ""},
	    {"", "", ""}
	};


        bool canStart = false;
        bool gameOver = false;
        bool playerOne;
        int playerTurn = 0;
        



        void GameTurn(int row, int col)
        {
          
           
            

            if (gameArray[row, col] == "" && !gameOver && canStart)
            {
                playerTurn++;

                if ((playerTurn % 2) == 0)
                    playerOne = true;
                else
                {
                    playerOne = false;
                }

                //player one clicked
                if (playerOne)
                {
                    gameArray[row, col] = "X";
                    DrawX(row, col);
                    lblTurn.Content = "Current Turn: Player Two  (O)) ";
                    didAnyoneWin();
                }
                    //player two clicked
                if(!playerOne)
                {
                    gameArray[row, col] = "O";
                    DrawCircle(row, col);
                    lblTurn.Content = "Current Turn: Player One (X) ";
                    didAnyoneWin();
                }

                string[] gameArrFlat;
                gameArrFlat = gameArray.Cast<string>().ToArray();
                if (!Array.Exists(gameArrFlat, element => element == ""))
                {
                    gameOver = true;
                    lblTurn.Content = "It's a Draw!";
                }
                
               
            }


        }//End GameTurn() method

        void didAnyoneWin()
        {
            string s1 = null;

            //horizontal rows
            for (int i = 0; i <= 2; i++)
            {
                for (int x = 0; x <= 2; x++)
                {
                     s1 += gameArray[i, x];
                     if (s1 == "XXX")
                     {
                         lblTurn.Content = "Player 1 won!";
                         gameOver = true;
                     }
                     if (s1 == "OOO")
                     {
                         lblTurn.Content = "Player 2 won!";
                         gameOver = true;
                     }
                    
                }
                s1 = null;
 
            }

            s1 = null;

            //vertical columns
            for (int y = 0; y < 3; y++)
            {
                for (int col = 0; col < 3; col++)
                {
                    s1 += gameArray[col, y];

                }
                if (s1 == "XXX")
                {
                    lblTurn.Content = "Player 1 won!";
                    gameOver = true;
                }
                if (s1 == "OOO")
                {
                    lblTurn.Content = "Player 2 won!";
                    gameOver = true;
                }

                s1 = null;
            }
            


            //  " \ " pattern

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col <3; col++)
                {
                            if(col == row) {
                                s1 += gameArray[row, col];
	                }
                }
                if (s1 == "XXX")
                {
                    lblTurn.Content = "Player 1 won!";
                    gameOver = true;
                }
                if (s1 == "OOO")
                {
                    lblTurn.Content = "Player 2 won!";
                    gameOver = true;
                }
                            
            }
            s1 = null;

            //       " / " pattern
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col <3; col++)
                {
                    if (col == 2-row)
                    {
                        s1 += gameArray[row, col];
                    }
                }
                if (s1 == "XXX")
                {
                    lblTurn.Content = "Player 1 won!";
                    gameOver = true;
                }
                if (s1 == "OOO")
                {
                    lblTurn.Content = "Player 2 won!";
                    gameOver = true;
                }

            }
            s1 = null;


        }//end didAnyoneWin


        void DrawX(int row, int col)
        {
            var myCanvas = (Canvas)this.FindName("canvas" + row + col);

            Line myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.Green;
            myLine.X1 = 35;
            myLine.X2 = 95;
            myLine.Y1 = 20;
            myLine.Y2 = 80;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;

            Line myLine2 = new Line();
            myLine2.Stroke = System.Windows.Media.Brushes.Green;
            myLine2.X1 = 95;
            myLine2.X2 = 35;
            myLine2.Y1 = 20;
            myLine2.Y2 = 80;
            myLine2.HorizontalAlignment = HorizontalAlignment.Left;
            myLine2.VerticalAlignment = VerticalAlignment.Center;
            myLine2.StrokeThickness = 2;

            myCanvas.Children.Add(myLine);
            myCanvas.Children.Add(myLine2);

        }//End DrawX

        void DrawCircle(int row, int col)
        {
            var myCanvas = (Canvas)this.FindName("canvas" + row + col);
            Ellipse myEllipse = new Ellipse();
            myEllipse.StrokeThickness = 2;
            myEllipse.Stroke = Brushes.Red;

            // Set the width and height of the Ellipse.
            myEllipse.Width = 70;
            myEllipse.Height = 70;

            myEllipse.SetValue(Canvas.LeftProperty, 30.0);
            myEllipse.SetValue(Canvas.TopProperty, 10.0);
            // Add the Ellipse to the StackPanel.
            myCanvas.Children.Add(myEllipse);

        }// end DrawCircle


        private void r00_MouseDown(object sender, MouseButtonEventArgs e)
        {
           GameTurn(0,0);
        }

        private void r01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GameTurn(0, 1);
        }

        private void r02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GameTurn(0, 2);
        }

        private void r10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GameTurn(1, 0);
        }

        private void r11_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GameTurn(1, 1);
        }

        private void r12_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GameTurn(1, 2);
        }

        private void r20_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GameTurn(2, 0);
        }

        private void r21_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GameTurn(2, 1);
        }

        private void r22_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GameTurn(2, 2);
        }

        private void btnToss_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
           int random2 = random.Next(2);

            if (random2 == 0)
            {
                playerTurn++;
                playerOne = true;
                lblTurn.Content = "Current Turn: Player One (X) ";
            }
            else if (random2 == 1)
            {
                
                playerOne = false;
                lblTurn.Content = "Current Turn:Player Two  (O)) ";
            }
            btnToss.IsEnabled = false;

            canStart = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newGameForm = new MainWindow();
            newGameForm.Left = this.Left;
            newGameForm.Top = this.Top;
            newGameForm.Show();
            this.Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Stan Bozhinov \n Version 0.1 \n .NET 4.0 Win 32\n Developed in VS C# Express 2010 \n March 8, 2013", "About");
        }

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("To win, get 3 of your letters in a row either horizontally, vertically or diagonally. ", "About");
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void mnuReset_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newGameForm = new MainWindow();
            newGameForm.Left = this.Left;
            newGameForm.Top = this.Top;
            newGameForm.Show();
            this.Close();
        }


    }
}
