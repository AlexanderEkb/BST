using System.Diagnostics;

namespace Exercize
{
    class Program
    {
      static SimpleBST BST_One = new SimpleBST();
      static SimpleBST BST_Two = new SimpleBST();
      static int Count = 200000;
      static int LesserCount = Count / 10;
      static int[] RandomArray = new int[Count];
      static int[] SortedArray = new int[Count];
      static int[,] BenchmarkResults = new int[3, 2];
      static void Main(string[] args)
      {
        bool Result = false;
        PrepareRandomArray();
        PrepareSortedArray();

        Console.WriteLine(@"CHAPTER I. Tests.");
        Console.WriteLine(@"=================");
        Console.WriteLine($"Insertion of {Count} items");
        PopulateTreeOne();
        Result = CheckTree(BST_One);
        if(!Result) return;

        Console.Write($"Search for {LesserCount} first elements ");
        Result = CheckSearch(BST_One, RandomArray);
        if(!Result) return;

        Console.Write($"Search for {LesserCount} nonexistent elements ");
        Result = CheckSearchWacky();
        if(!Result) return;

        Console.Write($"Removal of {LesserCount} elements ");
        Result = CheckRemove(BST_One, RandomArray);
        if(!Result) return;

        Console.WriteLine("\nCHAPTER II. Benchmarks.");
        Console.WriteLine("=================");
        Console.WriteLine("Evaluating performance. There are two BSTs,");
        Console.WriteLine("first of them (I) is populated by some random numbers,");
        Console.WriteLine("the second one (II) is consequently filled by pre-sorted");
        Console.WriteLine("values.\n\n");

        BST_One.Clean();
        BST_Two.Clean();

        Console.WriteLine($"Insertion of {Count} items");
        BenchmarkResults[0, 0] = PopulateOne();
        BenchmarkResults[0, 1] = PopulateTwo();
        Console.WriteLine($"Search for {LesserCount} first elements ");
        BenchmarkResults[1, 0] = SearchBenchmark(BST_One, RandomArray);
        BenchmarkResults[1, 1] = SearchBenchmark(BST_Two, SortedArray);
        Console.WriteLine($"Removal of {LesserCount} elements ");
        BenchmarkResults[2, 0] = RemovalBenchmark(BST_One, RandomArray);
        BenchmarkResults[2, 1] = RemovalBenchmark(BST_Two, SortedArray);
        Console.WriteLine( "          |\tI\t|\tII    ");
        Console.WriteLine( "--------------------------------");
        Console.WriteLine($"Insertion | {BenchmarkResults[0, 0]}\t| {BenchmarkResults[0, 1]}");
        Console.WriteLine($"Search    | {BenchmarkResults[1, 0]}\t| {BenchmarkResults[1, 1]}");
        Console.WriteLine($"Removal   | {BenchmarkResults[2, 0]}\t| {BenchmarkResults[2, 1]}");

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

      static bool CheckSearch(IBST bst, int[] Values)
      {
        for(int X=0; X<LesserCount; X++)
        {
          bool Result = bst.Find(Values[X]);
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
        Console.WriteLine(@"done (not found :).");
        return true;
      }

      static bool CheckRemove(IBST bst, int[] Values)
      {
        for(int X=0; X<LesserCount; X++)
        {
          bool Result = bst.Remove(Values[X]);
          if(Result == false)
          {
            Console.WriteLine(@"FAILED!!!");
            return false;
          }
        }
        Console.WriteLine(@"done.");
        return true;
      }

      static int PopulateOne()
      {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        PopulateTreeOne();
        sw.Stop();

        return Convert.ToInt32(sw.Elapsed.TotalMilliseconds);
      }

      static int PopulateTwo()
      {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        PopulateTreeTwo();
        sw.Stop();

        return Convert.ToInt32(sw.Elapsed.TotalMilliseconds);
      }
      static int SearchBenchmark(IBST bst, int[] Values)
      {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        CheckSearch(bst, Values);
        sw.Stop();

        return Convert.ToInt32(sw.Elapsed.TotalMilliseconds);
      }
      static int RemovalBenchmark(IBST bst, int[] Values)
      {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        CheckRemove(bst, Values);
        sw.Stop();

        return Convert.ToInt32(sw.Elapsed.TotalMilliseconds);
      }
    }
}