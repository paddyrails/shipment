using System;
using System.Threading.Tasks;
using Shipment.Services.Activities.Domain.Repositories;
using Shipment.Common.Exceptions;
using Shipment.Services.Activities.Domain.Models;
namespace Shipment.Services.Activities.Services
{
    public class ActivityService: IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ActivityService(IActivityRepository activityRepository, ICategoryRepository categoryRepository){
            _activityRepository = activityRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            var activityCategory = await _categoryRepository.GetAsync(category);
            if(activityCategory == null)
            {
                Console.WriteLine("Category not found");
                throw new ShipmentException("category_not_found", $"category: {category} was not found");
            }
            var activity = new Activity(id, userId, category, name, description, createdAt);
            await _activityRepository.AddAsync(activity);
        }
    }
}