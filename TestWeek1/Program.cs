using TestWeek1.Models;
using TestWeek1.Service;
namespace TestWeek1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BSTree tree = new BSTree();

            List<DefenceModel> defenceModels = JsonFunctions.ReadFromJson<List<DefenceModel>>("../../../defenceStrategiesBalanced.json")!;
            List<Threat> threads = JsonFunctions.ReadFromJson<List<Threat>>("../../../threats.json")!;

            foreach (DefenceModel def in defenceModels)
            {
                tree.Insert(def);
                tree.PrintTree();
                Thread.Sleep(1);
            }

            foreach (Threat thread in threads)
            {
                Console.WriteLine(tree.Search(thread));
                Thread.Sleep(1);
            }
        }
    }
}
