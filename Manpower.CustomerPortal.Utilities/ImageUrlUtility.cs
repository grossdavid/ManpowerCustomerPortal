using System;
using System.Drawing;

namespace Manpower.Portal.Utilities
{
    public static class ImageUrlUtility
    {
        //public static bool UseDefaultClubImage(Club club)
        //{
        //    return (club == null || club.Logotype == null || club.Logotype.Status != EntityStatus.Approved);
        //}

        //public static string GetClubImageUrl(Club club, Size size)
        //{
        //    try
        //    {
        //        return ImageGalleryHandler.Instance.GetThumbnail(club.Logotype, size.Width, size.Height, ThumbnailFormat.ReduceAndCrop).Url;
        //    }
        //    catch (Exception)
        //    {
        //        return "<i class=\"fa fa-group\"></i>";
        //    }

        //}

        //public static string GetClubContentImageUrl(Club club, Size size)
        //{
        //    try
        //    {
        //        var img = club.GetAttributeValue<EPiServer.Community.ImageGallery.Image>("ClubImageAttribute");
        //        return img != null ?
        //            ImageGalleryHandler.Instance.GetThumbnail(img, size.Width, size.Height, ThumbnailFormat.Proportional).Url :
        //            null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }
        //}

        //public static string GetProfileImageUrl(IUser user, Size size)
        //{
        //    MyPage myPage = MyPageHandler.Instance.GetMyPage(user);

        //    if (user == null || myPage == null || myPage.Portrait == null || myPage.Portrait.Status != EntityStatus.Approved)
        //    {
        //        return null;
        //    }

        //    try
        //    {
        //        return ImageGalleryHandler.Instance.GetThumbnail(myPage.Portrait, size.Width, size.Height, ThumbnailFormat.Exact).Url;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public static string GetThumbnailUrl(Thumbnail thumbnail)
        //{
        //    var helper = new SelectedEntitiesHelper();
        //    var urlBuilder = new UrlBuilder(Settings.DownloadImageUrl);

        //    if (thumbnail != null)
        //    {
        //        urlBuilder.QueryCollection.Add(helper.GetQueryStringParam(thumbnail.Parent.GetType()), thumbnail.Parent.ID.ToString());
        //        urlBuilder.QueryCollection.Add("width", thumbnail.Width.ToString());
        //        urlBuilder.QueryCollection.Add("height", thumbnail.Height.ToString());
        //        urlBuilder.QueryCollection.Add("thumbnailformat", ((int)thumbnail.Format).ToString());
        //        return urlBuilder.ToString();
        //    }
        //    return string.Empty;
        //}

        //public static string TryGetThumbnailUrl(EPiServer.Community.ImageGallery.Image image, Size size, ThumbnailFormat format = ThumbnailFormat.ReduceAndCrop)
        //{
        //    try
        //    {
        //        return GetThumbnailUrl(ImageGalleryHandler.Instance.GetThumbnail(image, size.Width, size.Height, format));
        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }
        //}

        //public static ISettings Settings
        //{
        //    get { return _settings ?? (_settings = SettingsProviderFactory.GetSettingsProvider().GetSettings()); }
        //}

        //public static string GetGenericIntranetImage(Size size)
        //{
        //    return string.Format("/images/default/GenericIntranetImage_w{0}h{1}.png", size.Width, size.Height);
        //}
    }
}

