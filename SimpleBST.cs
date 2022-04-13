namespace Exercize
{
    class SimpleBST : IBST
    {
        Node? Root;
        public SimpleBST()
        {
          Clean();
        }

        public void Clean()
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
        public bool Remove (int X)
        {
            Node? N = Root;
            while(N != null)
            {
                if(X == N.V)
                {
                  return Remove(N);
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

        bool Remove (Node N)
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
            return RemoveLeaf(N);
          }
          else if (Children == 1)
          {
            return RemoveNode1(N);
          }
          else
          {
            return RemoveNode2(N);
          }
        }
        bool RemoveLeaf(Node N)
        {
          if(N.P == null)
          {
            Root = null;
          }
          else
          {
            if(N == N.P.L)
            {
              N.P.L = null;
            }
            else
            {
              N.P.R = null;
            }
          }

          return true;
        }
        bool RemoveNode1(Node N)
        {
          
          Node? C = (N.L != null)?N.L:N.R;
          if(N.P != null)
          {
            // N isn't the root
            if(N.P.L == N)
            {
              N.P.L = C;
            }
            else
            {
              N.P.R = C;
            }
          }
          else
          {
            // N is the root
            Root = C;
          }

          return true;
        }
        bool RemoveNode2(Node N)
        {
          Node? M = FindNodeToSwap(N);
          if(M == null)
          {
            Console.WriteLine(@"It's impossible!");
            return false;
          }
          else
          {
            // Dirty, but works
            int X = N.V;
            N.V = M.V;

            return Remove(M);
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
          bool Result = Check(Root);
          return Result;
        }
    }
}