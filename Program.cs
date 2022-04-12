using System.Diagnostics;

namespace Exercize
{
    class Program
    {
      static SimpleBST BST_One = new SimpleBST();
      static SimpleBST BST_Two = new SimpleBST();
      static int Count = 1000000;
      static int LesserCount = Count / 10;
      static int[] RandomArray = new int[Count];
      static int[] SortedArray = new int[Count];
      static void Main(string[] args)
      {
        bool Result = false;
        PrepareRandomArray();
        PrepareSortedArray();

        Console.WriteLine($"Insertion of {Count} items");
        PopulateTreeOne();
        Result = CheckTree(BST_One);
        if(!Result) return;

        Console.Write($"Search for {LesserCount} first elements ");
        Result = CheckSearch();
        if(!Result) return;

        Console.Write($"Search for {LesserCount} nonexistent elements ");
        Result = CheckSearchWacky();
        if(!Result) return;

        Console.Write($"Removal of {LesserCount} elements ");
        Result = CheckRemove();
        if(!Result) return;
      }

      static void PrepareRandomArray()
      {
        Random R = new Random();
        for(int X=0; X<Count; X++)
        {
          int Num = R.Next(Count * 10);
          RandomArray[X] = Num;
        }
      }

     static void PrepareSortedArray()
      {
        for(int X=0; X<Count; X++)
        {
          SortedArray[X] = X;
        }
      }

      static void PopulateTreeOne()
      {
        for(int X=0; X<Count; X++)
        {
          BST_One.Insert(RandomArray[X]);
        }
      }

      static void PopulateTreeTwo()
      {
        for(int X=0; X<Count; X++)
        {
          BST_Two.Insert(SortedArray[X]);
        }
      }

      static bool CheckTree(IBST bst)
      {
          Console.Write(@"Check() ");
          bool Result = bst.Check();
          if(Result)
          {
            Console.WriteLine(@"passed");
          }
          else
          {
            Console.WriteLine(@"FAILED!");
          }
          return Result;
      }

      static bool CheckSearch()
      {
        for(int X=0; X<LesserCount; X++)
        {
          bool Result = BST_One.Find(RandomArray[X]);
          if(Result == false)
          {
            Console.WriteLine(@"FAILED!!!");
            return false;
          }
        }
        Console.WriteLine(@"done.");
        return true;
      }
    

      static bool CheckSearchWacky()
      {
        Random R = new Random();
        for(int X=0; X<LesserCount; X++)
        {
          int NumberToSearch = R.Next(LesserCount) + Count * 10;
          bool Result = BST_One.Find(NumberToSearch);
          if(Result == true)
          {
            Console.WriteLine(@"FAILED!!!");
            return false;
          }
        }
        Console.WriteLine(@"done.");
        return true;
      }

      static bool CheckRemove()
      {
        for(int X=0; X<LesserCount; X++)
        {
          bool Result = BST_One.Remove(RandomArray[X]);
          if(Result == false)
          {
            Console.WriteLine(@"FAILED!!!");
            return false;
          }
        }
        Console.WriteLine(@"done.");
        return true;
      }
    }
}