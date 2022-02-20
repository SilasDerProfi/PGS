using System.Collections;

namespace PGS.PebbleGame.Solver.Data
{
    public class PebbleStrategy : IEnumerable<PebbleStrategy.Move>
    {
        private readonly Move[] _moves;
        public PebbleStrategy() => _moves = Array.Empty<Move>();

        private PebbleStrategy(PebbleStrategy previousMoves, Move newMove)
        {
            _moves = new Move[previousMoves._moves.Length + 1];
            previousMoves._moves.CopyTo(_moves, 0);
            _moves[_moves.Length - 1] = newMove;
            MaxPebbles = Math.Max(previousMoves.MaxPebbles, newMove.PebblesInUse);
        }

        public byte MaxPebbles { get; private set; }

        public IEnumerator<Move> GetEnumerator() => _moves.Cast<Move>().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static PebbleStrategy operator +(PebbleStrategy previousMoves, Move newMove) => new PebbleStrategy(previousMoves, newMove);

        public class Move
        {
            public Move(int pebblePattern, int parentPebblePattern)
            {
                var difference = pebblePattern ^ parentPebblePattern;

                Operation = (pebblePattern | difference) == pebblePattern ? Action.Place : Action.Remove;
                AffectedPosition = difference.PositionOfRightmostSetBit();
                PebblesInUse = (byte)pebblePattern.CountOnes();
            }

            public byte PebblesInUse { get; private set; }

            public enum Action { Place, Remove }

            public int AffectedPosition { get; }
            public Action Operation { get; }
        }

    }
}
