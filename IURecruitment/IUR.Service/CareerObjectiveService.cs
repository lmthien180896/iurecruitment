using IUR.Data.Infrastructure;
using IUR.Data.Repositories;
using IUR.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUR.Service
{
    public interface ICareerObjectiveService
    {
        CareerObjective Add(CareerObjective careerObjective);

        CareerObjective GetById(int id);

        CareerObjective Delete(int id);

        IEnumerable<CareerObjective> GetAll();

        void Update(CareerObjective careerObjective);

        void SaveChanges();
    }

    public class CareerObjectiveService : ICareerObjectiveService
    {
        private ICareerObjectiveRepository _careerObjectiveRepository;
        private IUnitOfWork _unitOfWork;

        public CareerObjectiveService(ICareerObjectiveRepository careerObjectiveRepository, IUnitOfWork unitOfWork)
        {
            this._careerObjectiveRepository = careerObjectiveRepository;
            this._unitOfWork = unitOfWork;
        }

        public CareerObjective Add(CareerObjective careerObjective)
        {
            return _careerObjectiveRepository.Add(careerObjective);
        }

        public CareerObjective Delete(int id)
        {
            return _careerObjectiveRepository.Delete(id);
        }

        
        public IEnumerable<CareerObjective> GetAll()
        {
            return _careerObjectiveRepository.GetAll();
        }
        
        public CareerObjective GetById(int id)
        {
            return _careerObjectiveRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(CareerObjective careerObjective)
        {
            _careerObjectiveRepository.Update(careerObjective);
        }
    }
}
