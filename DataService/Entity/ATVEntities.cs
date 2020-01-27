namespace DataService.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ATVEntities : DbContext
    {
        public ATVEntities()
            : base("name=ATVEntities")
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleEmployee> ArticleEmployee { get; set; }
        public virtual DbSet<ArticlePointType> ArticlePointType { get; set; }
        public virtual DbSet<ArticleType> ArticleType { get; set; }
        public virtual DbSet<BusinessLog> BusinessLog { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<Criteria> Criteria { get; set; }
        public virtual DbSet<CriteriaValue> CriteriaValue { get; set; }
        public virtual DbSet<Deduction> Deduction { get; set; }
        public virtual DbSet<DeductionType> DeductionType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Point> Point { get; set; }
        public virtual DbSet<PointType> PointType { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleHasMenuItem> RoleHasMenuItem { get; set; }
        public virtual DbSet<SystemLog> SystemLog { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ArticleType>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ArticleType>()
                .HasMany(e => e.Article)
                .WithRequired(e => e.ArticleType)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ArticleType>()
                .HasMany(e => e.ArticlePointType)
                .WithRequired(e => e.ArticleType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<MenuItem>()
                .HasMany(e => e.RoleHasMenuItem)
                .WithRequired(e => e.MenuItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PointType>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<PointType>()
                .HasMany(e => e.ArticlePointType)
                .WithRequired(e => e.PointType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PointType>()
                .HasMany(e => e.Point)
                .WithOptional(e => e.PointType)
                .HasForeignKey(e => e.Type);

            modelBuilder.Entity<Position>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Employee)
                .WithOptional(e => e.Position)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.RoleHasMenuItem)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Configuration>()
                .HasMany(e => e.CriteriaValue)
                .WithRequired(e => e.Configuration)
                .WillCascadeOnDelete(true);
        }
    }
}
