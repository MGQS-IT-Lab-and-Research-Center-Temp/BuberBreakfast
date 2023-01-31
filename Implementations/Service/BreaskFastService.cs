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

        private readonly IBreakFastRepository _breakFastRepository;

        public BreaskFastService(ApplicationContext context, IBreakFastRepository breakFastRepository)
        {
            _breakFastRepository = breakFastRepository;
        }
        public BreakFastResponseModel DeleteBreakFast(int id)
        {
            var breakfast = _breakFastRepository.GetById(id);
            if (breakfast == null)
            {
                return new BreakFastResponseModel
                {
                    Message = "Breakfast Not found!!",
                    Status = false
                };
            }

            _breakFastRepository.Delete(id);
            return new BreakFastResponseModel
            {
                Message = "BreakFast Succesfully deleted",
                Status = true
            };


        }

        public BreakFastResponseModel GetBreakFast(int id)
        {
            var breakfast = _breakFastRepository.GetById(id);
            if (breakfast == null)
            {
                return new BreakFastResponseModel
                {
                    Message = "BreakFast not found!!",
                    Status = false
                };
            }
                return new BreakFastResponseModel
                {
                    Data = new BreakFastDto
                    {
                        BreakFastId = breakfast.Id,
                        Name = breakfast.Name,
                        Description = breakfast.Description,
                        StartDateTime = breakfast.StartDateTime,
                        EndDateTime = breakfast.EndDateTime
                    },
                    Status = true,
                    Message = "BreakFast successfully retrieved"
                };

        }

        public BreakFastsResponseModels PrintAllBreakFast()
        {
            var breakfasts = _breakFastRepository.GetAll();
            if (breakfasts == null)
            {
                return new BreakFastsResponseModels
                {
                    Status = false,
                    Message = "breakfast Not Found",
                };
            }

            return new BreakFastsResponseModels
            {
                Data = breakfasts,
                Status = true,
                Message = "List of admins",
            };
        }                                                 

        public BreakFastResponseModel CreateBreakFast(BreakFastDto request)
        {
            var breakfast = _breakFastRepository.GetById(request.BreakFastId);
            if (breakfast != null)
            {
                return new BreakFastResponseModel
                {
                    Message = "Breakfast already exist!!",
                    Status = false
                };
            }
            var newbreakfast = new BreakFast
            {
                Id = request.BreakFastId,
                Name = request.Name,
                Description = request.Description,
                StartDateTime = request.StartDateTime,
                EndDateTime = request.EndDateTime
            };
            _breakFastRepository.Create(newbreakfast);
            return new BreakFastResponseModel
            {
                Data = new BreakFastDto
                {
                    Name = newbreakfast.Name,
                    Description = newbreakfast.Description,
                    StartDateTime = newbreakfast.StartDateTime,
                    EndDateTime = newbreakfast.EndDateTime
                },
                Message = "Breakfast successfully created",
                Status = true
            };
        }

        public BreakFastResponseModel UpdateBreakFast(int id, UpdateBreakfastDTO request)
        {
            var breakfast = _breakFastRepository.GetById(id);
            if (breakfast == null)
            {
                return new BreakFastResponseModel
                {
                    Message = "Breakfast not found!!",
                    Status = false
                };
            }
                //breakfast.Id = request.BreakFastId;
                breakfast.Name = request.Name;
                breakfast.Description = request.Description;
                //breakfast.StartDateTime = request.StartDateTime;
                //breakfast.EndDateTime = request.EndDateTime; 
                _breakFastRepository.Update(id);
                return new BreakFastResponseModel
                {
                    Message = "BreakFast successfully updated",
                    Status = true
                };
        }

        
    }
}
