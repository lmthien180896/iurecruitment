using IUR.Data.Infrastructure;
using IUR.Data.Repositories;
using IUR.Model.Models;
using System.Collections.Generic;

namespace IUR.Service
{
    public interface IOtherSkillService
    {
        OtherSkill Add(OtherSkill otherSkill);

        OtherSkill GetById(int id);

        OtherSkill Delete(int id);

        IEnumerable<OtherSkill> GetAll();

        IEnumerable<OtherSkill> GetAllByApplicantID(int applicantId);

        void DeleteByApplicantId(int applicantId);

        void Update(OtherSkill otherSkill);

        void SaveChanges();
    }

    public class OtherSkillService : IOtherSkillService
    {
        private IOtherSkillRepository _otherSkillRepository;
        private IUnitOfWork _unitOfWork;

        public OtherSkillService(IOtherSkillRepository otherSkillRepository, IUnitOfWork unitOfWork)
        {
            this._otherSkillRepository = otherSkillRepository;
            this._unitOfWork = unitOfWork;
        }

        public OtherSkill Add(OtherSkill otherSkill)
        {
            return _otherSkillRepository.Add(otherSkill);
        }

        public OtherSkill Delete(int id)
        {
            return _otherSkillRepository.Delete(id);
        }

        public void DeleteByApplicantId(int applicantId)
        {
            _otherSkillRepository.DeleteMulti(x => x.ApplicantID == applicantId);
        }

        public IEnumerable<OtherSkill> GetAll()
        {
            return _otherSkillRepository.GetAll();
        }

        public IEnumerable<OtherSkill> GetAllByApplicantID(int applicantId)
        {
            return _otherSkillRepository.GetMulti(x => x.ApplicantID == applicantId);
        }

        public OtherSkill GetById(int id)
        {
            return _otherSkillRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(OtherSkill otherSkill)
        {
            _otherSkillRepository.Update(otherSkill);
        }
    }
}