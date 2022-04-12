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
            Node? N = Root;
            while(N != null)
            {
                if(X > N.V)
                {
                    N = N.R;
                }
                else
                {
                    N = N.L;
                }
            }
            N = new Node();
            N.V = X;
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
            bool Leaf = (N.L == null) && (N.R == null);
            if(Leaf)
            {
                if(N == Root)
                {
                    Root = null;
                }
                else
                {
                    if((P != null) && (N == P.L))
                    {
                        P.L = null;
                    }
                    else if(P != null)
                    {
                        P.R = null;
                    }
                }
            }
            else
            {

            }
        }
    }
}