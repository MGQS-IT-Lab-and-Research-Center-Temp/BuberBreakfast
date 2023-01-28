using BuberBreakfast.Context;
using BuberBreakfast.Contracts.Repository;
using BuberBreakfast.Contracts.Service;
using BuberBreakfast.DTO;
using BuberBreakfast.Entities;
using BuberBreakfast.Implementations.Repository;

namespace BuberBreakfast.Implementations.Service
{
    public class BreaskFastService : IBreakFastService
    {
        private readonly ApplicationContext _applicationContext;
        private static IBreakFastRepository _breakFastRepository;

        public BreaskFastService(ApplicationContext context,IBreakFastRepository breakFastRepository)
        {
            _applicationContext = context;
            _breakFastRepository = breakFastRepository;
        }
        public BreakFastResponseModel DeleteBreakFast(int id)
        {
            var breakfast = _breakFastRepository.GetById(id);
            if(breakfast == null)
            {
                return new BreakFastResponseModel
                {
                    Message = "Breakfast Not found!!",
                    Status = false
                };
            }
            else
            {
                _breakFastRepository.Delete(id);
                return new BreakFastResponseModel
                { Message = "BreakFast Succesfully deleted",
                  Status = true
                };

            }
        }

        public BreakFastResponseModel GetBreakFast(int id)
        {
            var breakfast = _breakFastRepository.GetById(id);
            if (breakfast == null )
            {
                return new BreakFastResponseModel
                {
                    Message = "BreakFast not found!!",
                    Status = false
                };
            }
            else
            {
                return new BreakFastResponseModel
                {
                    Data = new BreakFastDto
                    {
                        BreakFastId = breakfast.Id,
                        Name = breakfast.Name,
                        Description = breakfast.Description
                    },
                    Status = true,
                    Message = "BreakFast successfully retrieved"
                };
            }
        }

        public BreakFastResponseModel PrintAllBreakFast(BreakFast breakFast)
        {
            throw new NotImplementedException();
        }

        public BreakFastResponseModel RegisterBreakFast(BreakFastDto request)
        {
            throw new NotImplementedException();
        }

        public BreakFastResponseModel UpdateBreakFast(int id, BreakFastDto request)
        {
            var breakfast = _breakFastRepository.GetById(id);
            if(breakfast == null)
            {
                return new BreakFastResponseModel
                {
                    Message = "Breakfast not found!!",
                    Status = true
                };
            }
            else
            {
                breakfast.Id = request.BreakFastId;
                _breakFastRepository.Update(breakfast.Id);
                return new BreakFastResponseModel
                {
                  Message= "BreakFast successfully updated",
                  Status =  true
                };
            }
        }
    }
}
