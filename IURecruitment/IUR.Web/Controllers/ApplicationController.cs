using IUR.Common;
using IUR.Controllers;
using IUR.Model.Models;
using IUR.Service;
using IUR.Web.Infrastructure.Extensions;
using IUR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IUR.Web.Controllers
{
    public class ApplicationController : BaseController
    {
        private IJobService _jobService;
        private IDepartmentService _departmentService;
        private IApplicantDetailService _applicantDetailService;
        private IApplicantJobService _applicantJobService;
        private ICareerObjectiveService _careerObjectiveService;
        private IEducationBackgroundService _educationBackgroundService;
        private IRankService _rankService;
        private ILanguageService _languageService;
        private IComputerSkillService _computerSkillService;
        private IOtherSkillService _otherSkillService;
        private IEmploymentHistoryService _employmentHistoryService;
        private IOtherQuestionService _otherQuestionService;
        private IResumeService _resumeService;

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

        public ActionResult ApplyForm(int jobid)
        {
            ViewBag.JobID = jobid;
            var job = _jobService.GetById(jobid);
            ViewBag.JobName = job.Name;
            ViewBag.Department = _departmentService.GetById(job.DepartmentID).Name;
            return View();
        }

        public ApplicantDetail AddApplicantDetail(ApplicationViewModel applicationVm, HttpPostedFileBase filePhoto)
        {
            string physicalPath = "";
            if (filePhoto == null)
            {
                applicationVm.Photo = "/Assets/client/img/default-user.png";
            }
            else
            {
                string extension = System.IO.Path.GetExtension(filePhoto.FileName);
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png") //chỉ lấy đuôi hình ảnh
                {
                    string photoname = System.IO.Path.GetFileName(filePhoto.FileName);
                    physicalPath = Server.MapPath("~/UploadedFiles/ApplicantPhoto/" + photoname);
                    applicationVm.Photo = "/UploadedFiles/ApplicantPhoto/" + photoname;
                }
                else
                {
                    applicationVm.Photo = "/Assets/client/img/default-user.png";
                }
            }

            ApplicantDetail applicantDetail = new ApplicantDetail();
            applicantDetail.UpdateApplicantDetail(applicationVm);
            applicantDetail.CreatedDate = DateTime.Now;
            TryValidateModel(applicantDetail);
            if (ModelState.IsValid)
            {
                var newApplicantDetail = _applicantDetailService.Add(applicantDetail);
                _applicantJobService.SaveChanges();
                //save photo in a folder if add ApplicantDetail success
                filePhoto.SaveAs(physicalPath);
                return newApplicantDetail;
            }
            else
            {
                return null;
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

        public int AddApplicantJob(int applicantID, int jobID)
        {
            ApplicantJob applicantJob = new ApplicantJob();
            applicantJob.ApplicantID = applicantID;
            applicantJob.JobID = jobID;
            TryValidateModel(applicantJob);
            if (ModelState.IsValid)
            {
                var newApplicantJob = _applicantJobService.Add(applicantJob);
                _applicantJobService.SaveChanges();
                return newApplicantJob.ID;
            }
            else
            {
                DeleteApplicant(applicantID);
                return -1;
            }
        }

        public int AddCareerObjective(int applicantID, CareerObjective inputCareerObjective)
        {
            CareerObjective careerObjective = new CareerObjective();
            careerObjective.ID = applicantID;
            careerObjective.Objective = inputCareerObjective.Objective;
            TryValidateModel(careerObjective);
            if (ModelState.IsValid)
            {
                var newCareerObjective = _careerObjectiveService.Add(careerObjective);
                _careerObjectiveService.SaveChanges();
                return newCareerObjective.ID;
            }
            else
            {
                DeleteApplicant(applicantID);
                return -1;
            }
        }

        public int AddEducationBackground(int applicantID, List<EducationBackground> listEducationBackground)
        {
            var id = 0;
            foreach (var educationBackground in listEducationBackground)
            {
                educationBackground.ApplicantID = applicantID;
                TryValidateModel(educationBackground);
                if (ModelState.IsValid)
                {
                    var newEducationBackground = _educationBackgroundService.Add(educationBackground);
                    _educationBackgroundService.SaveChanges();
                    id = newEducationBackground.ID;
                }
                else
                {
                    DeleteApplicant(applicantID);
                    id = -1;
                    break;
                }
            }

            return id;
        }

        public int AddRank(int applicantID, string rankName)
        {
            Rank rank = new Rank();
            rank.ID = applicantID;
            rank.Name = rankName;
            TryValidateModel(rank);
            if (ModelState.IsValid)
            {
                var newRank = _rankService.Add(rank);
                return newRank.ID;
            }
            else
            {
                DeleteApplicant(applicantID);
                return -1;
            }
        }

        public int AddLanguage(int applicantID, List<Language> listLanguage)
        {
            var id = 0;
            foreach (var language in listLanguage)
            {
                language.ApplicantID = applicantID;
                TryValidateModel(language);
                if (ModelState.IsValid)
                {
                    var newLanguage = _languageService.Add(language);
                    _languageService.SaveChanges();
                    id = newLanguage.ID;
                }
                else
                {
                    DeleteApplicant(applicantID);
                    id = -1;
                    break;
                }
            }

            return id;
        }

        public int AddComputerSkill(int applicantID, List<ComputerSkill> listComputerSkill)
        {
            var id = 0;
            foreach (var computerSkill in listComputerSkill)
            {
                computerSkill.ApplicantID = applicantID;
                TryValidateModel(computerSkill);
                if (ModelState.IsValid)
                {
                    var newComputerSkill = _computerSkillService.Add(computerSkill);
                    _computerSkillService.SaveChanges();
                    id = newComputerSkill.ID;
                }
                else
                {
                    DeleteApplicant(applicantID);
                    id = -1;
                    break;
                }
            }

            return id;
        }

        public int AddOtherSkill(int applicantID, List<OtherSkill> listOtherSkill)
        {
            var id = 0;
            foreach (var otherSkill in listOtherSkill)
            {
                otherSkill.ApplicantID = applicantID;
                TryValidateModel(otherSkill);
                if (ModelState.IsValid)
                {
                    var newOtherSkill = _otherSkillService.Add(otherSkill);
                    _otherSkillService.SaveChanges();
                    id = newOtherSkill.ID;
                }
                else
                {
                    DeleteApplicant(applicantID);
                    id = -1;
                    break;
                }
            }

            return id;
        }

        public int AddEmploymentHistory(int applicantID, List<EmploymentHistory> listEmploymentHistory)
        {
            var id = 0;
            foreach (var employmentHistory in listEmploymentHistory)
            {
                employmentHistory.ApplicantID = applicantID;
                TryValidateModel(employmentHistory);
                if (ModelState.IsValid)
                {
                    var newEmploymentHistory = _employmentHistoryService.Add(employmentHistory);
                    _employmentHistoryService.SaveChanges();
                    id = newEmploymentHistory.ID;
                }
                else
                {
                    DeleteApplicant(applicantID);
                    id = -1;
                    break;
                }
            }

            return id;
        }

        public int AddOtherQuestion(int applicantID, OtherQuestion inputOtherQuestion)
        {
            OtherQuestion otherQuestion = new OtherQuestion();
            otherQuestion.ID = applicantID;
            otherQuestion.Available = inputOtherQuestion.Available;
            otherQuestion.IsApplied = inputOtherQuestion.IsApplied;
            otherQuestion.IsInformed = inputOtherQuestion.IsInformed;
            TryValidateModel(otherQuestion);
            if (ModelState.IsValid)
            {
                var newOtherQuestion = _otherQuestionService.Add(otherQuestion);
                return newOtherQuestion.ID;
            }
            else
            {
                DeleteApplicant(applicantID);
                return -1;
            }
        }

        public int AddResume(int applicantID, HttpPostedFileBase fileResume)
        {
            string physicalPath = "";
            Resume resume = new Resume();
            resume.ID = applicantID;
            string extension = System.IO.Path.GetExtension(fileResume.FileName);
            if (extension == ".pdf")
            {
                string PdfFileName = System.IO.Path.GetFileName(fileResume.FileName);
                physicalPath = Server.MapPath("~/UploadedFiles/Resume/" + PdfFileName);
                resume.ResumeUrl = "/UploadedFiles/Resume/" + PdfFileName;
            }
            else
            {
                resume.ResumeUrl = null;
            }
            TryValidateModel(resume);
            if (ModelState.IsValid)
            {
                var newResume = _resumeService.Add(resume);
                _resumeService.SaveChanges();
                //save photo in a folder
                fileResume.SaveAs(physicalPath);
                return newResume.ID;
            }
            else
            {
                DeleteApplicant(applicantID);
                return -1;
            }
        }

        public RedirectToRouteResult InvalidApplyForm(string message, int jobID)
        {
            SetAlert(message, "error");
            return RedirectToAction("ApplyForm", new { jobid = jobID });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitApplication(HttpPostedFileBase[] files, ApplicationViewModel applicationVm, ApplicantJobViewModel applicantJobVm)
        {
            var jobID = applicantJobVm.JobID;

            var newApplicantDetail = AddApplicantDetail(applicationVm, files[0]);
            if (newApplicantDetail == null)
            {
                SetAlert("Please enter valid Personal Information", "error");
                return RedirectToAction("ApplyForm", new { jobid = jobID });
            }
            var applicantID = newApplicantDetail.ID;

            var applicantJobId = AddApplicantJob(applicantID, jobID);
            if (applicantJobId < 0)
            {
                InvalidApplyForm("There are some problem in Applicant Job", jobID);
            }

            var careerObjectiveID = AddCareerObjective(applicantID, applicationVm.CareerObjective);
            if (careerObjectiveID < 0)
            {
                InvalidApplyForm("Please enter Career Objectives", jobID);
            }

            List<EducationBackground> listEducationBacground = new List<EducationBackground>();
            var listEduLevel = Request.Form.GetValues("EducationBackgroundVm.Level");
            var listEduSchool = Request.Form.GetValues("EducationBackgroundVm.School");
            var listEduCountry = Request.Form.GetValues("EducationBackgroundVm.Country");
            var listEduMajor = Request.Form.GetValues("EducationBackgroundVm.Major");
            var listEduGraduatedDate = Request.Form.GetValues("EducationBackgroundVm.GraduatedDate");
            for (int i = 0; i < listEduLevel.Count(); i++)
            {
                if (!string.IsNullOrEmpty(listEduSchool[i]) && !string.IsNullOrEmpty(listEduCountry[i]) && !string.IsNullOrEmpty(listEduMajor[i])) // Nếu applicant điền vào mục Education Background
                {
                    try
                    {
                        EducationBackground educationBackground = new EducationBackground();
                        educationBackground.Level = listEduLevel[i];
                        educationBackground.School = listEduSchool[i];
                        educationBackground.Country = listEduCountry[i];
                        educationBackground.Major = listEduMajor[i];
                        educationBackground.GraduatedDate = DateTime.ParseExact(listEduGraduatedDate[i], "yyyy-MM-dd", null);
                        listEducationBacground.Add(educationBackground);
                    }
                    catch
                    {
                    }
                }
            }
            var educationBackgroundID = AddEducationBackground(applicantID, listEducationBacground);
            if (educationBackgroundID < 0)
            {
                InvalidApplyForm("Please enter valid Education Background", jobID);
            }

            var rankID = AddRank(applicantID, applicationVm.Rank.Name);
            if (rankID < 0)
            {
                InvalidApplyForm("There are some problem in Rank", jobID);
            }

            List<Language> listLanguage = new List<Language>();
            var listLanguageCertificate = Request.Form.GetValues("Language.Certificate");
            var listLanguageLevel = Request.Form.GetValues("Language.Level");
            for (int i = 0; i < listLanguageCertificate.Length; i++)
            {
                if (!string.IsNullOrEmpty(listLanguageCertificate[i]) && !string.IsNullOrEmpty(listLanguageLevel[i]))
                {
                    Language language = new Language();
                    language.Certificate = listLanguageCertificate[i];
                    language.Level = listLanguageLevel[i];
                    listLanguage.Add(language);
                }
            }
            var newLanguageID = AddLanguage(applicantID, listLanguage);
            if (newLanguageID < 0)
            {
                InvalidApplyForm("Please enter valid Languages", jobID);
            }

            List<ComputerSkill> listComputerSkill = new List<ComputerSkill>();
            var ListComputerSkillSoftware = Request.Form.GetValues("ComputerSkill.Software");
            var ListComputerSkillLevel = Request.Form.GetValues("ComputerSkill.Level");
            for (int i = 0; i < ListComputerSkillSoftware.Length; i++)
            {
                if (!string.IsNullOrEmpty(ListComputerSkillSoftware[i]) && !string.IsNullOrEmpty(ListComputerSkillLevel[i]))
                {
                    ComputerSkill computerSkill = new ComputerSkill();
                    computerSkill.Software = ListComputerSkillSoftware[i];
                    computerSkill.Level = ListComputerSkillLevel[i];
                    listComputerSkill.Add(computerSkill);
                }
            }
            var newComputerSkillID = AddComputerSkill(applicantID, listComputerSkill);
            if (newComputerSkillID < 0)
            {
                InvalidApplyForm("Please enter valid Computer Skills", jobID);
            }

            List<OtherSkill> listOtherSkill = new List<OtherSkill>();
            var listSkill = Request.Form.GetValues("OtherSkill.Skill");
            var listOtherSkillReference = Request.Form.GetValues("OtherSkill.Reference");
            for (int i = 0; i < listSkill.Length; i++)
            {
                if (!string.IsNullOrEmpty(listSkill[i]) && !string.IsNullOrEmpty(listOtherSkillReference[i]))
                {
                    OtherSkill otherSkill = new OtherSkill();
                    otherSkill.Skill = listSkill[i];
                    otherSkill.Reference = listOtherSkillReference[i];
                    listOtherSkill.Add(otherSkill);
                }
            }
            var newOtherSkillID = AddOtherSkill(applicantID, listOtherSkill);
            if (newOtherSkillID < 0)
            {
                InvalidApplyForm("Please enter valid Other Skills", jobID);
            }

            List<EmploymentHistory> listEmploymentHistory = new List<EmploymentHistory>();
            var ListEmploymentHistoryFromDate = Request.Form.GetValues("EmploymentHistory.FromDate");
            var ListEmploymentHistoryToDate = Request.Form.GetValues("EmploymentHistory.ToDate");
            var ListEmploymentHistoryCompany = Request.Form.GetValues("EmploymentHistory.Company");
            var ListEmploymentHistoryPosition = Request.Form.GetValues("EmploymentHistory.Position");
            var ListEmploymentHistoryDescription = Request.Form.GetValues("EmploymentHistory.Description");
            var ListEmploymentHistoryLeavingReason = Request.Form.GetValues("EmploymentHistory.LeavingReason");
            for (int i = 0; i < ListEmploymentHistoryCompany.Length; i++)
            {
                if (!string.IsNullOrEmpty(ListEmploymentHistoryCompany[i]) && !string.IsNullOrEmpty(ListEmploymentHistoryPosition[i]) && !string.IsNullOrEmpty(ListEmploymentHistoryDescription[i]) && !string.IsNullOrEmpty(ListEmploymentHistoryLeavingReason[i]))
                {
                    try
                    {
                        EmploymentHistory employmentHistory = new EmploymentHistory();
                        employmentHistory.FromDate = DateTime.ParseExact(ListEmploymentHistoryFromDate[i], "yyyy-MM-dd", null);
                        employmentHistory.ToDate = DateTime.ParseExact(ListEmploymentHistoryToDate[i], "yyyy-MM-dd", null);
                        employmentHistory.Company = ListEmploymentHistoryCompany[i];
                        employmentHistory.Position = ListEmploymentHistoryPosition[i];
                        employmentHistory.Description = ListEmploymentHistoryDescription[i];
                        employmentHistory.LeavingReason = ListEmploymentHistoryLeavingReason[i];
                        listEmploymentHistory.Add(employmentHistory);
                    }
                    catch { }
                }
            }
            var newEmploymentHistoryID = AddEmploymentHistory(applicantID, listEmploymentHistory);
            if (newEmploymentHistoryID < 0)
            {
                InvalidApplyForm("Please enter valid Employment History", jobID);
            }

            var otherQuestionID = AddOtherQuestion(applicantID, applicationVm.OtherQuestion);
            if (otherQuestionID < 0)
            {
                InvalidApplyForm("There are some problems in Other Question", jobID);
            }

            var newResumeID = AddResume(applicantID, files[1]);
            if (newResumeID < 0)
            {
                InvalidApplyForm("Please upload a valid Resume", jobID);
            }

            var filepath = ConfigHelper.GetByKey("ConfirmSendingApplication");
            var content = System.IO.File.ReadAllText(Server.MapPath(filepath));
            content = content.Replace("{{Sender}}", newApplicantDetail.Fullname);
            MailHelper.SendMail(newApplicantDetail.Email, "IU Recruitment", content);
            SetAlert("Your application has been sent", "success");
            return RedirectToAction("JobListing", "Job");
        }
    }
}