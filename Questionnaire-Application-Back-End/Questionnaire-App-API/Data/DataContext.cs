namespace Questionnaire_App_API.Data
{
    public class DataContext : DbContext
    {
        #region Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        #endregion

        #region Database Connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=ProbeKITDB; Integrated Security=True; MultipleActiveResultSets=True; TrustServerCertificate=True;");
        }
        #endregion

        #region Database Sets
        public DbSet<User> Users { get; set; }

        public DbSet<Questionnaire> Questionnaires { get; set; }

        public DbSet<Question> Questions { get; set; }
        
        public DbSet<Answer> Answers { get; set; }
        #endregion
    }
}
