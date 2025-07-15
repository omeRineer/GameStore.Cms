namespace GameStore.Cms.Models.OData
{
    public class ODataSliderContent : ODataModel<Guid>
    {
        public int SliderTypeId { get; set; }
        public string? Header { get; set; }
        public string? To { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
