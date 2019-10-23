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
    public interface IApplicantDetailService
    {
        ApplicantDetail Add(ApplicantDetail applicantDetail);

        ApplicantDetail GetById(int id);

        ApplicantDetail Delete(int id);

        void DeleteByApplicantID(int applicantId);

        IEnumerable<ApplicantDetail> GetAll();


        void Update(ApplicantDetail applicantDetail);

        void SaveChanges();
    }

    public class ApplicantDetailService : IApplicantDetailService
    {
        private IApplicantDetailRepository _applicantDetailRepository;        
        private IUnitOfWork _unitOfWork;

        public ApplicantDetailService(IApplicantDetailRepository applicantDetailRepository, IUnitOfWork unitOfWork)
        {
            this._applicantDetailRepository = applicantDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public ApplicantDetail Add(ApplicantDetail applicantDetail)
        {
            return _applicantDetailRepository.Add(applicantDetail);
        }

        public ApplicantDetail Delete(int id)
        {
            return _applicantDetailRepository.Delete(id);
        }

        public void DeleteByApplicantID(int applicantId)
        {
            _applicantDetailRepository.Delete(applicantId);
        }

        public IEnumerable<ApplicantDetail> GetAll()
        {
            return _applicantDetailRepository.GetAll();
        }

        public ApplicantDetail GetById(int id)
        {
            return _applicantDetailRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ApplicantDetail applicantDetail)
        {
            _applicantDetailRepository.Update(applicantDetail);
        }
    }
}
