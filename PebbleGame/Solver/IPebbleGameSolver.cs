namespace PGS.PebbleGame.Solver
{
    internal interface IPebbleGameSolver
    {
        Data.PebbleStrategy Solve(Data.BitGraph graph, byte targetNodePosition);
    }
}
