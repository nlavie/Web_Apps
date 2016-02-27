using System;
using System.ComponentModel.DataAnnotations;

namespace Proj.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; } // primary key
        public int PostID { get; set; } //secondary key to Post Class
        public virtual Post Post { get; set; }//link to original post
        [Required,Display(Name = "Title")]
        public string CommentHeader { get; set; }
        [Required, Display(Name = "Name")]
        public string CommentAuthor { get; set; }
        [Url, Required, Display(Name = "Website")]
        public string CommentAuthorURL { get; set; }
        [DataType(DataType.DateTime),Display(Name="Date")]
        public DateTime CommentDate { get; set; }
        [DataType(DataType.MultilineText), Required,Display(Name="Comment")]
        public string CommentText { get; set; }
    }
}
