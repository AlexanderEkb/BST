namespace Exercize
{
    class SimpleBST : IBST
    {
        Node? Root;
        public SimpleBST()
        {
            Root = null;
        }
        public void Insert(int X)
        {
            // Console.WriteLine($"Insert({X})");
            ref Node? N = ref Root;
            Node? P = null;
            while(N != null)
            {
                P = N;
                if(X > N.V)
                {
                  // Console.WriteLine($"{N.V}->");
                  N = ref N.R;
                }
                else
                {
                  // Console.WriteLine($"<-{N.V}");
                  N = ref N.L;
                }
            }
            N = new Node();
            N.P = P;
            N.V = X;
            // Console.WriteLine(@"---");
        }
        public bool Find(int X)
        {
            Node? N = Root;
            while(N != null)
            {
                if(X == N.V)
                {
                    return true;
                }
                else if(X > N.V)
                { 
                    N = N.R;
                }
                else
                {
                    N = N.L;
                }
            }
            return false;
        }
        public void Remove (int X)
        {
            Node? P = null;
            Node? N = Root;
            while(N != null)
            {
                if(X == N.V)
                {
                    Remove(N, P);
                    return;
                }
                else if(X > N.V)
                {
                    P = N;
                    N = N.R;
                }
                else
                {
                    P = N;
                    N = N.L;
                }
            }
        }

        void Remove (Node N, Node? P)
        {
          int Children = 0;
          if(N.L != null)
          {
            Children++;
          }
          if(N.R != null)
          {
            Children++;
          }
          
          if(Children == 0)
          {
            RemoveLeaf(N, P);
          }
          else if (Children == 1)
          {
            RemoveNode1(N, P);
          }
          else
          {
            RemoveNode2(N, P);
          }
        }
        void RemoveLeaf(Node N, Node? P)
        {
          if(P == null)
          {
            Root = null;
          }
          else
          {
            if(N == P.L)
            {
              P.L = null;
            }
            else
            {
              P.R = null;
            }
          }
        }
        void RemoveNode1(Node N, Node? P)
        {
          
          Node? C = (N.L != null)?N.L:N.R;
          if(P != null)
          {
            // N isn't the root
            if(P.L == N)
            {
              P.L = C;
            }
            else
            {
              P.R = C;
            }
          }
          else
          {
            // N is the root
            Root = C;
          }
        }
        void RemoveNode2(Node N, Node? P)
        {
          Node? M = FindNodeToSwap(N);
          if(M == null)
          {
            Console.WriteLine(@"It's impossible!");
          }
          else
          {
            // Dirty, but works
            int X = N.V;
            try
            {
              N.V = M.V;
            }
            finally
            {}
            Remove(X);
          }
       }
        Node? FindNodeToSwap(Node N)
        {
          Node? M = N.L;
          if(M == null)
          {
            Console.WriteLine(@"It's impossible!");
          }
          else
          {
            while(M.R != null)
            {
              M = M.R;
            }
          }
          return M;
        }

        public bool Check(Node? N)
        {
          if(N == null)
          {
            return true;
          }
          else 
          {
            if(N.L != null)
            {
              if(N.V < N.L.V)
              {
                Console.WriteLine(@"Check failed!");
                return false;
              }
              else
              {
                Check(N.L);
              }
            }
            if(N.R != null)
            {
              if(N.V >= N.R.V)
              {
                Console.WriteLine(@"Check failed!");
                return false;
              }
              else
              {
                Check(N.R);
              }
            }
            return true;
          }
        }

        public bool Check()
        {
          Console.Write(@"Check() ");
          bool Result = Check(Root);

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
    }
}