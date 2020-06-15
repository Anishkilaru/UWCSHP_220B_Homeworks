using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool playerOneTurn;

        // 0 = free
        // 1 = X
        // 2 = O
        private int[] values;

        public MainWindow()
        {
            InitializeComponent();

            newGame();
        }

        private void newGame()
        {
            values = new int[9];

            uxGrid.Children.Cast<Button>().ToList().ForEach(x => x.Content = null);

            playerOneTurn = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Content != null)
                return;

            btn.Content = playerOneTurn ? "X" : "O";

            var col = Grid.GetColumn(btn);
            var row = Grid.GetRow(btn);

            var i = col + row * 3;

            values[i] = btn.Content.ToString() == "X" ? 1 : 2;

            playerOneTurn = !playerOneTurn;

            checkBoard();
        }

        private void checkBoard()
        {
            var result = values.Where(x => x == 0).ToList();

            if (result.Count == 0)
            {
                MessageBox.Show("Hahhah", "Game Ended");
            }

            for(int i=0;i<3;i++)
            {
                checkHorizontal(i);
            }

            for (int i = 0; i < 3; i++)
            {
                checkVertical(i);
            }

            if (values[0] != 0 && (values[0] & values[4] & values[8]) == values[0])
            {
                MessageBox.Show(!playerOneTurn ? "Player One Won" : "Player Two Won", "Game Ended");
                newGame();
            }

            if (values[2] != 0 && (values[2] & values[4] & values[6]) == values[2])
            {
                MessageBox.Show(!playerOneTurn ? "Player One Won" : "Player Two Won", "Game Ended");
                newGame();

            }
        }

        private void checkHorizontal(int row)
        {
            var col = row * 3;
            if (values[col] != 0 && (values[col] & values[col + 1] & values[col + 2]) == values[col])
            {
                MessageBox.Show(!playerOneTurn ? "Player One Won" : "Player Two Won", "Game Ended");
                newGame();

            }
        }

        private void checkVertical(int col)
        {
            if (values[col] != 0 && (values[col] & values[col + 3] & values[col + 6]) == values[col])
            {
                MessageBox.Show(!playerOneTurn ? "Player One Won" : "Player Two Won", "Game Ended");
                newGame();
            }
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            newGame();
        }
    }
}
