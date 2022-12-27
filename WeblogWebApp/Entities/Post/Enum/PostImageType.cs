using System.ComponentModel.DataAnnotations;

namespace WeblogWebApp.Entities.Post.Enum
{
    public enum PostImageType
    {
        [Display(Name = "تصویر بندانگشتی")]
        Thumbnail,
        [Display(Name = "تصویر کاور")]
        Cover
    }
}
