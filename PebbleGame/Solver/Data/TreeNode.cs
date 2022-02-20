using System.Collections;

namespace PGS.PebbleGame.Solver.Data
{
    internal class TreeNode
    {
        private readonly int _value;
        private readonly (int current, int max) _pebbleCount;
        private readonly TreeNode? _parent;
        private readonly bool[] _deadNodes = new bool[31];

        internal TreeNode(int value, ref BitArray availablePattern, TreeNode? parent = null, bool[]? deadNodes = null)
        {
            _value = value;
            _parent = parent;
            availablePattern[value] = false;
            
            if(parent != null)
            {
                _pebbleCount.current = parent._pebbleCount.current;
                _pebbleCount.current += _value > parent._value ? 1 : -1; 
                _pebbleCount.max = Math.Max(parent._pebbleCount.max, _pebbleCount.current);
            }

            deadNodes?.CopyTo(_deadNodes, 0);
        }

        public int MaxPebbleCount => _pebbleCount.max;

        internal (List<TreeNode> childrenThatDontNeedMorePebbles, List<TreeNode> childrenThatNeedOneMorePebble) GenerateChildren(BitGraph graph, byte targetNodePosition, ref BitArray availablePattern)
        {
            List<TreeNode> childrenThatDontNeedMorePebbles = new();
            List<TreeNode> childrenThatNeedOneMorePebble = new();


            // axiom: nodes that have no path without pebbles to the target are
            // dead nodes. There is no reason to set a pebble on such a node again
            for (byte currentPosition = 0; Settings.UseAxiomOptimization && currentPosition < graph.NodeCount; currentPosition++)
            {
                if (_deadNodes[currentPosition])
                    continue;

                var valueWithoutCurrentPosition = _value & ~(1 << currentPosition);
                if (graph.PathsToTarget(currentPosition).All(p => (p & valueWithoutCurrentPosition) > 0))
                    _deadNodes[currentPosition] = true;
            }

            // Generate Children
            for (byte i = 0; i < graph.NodeCount; i++)
            {
                var nodePatternPosition = 2.Pow(i);

                var nodeHasPebble = (_value & nodePatternPosition) > 0;

                if (nodeHasPebble)
                {
                    var newPattern = _value & ~nodePatternPosition;

                    // remove pebble
                    // axiom: remove only, if min 1 child (transitiv) is set
                    // Remove only, if the new pettern was never used before
                    if ((!Settings.UseAxiomOptimization || (graph.ChildrenOf(i) & newPattern) != 0) && availablePattern[newPattern])
                        childrenThatDontNeedMorePebbles.Add(new TreeNode(newPattern, ref availablePattern, this, _deadNodes));
                }
                else if (!nodeHasPebble && !_deadNodes[i])
                {
                    var newPattern = _value | nodePatternPosition;
                    var allParentsSet = (newPattern & graph[i]) == graph[i];

                    // Place only, if the new pettern was never used before
                    if (!allParentsSet || !availablePattern[newPattern])
                        continue;

                    // Place pebble
                    var newNode = new TreeNode(newPattern, ref availablePattern, this, _deadNodes);

                    if (newNode._pebbleCount.max > _pebbleCount.max)
                        childrenThatNeedOneMorePebble.Add(newNode);
                    else
                        childrenThatDontNeedMorePebbles.Add(newNode);
                }
            }

            return (childrenThatDontNeedMorePebbles, childrenThatNeedOneMorePebble);
        }

        internal PebbleStrategy GeneratePebbleStrategy()
        {
            if (_parent == null)
                return new PebbleStrategy();

            return _parent.GeneratePebbleStrategy() + new PebbleStrategy.Move(_value, _parent._value);
        }

        internal bool HasPebbleOnPostion(byte postion) => (_value & (1 << postion)) != 0;
    }
}
