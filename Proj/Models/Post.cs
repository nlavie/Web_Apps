using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proj.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Url, Required, Display(Name = "Author Website")]
        public string URLWebAddress { get; set; }
         [DataType(DataType.DateTime), Display(Name = "Publish Date")]
        public DateTime PostDate { get; set; }
        [DataType(DataType.MultilineText), Required]
        public string Text { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image URL (Optional)")]
        public string ImageUrl { get; set; }
        [Url, Display(Name = "Video URL (Optional)")]
        public string VideoUrl { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }//comment list
    }
}