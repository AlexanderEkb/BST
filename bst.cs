namespace Exercize
{
    class Node
    {
        public int V;
        public Node? L;
        public Node? R;
        public Node? P;
        
        public Node()
        {
            L = null;
            R = null;
            P = null;
            V = -1;
        }
        // public INode? GetL() {return L;}
        // public void SetL(INode Value) {L = Value;}
        // public INode? GetR() {return R;}
        // public void SetR(INode Value) {L = Value;}
    }

    interface IBST
    {
        void Clean();
        void Insert(int X);
        bool Find(int X);
        bool Remove (int X);
        bool Check();
    }
}