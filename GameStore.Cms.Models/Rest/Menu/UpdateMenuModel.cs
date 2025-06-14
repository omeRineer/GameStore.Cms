using System.ComponentModel.DataAnnotations;

namespace GameStore.Cms.Models.Rest.Menu
{
    public class UpdateMenuModel
    {
        public Guid Id { get; set; }
        public Guid? ParentMenuId { get; set; }

        [MaxLength(5)]
        public string? Code { get; set; }

        [MaxLength(20)]
        public string Title { get; set; }
        public int? Priority { get; set; }

        [MaxLength(50)]
        public string? Path { get; set; }

        [MaxLength(30)]
        public string? Icon { get; set; }
    }
}
