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

        public static void UpdateApplicantJob(this ApplicantJob applicantJob, ApplicantJobViewModel applicantJobVm)
        {
            applicantJob.JobID = applicantJobVm.JobID;
            applicantJob.ApplicantID = applicantJobVm.ApplicantID;
        }

        public static void UpdateUser(this User user, UserViewModel userVm)
        {
            user.ID = userVm.ID;
            user.Username = userVm.Username;
            user.HashedPassword = userVm.HashedPassword;
            user.Fullname = userVm.Fullname;
            user.Phone = userVm.Phone;
            user.Status = userVm.Status;
            user.CreatedDate = userVm.CreatedDate;
            user.CreatedBy = userVm.CreatedBy;
            user.UpdatedDate = userVm.UpdatedDate;
        }

        public static void UpdateApplicantDetail(this ApplicantDetail applicantDetailVm, ApplicationViewModel applicationVm)
        {
            applicantDetailVm.ID = applicationVm.ApplicantID;
            applicantDetailVm.Title = applicationVm.Title;
            applicantDetailVm.Fullname = applicationVm.Fullname;
            applicantDetailVm.DOB = applicationVm.DOB;
            applicantDetailVm.PlaceOfBirth = applicationVm.PlaceOfBirth;            
            applicantDetailVm.Nationality = applicationVm.Nationality;            
            applicantDetailVm.ContactAddress = applicationVm.ContactAddress;            
            applicantDetailVm.PermanentAddress = applicationVm.PermanentAddress;            
            applicantDetailVm.Phone = applicationVm.Phone;            
            applicantDetailVm.Email = applicationVm.Email;            
            applicantDetailVm.IDCard = applicationVm.IDCard;            
            applicantDetailVm.IssuedDate = applicationVm.IssuedDate;            
            applicantDetailVm.IssuedPlace = applicationVm.IssuedPlace;                                    
            applicantDetailVm.Photo = applicationVm.Photo;                                    
        }
    }
}