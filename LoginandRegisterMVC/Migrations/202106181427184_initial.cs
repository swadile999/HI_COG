namespace LoginandRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        ClinicName = c.String(),
                        DoctorName = c.String(),
                        DoctorId = c.Int(nullable: false),
                        ClinicCity = c.String(),
                        DateOfAppointment = c.String(nullable: false),
                        TimeOfAppointment = c.String(nullable: false),
                        PatientName = c.String(),
                        PatientId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.AppointmentId);
            
            CreateTable(
                "dbo.BMIs",
                c => new
                    {
                        BMIId = c.Int(nullable: false, identity: true),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        BMIResult = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BMIId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        MailId = c.String(nullable: false),
                        firstname = c.String(nullable: false),
                        lastname = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Dob = c.String(nullable: false),
                        MNumber = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        Role = c.String(nullable: false),
                        Fque = c.String(nullable: false),
                        Sque = c.String(nullable: false),
                        Tque = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ClinicFacilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacilityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clinics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClinicName = c.String(nullable: false),
                        DoctorName = c.String(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Specialization = c.String(nullable: false),
                        Facilities = c.String(nullable: false),
                        ClinicTiming = c.String(nullable: false),
                        AddressFLine = c.String(nullable: false),
                        AddressSLine = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DietRecommendations",
                c => new
                    {
                        DietRecommendationId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Recommendation = c.String(),
                    })
                .PrimaryKey(t => t.DietRecommendationId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DoctorDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Specialization = c.String(nullable: false),
                        TotalClinic = c.String(nullable: false),
                        Avalaibility = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeedbackQuestions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        FeedBackQuestion = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.FeedbackId)
                .ForeignKey("dbo.FeedbackQuestions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Helps",
                c => new
                    {
                        HelpId = c.Int(nullable: false, identity: true),
                        Issue = c.String(),
                        UserId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.HelpId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PatientRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                        Age = c.String(),
                        Gender = c.String(),
                        VisitDate = c.String(),
                        DoctorName = c.String(),
                        DoctorID = c.Int(nullable: false),
                        AppointmentId = c.Int(nullable: false),
                        DoctorSpecialization = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientTreatmentRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientName = c.String(nullable: false),
                        PatientId = c.Int(nullable: false),
                        Symptoms = c.String(nullable: false),
                        Diagnosis = c.String(nullable: false),
                        TreatmentPlanned = c.String(nullable: false),
                        Prescription = c.String(nullable: false),
                        RevisitRequired = c.String(),
                        NextRevisitDate = c.String(),
                        NextRevisitTime = c.String(),
                        FrequencyRevisit = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResolveHelps",
                c => new
                    {
                        ResolveId = c.Int(nullable: false, identity: true),
                        HelpId = c.Int(nullable: false),
                        ResolveAnswer = c.String(),
                    })
                .PrimaryKey(t => t.ResolveId)
                .ForeignKey("dbo.Helps", t => t.HelpId, cascadeDelete: true)
                .Index(t => t.HelpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResolveHelps", "HelpId", "dbo.Helps");
            DropForeignKey("dbo.Helps", "UserId", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Feedbacks", "QuestionId", "dbo.FeedbackQuestions");
            DropForeignKey("dbo.DietRecommendations", "UserId", "dbo.Users");
            DropForeignKey("dbo.BMIs", "UserId", "dbo.Users");
            DropIndex("dbo.ResolveHelps", new[] { "HelpId" });
            DropIndex("dbo.Helps", new[] { "UserId" });
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropIndex("dbo.Feedbacks", new[] { "QuestionId" });
            DropIndex("dbo.DietRecommendations", new[] { "UserId" });
            DropIndex("dbo.BMIs", new[] { "UserId" });
            DropTable("dbo.ResolveHelps");
            DropTable("dbo.PatientTreatmentRecords");
            DropTable("dbo.PatientRecords");
            DropTable("dbo.Helps");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.FeedbackQuestions");
            DropTable("dbo.DoctorDetails");
            DropTable("dbo.DietRecommendations");
            DropTable("dbo.Clinics");
            DropTable("dbo.ClinicFacilities");
            DropTable("dbo.Users");
            DropTable("dbo.BMIs");
            DropTable("dbo.Appointments");
        }
    }
}
