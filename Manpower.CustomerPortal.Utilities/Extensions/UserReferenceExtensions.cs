namespace Manpower.Portal.Utilities.Extensions
{
    public static class UserReferenceExtensions
    {
        public static string GetDisplayName(this UserReference userReference, bool addRemovedStatus = true)
        {
            if (userReference == null)
            {
                return string.Empty;
            }

            var user = userReference.GetUser();
            return user.GetDisplayName();
        }
    }
}
