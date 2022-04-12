using System.Diagnostics;

namespace Exercize
{
    class Program
    {
      static SimpleBST BST = new SimpleBST();
      static int Count = 100000;
      static int[] Array = new int[Count];
      static void Main(string[] args)
      {
        PrepareArray();

        Console.WriteLine($"Insertion of {Count} items");
        PopulateTree();
        BST.Check();
      }

      static void PrepareArray()
      {
        Random R = new Random();
        for(int X=0; X<Count; X++)
        {
          int Num = R.Next(Count * 10);
          Array[X] = Num;
        }
      }

      static void PopulateTree()
      {
        for(int X=0; X<Count; X++)
        {
          BST.Insert(Array[X]);
        }
      }
    }
}