using BuberBreakfast.DTO;
using BuberBreakfast.Entities;

namespace BuberBreakfast.Contracts.Service
{
    public interface IBreakFastService
    {
        BreakFastResponseModel CreateBreakFast(BreakFastDto request);
        BreakFastResponseModel GetBreakFast(int id);
        BreakFastResponseModel DeleteBreakFast(int id);
        BreakFastResponseModel UpdateBreakFast(int id, UpdateBreakfastDTO request);
        BreakFastsResponseModels PrintAllBreakFast();
    }
}
