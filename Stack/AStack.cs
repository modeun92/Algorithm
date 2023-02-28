namespace ModuenKang.DataStructure
{
    public abstract class AStack<T> : IStack<T>, IStack
    {
        public int Count => mCount;
        public int Capacity => mLength;
        public const int DEFAULT_LENGTH = 32;

        protected int mLength;
        protected int mTop = 0;
        protected int mCount = 0;
        protected T[] mValues = new T[0];

        protected abstract T InternalPeek();
        protected abstract T InternalPop();
        protected abstract void InternalPush(T aItem);
        protected abstract T[] InternalPeekRange(int aLength);
        protected abstract T[] InternalPopRange(int aLength);
        protected abstract void InternalPushRange(T[] aItem);
        public abstract T Peek();
        public abstract T[] PeekRange(int aLength);
        public abstract T Pop();
        public abstract T[] PopRange(int aLength);
        public abstract void Push(T aItem);
        public abstract void Push(object? aItem);
        public abstract void PushRange(T[] aItem);
        public abstract void PushRange(object?[] aItems);
        public abstract bool TryPeek(out T aResult);
        public abstract bool TryPeek(out object? aResult);
        public abstract bool TryPeekRange(out T[] aResult, int aLength);
        public abstract bool TryPeekRange(out object?[] aResult, int aLength);
        public abstract bool TryPop(out T[] aResult, int aLength);
        public abstract bool TryPop(out object? aResult);
        public abstract bool TryPopRange(out T aResult);
        public abstract bool TryPopRange(out object?[] aResult, int aLength);
        public abstract bool TryPush(T aItem);
        public abstract bool TryPush(object? aItem);
        public abstract bool TryPushRange(T[] aItem, int aLength);
        public abstract bool TryPushRange(object?[] aItem);

        object? IStack.Peek()
        { throw new NotImplementedException(); }
        object?[] IStack.PeekRange(int aLength)
        { throw new NotImplementedException(); }
        object? IStack.Pop()
        { throw new NotImplementedException(); }
        object?[] IStack.PopRange(int aLength)
        { throw new NotImplementedException(); }
    }
}
