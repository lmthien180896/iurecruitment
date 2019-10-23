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
    public interface IResumeService
    {
        Resume Add(Resume resume);

        Resume GetById(int id);

        Resume Delete(int id);

        IEnumerable<Resume> GetAll();

        void Update(Resume resume);

        void SaveChanges();
    }

    public class ResumeService : IResumeService
    {
        private IResumeRepository _resumeRepository;
        private IUnitOfWork _unitOfWork;

        public ResumeService(IResumeRepository resumeRepository, IUnitOfWork unitOfWork)
        {
            this._resumeRepository = resumeRepository;
            this._unitOfWork = unitOfWork;
        }

        public Resume Add(Resume resume)
        {
            return _resumeRepository.Add(resume);
        }

        public Resume Delete(int id)
        {
            return _resumeRepository.Delete(id);
        }

        public IEnumerable<Resume> GetAll()
        {
            return _resumeRepository.GetAll();
        }

        public Resume GetById(int id)
        {
            return _resumeRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Resume resume)
        {
            _resumeRepository.Update(resume);
        }
    }
}


