using BuberBreakfast.Entities;

namespace BuberBreakfast.DTO
{
    public class BreakFastsResponseModels : BaseResponseModel
    {
        public IList<BreakFast> Data { get; set; }
    }
}
