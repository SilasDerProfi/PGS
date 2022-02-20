using System.Xml.Serialization;
using PGS.Data;

namespace PGS.IO
{
    internal class GraphIOManager
    {
        internal static void Save(string fileName, Graph<PebbledNode> graph)
        {
            XmlSerializer serializer = new(typeof(GraphWrapper));
            XmlSerializerNamespaces ns = new();
            ns.Add("", "");

            using StreamWriter file = new(fileName);
            serializer.Serialize(file, (GraphWrapper)graph, ns);
        }

        internal static Graph<PebbledNode> Load(string fileName)
        {
            using StreamReader file = new(fileName);
            var result  = new XmlSerializer(typeof(GraphWrapper)).Deserialize(file);

            if (result is not GraphWrapper wrapper)
                throw new ArgumentException("Invalid Graph-File");

            return (Graph<PebbledNode>)wrapper;
        }

        internal static Graph<PebbledNode> Load(int predefinedRessourceNumber)
        {
            MemoryStream file = new(
                predefinedRessourceNumber switch
                {
                    1 => Properties.Resources.example1,
                    2 => Properties.Resources.example2,
                    3 => Properties.Resources.example3,
                    4 => Properties.Resources.example4,
                    5 => Properties.Resources.example5,
                    _ => Properties.Resources.example1
                });

            var result = new XmlSerializer(typeof(GraphWrapper)).Deserialize(file);

            if (result is not GraphWrapper wrapper)
                throw new ArgumentException("Invalid Graph-File");

            return (Graph<PebbledNode>)wrapper;
        }
    }
}
