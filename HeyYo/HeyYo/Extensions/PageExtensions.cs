using Xamarin.Forms;

namespace HeyYo.Extensions
{
    public static class PageExtensions
    {
        public static Page WithoutNavBar(this Page page)
        {
            NavigationPage.SetHasNavigationBar(page, false);

            return page;
        }
    }
}
