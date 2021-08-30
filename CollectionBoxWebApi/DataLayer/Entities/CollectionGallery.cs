using System.ComponentModel.DataAnnotations;

namespace CollectionBoxWebApi.DataLayer.Entities
{
    public class CollectionGallery
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Theme { get; set; }

        public int UserId { get; set; }
    }
}
