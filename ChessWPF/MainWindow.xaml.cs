using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessWPF
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
        String choosenPiece = "";

        private void KingButton_Click(object sender, RoutedEventArgs e)
        {
            choosenPiece = "King";
        }

        private void QueenButton_Click(object sender, RoutedEventArgs e)
        {
            choosenPiece = "Queen";
        }

        private void BishopButton_Click(object sender, RoutedEventArgs e)
        {
            choosenPiece = "Bishop";
        }

        private void KnightButton_Click(object sender, RoutedEventArgs e)
        {
            choosenPiece = "Knight";
        }

        private void Rook_Click(object sender, RoutedEventArgs e)
        {
            choosenPiece = "Rook";
        }

        private void Pawn_Click(object sender, RoutedEventArgs e)
        {
            choosenPiece = "Pawn";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (choosenPiece != null)
            {
                Cell8_1.Content = choosenPiece;
                piece = new Make;
            }
        }
    }
}
