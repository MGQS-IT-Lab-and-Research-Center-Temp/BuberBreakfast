using BuberBreakfast.DTO;
using BuberBreakfast.Entities;

namespace BuberBreakfast.Contracts.Service
{
    public interface IBreakFastService
    {
        BreakFastResponseModel RegisterBreakFast(BreakFastDto request);
        BreakFastResponseModel GetBreakFast(int id);
        BreakFastResponseModel DeleteBreakFast(int id);
        BreakFastResponseModel UpdateBreakFast(int id, BreakFastDto request);
        BreakFastResponseModel PrintAllBreakFast(BreakFast breakFast);
    }
}
