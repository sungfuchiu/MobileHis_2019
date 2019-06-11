using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;

namespace MobileHis.Data
{
    public partial class MobileHISEntities : DbContext
    {
        public MobileHISEntities()
            : base("MobileHISEntities")
        {
            this.Configuration.LazyLoadingEnabled = true;
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            objectContext.SavingChanges += (sender, args) =>
            {
                var now = DateTime.Now;
                foreach (var entry in this.ChangeTracker.Entries<IDatedEntity>())
                {
                    var entity = entry.Entity;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreateDate= now;
                            entity.UpdateDate= now;
                            break;
                        case EntityState.Modified:
                            entity.UpdateDate = now;
                            break;
                    }
                }
                this.ChangeTracker.DetectChanges();
            };
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// auto update create at, by, update at, mod by
        /// </summary>
        /// <param name="user">user.name</param>
        /// <returns></returns>
        public int SaveChanges(string user)
        {
            RenewMacroColumn(user);
            return SaveChanges();
        }
        /// <summary>
        /// base save changes
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Exception raise = ex;
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                return -1;
            }
        }


        protected void RenewMacroColumn(string user)
        {
            foreach (var dbEntry in this.ChangeTracker.Entries())
            {
                switch (dbEntry.State)
                {

                    case EntityState.Added:
                        CreateWithValues(dbEntry, "GID", System.Guid.NewGuid());
                        CreateWithValues(dbEntry, "CreatedAt", System.DateTime.Now);

                        CreateWithValues(dbEntry, "ModBy", user);
                        CreateWithValues(dbEntry, "UpdatedAt", System.DateTime.Now);
                        break;

                    case EntityState.Modified:

                        CreateWithValues(dbEntry, "ModBy", user);
                        CreateWithValues(dbEntry, "UpdatedAt", System.DateTime.Now);
                        break;
                }
            }
        }

        private void CreateWithValues(System.Data.Entity.Infrastructure.DbEntityEntry dbEntry, string propertyName, object value)
        {
            if (dbEntry.CurrentValues.PropertyNames.Any(x => x == propertyName))
                dbEntry.Property(propertyName).CurrentValue = value;
        }

        #region DbSet
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Account2Dept> Account2Dept { get; set; }
        public virtual DbSet<Account2Role> Account2Role { get; set; }
        public virtual DbSet<Ap2Role> Ap2Role { get; set; }
        public virtual DbSet<CodeFile> CodeFile { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Course_Exam> Course_Exam { get; set; }
        public virtual DbSet<Course_Exam_Answer> Course_Exam_Answer { get; set; }
        public virtual DbSet<Course_Exam_AnswerImage> Course_Exam_AnswerImage { get; set; }
        public virtual DbSet<Course_Exam_Question> Course_Exam_Question { get; set; }
        public virtual DbSet<Course_Exam_QuestionImage> Course_Exam_QuestionImage { get; set; }
        public virtual DbSet<CourseAttachment> CourseAttachment { get; set; }
        public virtual DbSet<CourseDateTime> CourseDateTime { get; set; }
        public virtual DbSet<CourseLog> CourseLog { get; set; }
        public virtual DbSet<CourseMember> CourseMember { get; set; }
        public virtual DbSet<CourseRegistration> CourseRegistration { get; set; }
        public virtual DbSet<CourseSetting> CourseSetting { get; set; }
        public virtual DbSet<CourseSignUp> CourseSignUp { get; set; }
        public virtual DbSet<CourseTested> CourseTested { get; set; }
        public virtual DbSet<CourseTestPaper> CourseTestPaper { get; set; }
        public virtual DbSet<CourseYoutube> CourseYoutube { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Dept2Room> Dept2Room { get; set; }
        public virtual DbSet<DialysisBeds> DialysisBeds { get; set; }
        public virtual DbSet<DorSchedule> DorSchedule { get; set; }
        public virtual DbSet<Drug> Drug { get; set; }
        public virtual DbSet<DrugAppearance> DrugAppearance { get; set; }
        public virtual DbSet<DrugCost> DrugCost { get; set; }
        public virtual DbSet<DrugOrderRestriction> DrugOrderRestriction { get; set; }
        public virtual DbSet<DrugRestriction> DrugRestriction { get; set; }
        public virtual DbSet<DrugSetting> DrugSetting { get; set; }
        public virtual DbSet<DrugVendor> DrugVendor { get; set; }
        public virtual DbSet<DrugStock> DrugStock { get; set; }
        public virtual DbSet<ExamReport> ExamReport { get; set; }
        public virtual DbSet<ICD10> ICD10 { get; set; }
        public virtual DbSet<ICD10Favorites> ICD10Favorites { get; set; }
        public virtual DbSet<Kit> Kit { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NotifyMessage> NotifyMessage { get; set; }
        public virtual DbSet<OpdRecord> OpdRecord { get; set; }
        public virtual DbSet<OpdRecordAttachment> OpdRecordAttachment { get; set; }
        public virtual DbSet<OpdRecord2ICD10> OpdRecord2ICD10 { get; set; }
        public virtual DbSet<OpdRegister> OpdRegister { get; set; }
        public virtual DbSet<OpdRecordHistory> OpdRecordHistory { get; set; }
        public virtual DbSet<OrderDrug> OrderDrug { get; set; }
        public virtual DbSet<OrderExam> OrderExam { get; set; }
        public virtual DbSet<OrderKit> OrderKit { get; set; }
        public virtual DbSet<OrderLaboratory> OrderLaboratory { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientAdmissionForm> PatientAdmissionForm { get; set; }
        public virtual DbSet<PatientFinalDiagnosis> PatientFinalDiagnosis { get; set; }
        public virtual DbSet<PatientOperativeProcedure> PatientOperativeProcedure { get; set; }
        public virtual DbSet<Phrase> Phrase { get; set; }
        public virtual DbSet<PosTransactionD> PosTransactionD { get; set; }
        public virtual DbSet<PosTransactionM> PosTransactionM { get; set; }
        public virtual DbSet<PurchaseD> PurchaseD { get; set; }
        public virtual DbSet<PurchaseM> PurchaseM { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<TestAnswer> TestAnswer { get; set; }
        public virtual DbSet<TestAnswerImage> TestAnswerImage { get; set; }
        public virtual DbSet<TestPaper> TestPaper { get; set; }
        public virtual DbSet<TestQuestion> TestQuestion { get; set; }
        public virtual DbSet<TestQuestionImage> TestQuestionImage { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<VitalSign> VitalSign { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<HealthEdu> HealthEdu { get; set; }
        public virtual DbSet<HealthEdu_File> HealthEdu_File { get; set; }

        public virtual DbSet<Billing> Billing { get; set; }
        public virtual DbSet<BillingItemLog> BillingItemLog { get; set; }
        public virtual DbSet<BillingLog> BillingLog { get; set; }
        public virtual DbSet<MedicalRecord> MedicalRecord { get; set; }

        public virtual DbSet<PrintPool> PrintPool { get; set; }

        public virtual DbSet<SystemLog> SystemLog { get; set; }

        public virtual DbSet<PatientLog> PatientLog { get; set; }
        public virtual DbSet<Ward2Room> Ward2Room { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }

        #endregion
    }
}