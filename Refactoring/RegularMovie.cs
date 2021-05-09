namespace Refactoring
{
    internal class RegularMovie : Movie
    {
        public const int Code = 0;

        public RegularMovie(string title) : base(title, Code)
        {
        }
    }
}