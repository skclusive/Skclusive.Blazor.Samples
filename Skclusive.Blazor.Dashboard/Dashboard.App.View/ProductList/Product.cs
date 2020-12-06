using System;

namespace Skclusive.Dashboard.App.View
{
    public class Product
    {
        public string Id { set; get; }

        public string Title { set; get; }

        public string Description { set; get; }

        public string ImageUrl { set; get; }

        public int TotalDownloads { set; get; }

        public DateTime CreatedAt { set; get; }

        public DateTime UpdatedAt { set; get; }
    }
}
