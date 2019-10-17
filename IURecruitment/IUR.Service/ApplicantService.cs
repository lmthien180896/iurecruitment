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
    public interface IApplicantService
    {
        void Save();
    }

    public class ApplicantService : IApplicantService
    {
        private IApplicantDetailRepository _applicantDetailRepository;
        private ICareerObjectiveRepository _careerObjectiveRepository;
        private IEducationBackgroundRepository _EducationBackgroundRepository;
        private ILanguageRepository _languageRepository;
        private IComputerSkillRepository _computerSKillRepository;
        private IOtherSkillRepository _otherSkillRepository;
        private IEmploymentHistoryRepository _employmentHistoryRepository;
        private IOtherQuestionRepository _otherQuestionRepository;
        private IResumeRepository _resumeRepository;
        private IApplicantJobRepository _applicantJobRepository;        
        private IUnitOfWork _unitOfWork;

        public ApplicantService(IApplicantDetailRepository applicantDetailRepository, IUnitOfWork unitOfWork)
        {
            this._applicantDetailRepository = applicantDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

    }
}
