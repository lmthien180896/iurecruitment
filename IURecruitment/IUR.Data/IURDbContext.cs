using IUR.Model.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IUR.Data
{
    public class IURDbContext : DbContext
    {
        public IURDbContext() : base("IURConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<ApplicantDetail> ApplicantDetails { get; set; }
        public DbSet<CareerObjective> CareerObjectives { get; set; }
        public DbSet<ComputerSkill> ComputerSkills { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EducationBackground> EducationBackgrounds { get; set; }
        public DbSet<EmploymentHistory> EmploymentHistorys { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<OtherQuestion> OtherQuestions { get; set; }
        public DbSet<OtherSkill> OtherSkills { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<SystemConfig> SystemConfig { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }
        public DbSet<ApplicantJob> ApplicantJobs { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<User> Users { get; set; }


        public static IURDbContext Create()
        {
            return new IURDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {            
        }
    }
}
