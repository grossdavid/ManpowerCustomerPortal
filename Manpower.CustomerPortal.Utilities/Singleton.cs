namespace Manpower.CustomerPortal.Utilities
{
    public class Singleton<T>
        where T : class, new()
    {
        private static T _Instance;

        public static T Instance
        {
            get { return _Instance ?? (_Instance = new T()); }
        }
    }
}
