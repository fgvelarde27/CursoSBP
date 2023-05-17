using CursoSBP.Common.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoSBP.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        #region Define SQL Entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Schedule> schedules { get; set; }


        #endregion
    }
}
