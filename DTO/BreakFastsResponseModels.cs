using BuberBreakfast.Entities;

namespace BuberBreakfast.DTO
{
    public class BreakFastsResponseModels : BaseResponseModel
    {
        public List<BreakFast> Data { get; set; }
    }
}
