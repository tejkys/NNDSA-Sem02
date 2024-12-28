using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNDSA_Sem02
{
    public class Persistence
    {
        public static void Save(string filename, Dictionary<string, Product> products)
        {
            var sb = new StringBuilder();
            foreach (var node in products)
            {
                sb.AppendLine(node.Key + ";" + node.Value.ProductNumber);
            }
            System.IO.File.WriteAllText(filename, sb.ToString());
        }
        public static Dictionary<string, Product> Load(string filename)
        {
            Dictionary<string, Product> result = new ();
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                result.Add(parts[0], new Product() { ProductNumber = parts[1] });
            }
            return result;
        }
    }
}
