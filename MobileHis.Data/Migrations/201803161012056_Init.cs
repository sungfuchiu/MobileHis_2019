namespace MobileHis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserNo = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        Password = c.String(maxLength: 50),
                        Name = c.String(maxLength: 100),
                        Title_id = c.Int(),
                        Gender = c.String(maxLength: 1),
                        Birthday = c.DateTime(),
                        Tel = c.String(maxLength: 30),
                        IsLockedOut = c.String(maxLength: 1),
                        IsDoctor = c.String(maxLength: 1),
                        ImagePath = c.String(),
                        Comment = c.String(storeType: "ntext"),
                        Experience = c.String(storeType: "ntext"),
                        Major = c.String(storeType: "ntext"),
                        Status = c.String(maxLength: 50),
                        LastLoginDate = c.DateTime(),
                        CreateDate = c.DateTime(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        ModUser = c.String(maxLength: 100),
                        Card = c.String(maxLength: 20),
                        Dept_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dept", t => t.Dept_ID)
                .ForeignKey("dbo.CodeFile", t => t.Title_id)
                .Index(t => t.Title_id)
                .Index(t => t.Dept_ID);
            
            CreateTable(
                "dbo.Account2Dept",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DeptId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .ForeignKey("dbo.Dept", t => t.DeptId)
                .Index(t => t.DeptId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Dept",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        DepNo = c.String(nullable: false, maxLength: 2),
                        DepName = c.String(maxLength: 50),
                        IsRegistered = c.String(maxLength: 1),
                        CreateDate = c.DateTime(),
                        ModDate = c.DateTime(),
                        ModUser = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CodeFile", t => t.Category)
                .Index(t => t.Category);
            
            CreateTable(
                "dbo.CodeFile",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemType = c.String(maxLength: 2),
                        ItemCode = c.String(maxLength: 8),
                        ItemDescription = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 50),
                        CheckFlag = c.String(maxLength: 1),
                        CreateDate = c.DateTime(nullable: false),
                        ModDate = c.DateTime(),
                        ModUser = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DorSchedule",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SchDate = c.DateTime(nullable: false),
                        AccountID = c.Int(nullable: false),
                        ShiftNo = c.String(nullable: false, maxLength: 2),
                        DeptID = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        CancelReasonId = c.Int(),
                        CancelRemark = c.String(),
                        CreateDate = c.DateTime(),
                        ModDate = c.DateTime(),
                        ModUser = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.AccountID)
                .ForeignKey("dbo.CodeFile", t => t.CancelReasonId)
                .ForeignKey("dbo.Dept", t => t.DeptID)
                .ForeignKey("dbo.Room", t => t.RoomID)
                .Index(t => t.AccountID)
                .Index(t => t.DeptID)
                .Index(t => t.RoomID)
                .Index(t => t.CancelReasonId);
            
            CreateTable(
                "dbo.OpdRegister",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookingNo = c.String(maxLength: 12),
                        PatinetID = c.String(maxLength: 12),
                        OpdDate = c.DateTime(),
                        Deptid = c.Int(),
                        RoomID = c.Int(),
                        ShiftNo = c.String(maxLength: 2),
                        RegType = c.String(maxLength: 2),
                        RecStatus = c.String(maxLength: 1),
                        OpdStatus = c.String(maxLength: 1),
                        AdmissionNo = c.String(maxLength: 12),
                        ReferalNo = c.String(maxLength: 12),
                        Seq = c.Int(),
                        Remark = c.String(),
                        CreateDate = c.DateTime(),
                        ModDate = c.DateTime(),
                        ModUser = c.String(maxLength: 100),
                        DorScheduleId = c.Int(nullable: false),
                        OpdRecordID = c.Int(),
                        Diarrhea = c.Boolean(),
                        ILI = c.Boolean(),
                        Prolonged_Fever = c.Boolean(),
                        AFR = c.Boolean(),
                        NoneAll = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dept", t => t.Deptid)
                .ForeignKey("dbo.DorSchedule", t => t.DorScheduleId)
                .ForeignKey("dbo.OpdRecord", t => t.OpdRecordID)
                .ForeignKey("dbo.Patient", t => t.PatinetID)
                .ForeignKey("dbo.Room", t => t.RoomID)
                .Index(t => t.PatinetID)
                .Index(t => t.Deptid)
                .Index(t => t.RoomID)
                .Index(t => t.DorScheduleId)
                .Index(t => t.OpdRecordID);
            
            CreateTable(
                "dbo.OpdRecord",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50),
                        PatinetID = c.String(nullable: false, maxLength: 12),
                        DoctorID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        DeptID = c.Int(nullable: false),
                        Subjective = c.String(),
                        Objective = c.String(),
                        Assessment = c.String(),
                        Plan = c.String(),
                        Remark = c.String(),
                        PayStatus = c.Boolean(),
                        MedStatus = c.Boolean(),
                        MedCreatedAt = c.DateTime(),
                        SubmitedAt = c.DateTime(),
                        CreatedAt = c.DateTime(nullable: false),
                        LabIssueNo = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dept", t => t.DeptID)
                .ForeignKey("dbo.Account", t => t.DoctorID)
                .ForeignKey("dbo.Patient", t => t.PatinetID)
                .Index(t => t.PatinetID)
                .Index(t => t.DoctorID)
                .Index(t => t.DeptID);
            
            CreateTable(
                "dbo.OpdRecord2ICD10",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OpdRecordID = c.Int(nullable: false),
                        ICD10Code = c.String(nullable: false, maxLength: 10),
                        Index = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ICD10", t => t.ICD10Code)
                .ForeignKey("dbo.OpdRecord", t => t.OpdRecordID)
                .Index(t => t.OpdRecordID)
                .Index(t => t.ICD10Code);
            
            CreateTable(
                "dbo.ICD10",
                c => new
                    {
                        ICD10Code = c.String(nullable: false, maxLength: 10),
                        StdName = c.String(nullable: false),
                        Type = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.ICD10Code);
            
            CreateTable(
                "dbo.OpdRecordAttachment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpdRecordId = c.Int(nullable: false),
                        FileName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.CreateBy)
                .ForeignKey("dbo.OpdRecord", t => t.OpdRecordId)
                .Index(t => t.OpdRecordId)
                .Index(t => t.CreateBy);
            
            CreateTable(
                "dbo.OrderDrug",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RecordID = c.Int(nullable: false),
                        Dose = c.Double(nullable: false),
                        Unit = c.Int(nullable: false),
                        Frequency = c.Int(nullable: false),
                        Route = c.Int(nullable: false),
                        Days = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        Remark = c.String(nullable: false),
                        DrugID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drug", t => t.DrugID)
                .ForeignKey("dbo.OpdRecord", t => t.RecordID)
                .Index(t => t.RecordID)
                .Index(t => t.DrugID);
            
            CreateTable(
                "dbo.Drug",
                c => new
                    {
                        GID = c.Guid(nullable: false, identity: true),
                        OrderCode = c.String(nullable: false, maxLength: 50),
                        DrugCode = c.String(nullable: false, maxLength: 50),
                        ExamCode = c.String(maxLength: 20),
                        ExamModality = c.String(maxLength: 10),
                        Title = c.String(nullable: false, maxLength: 256),
                        Remark = c.String(),
                        DrugType = c.String(maxLength: 20),
                        IsHighRisk = c.Boolean(nullable: false),
                        IsPediatrics = c.Boolean(nullable: false),
                        StockAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.Int(),
                    })
                .PrimaryKey(t => t.GID);
            
            CreateTable(
                "dbo.DrugAppearance",
                c => new
                    {
                        DrugID = c.Guid(nullable: false),
                        MajorType = c.String(maxLength: 255),
                        Color = c.String(maxLength: 255),
                        Shape = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.DrugID)
                .ForeignKey("dbo.Drug", t => t.DrugID)
                .Index(t => t.DrugID);
            
            CreateTable(
                "dbo.DrugCost",
                c => new
                    {
                        GID = c.Guid(nullable: false, identity: true),
                        DrugID = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ver = c.String(maxLength: 2),
                        CreateAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.GID)
                .ForeignKey("dbo.Drug", t => t.DrugID)
                .Index(t => t.DrugID);
            
            CreateTable(
                "dbo.DrugOrderRestriction",
                c => new
                    {
                        GID = c.Guid(nullable: false),
                        DrugId = c.Guid(nullable: false),
                        RestrictName = c.String(nullable: false, maxLength: 255),
                        Data = c.String(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GID)
                .ForeignKey("dbo.Drug", t => t.DrugId)
                .Index(t => t.DrugId);
            
            CreateTable(
                "dbo.DrugRestriction",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DrugID = c.Guid(nullable: false),
                        RestraintID = c.Guid(nullable: false),
                        Grade = c.String(maxLength: 20),
                        Effect = c.String(maxLength: 1000),
                        ProcessingMethods = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drug", t => t.DrugID)
                .Index(t => t.DrugID);
            
            CreateTable(
                "dbo.DrugSetting",
                c => new
                    {
                        DrugID = c.Guid(nullable: false),
                        Dose = c.Double(nullable: false),
                        Unit = c.String(maxLength: 32),
                        Frequency = c.String(maxLength: 8),
                        Route = c.String(maxLength: 8),
                        Days = c.Int(),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DrugID)
                .ForeignKey("dbo.Drug", t => t.DrugID)
                .Index(t => t.DrugID);
            
            CreateTable(
                "dbo.DrugVendor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VendorID = c.Int(nullable: false),
                        DrugGID = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.Int(),
                        PurchaseRate = c.Int(nullable: false),
                        StockUsingRate = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        Creator = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drug", t => t.DrugGID)
                .ForeignKey("dbo.Vendor", t => t.VendorID)
                .Index(t => t.VendorID)
                .Index(t => t.DrugGID);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 20),
                        Name = c.String(maxLength: 50),
                        ShortName = c.String(nullable: false, maxLength: 20),
                        PayType = c.Int(),
                        Contact1 = c.String(maxLength: 20),
                        Contact2 = c.String(maxLength: 20),
                        Phone1 = c.String(maxLength: 20),
                        Phone2 = c.String(maxLength: 20),
                        Address = c.String(maxLength: 200),
                        Fax = c.String(maxLength: 20),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        Creator = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PosTransactionM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VendorID = c.Int(nullable: false),
                        DRNo = c.String(nullable: false, maxLength: 20),
                        InDate = c.DateTime(),
                        Flag = c.String(maxLength: 1),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        Creator = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vendor", t => t.VendorID)
                .Index(t => t.VendorID);
            
            CreateTable(
                "dbo.PosTransactionD",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PosTransactionMID = c.Int(nullable: false),
                        PurchaseDID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        Creator = c.Int(nullable: false),
                        AcceptancePosTransactionMID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PosTransactionM", t => t.PosTransactionMID)
                .ForeignKey("dbo.PurchaseD", t => t.PurchaseDID)
                .Index(t => t.PosTransactionMID)
                .Index(t => t.PurchaseDID);
            
            CreateTable(
                "dbo.PurchaseD",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PurchaseMID = c.Int(nullable: false),
                        VendorID = c.Int(nullable: false),
                        DrugGID = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstimatedArrivalDate = c.DateTime(),
                        RealArrivalDate = c.DateTime(),
                        Status = c.String(maxLength: 1),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        Creator = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drug", t => t.DrugGID)
                .ForeignKey("dbo.PurchaseM", t => t.PurchaseMID)
                .ForeignKey("dbo.Vendor", t => t.VendorID)
                .Index(t => t.PurchaseMID)
                .Index(t => t.VendorID)
                .Index(t => t.DrugGID);
            
            CreateTable(
                "dbo.PurchaseM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PurchaseNo = c.String(nullable: false, maxLength: 20),
                        InDate = c.DateTime(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        Creator = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderExam",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RecordID = c.Int(nullable: false),
                        DrugID = c.Guid(nullable: false),
                        AccessionNumber = c.String(nullable: false, maxLength: 50),
                        ExamCode = c.String(maxLength: 50),
                        ExamMeaning = c.String(maxLength: 100),
                        ExamDate = c.DateTime(nullable: false),
                        ExamTime = c.String(nullable: false, maxLength: 6),
                        ExamStatus = c.String(maxLength: 20),
                        ExamResult = c.String(),
                        IsCheckin = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drug", t => t.DrugID)
                .ForeignKey("dbo.OpdRecord", t => t.RecordID)
                .Index(t => t.RecordID)
                .Index(t => t.DrugID);
            
            CreateTable(
                "dbo.ExamReport",
                c => new
                    {
                        ExamID = c.Guid(nullable: false),
                        CreateAt = c.DateTime(),
                        DoctorID = c.Int(),
                        UpdateAt = c.DateTime(),
                        ReportContent = c.String(),
                    })
                .PrimaryKey(t => t.ExamID)
                .ForeignKey("dbo.OrderExam", t => t.ExamID)
                .Index(t => t.ExamID);
            
            CreateTable(
                "dbo.OrderLaboratory",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RecordID = c.Int(nullable: false),
                        DrugID = c.Guid(nullable: false),
                        AccessionNumber = c.String(nullable: false, maxLength: 50),
                        LaboratoryCode = c.String(nullable: false, maxLength: 50),
                        LaboratoryDate = c.DateTime(nullable: false),
                        LaboratoryTime = c.String(maxLength: 6),
                        LaboratoryStatus = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drug", t => t.DrugID)
                .ForeignKey("dbo.OpdRecord", t => t.RecordID)
                .Index(t => t.RecordID)
                .Index(t => t.DrugID);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        PatientID = c.String(nullable: false, maxLength: 12),
                        NationalID = c.String(maxLength: 20),
                        SurName = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        Gender = c.String(maxLength: 1),
                        Birthday = c.DateTime(),
                        Tel = c.String(maxLength: 50),
                        MobilePhone = c.String(maxLength: 50),
                        Married = c.Int(),
                        Occupation = c.Int(),
                        Occupation_Others = c.String(maxLength: 100),
                        BloodType = c.String(maxLength: 1),
                        Allergic = c.String(maxLength: 1),
                        AllergicDesc = c.String(),
                        HIV = c.String(maxLength: 1),
                        HIVDesc = c.String(),
                        TB = c.String(maxLength: 1),
                        TBDesc = c.String(),
                        Disability = c.String(maxLength: 1),
                        DisabilityDesc = c.String(),
                        TA = c.Int(),
                        TA_Others = c.String(maxLength: 100),
                        Village = c.Int(),
                        Village_Others = c.String(maxLength: 100),
                        District = c.Int(),
                        Address = c.String(maxLength: 300),
                        AddressZipcode = c.String(maxLength: 5),
                        PostAddress = c.String(maxLength: 300),
                        PostAddressZipcode = c.String(maxLength: 5),
                        NextOfKinAddress = c.String(maxLength: 300),
                        NextOfKinAddressZipcode = c.String(maxLength: 5),
                        Nationality = c.Int(),
                        Email = c.String(maxLength: 100),
                        ImagePath = c.String(),
                        GuardiansName = c.String(maxLength: 50),
                        GuardiansRelation = c.Int(),
                        GuardiansPhone = c.String(maxLength: 50),
                        FirstVisitDate = c.DateTime(),
                        LastVisitDate = c.DateTime(),
                        FirstAdmission = c.DateTime(),
                        LastAdmission = c.DateTime(),
                        Insurance = c.Int(),
                        InsuranceCategory = c.Int(),
                        ArrearsTimes = c.Int(),
                        Comment = c.String(),
                        Status = c.String(maxLength: 1),
                        IssueDate = c.DateTime(),
                        CreateDate = c.DateTime(),
                        Language = c.String(maxLength: 30),
                        FingerData = c.String(),
                        FingerData1 = c.String(),
                        FingerData2 = c.String(),
                        FingerData3 = c.String(),
                        FingerData4 = c.String(),
                        FingerImageData = c.String(),
                        AttachmentPath1 = c.String(),
                        AttachmentPath2 = c.String(),
                        AttachmentPath3 = c.String(),
                        ModDate = c.DateTime(),
                        ModUser = c.String(maxLength: 100),
                        SocialSecurityNo = c.String(maxLength: 50),
                        ContactPerson = c.String(),
                        ContactPersonPhone = c.String(),
                        ContactPersonRelationship = c.String(),
                        PassportIssueDate = c.DateTime(),
                        PassportExpiredDate = c.DateTime(),
                        MidName = c.String(maxLength: 50),
                        Ethnicity = c.Int(),
                        Birth_Country = c.Int(),
                        Birth_Atoll = c.Int(),
                        Birth_Village = c.Int(),
                        Religion = c.String(maxLength: 30),
                        Marshall_Zone = c.Int(),
                        Marshall_Village = c.Int(),
                        Marshall_Atoll = c.Int(),
                        Country = c.Int(),
                        MotherFName = c.String(maxLength: 50),
                        MotherMName = c.String(maxLength: 50),
                        MotherLName = c.String(maxLength: 50),
                        FatherFName = c.String(maxLength: 50),
                        FatherMName = c.String(maxLength: 50),
                        FatherLName = c.String(maxLength: 50),
                        HomeAtoll = c.Int(),
                        StateCityAtoll = c.Int(),
                        LevelInSchool = c.Int(),
                        NameOfSchool = c.Int(),
                        Company = c.String(maxLength: 30),
                        Employer = c.String(maxLength: 30),
                        PatientFrom = c.Int(nullable: false),
                        RegAtoll = c.String(),
                        Smoking = c.String(maxLength: 1),
                        Paternity = c.String(maxLength: 1),
                        CodeFile_ID = c.Int(),
                    })
                .PrimaryKey(t => t.PatientID)
                .ForeignKey("dbo.CodeFile", t => t.District)
                .ForeignKey("dbo.CodeFile", t => t.GuardiansRelation)
                .ForeignKey("dbo.CodeFile", t => t.Insurance)
                .ForeignKey("dbo.CodeFile", t => t.InsuranceCategory)
                .ForeignKey("dbo.CodeFile", t => t.Nationality)
                .ForeignKey("dbo.CodeFile", t => t.Occupation)
                .ForeignKey("dbo.CodeFile", t => t.TA)
                .ForeignKey("dbo.CodeFile", t => t.Village)
                .ForeignKey("dbo.CodeFile", t => t.CodeFile_ID)
                .Index(t => t.Occupation)
                .Index(t => t.TA)
                .Index(t => t.Village)
                .Index(t => t.District)
                .Index(t => t.Nationality)
                .Index(t => t.GuardiansRelation)
                .Index(t => t.Insurance)
                .Index(t => t.InsuranceCategory)
                .Index(t => t.CodeFile_ID);
            
            CreateTable(
                "dbo.MedicalRecord",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PatientID = c.String(nullable: false, maxLength: 12),
                        DeptID = c.Int(nullable: false),
                        TypeOfVisit = c.Int(),
                        AlcoholRelated = c.Boolean(nullable: false),
                        InjuryRelated = c.Boolean(nullable: false),
                        PullOut = c.Boolean(nullable: false),
                        PullIn = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dept", t => t.DeptID)
                .ForeignKey("dbo.Patient", t => t.PatientID)
                .Index(t => t.PatientID)
                .Index(t => t.DeptID);
            
            CreateTable(
                "dbo.Billing",
                c => new
                    {
                        MedicalRecordID = c.Int(nullable: false),
                        total_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isPay = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MedicalRecordID)
                .ForeignKey("dbo.MedicalRecord", t => t.MedicalRecordID)
                .Index(t => t.MedicalRecordID);
            
            CreateTable(
                "dbo.BillingLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MedicalRecordID = c.Int(nullable: false),
                        pay_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Billing", t => t.MedicalRecordID)
                .Index(t => t.MedicalRecordID);
            
            CreateTable(
                "dbo.VitalSign",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PatientID = c.String(nullable: false, maxLength: 12),
                        Systolic = c.Double(),
                        Diastolic = c.Double(),
                        Pulse = c.Double(),
                        BodyTemp = c.Double(),
                        Weight = c.Double(),
                        BMI = c.Double(),
                        Height = c.Double(),
                        O2 = c.Double(),
                        BloodSugar = c.Double(),
                        BodyFat = c.Double(),
                        VatLevel = c.Double(),
                        BMR = c.Double(),
                        MetabolicAge = c.Double(),
                        MuscleMass = c.Double(),
                        BoneMass = c.Double(),
                        BodyWaterMass = c.Double(),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.CreateBy)
                .ForeignKey("dbo.Patient", t => t.PatientID)
                .Index(t => t.PatientID)
                .Index(t => t.CreateBy);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoomNo = c.String(maxLength: 5),
                        RoomName = c.String(maxLength: 50),
                        RoomMax = c.Int(),
                        Remark = c.String(storeType: "ntext"),
                        Guardian_ID = c.Int(),
                        CreateDate = c.DateTime(),
                        ModDate = c.DateTime(),
                        ModUser = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Guardian", t => t.Guardian_ID)
                .Index(t => t.Guardian_ID);
            
            CreateTable(
                "dbo.Dept2Room",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Dept_id = c.Int(),
                        Room_id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dept", t => t.Dept_id)
                .ForeignKey("dbo.Room", t => t.Room_id)
                .Index(t => t.Dept_id)
                .Index(t => t.Room_id);
            
            CreateTable(
                "dbo.Guardian",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Guardian_Type_CodeFile = c.Int(nullable: false),
                        Guardian_Name = c.String(maxLength: 50),
                        IsUsed = c.Boolean(nullable: false),
                        IsForLobbyUsed = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(),
                        ModDate = c.DateTime(),
                        ModUser = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CodeFile", t => t.Guardian_Type_CodeFile)
                .Index(t => t.Guardian_Type_CodeFile);
            
            CreateTable(
                "dbo.Guardian_File",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Guardian_ID = c.Int(nullable: false),
                        FileName = c.String(maxLength: 200),
                        Show_Order = c.Int(nullable: false),
                        Show_Seconds = c.Int(nullable: false),
                        IsUsed = c.Boolean(nullable: false),
                        UploadDate = c.DateTime(),
                        ModDate = c.DateTime(),
                        ModUser = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Guardian", t => t.Guardian_ID)
                .Index(t => t.Guardian_ID);
            
            CreateTable(
                "dbo.Account2Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Role_id = c.Int(nullable: false),
                        Account_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.Account_id)
                .ForeignKey("dbo.Role", t => t.Role_id)
                .Index(t => t.Role_id)
                .Index(t => t.Account_id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Kit",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        KitCode = c.String(nullable: false, maxLength: 30),
                        KitDescription = c.String(maxLength: 100),
                        Subjective = c.String(),
                        Objective = c.String(),
                        ICD10Code1 = c.String(maxLength: 10),
                        ICD10Code2 = c.String(maxLength: 10),
                        ICD10Code3 = c.String(maxLength: 10),
                        ICD10Code4 = c.String(maxLength: 10),
                        CreateDate = c.DateTime(),
                        ModDate = c.DateTime(),
                        ModUser = c.String(maxLength: 100),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.AccountID)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.NotifyMessage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MsgFrom = c.Int(),
                        MsgTo = c.Int(),
                        MessageText = c.String(),
                        IsRead = c.Int(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.MsgTo)
                .Index(t => t.MsgTo);
            
            CreateTable(
                "dbo.Phrase",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PhraseCode = c.String(maxLength: 20),
                        PhaereContent = c.String(maxLength: 50),
                        CreateDate = c.DateTime(),
                        ModDate = c.DateTime(),
                        ModUser = c.String(maxLength: 100),
                        AccountID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.AccountID)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Ap2Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        role_id = c.Int(nullable: false),
                        ap_key = c.String(maxLength: 10),
                        isRead = c.String(maxLength: 1),
                        isAdd = c.String(maxLength: 1),
                        isUpdate = c.String(maxLength: 1),
                        isDelete = c.String(maxLength: 1),
                        isPrint = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.role_id)
                .Index(t => t.role_id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Description = c.String(maxLength: 1500),
                        RoomID = c.Int(),
                        CourseType = c.Int(nullable: false),
                        WayOfTeaching = c.String(maxLength: 100),
                        Enrollment = c.Int(),
                        NeedRecord = c.Boolean(nullable: false),
                        BroadcastLive = c.Boolean(nullable: false),
                        BeginTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        OpenEnrollment = c.Boolean(nullable: false),
                        EnrollmentBeginDateTime = c.DateTime(),
                        EnrollmentEndDateTime = c.DateTime(),
                        OpenEnrollmentDateTime = c.DateTime(),
                        Status = c.String(maxLength: 20),
                        EmailNotice = c.Boolean(nullable: false),
                        Views = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatorID = c.Int(),
                        Creator = c.String(maxLength: 50),
                        Lecturer = c.Int(),
                        Precautions = c.String(maxLength: 1000),
                        Remark = c.String(maxLength: 1000),
                        PublishDateTime = c.DateTime(),
                        UnPublishDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CodeFile", t => t.CourseType)
                .ForeignKey("dbo.Room", t => t.RoomID)
                .Index(t => t.RoomID)
                .Index(t => t.CourseType);
            
            CreateTable(
                "dbo.Course_Exam",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExamID = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        ExamTitle = c.String(maxLength: 150),
                        TestType = c.Int(),
                        IsCustomScore = c.Boolean(),
                        IsPublic = c.Boolean(),
                        CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Course_Exam_Question",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExamID = c.Int(nullable: false),
                        Question = c.String(nullable: false, maxLength: 500),
                        QuestionType = c.String(nullable: false, maxLength: 50),
                        Created = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                        IsEnabled = c.Boolean(),
                        Remark = c.String(nullable: false, maxLength: 500),
                        Score = c.Double(nullable: false),
                        UseHtmlEditor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course_Exam", t => t.ExamID)
                .Index(t => t.ExamID);
            
            CreateTable(
                "dbo.Course_Exam_Answer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExamQuestionID = c.Int(nullable: false),
                        Answer = c.String(nullable: false, maxLength: 1500),
                        IsCorrect = c.Boolean(nullable: false),
                        Sort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course_Exam_Question", t => t.ExamQuestionID)
                .Index(t => t.ExamQuestionID);
            
            CreateTable(
                "dbo.Course_Exam_AnswerImage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sort = c.Int(nullable: false),
                        AnswerID = c.Int(),
                        FileName = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course_Exam_Answer", t => t.AnswerID)
                .Index(t => t.AnswerID);
            
            CreateTable(
                "dbo.Course_Exam_QuestionImage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(),
                        Using = c.Boolean(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course_Exam_Question", t => t.QuestionID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.CourseAttachment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 100),
                        IsEnabled = c.Boolean(nullable: false),
                        FileLength = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.CourseDateTime",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        BeginDateTime = c.DateTime(nullable: false),
                        TotalSeconds = c.Long(),
                        EndDateTime = c.DateTime(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.CourseLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        LogType = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 1000),
                        Creator = c.Int(nullable: false),
                        CreatorName = c.String(nullable: false, maxLength: 100),
                        ParentId = c.Int(),
                        Before = c.String(maxLength: 2000),
                        After = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.CourseMember",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        Member = c.String(nullable: false, maxLength: 100),
                        MemberType = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.CourseRegistration",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        Account = c.Int(),
                        UserNo = c.String(maxLength: 20),
                        Status = c.String(maxLength: 10),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.CourseSetting",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        CheckOnline = c.Boolean(nullable: false),
                        CheckRemain = c.Int(),
                        CheckTimer = c.Int(),
                        ExamLimit = c.Int(),
                        PassMinutes = c.Int(),
                        CanGrandTotal = c.Boolean(),
                        LearnedQuiz = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.CourseSignUp",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                        Email = c.String(maxLength: 100),
                        Cancelled = c.Boolean(nullable: false),
                        ModifyID = c.Int(),
                        Modified = c.DateTime(),
                        Created = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.CourseTestPaper",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        TestPaperID = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        ShuffleAnswer = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.CourseYoutube",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        HyperLink = c.String(nullable: false, maxLength: 300),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.CourseTested",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseTestPaperID = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                        Email = c.String(maxLength: 100),
                        IsTested = c.Boolean(nullable: false),
                        PaperPath = c.String(nullable: false, maxLength: 150),
                        CorrectRate = c.Double(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CourseID = c.Int(),
                        Score = c.Double(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DialysisBeds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Room = c.String(maxLength: 20, fixedLength: true),
                        BedName = c.String(maxLength: 20, fixedLength: true),
                        CreateAt = c.DateTime(),
                        Enable = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NewsTitle = c.String(nullable: false, maxLength: 200),
                        NewsContent = c.String(),
                        PublishStart = c.DateTime(nullable: false),
                        PublishEnd = c.DateTime(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(),
                        ModDate = c.DateTime(),
                        ModUser = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderKit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KitID = c.Guid(nullable: false),
                        DrugID = c.Guid(nullable: false),
                        Dose = c.Single(nullable: false),
                        Unit = c.Int(nullable: false),
                        Frequency = c.Int(nullable: false),
                        Route = c.Int(nullable: false),
                        Days = c.Int(nullable: false),
                        Quantity = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kit", t => t.KitID)
                .Index(t => t.KitID);
            
            CreateTable(
                "dbo.PrintPool",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HospitalNo = c.String(nullable: false, maxLength: 12),
                        Ip = c.String(maxLength: 30),
                        Done = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(),
                        ModUser = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        SettingName = c.String(),
                        Value = c.String(),
                        Deletable = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.CreatedBy)
                .ForeignKey("dbo.Setting", t => t.ParentId)
                .Index(t => t.ParentId)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.SystemLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(maxLength: 50),
                        Controller = c.String(maxLength: 20),
                        FunctionType = c.String(maxLength: 20),
                        User = c.String(maxLength: 20),
                        UserIPAddress = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TestAnswer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        Answer = c.String(nullable: false, maxLength: 1500),
                        IsCorrect = c.Boolean(nullable: false),
                        Sort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TestQuestion", t => t.QuestionID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.TestAnswerImage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sort = c.Int(nullable: false),
                        AnswerID = c.Int(),
                        FileName = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TestAnswer", t => t.AnswerID)
                .Index(t => t.AnswerID);
            
            CreateTable(
                "dbo.TestQuestion",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PaperID = c.Int(nullable: false),
                        Question = c.String(nullable: false, maxLength: 500),
                        QuestionType = c.String(nullable: false, maxLength: 50),
                        Created = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                        IsEnabled = c.Boolean(),
                        Remark = c.String(nullable: false, maxLength: 500),
                        Score = c.Double(nullable: false),
                        UseHtmlEditor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TestPaper", t => t.PaperID)
                .Index(t => t.PaperID);
            
            CreateTable(
                "dbo.TestPaper",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 300),
                        TestType = c.Int(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        ShuffleAnswer = c.Boolean(nullable: false),
                        IsCustomScore = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TestQuestionImage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(),
                        Using = c.Boolean(nullable: false),
                        FileName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TestQuestion", t => t.QuestionID)
                .Index(t => t.QuestionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestQuestionImage", "QuestionID", "dbo.TestQuestion");
            DropForeignKey("dbo.TestQuestion", "PaperID", "dbo.TestPaper");
            DropForeignKey("dbo.TestAnswer", "QuestionID", "dbo.TestQuestion");
            DropForeignKey("dbo.TestAnswerImage", "AnswerID", "dbo.TestAnswer");
            DropForeignKey("dbo.Setting", "ParentId", "dbo.Setting");
            DropForeignKey("dbo.Setting", "CreatedBy", "dbo.Account");
            DropForeignKey("dbo.OrderKit", "KitID", "dbo.Kit");
            DropForeignKey("dbo.Course", "RoomID", "dbo.Room");
            DropForeignKey("dbo.CourseYoutube", "CourseID", "dbo.Course");
            DropForeignKey("dbo.CourseTestPaper", "CourseID", "dbo.Course");
            DropForeignKey("dbo.CourseSignUp", "CourseID", "dbo.Course");
            DropForeignKey("dbo.CourseSetting", "CourseID", "dbo.Course");
            DropForeignKey("dbo.CourseRegistration", "CourseID", "dbo.Course");
            DropForeignKey("dbo.CourseMember", "CourseID", "dbo.Course");
            DropForeignKey("dbo.CourseLog", "CourseID", "dbo.Course");
            DropForeignKey("dbo.CourseDateTime", "CourseID", "dbo.Course");
            DropForeignKey("dbo.CourseAttachment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Course_Exam_QuestionImage", "QuestionID", "dbo.Course_Exam_Question");
            DropForeignKey("dbo.Course_Exam_Answer", "ExamQuestionID", "dbo.Course_Exam_Question");
            DropForeignKey("dbo.Course_Exam_AnswerImage", "AnswerID", "dbo.Course_Exam_Answer");
            DropForeignKey("dbo.Course_Exam_Question", "ExamID", "dbo.Course_Exam");
            DropForeignKey("dbo.Course_Exam", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Course", "CourseType", "dbo.CodeFile");
            DropForeignKey("dbo.Ap2Role", "role_id", "dbo.Role");
            DropForeignKey("dbo.Phrase", "AccountID", "dbo.Account");
            DropForeignKey("dbo.NotifyMessage", "MsgTo", "dbo.Account");
            DropForeignKey("dbo.Kit", "AccountID", "dbo.Account");
            DropForeignKey("dbo.Account2Role", "Role_id", "dbo.Role");
            DropForeignKey("dbo.Account2Role", "Account_id", "dbo.Account");
            DropForeignKey("dbo.Account2Dept", "DeptId", "dbo.Dept");
            DropForeignKey("dbo.Patient", "CodeFile_ID", "dbo.CodeFile");
            DropForeignKey("dbo.OpdRegister", "RoomID", "dbo.Room");
            DropForeignKey("dbo.Room", "Guardian_ID", "dbo.Guardian");
            DropForeignKey("dbo.Guardian_File", "Guardian_ID", "dbo.Guardian");
            DropForeignKey("dbo.Guardian", "Guardian_Type_CodeFile", "dbo.CodeFile");
            DropForeignKey("dbo.DorSchedule", "RoomID", "dbo.Room");
            DropForeignKey("dbo.Dept2Room", "Room_id", "dbo.Room");
            DropForeignKey("dbo.Dept2Room", "Dept_id", "dbo.Dept");
            DropForeignKey("dbo.VitalSign", "PatientID", "dbo.Patient");
            DropForeignKey("dbo.VitalSign", "CreateBy", "dbo.Account");
            DropForeignKey("dbo.Patient", "Village", "dbo.CodeFile");
            DropForeignKey("dbo.Patient", "TA", "dbo.CodeFile");
            DropForeignKey("dbo.OpdRegister", "PatinetID", "dbo.Patient");
            DropForeignKey("dbo.OpdRecord", "PatinetID", "dbo.Patient");
            DropForeignKey("dbo.Patient", "Occupation", "dbo.CodeFile");
            DropForeignKey("dbo.Patient", "Nationality", "dbo.CodeFile");
            DropForeignKey("dbo.MedicalRecord", "PatientID", "dbo.Patient");
            DropForeignKey("dbo.MedicalRecord", "DeptID", "dbo.Dept");
            DropForeignKey("dbo.Billing", "MedicalRecordID", "dbo.MedicalRecord");
            DropForeignKey("dbo.BillingLog", "MedicalRecordID", "dbo.Billing");
            DropForeignKey("dbo.Patient", "InsuranceCategory", "dbo.CodeFile");
            DropForeignKey("dbo.Patient", "Insurance", "dbo.CodeFile");
            DropForeignKey("dbo.Patient", "GuardiansRelation", "dbo.CodeFile");
            DropForeignKey("dbo.Patient", "District", "dbo.CodeFile");
            DropForeignKey("dbo.OrderDrug", "RecordID", "dbo.OpdRecord");
            DropForeignKey("dbo.OrderLaboratory", "RecordID", "dbo.OpdRecord");
            DropForeignKey("dbo.OrderLaboratory", "DrugID", "dbo.Drug");
            DropForeignKey("dbo.OrderExam", "RecordID", "dbo.OpdRecord");
            DropForeignKey("dbo.ExamReport", "ExamID", "dbo.OrderExam");
            DropForeignKey("dbo.OrderExam", "DrugID", "dbo.Drug");
            DropForeignKey("dbo.OrderDrug", "DrugID", "dbo.Drug");
            DropForeignKey("dbo.PosTransactionM", "VendorID", "dbo.Vendor");
            DropForeignKey("dbo.PurchaseD", "VendorID", "dbo.Vendor");
            DropForeignKey("dbo.PurchaseD", "PurchaseMID", "dbo.PurchaseM");
            DropForeignKey("dbo.PosTransactionD", "PurchaseDID", "dbo.PurchaseD");
            DropForeignKey("dbo.PurchaseD", "DrugGID", "dbo.Drug");
            DropForeignKey("dbo.PosTransactionD", "PosTransactionMID", "dbo.PosTransactionM");
            DropForeignKey("dbo.DrugVendor", "VendorID", "dbo.Vendor");
            DropForeignKey("dbo.DrugVendor", "DrugGID", "dbo.Drug");
            DropForeignKey("dbo.DrugSetting", "DrugID", "dbo.Drug");
            DropForeignKey("dbo.DrugRestriction", "DrugID", "dbo.Drug");
            DropForeignKey("dbo.DrugOrderRestriction", "DrugId", "dbo.Drug");
            DropForeignKey("dbo.DrugCost", "DrugID", "dbo.Drug");
            DropForeignKey("dbo.DrugAppearance", "DrugID", "dbo.Drug");
            DropForeignKey("dbo.OpdRegister", "OpdRecordID", "dbo.OpdRecord");
            DropForeignKey("dbo.OpdRecordAttachment", "OpdRecordId", "dbo.OpdRecord");
            DropForeignKey("dbo.OpdRecordAttachment", "CreateBy", "dbo.Account");
            DropForeignKey("dbo.OpdRecord2ICD10", "OpdRecordID", "dbo.OpdRecord");
            DropForeignKey("dbo.OpdRecord2ICD10", "ICD10Code", "dbo.ICD10");
            DropForeignKey("dbo.OpdRecord", "DoctorID", "dbo.Account");
            DropForeignKey("dbo.OpdRecord", "DeptID", "dbo.Dept");
            DropForeignKey("dbo.OpdRegister", "DorScheduleId", "dbo.DorSchedule");
            DropForeignKey("dbo.OpdRegister", "Deptid", "dbo.Dept");
            DropForeignKey("dbo.DorSchedule", "DeptID", "dbo.Dept");
            DropForeignKey("dbo.DorSchedule", "CancelReasonId", "dbo.CodeFile");
            DropForeignKey("dbo.DorSchedule", "AccountID", "dbo.Account");
            DropForeignKey("dbo.Dept", "Category", "dbo.CodeFile");
            DropForeignKey("dbo.Account", "Title_id", "dbo.CodeFile");
            DropForeignKey("dbo.Account", "Dept_ID", "dbo.Dept");
            DropForeignKey("dbo.Account2Dept", "AccountId", "dbo.Account");
            DropIndex("dbo.TestQuestionImage", new[] { "QuestionID" });
            DropIndex("dbo.TestQuestion", new[] { "PaperID" });
            DropIndex("dbo.TestAnswerImage", new[] { "AnswerID" });
            DropIndex("dbo.TestAnswer", new[] { "QuestionID" });
            DropIndex("dbo.Setting", new[] { "CreatedBy" });
            DropIndex("dbo.Setting", new[] { "ParentId" });
            DropIndex("dbo.OrderKit", new[] { "KitID" });
            DropIndex("dbo.CourseYoutube", new[] { "CourseID" });
            DropIndex("dbo.CourseTestPaper", new[] { "CourseID" });
            DropIndex("dbo.CourseSignUp", new[] { "CourseID" });
            DropIndex("dbo.CourseSetting", new[] { "CourseID" });
            DropIndex("dbo.CourseRegistration", new[] { "CourseID" });
            DropIndex("dbo.CourseMember", new[] { "CourseID" });
            DropIndex("dbo.CourseLog", new[] { "CourseID" });
            DropIndex("dbo.CourseDateTime", new[] { "CourseID" });
            DropIndex("dbo.CourseAttachment", new[] { "CourseID" });
            DropIndex("dbo.Course_Exam_QuestionImage", new[] { "QuestionID" });
            DropIndex("dbo.Course_Exam_AnswerImage", new[] { "AnswerID" });
            DropIndex("dbo.Course_Exam_Answer", new[] { "ExamQuestionID" });
            DropIndex("dbo.Course_Exam_Question", new[] { "ExamID" });
            DropIndex("dbo.Course_Exam", new[] { "CourseID" });
            DropIndex("dbo.Course", new[] { "CourseType" });
            DropIndex("dbo.Course", new[] { "RoomID" });
            DropIndex("dbo.Ap2Role", new[] { "role_id" });
            DropIndex("dbo.Phrase", new[] { "AccountID" });
            DropIndex("dbo.NotifyMessage", new[] { "MsgTo" });
            DropIndex("dbo.Kit", new[] { "AccountID" });
            DropIndex("dbo.Account2Role", new[] { "Account_id" });
            DropIndex("dbo.Account2Role", new[] { "Role_id" });
            DropIndex("dbo.Guardian_File", new[] { "Guardian_ID" });
            DropIndex("dbo.Guardian", new[] { "Guardian_Type_CodeFile" });
            DropIndex("dbo.Dept2Room", new[] { "Room_id" });
            DropIndex("dbo.Dept2Room", new[] { "Dept_id" });
            DropIndex("dbo.Room", new[] { "Guardian_ID" });
            DropIndex("dbo.VitalSign", new[] { "CreateBy" });
            DropIndex("dbo.VitalSign", new[] { "PatientID" });
            DropIndex("dbo.BillingLog", new[] { "MedicalRecordID" });
            DropIndex("dbo.Billing", new[] { "MedicalRecordID" });
            DropIndex("dbo.MedicalRecord", new[] { "DeptID" });
            DropIndex("dbo.MedicalRecord", new[] { "PatientID" });
            DropIndex("dbo.Patient", new[] { "CodeFile_ID" });
            DropIndex("dbo.Patient", new[] { "InsuranceCategory" });
            DropIndex("dbo.Patient", new[] { "Insurance" });
            DropIndex("dbo.Patient", new[] { "GuardiansRelation" });
            DropIndex("dbo.Patient", new[] { "Nationality" });
            DropIndex("dbo.Patient", new[] { "District" });
            DropIndex("dbo.Patient", new[] { "Village" });
            DropIndex("dbo.Patient", new[] { "TA" });
            DropIndex("dbo.Patient", new[] { "Occupation" });
            DropIndex("dbo.OrderLaboratory", new[] { "DrugID" });
            DropIndex("dbo.OrderLaboratory", new[] { "RecordID" });
            DropIndex("dbo.ExamReport", new[] { "ExamID" });
            DropIndex("dbo.OrderExam", new[] { "DrugID" });
            DropIndex("dbo.OrderExam", new[] { "RecordID" });
            DropIndex("dbo.PurchaseD", new[] { "DrugGID" });
            DropIndex("dbo.PurchaseD", new[] { "VendorID" });
            DropIndex("dbo.PurchaseD", new[] { "PurchaseMID" });
            DropIndex("dbo.PosTransactionD", new[] { "PurchaseDID" });
            DropIndex("dbo.PosTransactionD", new[] { "PosTransactionMID" });
            DropIndex("dbo.PosTransactionM", new[] { "VendorID" });
            DropIndex("dbo.DrugVendor", new[] { "DrugGID" });
            DropIndex("dbo.DrugVendor", new[] { "VendorID" });
            DropIndex("dbo.DrugSetting", new[] { "DrugID" });
            DropIndex("dbo.DrugRestriction", new[] { "DrugID" });
            DropIndex("dbo.DrugOrderRestriction", new[] { "DrugId" });
            DropIndex("dbo.DrugCost", new[] { "DrugID" });
            DropIndex("dbo.DrugAppearance", new[] { "DrugID" });
            DropIndex("dbo.OrderDrug", new[] { "DrugID" });
            DropIndex("dbo.OrderDrug", new[] { "RecordID" });
            DropIndex("dbo.OpdRecordAttachment", new[] { "CreateBy" });
            DropIndex("dbo.OpdRecordAttachment", new[] { "OpdRecordId" });
            DropIndex("dbo.OpdRecord2ICD10", new[] { "ICD10Code" });
            DropIndex("dbo.OpdRecord2ICD10", new[] { "OpdRecordID" });
            DropIndex("dbo.OpdRecord", new[] { "DeptID" });
            DropIndex("dbo.OpdRecord", new[] { "DoctorID" });
            DropIndex("dbo.OpdRecord", new[] { "PatinetID" });
            DropIndex("dbo.OpdRegister", new[] { "OpdRecordID" });
            DropIndex("dbo.OpdRegister", new[] { "DorScheduleId" });
            DropIndex("dbo.OpdRegister", new[] { "RoomID" });
            DropIndex("dbo.OpdRegister", new[] { "Deptid" });
            DropIndex("dbo.OpdRegister", new[] { "PatinetID" });
            DropIndex("dbo.DorSchedule", new[] { "CancelReasonId" });
            DropIndex("dbo.DorSchedule", new[] { "RoomID" });
            DropIndex("dbo.DorSchedule", new[] { "DeptID" });
            DropIndex("dbo.DorSchedule", new[] { "AccountID" });
            DropIndex("dbo.Dept", new[] { "Category" });
            DropIndex("dbo.Account2Dept", new[] { "AccountId" });
            DropIndex("dbo.Account2Dept", new[] { "DeptId" });
            DropIndex("dbo.Account", new[] { "Dept_ID" });
            DropIndex("dbo.Account", new[] { "Title_id" });
            DropTable("dbo.TestQuestionImage");
            DropTable("dbo.TestPaper");
            DropTable("dbo.TestQuestion");
            DropTable("dbo.TestAnswerImage");
            DropTable("dbo.TestAnswer");
            DropTable("dbo.SystemLog");
            DropTable("dbo.Setting");
            DropTable("dbo.PrintPool");
            DropTable("dbo.OrderKit");
            DropTable("dbo.News");
            DropTable("dbo.DialysisBeds");
            DropTable("dbo.CourseTested");
            DropTable("dbo.CourseYoutube");
            DropTable("dbo.CourseTestPaper");
            DropTable("dbo.CourseSignUp");
            DropTable("dbo.CourseSetting");
            DropTable("dbo.CourseRegistration");
            DropTable("dbo.CourseMember");
            DropTable("dbo.CourseLog");
            DropTable("dbo.CourseDateTime");
            DropTable("dbo.CourseAttachment");
            DropTable("dbo.Course_Exam_QuestionImage");
            DropTable("dbo.Course_Exam_AnswerImage");
            DropTable("dbo.Course_Exam_Answer");
            DropTable("dbo.Course_Exam_Question");
            DropTable("dbo.Course_Exam");
            DropTable("dbo.Course");
            DropTable("dbo.Ap2Role");
            DropTable("dbo.Phrase");
            DropTable("dbo.NotifyMessage");
            DropTable("dbo.Kit");
            DropTable("dbo.Role");
            DropTable("dbo.Account2Role");
            DropTable("dbo.Guardian_File");
            DropTable("dbo.Guardian");
            DropTable("dbo.Dept2Room");
            DropTable("dbo.Room");
            DropTable("dbo.VitalSign");
            DropTable("dbo.BillingLog");
            DropTable("dbo.Billing");
            DropTable("dbo.MedicalRecord");
            DropTable("dbo.Patient");
            DropTable("dbo.OrderLaboratory");
            DropTable("dbo.ExamReport");
            DropTable("dbo.OrderExam");
            DropTable("dbo.PurchaseM");
            DropTable("dbo.PurchaseD");
            DropTable("dbo.PosTransactionD");
            DropTable("dbo.PosTransactionM");
            DropTable("dbo.Vendor");
            DropTable("dbo.DrugVendor");
            DropTable("dbo.DrugSetting");
            DropTable("dbo.DrugRestriction");
            DropTable("dbo.DrugOrderRestriction");
            DropTable("dbo.DrugCost");
            DropTable("dbo.DrugAppearance");
            DropTable("dbo.Drug");
            DropTable("dbo.OrderDrug");
            DropTable("dbo.OpdRecordAttachment");
            DropTable("dbo.ICD10");
            DropTable("dbo.OpdRecord2ICD10");
            DropTable("dbo.OpdRecord");
            DropTable("dbo.OpdRegister");
            DropTable("dbo.DorSchedule");
            DropTable("dbo.CodeFile");
            DropTable("dbo.Dept");
            DropTable("dbo.Account2Dept");
            DropTable("dbo.Account");
        }
    }
}
