namespace BuberBreakfast.DTO
{
    public class UpdateBreakfastDTO
    {
        public int BreakFastId { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Description { get; set; } =   string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
