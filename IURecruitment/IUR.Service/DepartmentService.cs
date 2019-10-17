using IUR.Data.Infrastructure;
using IUR.Data.Repositories;
using IUR.Model.Models;
using System.Collections.Generic;

namespace IUR.Service
{
    public interface IDepartmentService
    {
        Department Add(Department department);

        void Update(Department department);

        Department Delete(int id);

        Department GetById(int id);

        IEnumerable<Department> GetAll();

        Department CheckExistedName(string name);

        void SaveChanges();
    }

    public class DepartmentService : IDepartmentService
    {
        private IUnitOfWork _unitOfWork;
        private IDepartmentRepository _departmentRepository;
        private IJobService _jobService;

        public DepartmentService(IUnitOfWork unitOfWork, IJobService jobService, IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
            this._jobService = jobService;
            this._unitOfWork = unitOfWork;
        }

        public Department Add(Department department)
        {
            return _departmentRepository.Add(department);
        }

        public Department CheckExistedName(string name)
        {
            return _departmentRepository.GetSingleByCondition(x => x.Name == name);
        }

        public Department Delete(int id)
        {
            var department = _departmentRepository.Delete(id);
            _jobService.DeleteMultiById(id);
            return department;
        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        public Department GetById(int id)
        {
            return _departmentRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Department department)
        {
            _departmentRepository.Update(department);
        }
    }
}