namespace CollectionBoxWebApi.DataLayer.Entities
{
    public class AlcoholTag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AlcoholId { get; set; }

        public int UserId { get; set; }
    }
}
