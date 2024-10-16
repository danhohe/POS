namespace LinearDataStructures.Logic
{
    public static class DataStructuresFactory
    {
        public static IStack<T> CreateStack<T>()
        {
            return new Stack<T>();
        }
        public static IQueue<T> CreateQueue<T>()
        {
            return new Queue<T>();
        }
        public static IUniversalQueue<T> CreateUniversalQueue<T>()
        {
            return new UniversalQueue<T>();
        }
    }
}
