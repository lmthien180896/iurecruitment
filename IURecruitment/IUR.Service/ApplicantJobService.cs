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
    public interface IApplicantJobService
    {
        ApplicantJob Add(ApplicantJob applicantJob);

        ApplicantJob GetById(int id);

        ApplicantJob GetByApplicantId(int applicantID);

        ApplicantJob Delete(int id);

        IEnumerable<ApplicantJob> GetAll();

        void DeleteByApplicantId(int applicantId);

        void Update(ApplicantJob applicantJob);

        void SaveChanges();
    }

    public class ApplicantJobService : IApplicantJobService
    {
        private IApplicantJobRepository _applicantJobRepository;
        private IUnitOfWork _unitOfWork;

        public ApplicantJobService(IApplicantJobRepository applicantJobRepository, IUnitOfWork unitOfWork)
        {
            this._applicantJobRepository = applicantJobRepository;
            this._unitOfWork = unitOfWork;
        }

        public ApplicantJob Add(ApplicantJob applicantJob)
        {
            return _applicantJobRepository.Add(applicantJob);
        }

        public ApplicantJob Delete(int id)
        {
            return _applicantJobRepository.Delete(id);
        }

        public void DeleteByApplicantId(int applicantId)
        {
            _applicantJobRepository.DeleteMulti(x => x.ApplicantID == applicantId);           
        }

        public IEnumerable<ApplicantJob> GetAll()
        {
            return _applicantJobRepository.GetAll();
        }

        public ApplicantJob GetByApplicantId(int applicantID)
        {
            return _applicantJobRepository.GetSingleByCondition(x => x.ApplicantID == applicantID);
        }

        public ApplicantJob GetById(int id)
        {
            return _applicantJobRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ApplicantJob applicantJob)
        {
            _applicantJobRepository.Update(applicantJob);
        }
    }
}
