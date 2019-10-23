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
    public interface ILanguageService
    {
        Language Add(Language language);

        Language GetById(int id);

        Language Delete(int id);

        IEnumerable<Language> GetAll();

        IEnumerable<Language> GetAllByApplicantID(int applicantId);

        void DeleteByApplicantId(int applicantId);

        void Update(Language language);

        void SaveChanges();
    }

    public class LanguageService : ILanguageService
    {
        private ILanguageRepository _languageRepository;
        private IUnitOfWork _unitOfWork;

        public LanguageService(ILanguageRepository languageRepository, IUnitOfWork unitOfWork)
        {
            this._languageRepository = languageRepository;
            this._unitOfWork = unitOfWork;
        }

        public Language Add(Language language)
        {
            return _languageRepository.Add(language);
        }

        public Language Delete(int id)
        {
            return _languageRepository.Delete(id);
        }

        public void DeleteByApplicantId(int applicantId)
        {
            _languageRepository.DeleteMulti(x => x.ApplicantID == applicantId);    
        }

        public IEnumerable<Language> GetAll()
        {
            return _languageRepository.GetAll();
        }

        public IEnumerable<Language> GetAllByApplicantID(int applicantId)
        {
            return _languageRepository.GetMulti(x => x.ApplicantID == applicantId);
        }

        public Language GetById(int id)
        {
            return _languageRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Language language)
        {
            _languageRepository.Update(language);
        }
    }
}
