using System;
using System.Drawing;
using System.Globalization;
using Newtonsoft.Json;

namespace Manpower.Portal.Utilities.Extensions
{
    public static class UserExtensions
    {
        public static string GetDisplayName(this IUser user, bool addRemovedStatus = true)
        {
            if (user == null)
            {
                return string.Empty;
            }
            var displayName = String.Format(CultureInfo.InvariantCulture, "{0} {1}", user.GivenName, user.SurName);
            if (user.Status == EntityStatus.Removed && addRemovedStatus)
                displayName += " (inactive)";
            return displayName;
        }

        public static T GetAttributeValueFromJson<T>(this IUser user, string attribute)
            where T : class
        {
            if (user == null)
                throw new ArgumentNullException("user");

            var json = user.GetAttributeValue<string>(attribute);
            if (string.IsNullOrWhiteSpace(json))
                return null;

            try
            {
                return JsonConvert.DeserializeObject<T>(json);    
            }
            catch (Exception)
            {
                throw new Exception(string.Format("Invalid attribute value '{0}' for user {1}", json, user.ID));
            }
        }

        public static void SetJsonAttributeValue<T>(this IUser user, string attribute, T value)
            where T : class
        {
            if (user == null)
                throw new ArgumentNullException("user");

            string json = null;

            if (value != null)
                json = JsonConvert.SerializeObject(value);

            user.SetAttributeValue(attribute, json);
        }

        public static string GetProfileImageUrl(this IUser user, Size size)
        {
            return ImageUrlUtility.GetProfileImageUrl(user, size);
        }

        public static string GetTelephone(this IUser user)
        {
            return user.GetAttributeValue<string>("Telephone");
        }
        public static void SetTelephone(this IUser user, string telephone)
        {
            user.SetAttributeValue("Telephone", telephone);
        }

        public static string GetDepartmentCode(this IUser user)
        {
            return user.GetAttributeValue<string>("DepartmentCode");
        }

        public static void SetDepartmentCode(this IUser user, string departmentCode)
        {
            user.SetAttributeValue("DepartmentCode", departmentCode);
        }

        public static string GetDepartmentName(this IUser user)
        {
            return user.GetAttributeValue<string>("DepartmentName");
        }
        public static void SetDepartmentName(this IUser user, string departmentName)
        {
            user.SetAttributeValue("DepartmentName", departmentName);
        }

        public static string GetEmploymentNumber(this IUser user)
        {
            return user.GetAttributeValue<string>("EmploymentNumber");
        }
        public static void SetEmploymentNumber(this IUser user, string employeeNumber)
        {
            user.SetAttributeValue("EmploymentNumber", employeeNumber);
        }

        public static string GetEmploymentType(this IUser user)
        {
            return user.GetAttributeValue<string>("EmploymentType");
        }
        public static void SetEmploymentType(this IUser user, string employeeType)
        {
            user.SetAttributeValue("EmploymentType", employeeType);
        }

        public static string GetCompanyCode(this IUser user)
        {
            return user.GetAttributeValue<string>("CompanyCode");
        }
        public static void SetCompanyCode(this IUser user, string company)
        {
            user.SetAttributeValue("CompanyCode", company);
        }

        public static string GetCountryCode(this IUser user)
        {
            return user.GetAttributeValue<string>("CountryCode");
        }
        public static void SetCountryCode(this IUser user, string country)
        {
            user.SetAttributeValue("CountryCode", country);
        }

        public static string GetCountry(this IUser user)
        {
            return user.GetAttributeValue<string>("Country");
        }
        public static void SetCountry(this IUser user, string country)
        {
            user.SetAttributeValue("Country", country);
        }

        public static string GetManager(this IUser user)
        {
            return user.GetAttributeValue<string>("Manager");
        }
        public static void SetManager(this IUser user, string country)
        {
            user.SetAttributeValue("Manager", country);
        }
        public static string GetProfilePhotoImageOriginalContentLink(this IUser user)
        {
            return user.GetAttributeValue<string>("ProfilePhotoImageOriginalContentLink");
        }

        public static void SetProfilePhotoImageOriginalContentLink(this IUser user, string profilePhotoImageOriginalContentLink)
        {
            user.SetAttributeValue("ProfilePhotoImageOriginalContentLink", profilePhotoImageOriginalContentLink);
        }

        public static string GetChangePasswordGuid(this IUser user)
        {
            return user.GetAttributeValue<string>("ChangePasswordGuid");
        }
        public static void SetChangePasswordGuid(this IUser user, string changePasswordGuid)
        {
            user.SetAttributeValue("ChangePasswordGuid", changePasswordGuid);
        }


    }
}
