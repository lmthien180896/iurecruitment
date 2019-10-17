using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IUR.Model.Models;
using IUR.Web.Models;

namespace IUR.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateDepartment(this Department department, DepartmentViewModel departmentVm)
        {
            department.ID = departmentVm.ID;
            department.Name = departmentVm.Name;

            department.UpdatedDate = departmentVm.UpdatedDate;
            department.UpdatedBy = departmentVm.UpdatedBy;
            department.MetaKeyword = departmentVm.MetaKeyword;
            department.MetaDescription = departmentVm.MetaDescription;
            department.Status = departmentVm.Status;

        }

        public static void UpdateJob(this Job job, JobViewModel jobVm)
        {
            job.ID = jobVm.ID;
            job.Name = jobVm.Name;
            job.TimeType = jobVm.TimeType;
            job.EmployeeType = jobVm.EmployeeType;
            job.DepartmentID = jobVm.DepartmentID;
            job.Requirement = jobVm.Requirement;
            job.Description = jobVm.Description;
            job.Deadline = jobVm.Deadline;
            job.UpdatedDate = jobVm.UpdatedDate;
            job.UpdatedBy = jobVm.UpdatedBy;
            job.MetaKeyword = jobVm.MetaKeyword;
            job.MetaDescription = jobVm.MetaDescription;
            job.Status = jobVm.Status;
        }
    }
}