using ProductReviews.DAL.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductReviews.DTO
{
    public class ReviewDTO
    {
       public int Id { get; set; }
        public string? Author { get; set; }
        public string? Email { get; set; }
        public string? Text { get; set; }
        public int Score { get; set; }
        public int ProductId { get; set; }
        
        public static ReviewDTO Create(Review rev)
        {
            return new ReviewDTO { Id = rev.Id, Author = rev.Author, Email = rev.Email, ProductId = rev.ProductId, Score = rev.Score, Text = rev.Text };
        }
    }
}