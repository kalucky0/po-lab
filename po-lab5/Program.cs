using System;
using System.Collections;
using System.Collections.Generic;

namespace po_lab5
{
    /*class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team()
            {
                Leader = "Kowalski",
                ViceLeader = "Nowak",
                Admin = "Karolak",
                Developer = "Stasiak",
            };

            foreach (string member in team)
            {
                Console.WriteLine(member);
            }

            Board board = new Board();
            board[1, 1] = 'O';
            // foreach (char cell in board)
            // {
                // Console.WriteLine(cell);
            // }
            board.Print();
        }
    }*/

    public class Board : IEnumerable<char>
    {
        private char[,] _board = {
            { '-', 'X', '-' },
            { 'O', 'X', '-' },
            { '-', 'X', '-' },
        };

        public char this[int x, int y]
        {
            get
            {
                if(x < 1 || y < 1 || x > _board.GetLength(0) + 1 || y > _board.GetLength(1) + 1)
                    throw new IndexOutOfRangeException();

                return _board[y - 1, x - 1];
            }
            set
            {
                if (x < 1 || y < 1 || x > _board.GetLength(0) + 1 || y > _board.GetLength(1) + 1)
                    throw new IndexOutOfRangeException();

                _board[y - 1, x - 1] = value;
            }
        }

        public void Print() {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    Console.Write(_board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (int j = 0; j < _board.GetLength(1); j++)
                for (int i = 0; i < _board.GetLength(0); i++)
                    yield return _board[i, j];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Team : IEnumerable<string>
    {
        public string Leader { get; init; }
        public string ViceLeader { get; init; }
        public string Admin { get; init; }
        public string Developer { get; init; }


        public IEnumerator<string> GetEnumerator()
        {
            // return new TeamEnumerator(this);
            yield return Leader;
            yield return ViceLeader;
            yield return Admin;
            yield return Developer;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class TeamEnumerator : IEnumerator<string>
    {
        private Team _team;
        private int _counter;

        public string Current
        {
            get
            {
                switch (_counter)
                {
                    case 0:
                        return _team.Leader;
                    case 1:
                        return _team.ViceLeader;
                    case 2:
                        return _team.Admin;
                    case 3:
                        return _team.Developer;
                    default:
                        return null;
                }
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            return _counter++ < 4;
        }

        public void Reset()
        {
            _counter = 0;
        }
    }
}
