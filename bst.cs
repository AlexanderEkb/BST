namespace Exercize
{
    class Node
    {
        public int V;
        public Node? L;
        public Node? R;
        
        public Node()
        {
            L = null;
            R = null;
            V = 0;
        }
        // public INode? GetL() {return L;}
        // public void SetL(INode Value) {L = Value;}
        // public INode? GetR() {return R;}
        // public void SetR(INode Value) {L = Value;}
    }

    interface IBST
    {
        void Insert(int X);
        bool Find(int X);
        void Remove (int X);
    }
}