namespace Refactoring
{
    internal class ChildrensMovie : Movie
    {
        public ChildrensMovie(string title) 
            : base(title, new ChildrensPrice())
        {
        }
    }
}