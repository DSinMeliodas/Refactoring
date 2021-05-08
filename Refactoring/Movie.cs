namespace Refactoring
{
    internal class Movie
    {

        public const int Childrens = 2;
        public const int Regular = 0;
        public const int NewRelease = 1;

        private string m_Title;
        private int m_PriceCode;

        public Movie(string newtitle, int newpriceCode)
        {
            m_Title = newtitle;
            m_PriceCode = newpriceCode;
        }

        public int GetPriceCode()
        {
            return m_PriceCode;
        }

        public void SetPriceCode(int arg)
        {
            m_PriceCode = arg;
        }

        public string GetTitle()
        {
            return m_Title;
        }
    }
}