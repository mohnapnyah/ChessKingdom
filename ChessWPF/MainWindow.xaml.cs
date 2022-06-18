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
using System.IO;

namespace ChessWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class PieceMaker
        {       
            static public Piece Make(string pieceCode, int x, int y)
            {
                Piece piece = null;

                switch (pieceCode)
                {
                    case "King":
                    case "1":
                    case "K":
                        piece = new King(x, y);
                        break;

                    case "Queen":
                    case "2":
                    case "Q":
                        piece = new Queen(x, y);
                        break;

                    case "Bishop":
                    case "3":
                    case "B":
                        piece = new Bishop(x, y);
                        break;

                    case "Knight":
                    case "4":
                    case "N":
                        piece = new Knight(x, y);
                        break;

                    case "Rook":
                    case "5":
                    case "R":
                        piece = new Rook(x, y);
                        break;

                    case "Pawn":
                    case "6":
                    case "P":
                        piece = new Pawn(x, y);
                        break;

                    default: throw (new Exception("Unknown piece code."));
                }

                return piece;
            }

            static public Piece Make(int pieceCode, int x, int y)
            {
                return Make(pieceCode.ToString(), x, y);
            }
        }

        // -------------------------------------------------------
        // Piece classes 

        abstract class Piece
        {
            protected int x;
            protected int y;

            public Piece(int newX, int newY)
            {
                x = newX;
                y = newY;
            }
            public abstract bool TestMove(int newX, int newY);

            public bool Move(int newX, int newY)
            {
                if (TestMove(newX, newY))
                {
                    x = newX;
                    y = newY;
                    return true;
                }
                return false;
            }
        }

        class King : Piece
        {
            public King(int newX, int newY) : base(newX, newY)
            { }

            public override bool TestMove(int newX, int newY)
            {
                return (Math.Abs(x - newX) <= 1 && Math.Abs(y - newY) <= 1);
            }

        }

        class Queen : Piece
        {
            public Queen(int newX, int newY) : base(newX, newY)
            { }

            public override bool TestMove(int newX, int newY)
            {
                return (x == newX || y == newY || Math.Abs(x - newX) == Math.Abs(y - newY));
            }
        }

        class Bishop : Piece
        {
            public Bishop(int newX, int newY) : base(newX, newY)
            { }

            public override bool TestMove(int newX, int newY)
            {
                return (Math.Abs(x - newX) == Math.Abs(y - newY));
            }
        }

        class Knight : Piece
        {
            public Knight(int newX, int newY) : base(newX, newY)
            { }

            public override bool TestMove(int newX, int newY)
            {
                return ((Math.Abs(x - newX) == 2 && Math.Abs(y - newY) == 1) ||
                        (Math.Abs(x - newX) == 1 && Math.Abs(y - newY) == 2));
            }
        }

        class Rook : Piece
        {
            public Rook(int newX, int newY) : base(newX, newY)
            { }

            public override bool TestMove(int newX, int newY)
            {
                return (x == newX || y == newY);
            }

        }

        class Pawn : Piece
        {
            public Pawn(int newX, int newY) : base(newX, newY)
            { }

            public override bool TestMove(int newX, int newY)
            {
                return ((x == newX && y == 2 && y + 2 >= newY) ||
                        (x == newX && y + 1 == newY));
            }
            //
        }

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
            MessageBox.Show(choosenPiece);
        }

        private void Pawn_Click(object sender, RoutedEventArgs e)
        {
            choosenPiece = "Pawn";
        }

        private void Cell8_1_Click(object sender, RoutedEventArgs e)
        {
            if(choosenPiece != null)
            {
                Cell8_1.Content = choosenPiece;
                Piece piece = PieceMaker.Make(choosenPiece, Grid.GetRow(this), Grid.GetColumn(this));
            }    
        }
    }
}
