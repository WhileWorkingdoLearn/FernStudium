namespace Teilaufgabe2
{
    internal class A : IInitializing<String>
    {
        public string Culture { get; private set; }
        public void Initialize(string t)
        {
            Culture = t;
        }
    }
}