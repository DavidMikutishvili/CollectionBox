namespace CollectionBoxWebApi.DataLayer.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Tags { get; set; } 

        public int CollectionId { get; set; }
        
        public int UserId { get; set; }

        public int PageCount { get; set; }
    }
}
