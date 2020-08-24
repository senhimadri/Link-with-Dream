using System;
using System.Collections.Generic;
using System.Text;
using Link_with_Dream.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Link_with_Dream.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Link_with_Dream.Models.AcademicQualification> AcademicQualification { get; set; }
        public DbSet<Link_with_Dream.Models.CandidateAnswer> CandidateAnswer { get; set; }
        public DbSet<Link_with_Dream.Models.CareerInformation> CareerInformation { get; set; }
        public DbSet<Link_with_Dream.Models.ChatMessege> ChatMessege { get; set; }
        public DbSet<Link_with_Dream.Models.Company> Company { get; set; }
        public DbSet<Link_with_Dream.Models.CompanyPeople> CompanyPeople { get; set; }
        public DbSet<Link_with_Dream.Models.Complaint> Complaint { get; set; }
        public DbSet<Link_with_Dream.Models.ContentComents> ContentComents { get; set; }
        public DbSet<Link_with_Dream.Models.ContentLike> ContentLike { get; set; }
        public DbSet<Link_with_Dream.Models.ContentPost> ContentPost { get; set; }
        public DbSet<Link_with_Dream.Models.ExamQuestion> ExamQuestion { get; set; }
        public DbSet<Link_with_Dream.Models.Friendship> Friendship { get; set; }
        public DbSet<Link_with_Dream.Models.Group> Group { get; set; }
        public DbSet<Link_with_Dream.Models.GroupPeople> GroupPeople { get; set; }
        public DbSet<Link_with_Dream.Models.Notification> Notification { get; set; }
        public DbSet<Link_with_Dream.Models.ProfessionalSkill> ProfessionalSkill { get; set; }
        public DbSet<Link_with_Dream.Models.Project> Project { get; set; }
        public DbSet<Link_with_Dream.Models.QuestionAnswer> QuestionAnswer { get; set; }
        public DbSet<Link_with_Dream.Models.SpecialQualification> SpecialQualification { get; set; }
        public DbSet<Link_with_Dream.Models.WorkingExperience> WorkingExperience { get; set; }
    }
}
