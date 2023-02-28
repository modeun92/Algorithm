namespace ModuenKang.DataStructure
{
    public interface IStack<T>
    {
        T Peek();
        T[] PeekRange(int aLength);
        T Pop();
        T[] PopRange(int aLength);
        void Push(T aItem);
        void PushRange(T[] aItem);
        bool TryPeek(out T aResult);
        bool TryPeekRange(out T[] aResult, int aLength);
        bool TryPopRange(out T aResult);
        bool TryPop(out T[] aResult, int aLength);
        bool TryPush(T aItem);
        bool TryPushRange(T[] aItem, int aLength);
    }
    public interface IStack
    {
        object? Peek();
        object?[] PeekRange(int aLength);
        object? Pop();
        object?[] PopRange(int aLength);
        void Push(object? aItem);
        void PushRange(object?[] aItems);
        bool TryPeek(out object? aResult);
        bool TryPeekRange(out object?[] aResult, int aLength);
        bool TryPop(out object? aResult);
        bool TryPopRange(out object?[] aResult, int aLength);
        bool TryPush(object? aItem);
        bool TryPushRange(object?[] aItem);
    }
}
