using IUR.Data.Infrastructure;
using IUR.Data.Repositories;
using IUR.Model.Models;
using System.Collections.Generic;

namespace IUR.Service
{
    public interface IOtherQuestionService
    {
        OtherQuestion Add(OtherQuestion otherQuestion);

        OtherQuestion GetById(int id);

        OtherQuestion Delete(int id);

        IEnumerable<OtherQuestion> GetAll();

        void Update(OtherQuestion otherQuestion);

        void SaveChanges();
    }

    public class OtherQuestionService : IOtherQuestionService
    {
        private IOtherQuestionRepository _otherQuestionRepository;
        private IUnitOfWork _unitOfWork;

        public OtherQuestionService(IOtherQuestionRepository otherQuestionRepository, IUnitOfWork unitOfWork)
        {
            this._otherQuestionRepository = otherQuestionRepository;
            this._unitOfWork = unitOfWork;
        }

        public OtherQuestion Add(OtherQuestion otherQuestion)
        {
            return _otherQuestionRepository.Add(otherQuestion);
        }

        public OtherQuestion Delete(int id)
        {
            return _otherQuestionRepository.Delete(id);
        }

        public IEnumerable<OtherQuestion> GetAll()
        {
            return _otherQuestionRepository.GetAll();
        }

        public OtherQuestion GetById(int id)
        {
            return _otherQuestionRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(OtherQuestion otherQuestion)
        {
            _otherQuestionRepository.Update(otherQuestion);
        }
    }
}