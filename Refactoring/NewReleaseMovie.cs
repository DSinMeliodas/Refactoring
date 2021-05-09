namespace Refactoring
{
    internal class NewReleaseMovie : Movie
    {
        public const int Code = 1;

        public NewReleaseMovie(string title) : base(title, Code)
        {
        }
    }
}