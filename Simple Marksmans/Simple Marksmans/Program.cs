using EloBuddy.SDK.Events;

namespace Simple_Marksmans
{
    public class Program
    {
        private static void Main()
        {
            Loading.OnLoadingComplete += delegate
            {
                Bootstrap.Initialize();
            };
        }
    }
}