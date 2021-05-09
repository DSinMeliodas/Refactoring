namespace Refactoring
{
    internal class RegularMovie : Movie
    {
        public RegularMovie(string title) 
            : base(title, new RegularPrice())
        {
        }
    }
}