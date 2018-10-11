namespace Selenium_OpenCart.Tools.SearchWebElements
{
    public interface ISearchStrategy : ISearch
    {
        void SetImplicitStrategy();
        void SetExplicitStrategy();
    }
}
