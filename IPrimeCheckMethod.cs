namespace PrimeNumbers
{
    public delegate void Progress(int percent);
    interface IPrimeCheckMethod
    {
        int Number { get; }
        bool Result { get; }
        bool IsPrime(Progress progress);
    }
}
