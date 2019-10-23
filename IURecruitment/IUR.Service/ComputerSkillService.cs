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
    public interface IComputerSkillService
    {
        ComputerSkill Add(ComputerSkill computerSkill);

        ComputerSkill GetById(int id);

        ComputerSkill Delete(int id);

        IEnumerable<ComputerSkill> GetAll();

        IEnumerable<ComputerSkill> GetAllByApplicantID(int applicantId);

        void DeleteByApplicantId(int applicantId);

        void Update(ComputerSkill computerSkill);

        void SaveChanges();
    }

    public class ComputerSkillService : IComputerSkillService
    {
        private IComputerSkillRepository _computerSkillRepository;
        private IUnitOfWork _unitOfWork;

        public ComputerSkillService(IComputerSkillRepository computerSkillRepository, IUnitOfWork unitOfWork)
        {
            this._computerSkillRepository = computerSkillRepository;
            this._unitOfWork = unitOfWork;
        }

        public ComputerSkill Add(ComputerSkill computerSkill)
        {
            return _computerSkillRepository.Add(computerSkill);
        }

        public ComputerSkill Delete(int id)
        {
            return _computerSkillRepository.Delete(id);
        }

        public void DeleteByApplicantId(int applicantId)
        {
            _computerSkillRepository.DeleteMulti(x => x.ApplicantID == applicantId);        
        }

        public IEnumerable<ComputerSkill> GetAll()
        {
            return _computerSkillRepository.GetAll();
        }

        public IEnumerable<ComputerSkill> GetAllByApplicantID(int applicantId)
        {
            return _computerSkillRepository.GetMulti(x => x.ApplicantID == applicantId);
        }

        public ComputerSkill GetById(int id)
        {
            return _computerSkillRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ComputerSkill computerSkill)
        {
            _computerSkillRepository.Update(computerSkill);
        }
    }
}


