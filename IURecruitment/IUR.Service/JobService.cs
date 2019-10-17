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
    public interface IJobService
    {
        Job Add(Job job);

        Job GetById(int id);

        Job Delete(int id);

        void DeleteMultiById(int id);

        IEnumerable<Job> GetAll();

        IEnumerable<Job> GetAllSort(string sortItem);

        void Update(Job job);

        void SaveChanges();
    }

    public class JobService : IJobService
    {
        private IJobRepository _jobRepository;
        private IUnitOfWork _unitOfWork;

        public JobService(IJobRepository jobRepository, IUnitOfWork unitOfWork)
        {
            this._jobRepository = jobRepository;
            this._unitOfWork = unitOfWork;
        }

        public Job Add(Job job)
        {
            return _jobRepository.Add(job);
        }

        public Job Delete(int id)
        {
            return _jobRepository.Delete(id);
        }

        public void DeleteMultiById(int id)
        {
            _jobRepository.DeleteMulti(x => x.DepartmentID == id);
        }

        public IEnumerable<Job> GetAll()
        {
            return _jobRepository.GetAll(new string[] { "Department" });
        }

        public IEnumerable<Job> GetAllSort(string sortItem)
        {
            if (sortItem == "department")
            {
                return _jobRepository.GetAll(new string[] { "Department" }).OrderBy(x => x.Department);
            }
            else if (sortItem == "position")
            {
                return _jobRepository.GetAll(new string[] { "Department" }).OrderBy(x => x.Name);
            }
            else if (sortItem == "postedDate")
            {
                return _jobRepository.GetAll(new string[] { "Department" }).OrderByDescending(x => x.CreatedDate);
            }
            else
            {
                return _jobRepository.GetAll(new string[] { "Department" });
            }
        }

        public Job GetById(int id)
        {
            return _jobRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Job job)
        {
            _jobRepository.Update(job);
        }
    }
}