using System.ComponentModel.DataAnnotations;

namespace VerticalSliceSample.Entities
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }
        public string? Name { get; set; }
    }
}
