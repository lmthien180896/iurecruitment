using IUR.Data.Infrastructure;
using IUR.Data.Repositories;
using IUR.Model.Models;
using System.Collections.Generic;

namespace IUR.Service
{
    public interface IEmploymentHistoryService
    {
        EmploymentHistory Add(EmploymentHistory employmentHistory);

        EmploymentHistory GetById(int id);

        EmploymentHistory Delete(int id);

        IEnumerable<EmploymentHistory> GetAll();

        IEnumerable<EmploymentHistory> GetAllByApplicantID(int applicantId);

        void DeleteByApplicantId(int applicantId);

        void Update(EmploymentHistory employmentHistory);

        void SaveChanges();
    }

    public class EmploymentHistoryService : IEmploymentHistoryService
    {
        private IEmploymentHistoryRepository _employmentHistoryRepository;
        private IUnitOfWork _unitOfWork;

        public EmploymentHistoryService(IEmploymentHistoryRepository employmentHistoryRepository, IUnitOfWork unitOfWork)
        {
            this._employmentHistoryRepository = employmentHistoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public EmploymentHistory Add(EmploymentHistory employmentHistory)
        {
            return _employmentHistoryRepository.Add(employmentHistory);
        }

        public EmploymentHistory Delete(int id)
        {
            return _employmentHistoryRepository.Delete(id);
        }

        public void DeleteByApplicantId(int applicantId)
        {
            _employmentHistoryRepository.DeleteMulti(x => x.ApplicantID == applicantId);
        }

        public IEnumerable<EmploymentHistory> GetAll()
        {
            return _employmentHistoryRepository.GetAll();
        }

        public IEnumerable<EmploymentHistory> GetAllByApplicantID(int applicantId)
        {
            return _employmentHistoryRepository.GetMulti(x => x.ApplicantID == applicantId);
        }

        public EmploymentHistory GetById(int id)
        {
            return _employmentHistoryRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(EmploymentHistory employmentHistory)
        {
            _employmentHistoryRepository.Update(employmentHistory);
        }
    }
}