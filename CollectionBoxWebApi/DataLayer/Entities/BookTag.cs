namespace CollectionBoxWebApi.DataLayer.Entities
{
    public class BookTag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BookId { get; set; }

        public int UserId { get; set; }
    }
}
