using System.ComponentModel;
using System.Xml.Serialization;
using PGS.Data;

namespace PGS.IO
{
    [XmlRoot("graph", IsNullable = false)]
    public class GraphWrapper
    {
        [XmlElement("node")]
        public List<NodeWrapper> Nodes { get; set; } = new List<NodeWrapper>();

        [XmlElement("edge")]
        public List<EdgeWrapper> Edges { get; set; } = new List<EdgeWrapper>();


        public static explicit operator Graph<PebbledNode>(GraphWrapper wrapper)
        {
            var graph = new Graph<PebbledNode>();

            var nodePositions = new Dictionary<int, Point>();

            wrapper.Nodes.ForEach(n =>
            {
                var nodePos = new Point(n.PositionX, n.PositionY);
                graph.AddNodeAt(nodePos);
                graph.RenameNodeAt(nodePos, n.IdentifierChar);
                nodePositions[n.Id] = nodePos;
            });

            wrapper.Edges.OrderByDescending(e => e.TargetNode).ToList().ForEach(e =>
            {
                graph.AddEdgeAt(nodePositions[e.StartNode]);
                if (graph.CurrentEdge != null && nodePositions.ContainsKey(e.TargetNode))
                    graph.CurrentEdge.TargetNode = graph.GetNearestNode(nodePositions[e.TargetNode])?.Node;
            });

            return graph;
        }

        public static explicit operator GraphWrapper(Graph<PebbledNode> graph)
        {
            var wrapper = new GraphWrapper();

            var nodesField = typeof(Graph<PebbledNode>).GetField("_nodes", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetField);
            if (nodesField?.GetValue(graph) is not List<PebbledNode> nodes)
                throw new Exception("The nodes of the graph cannot be accessed via reflection.");
            
            var edgesField = typeof(Node).GetField("_outEdges", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetField);

            foreach (var node in nodes)
            {
                wrapper.Nodes.Add(new NodeWrapper() { Id = node.GetHashCode(), IdentifierChar = node.Identifier, PositionX = node.Position?.X ?? 0, PositionY = node.Position?.Y ?? 0});

                if (edgesField?.GetValue(node) is not HashSet<Edge> edges)
                    throw new Exception("The edges of the graph cannot be accessed via reflection.");
                
                wrapper.Edges.AddRange(edges.Select(e => new EdgeWrapper() { StartNode = e.StartNode.GetHashCode(), TargetNode = e.TargetNode?.GetHashCode() ?? 0 }));
            }

            return wrapper;
        }
    }

    public class NodeWrapper
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("positionX")]
        public int PositionX { get; set; }

        [XmlAttribute("positionY")]
        public int PositionY { get; set; }

        [XmlIgnore]
        public char IdentifierChar { get; set; }

        [XmlAttribute("identifier"), Browsable(false)]
        public string Identifier
        {
            get => $"{IdentifierChar}";
            set => IdentifierChar = value?.FirstChar() ?? 'A';
        }
    }

    public class EdgeWrapper
    {
        [XmlAttribute("start")]
        public int StartNode { get; set; }

        [XmlAttribute("target")]
        public int TargetNode { get; set; }
    }
}
