using AutoMapper;
using IUR.Model.Models;
using IUR.Service;
using IUR.Web.Areas.Admin.Models;
using IUR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IUR.Web.Areas.Admin.Controllers
{
    public class ApplicationController : BaseController
    {
        IJobService _jobService;
        IDepartmentService _departmentService;
        IApplicantDetailService _applicantDetailService;
        IApplicantJobService _applicantJobService;
        ICareerObjectiveService _careerObjectiveService;
        IEducationBackgroundService _educationBackgroundService;
        IRankService _rankService;
        ILanguageService _languageService;
        IComputerSkillService _computerSkillService;
        IOtherSkillService _otherSkillService;
        IEmploymentHistoryService _employmentHistoryService;
        IOtherQuestionService _otherQuestionService;
        IResumeService _resumeService;

        public ApplicationController(IResumeService resumeService, IOtherQuestionService otherQuestionService, IEmploymentHistoryService employmentHistoryService, IOtherSkillService otherSkillService, IComputerSkillService computerSkillService, ILanguageService languageService, IRankService rankService, IEducationBackgroundService educationBackgroundService, ICareerObjectiveService careerObjectiveService, IApplicantJobService applicantJobService, IJobService jobService, IDepartmentService departmentService, IApplicantDetailService applicantDetailService)
        {
            this._applicantDetailService = applicantDetailService;
            this._jobService = jobService;
            this._departmentService = departmentService;
            this._applicantJobService = applicantJobService;
            this._educationBackgroundService = educationBackgroundService;
            this._careerObjectiveService = careerObjectiveService;
            this._rankService = rankService;
            this._languageService = languageService;
            this._computerSkillService = computerSkillService;
            this._otherSkillService = otherSkillService;
            this._employmentHistoryService = employmentHistoryService;
            this._otherQuestionService = otherQuestionService;
            this._resumeService = resumeService;
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult LoadApplications(string sortItem)
        {
            List<ApplicationTableViewModel> listApplicationTableVm = new List<ApplicationTableViewModel>();
            var listApplicantDetail = _applicantDetailService.GetAll();
            foreach (var applicant in listApplicantDetail)
            {
                ApplicationTableViewModel applicationTableVm = new ApplicationTableViewModel();
                applicationTableVm.ApplicantID = applicant.ID;
                applicationTableVm.Fullname = applicant.Fullname;
                applicationTableVm.AppliedDate = applicant.CreatedDate.Value.ToString("dd/MM/yyyy");
                var jobID = _applicantJobService.GetByApplicantId(applicant.ID).JobID;
                var job = _jobService.GetById(jobID);
                applicationTableVm.Position = job.Name;
                applicationTableVm.Department = _departmentService.GetById(job.DepartmentID).Name;
                applicationTableVm.ResumeURL = _resumeService.GetById(applicant.ID).ResumeUrl;
                listApplicationTableVm.Add(applicationTableVm);
            }
            return Json(new
            {
                data = listApplicationTableVm,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewApplicant(int id)
        {
            var applicantDetail = _applicantDetailService.GetById(id);
            ApplicantDetailViewModel applicationVm = new ApplicantDetailViewModel();
            applicationVm = Mapper.Map<ApplicantDetail, ApplicantDetailViewModel>(applicantDetail);
            applicationVm.ApplicantJob = _applicantJobService.GetByApplicantId(id);
            applicationVm.CareerObjective = _careerObjectiveService.GetById(id);
            applicationVm.EducationBackgrounds = _educationBackgroundService.GetAllByApplicantID(id);
            applicationVm.Rank = _rankService.GetById(id);
            applicationVm.Languages = _languageService.GetAllByApplicantID(id);
            applicationVm.ComputerSkills = _computerSkillService.GetAllByApplicantID(id);
            applicationVm.OtherSkills = _otherSkillService.GetAllByApplicantID(id);
            applicationVm.EmploymentHistories = _employmentHistoryService.GetAllByApplicantID(id);
            applicationVm.OtherQuestion = _otherQuestionService.GetById(id);
            applicationVm.Resume = _resumeService.GetById(id);
            return View(applicationVm);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = false
                });
            }
            else
            {
                DeleteApplicant(id);
                return Json(new
                {
                    message = "Delete successfully",
                    status = true
                });
            }
        }

        public void DeleteApplicant(int applicantId)
        {
            _applicantJobService.DeleteByApplicantId(applicantId);
            _careerObjectiveService.Delete(applicantId);
            _educationBackgroundService.DeleteByApplicantId(applicantId);
            _rankService.Delete(applicantId);
            _languageService.DeleteByApplicantId(applicantId);
            _computerSkillService.DeleteByApplicantId(applicantId);
            _otherSkillService.DeleteByApplicantId(applicantId);
            _employmentHistoryService.DeleteByApplicantId(applicantId);
            _otherQuestionService.Delete(applicantId);
            _resumeService.Delete(applicantId);
            _applicantDetailService.Delete(applicantId);

            _applicantJobService.SaveChanges();
            _careerObjectiveService.SaveChanges();
            _educationBackgroundService.SaveChanges();
            _rankService.SaveChanges();
            _languageService.SaveChanges();
            _computerSkillService.SaveChanges();
            _otherSkillService.SaveChanges();
            _employmentHistoryService.SaveChanges();
            _otherQuestionService.SaveChanges();
            _resumeService.SaveChanges();
            _applicantDetailService.SaveChanges();

        }

        [HttpPost]
        public JsonResult DeleteAll(string listId)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var Ids = serializer.Deserialize<string>(listId);
            int countDelete = 0;
            foreach (var id in Ids.Split('-'))
            {
                if (!string.IsNullOrEmpty(id))
                {
                    DeleteApplicant(int.Parse(id));
                    countDelete++;
                }
            }
            _applicantDetailService.SaveChanges();
            return Json(new
            {
                message = "Delete " + countDelete + " applications successfully",
                status = true
            });
        }
    }
}