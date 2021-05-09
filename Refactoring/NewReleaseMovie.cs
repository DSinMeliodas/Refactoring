namespace Refactoring
{
    internal class NewReleaseMovie : Movie
    {
        public NewReleaseMovie(string title) 
            : base(title, new NewReleasePrice())
        {
        }
    }
}