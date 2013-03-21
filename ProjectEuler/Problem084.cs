using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    static class Problem084
    {
        private static Random _random = new Random((int)DateTime.Now.Ticks);

        private static string[] _board = new string[] 
        { 
            "GO", "A1", "CC1", "A2", "T1", "R1", "B1", "CH1", "B2", "B3", 
            "JAIL", "C1", "U1", "C2", "C3", "R2", "D1", "CC2", "D2", "D3", 
            "FP", "E1", "CH2", "E2", "E3", "R3", "F1", "F2", "U2", "F3", 
            "G2J", "G1", "G2", "CC3", "G3", "R4", "CH3", "H1", "T2", "H2" 
        };

        private static int consecutiveDoubles = 0;
        private static int[] _boardCount = new int[40];

        private static int lastChanceCard = -1;
        private static string[] _chanceCards = new string[] { "A#0", "A#10", "A#11", "A#24", "A#39", "A#5", "N#R", "N#R", "N#U", "R#-3", "R#0", "R#0", "R#0", "R#0", "R#0", "R#0" };

        private static int lastCommunityChestCard = -1;
        private static string[] _communityChestCards = new string[] { "A#0", "A#10", "R#0", "R#0", "R#0", "R#0", "R#0", "R#0", "R#0", "R#0", "R#0", "R#0", "R#0", "R#0", "R#0", "R#0" };

        public static string Solve()
        {
            var random = new Random();
            var lastPosition = 0;
            var newPosition = 0;
            int max = 5500000;

            for (int i = 0; i < max; i++)
            {
                var move = RollDice();
                if (consecutiveDoubles == 3)
                {
                    newPosition = 10;
                    consecutiveDoubles = 0;
                }
                else
                {
                    newPosition = (lastPosition + move) % _board.Length;
                }

                newPosition = EvaluatePosition(newPosition);

                _boardCount[newPosition]++;
                lastPosition = newPosition;
            }

            var top = _boardCount.Select((v, i) => new { Value = 100.0 * v / max, Index = i })
                                 .OrderByDescending(x => x.Value)
                                 .ToArray();

            return top.Take(3)
                      .Select(x => x.Index.ToString().PadLeft(2, '0'))
                      .Aggregate((a, b) => a + b);
        }

        private static int EvaluatePosition(int position)
        {
            if (_board[position].StartsWith("CH"))
            {
                var newPosition = TakeChanceCard(position);
                if (position != newPosition)
                    position = EvaluatePosition(newPosition);
            }

            if (_board[position].StartsWith("CC"))
            {
                var newPosition = TakeCommunityChestCard(position);
                if (position != newPosition)
                    position = EvaluatePosition(newPosition);
            }

            if (_board[position] == "G2J")
                position = 10;

            return position;
        }

        private static int TakeCommunityChestCard(int position)
        {
            return TakeCard(position, ref lastCommunityChestCard, _communityChestCards);
        }

        private static int TakeChanceCard(int position)
        {
            return TakeCard(position, ref lastChanceCard, _chanceCards);
        }

        private static int TakeCard(int position, ref int lastCard, string[] cards)
        {
            lastCard = (++lastCard % cards.Length);
            var moveType = cards[lastCard].Split('#')[0];
            var move = cards[lastCard].Split('#')[1];

            switch (moveType)
            {
                // Absolute position
                case "A":
                    return int.Parse(move);

                // Relative position
                case "R":
                    return (position + int.Parse(move)) % _board.Length;

                // Next position by pattern
                case "N":
                    while (true)
                    {
                        if (_board[++position % _board.Length].StartsWith(move))
                            return (position % _board.Length);
                    }

                default:
                    throw new ApplicationException();
            }
        }

        private static int RollDice()
        {
            var d1 = _random.Next(1, 6);
            var d2 = _random.Next(1, 6);

            if (d1 == d2)
                consecutiveDoubles++;
            else
                consecutiveDoubles = 0;

            return d1 + d2;
        }
    }
}
