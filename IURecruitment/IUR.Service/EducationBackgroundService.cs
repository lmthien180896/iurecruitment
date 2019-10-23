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
    public interface IEducationBackgroundService
    {
        EducationBackground Add(EducationBackground educationBackground);

        EducationBackground GetById(int id);

        EducationBackground Delete(int id);

        IEnumerable<EducationBackground> GetAll();

        IEnumerable<EducationBackground> GetAllByApplicantID(int applicantId);

        void DeleteByApplicantId(int applicantId);

        void Update(EducationBackground educationBackground);

        void SaveChanges();
    }

    public class EducationBackgroundService : IEducationBackgroundService
    {
        private IEducationBackgroundRepository _educationBackgroundRepository;
        private IUnitOfWork _unitOfWork;

        public EducationBackgroundService(IEducationBackgroundRepository educationBackgroundRepository, IUnitOfWork unitOfWork)
        {
            this._educationBackgroundRepository = educationBackgroundRepository;
            this._unitOfWork = unitOfWork;
        }

        public EducationBackground Add(EducationBackground educationBackground)
        {
            return _educationBackgroundRepository.Add(educationBackground);
        }

        public EducationBackground Delete(int id)
        {
            return _educationBackgroundRepository.Delete(id);
        }

        public void DeleteByApplicantId(int applicantId)
        {
            _educationBackgroundRepository.DeleteMulti(x => x.ApplicantID == applicantId);   
        }

        public IEnumerable<EducationBackground> GetAll()
        {
            return _educationBackgroundRepository.GetAll();
        }

        public IEnumerable<EducationBackground> GetAllByApplicantID(int applicantId)
        {
            return _educationBackgroundRepository.GetMulti(x => x.ApplicantID == applicantId);
        }

        public EducationBackground GetById(int id)
        {
            return _educationBackgroundRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(EducationBackground educationBackground)
        {
            _educationBackgroundRepository.Update(educationBackground);
        }
    }
}


