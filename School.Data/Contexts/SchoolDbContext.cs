using System.Reflection;
using Microsoft.EntityFrameworkCore;
using School.Data.Entities;

namespace School.Data.Contexts
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<School_Class> School_Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<TeacherAttendance> TeacherAttendances { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<Fees> Fees { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}
