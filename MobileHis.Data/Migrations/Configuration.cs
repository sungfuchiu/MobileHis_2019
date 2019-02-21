namespace MobileHis.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.SqlServer;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MobileHis.Data.MobileHISEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;


            AutomaticMigrationDataLossAllowed = true;
            CommandTimeout = (int)TimeSpan.FromMinutes(10).TotalSeconds;
            SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(MobileHis.Data.MobileHISEntities context)
        {
            if (context.Account.Any()) return;

            int iflag = 1;

            #region setting
            iflag = 1;
            List<Setting> settings = new List<Setting>() {
                new Setting{ID=iflag++,ParentId=null,SettingName="Default",Value=null,Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=null,SettingName="info",Value=null,Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=null,SettingName="other",Value=null,Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=null,SettingName="category",Value=null,Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=null,SettingName="mail",Value=null,Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},                 
            };

            int defaultid = settings.Where(x => x.SettingName == "Default").Select(x => x.ID).First();
            int infoid = settings.Where(x => x.SettingName == "info").Select(x => x.ID).First();
            int otherid = settings.Where(x => x.SettingName == "other").Select(x => x.ID).First();
            int categoryid = settings.Where(x => x.SettingName == "category").Select(x => x.ID).First();
            int mailid = settings.Where(x => x.SettingName == "mail").Select(x => x.ID).First();

            settings.AddRange(new List<Setting>(){
#region default
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="FingerPrint",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="Pacs",Value="Y",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="ConsultationFee",Value="0",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},                 
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="BK_img",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},   
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="Partner1",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},   
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="Partner2",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},   
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="Partner3",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},   
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="Partner4",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},   
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="Official_Banner_Img",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},  
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="Official_Logo_Img",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},  
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="Opd" + "_" + "Shift" + "_" + ScheduleShift.Morning,Value="08:00-12:00",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="Opd" + "_" + "Shift" + "_" + ScheduleShift.Afternoon,Value="13:00-17:00",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="Opd" + "_" + "Shift" + "_" + ScheduleShift.Night,Value="19:00-21:00",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=defaultid,SettingName="ApiKey",Value="aAcOmSikSzeiYsbTAawO",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
#endregion
                new Setting{ID=iflag++,ParentId=infoid,SettingName="Hospital_No",Value="Majuro",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=infoid,SettingName="Hospital_Name",Value="RMI Ministry of Health & Human Services",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=infoid,SettingName="Hospital_Tel",Value="(692) 625-3632",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=infoid,SettingName="Hospital_Address",Value="Majuro Hospital, Majuro, Majuro Atoll, Marshall Islands",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=infoid,SettingName="Hospital_Contact_Name",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=infoid,SettingName="Hospital_Contact_Tel",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=infoid,SettingName="Hospital_About",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},                               
                new Setting{ID=iflag++,ParentId=infoid,SettingName="Hospital_OpenTime",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1}, 
                new Setting{ID=iflag++,ParentId=infoid,SettingName="Hospital_lat",Value="0",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1}, 
                new Setting{ID=iflag++,ParentId=infoid,SettingName="Hospital_lng",Value="0",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++, ParentId=infoid, SettingName="Hospital_Environment",Value="", Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=infoid, SettingName="Hospital_Slogan", Value="", Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="UPIS_APIKEY",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="UPIS_IP",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="SymptomShot",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="SymptomShotIP",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="SymptomShot_3DesKey",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="SymptomShot_3DesIv",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="SmartHealth_APIKEY",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="SmartHealth_IP",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="SmartHealth_Register_IP",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="SmartHealth_3DesKey",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="SmartHealth_3DesIv",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="Owl_APIKEY",Value="G848DA03795846BBBAF85CFAA7E46384",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="Owl_IP",Value="https://owl.mhis.pro/LandingPage/remoteLogin",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="Owl_3DesKey",Value="44FCAA6EFE50555R",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=otherid,SettingName="Owl_3DesIv",Value="G646HF2C",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                //http://thailab.advmeds.com/
                new Setting{ID=iflag++,ParentId=otherid,SettingName="Lab_IP",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=categoryid,SettingName="ItemType",Value=null,Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},  
                new Setting{ID=iflag++,ParentId=mailid,SettingName="Mail_UserName",Value=null,Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},       
                new Setting{ID=iflag++,ParentId=mailid,SettingName="Mail_UserPassword",Value=null,Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=mailid,SettingName="Mail_Port",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=mailid,SettingName="Mail_Url",Value="",Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=mailid,SettingName="Mail_ContactMail",Value=null,Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1},
                new Setting{ID=iflag++,ParentId=mailid,SettingName="Mail_ContactBccMail",Value=null,Deletable=false, CreatedAt=DateTime.Now, CreatedBy=1}
            });

            int itemtypeid = settings.Where(x => x.SettingName == "ItemType").Select(x => x.ID).First();
            List<string> typeList = new List<string>{  //Job Title
                                      "10",                                      
                                      "VI",
                                      //Insurance 保險 內容有預設建立
                                      "IN",
                                       //Nationality 馬紹爾用來裝Citizen
                                      "NA",
                                      "DP",
                                        "CO",
                                        "TP",
                                        "SP",
                                        "CS",
                                        "PY",
                                        "UT",
                                        "FQ",
                                        "RU",
                                        "GD",
                                  //環礁
                                  "AT",
                                  //區域
                                  "ZN",
                                  //學校名稱
                                  "SC",
                                  //學歷
                                  "SL",
                                  //國家country
                                    "CT",
                                      //cancel reason
                                    "CR",
                                      //Race  (White/Caucasian , Black/African American ,Asian) 內容有預設建立
                                    "RA",
                                     //Ethnicity (Hispanic or Latino , Not Hispanic or Latino) 內容有預設建 立
                                    "ET",
                                    //Poverty Level 貧窮程度 內容有預設建立
                                    "PL",
                                      //Religion
                                    "RG",
                                    //marry status
                                    "MR",
                                    //department unit
                                    "DU",
                                    //Contact Person Relationship
                                    "PR",
                                        //weto
                                    "WE",
                                       //ICD10 type
                                    "CD",
                                    //drug sub category
                                    "DC",
                                    //Formulation 
                                    "DF"
                                   };
            var ItemTypeSetting = typeList.Select(a => new Setting { ID = iflag++, ParentId = itemtypeid, SettingName = null, Value = a, Deletable = true, CreatedAt = DateTime.Now, CreatedBy = 1 }).ToList();


            //check setting
            var currSetting = context.Setting.Select(a => a.SettingName).ToList();
            var currItemTypeSetting = context.Setting.Where(a => a.ParentId == itemtypeid).Select(a => a.Value).ToList();
            var finalSetting = settings.Where(a => !currSetting.Contains(a.SettingName)).ToList();
            finalSetting.AddRange(ItemTypeSetting.Where(a => !currItemTypeSetting.Contains(a.Value)));
            context.Setting.AddRange(finalSetting);
            #endregion


            #region CodeFile
            iflag = 1;
            var itemCode = 1;
            List<string> subCatList = new List<string> { "ANALGESICS", "ANAESTHETICS", "ANTIBACTERIAL", "ANTIFUNGALS", "ANTIHELMINTICS", 
                "ANTITUBERCULOSIS AGENTS", "CENTRAL NERVOUS SYSTEM DRUGS", "CARDIOVASCULAR AGENTS", "CONTROLLED SUBSTANCES", "DERMATOLOGICAL AGENTS", 
                "EAR/NOSE/THROAT AGENTS", "ENDOCRINE & METABOLIC AGENTS", "EYE PREPARATION", "GASTROITESTINAL AGENTS", "GENITO-URINARY AGENTS", 
                "HEMATOLOGICAL AGENTS", "INJECTABLE NUTRITIONAL", "INTRAVENOUS FLUIDS", "Misc", "NUTRITIONAL AGENTS/VITAMINS", "OBGYN AGENTS", "RESPIRATORY AGENTS" };
            List<CodeFile> codeFiles = new List<CodeFile>() {
            #region Job Title
                 //new CodeFile(){ID=iflag++,ItemType="10",ItemCode="01",ItemDescription="Pediatrician",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="10",ItemCode="02",ItemDescription="Internist",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="10",ItemCode="03",ItemDescription="Surgeon",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="10",ItemCode="04",ItemDescription="Family  Physician",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="10",ItemCode="05",ItemDescription="Public Health Medical Director",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="10",ItemCode="06",ItemDescription="Chief of Staff",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="10",ItemCode="07",ItemDescription="Dentist",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="10",ItemCode="08",ItemDescription="Medical Assistant",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="10",ItemCode="09",ItemDescription="ER Doctor",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="10",ItemCode="10",ItemDescription="DOE Physician",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="10",ItemCode="11",ItemDescription="OBGYNE",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="10",ItemCode="12",ItemDescription="Active",Remark="", CreateDate=DateTime.Now },
            #endregion
            #region 預設國家 Country

                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Afghanistan",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Albania",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Algeria",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="American Samoa",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Andorra",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Angola",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Anguilla",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Antigua & Barbuda",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Argentina",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Armenia",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Aruba",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Australia",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Austria",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Azerbaijan",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Bahamas",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Bahrain",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Bangladesh",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Barbados",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Belarus",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Belgium",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Belize",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Benin",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Bermuda",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Bhutan",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Bolivia",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Bonaire",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Bosnia & Herzegovina",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Botswana",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Brazil",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="British Indian Ocean Ter",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Brunei",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Bulgaria",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Burkina Faso",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Burundi",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Cambodia",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Cameroon",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Canada",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Canary Islands",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Cape Verde",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Cayman Islands",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Central African Republic",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Chad",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Channel Islands",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Chile",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="China",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Christmas Island",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Cocos Island",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Colombia",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Comoros",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Congo",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Cook Islands",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Costa Rica",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Cote D'Ivoire",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Croatia",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Cuba",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Curacao",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Cyprus",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Czech Republic",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Denmark",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Djibouti",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Dominica",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Dominican Republic",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="East Timor",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Ecuador",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Egypt",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="El Salvador",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Equatorial Guinea",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Eritrea",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Estonia",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Ethiopia",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Falkland Islands",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Faroe Islands",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Fiji",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Finland",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="France",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="French Guiana",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="French Polynesia",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="French Southern Ter",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Gabon",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Gambia",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Georgia",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Germany",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Ghana",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Gibraltar",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Congo",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Congo",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Congo",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Congo",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Congo",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Congo",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Congo",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Congo",Remark="", CreateDate=DateTime.Now },
                 //new CodeFile(){ID=iflag++,ItemType="CT",ItemCode="CT"+itemCode++.ToString(),ItemDescription="Congo",Remark="", CreateDate=DateTime.Now },



            #endregion


                 new CodeFile(){ID=iflag++,ItemType="DP",ItemCode="1",ItemDescription="OPD",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="DP",ItemCode="2",ItemDescription="PH",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="DP",ItemCode="3",ItemDescription="Other",Remark="", CreateDate=DateTime.Now },            
                 new CodeFile(){ID=iflag++,ItemType="DP",ItemCode="4",ItemDescription="Administration",Remark="", CreateDate=DateTime.Now },            
                 new CodeFile(){ID=iflag++,ItemType="CO",ItemCode="01",ItemDescription="Red",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="CO",ItemCode="02",ItemDescription="Blue",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="CO",ItemCode="03",ItemDescription="yellow",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="TP",ItemCode="01",ItemDescription="Oral medication",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="TP",ItemCode="02",ItemDescription="Injection",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="TP",ItemCode="03",ItemDescription="External use medication",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="SP",ItemCode="03",ItemDescription="Circle",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="SP",ItemCode="02",ItemDescription="Oval",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="SP",ItemCode="01",ItemDescription="Triangle",Remark="", CreateDate=DateTime.Now },                 
                 new CodeFile(){ID=iflag++,ItemType="CS",ItemCode="EC1",ItemDescription="Information System",Remark="Information System", CreateDate=DateTime.Now },           
                 new CodeFile(){ID=iflag++,ItemType="UT",ItemCode="U01",ItemDescription="bale",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="FQ",ItemCode="F01",ItemDescription="TIDPC",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="FQ",ItemCode="F02",ItemDescription="HS",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="RU",ItemCode="R01",ItemDescription="PO",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++,ItemType="RU",ItemCode="R02",ItemDescription="MSC",Remark="", CreateDate=DateTime.Now },
                 new CodeFile(){ID=iflag++, ItemType="CR", ItemCode="CR01", ItemDescription="Sick", Remark="", CreateDate=DateTime.Now},
                 new CodeFile(){ID=iflag++, ItemType="CR", ItemCode="CR99", ItemDescription="Other", Remark="", CreateDate=DateTime.Now},
                 new CodeFile(){ID=iflag++, ItemType="GD", ItemCode="G01", ItemDescription="Normal", Remark="", CreateDate=DateTime.Now},
                 new CodeFile(){ID=iflag++, ItemType="RG", ItemCode="RG01", ItemDescription="Catholic", Remark="", CreateDate=DateTime.Now},
                 new CodeFile(){ID=iflag++, ItemType="RG", ItemCode="RG02", ItemDescription="Protestant", Remark="", CreateDate=DateTime.Now},
                 new CodeFile(){ID=iflag++, ItemType="RG", ItemCode="RG03", ItemDescription="Assembly of God", Remark="", CreateDate=DateTime.Now},
                 new CodeFile(){ID=iflag++, ItemType="RG", ItemCode="RG04", ItemDescription="Salvation Army", Remark="", CreateDate=DateTime.Now},
                 new CodeFile(){ID=iflag++, ItemType="RG", ItemCode="RG05", ItemDescription="SDA. Latter Day Saints", Remark="", CreateDate=DateTime.Now},
                 new CodeFile(){ID=iflag++, ItemType="RG", ItemCode="RG06", ItemDescription="Jehovah's Witness", Remark="", CreateDate=DateTime.Now},            
                 new CodeFile(){ID=iflag++, ItemType="RG", ItemCode="RG07", ItemDescription="Other", Remark="", CreateDate=DateTime.Now},
                 new CodeFile(){ID=iflag++, ItemType="MR", ItemCode="MR01", ItemDescription="Single", Remark="", CreateDate=DateTime.Now},
                 new CodeFile(){ID=iflag++, ItemType="MR", ItemCode="MR02", ItemDescription="Married", Remark="", CreateDate=DateTime.Now},
                 new CodeFile(){ID=iflag++, ItemType="MR", ItemCode="MR03", ItemDescription="Common Law", Remark="", CreateDate=DateTime.Now},
                 new CodeFile(){ID=iflag++, ItemType="MR", ItemCode="MR04", ItemDescription="Widow", Remark="", CreateDate=DateTime.Now},
                 new CodeFile(){ID =iflag++, ItemType="DU", ItemCode="DU01", ItemDescription="Medical Unit", Remark="",CreateDate=DateTime.Now},
                 new CodeFile(){ID =iflag++, ItemType="DU", ItemCode="DU02", ItemDescription="Administration Unit", Remark="",CreateDate=DateTime.Now},
                 new CodeFile(){ID =iflag++, ItemType="CD", ItemCode="01", ItemDescription="PCS", Remark="",CreateDate=DateTime.Now},
                 new CodeFile(){ID =iflag++, ItemType="CD", ItemCode="02", ItemDescription="cm2", Remark="",CreateDate=DateTime.Now},
            #region 馬紹爾新增的預設Category (RACE/Ethnicity/Poverty Level/Insurance/Atoll/Contact Person Relationship)
                //RACE
                new CodeFile(){ID=iflag++, ItemType="RA", ItemCode="RA01", ItemDescription="Native Hawaiian/Pacific Islander", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="RA", ItemCode="RA02", ItemDescription="White/Caucasian", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="RA", ItemCode="RA03", ItemDescription="Asian", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="RA", ItemCode="RA04", ItemDescription="Black/African American", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="RA", ItemCode="RA05", ItemDescription="American/Alaskan Native", Remark="", CreateDate=DateTime.Now},
                //Ethnicity
                new CodeFile(){ID=iflag++, ItemType="ET", ItemCode="ET01", ItemDescription="Hispanic or Latino", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="ET", ItemCode="ET02", ItemDescription="Not Hispanic or Latino", Remark="", CreateDate=DateTime.Now},
                //Poverty Level
                new CodeFile(){ID=iflag++, ItemType="PL", ItemCode="PL01", ItemDescription="100% and below", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PL", ItemCode="PL02", ItemDescription="101%-150%", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PL", ItemCode="PL03", ItemDescription="151%-200%", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PL", ItemCode="PL04", ItemDescription="201%-250%", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PL", ItemCode="PL05", ItemDescription="Over 250%", Remark="", CreateDate=DateTime.Now},
                //Insurance
                new CodeFile(){ID=iflag++, ItemType="IN", ItemCode="IN01", ItemDescription="Public Insurance", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="IN", ItemCode="IN02", ItemDescription="Private Insurance", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="IN", ItemCode="IN03", ItemDescription="None", Remark="", CreateDate=DateTime.Now},
                //Atoll
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT01", ItemDescription="Ailinglaplap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT02", ItemDescription="Ailuk", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT03", ItemDescription="Arno", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT04", ItemDescription="Aur", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT05", ItemDescription="Bikini", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT06", ItemDescription="Ebon", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT07", ItemDescription="Enewetak", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT08", ItemDescription="Jabat Is.", Remark="", CreateDate=DateTime.Now},
                //new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT09", ItemDescription="Jah", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT10", ItemDescription="Jaluit", Remark="", CreateDate=DateTime.Now},
                //new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT11", ItemDescription="Jeh", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT12", ItemDescription="Kili", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT13", ItemDescription="Kwajalein", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT14", ItemDescription="Lae", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT15", ItemDescription="Lib", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT16", ItemDescription="Likiep", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT17", ItemDescription="Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT18", ItemDescription="Maloelap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT19", ItemDescription="Mejit Is.", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT20", ItemDescription="Mili", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT21", ItemDescription="Namdrik", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT22", ItemDescription="Namu", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT23", ItemDescription="Rongelap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT24", ItemDescription="Ujae", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT25", ItemDescription="Utrik", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT26", ItemDescription="Wotho", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT27", ItemDescription="Wotje", Remark="", CreateDate=DateTime.Now},


                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT28", ItemDescription="Ujelang", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT29", ItemDescription="Rongdrik", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT30", ItemDescription="Rongrong", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT31", ItemDescription="Jemo", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT32", ItemDescription="Bikar", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT33", ItemDescription="Bokar", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="AT", ItemCode="AT34", ItemDescription="Toke", Remark="", CreateDate=DateTime.Now},
                //Contact Person Relationship
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR001", ItemDescription="MOHTER", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR002", ItemDescription="FATHER", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR003", ItemDescription="UNCLE", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR004", ItemDescription="WIFE", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR005", ItemDescription="SISTER", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR006", ItemDescription="BROTHER", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR007", ItemDescription="SON", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR008", ItemDescription="DAUGHTER", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR009", ItemDescription="HUSBAN", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR010", ItemDescription="FRIEND", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR011", ItemDescription="GRANDFATHER", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR012", ItemDescription="GRANDMOTHER", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR013", ItemDescription="BOSS", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR014", ItemDescription="AGENT", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="PR", ItemCode="PR015", ItemDescription="AGENCY", Remark="", CreateDate=DateTime.Now},

            #region School Name
                //School Name
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC01", ItemDescription="Ajeltake Christian Academy ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC02", ItemDescription="Ajeltake ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC03", ItemDescription="Assumption ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC04", ItemDescription="Delap ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC05", ItemDescription="Delap, SDA ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC06", ItemDescription="Laura ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC07", ItemDescription="Laura, SDA ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC08", ItemDescription="Majuro Baptist ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC09", ItemDescription="Majuro Coop ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC10", ItemDescription="Rairok ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC11", ItemDescription="Rita Christian ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC12", ItemDescription="Rita ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC13", ItemDescription="RonRon Protestant ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC14", ItemDescription="Uliga ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC15", ItemDescription="Woja ES-Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC16", ItemDescription="Calvary, Ebeye ES-Kwajalein", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC17", ItemDescription="Carlos ES-Kwajalein", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC18", ItemDescription="Ebadon ES-Kwajalein", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC19", ItemDescription="Ebeye ES-Kwajalein", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC20", ItemDescription="Eniburr ES-Kwajalein", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC21", ItemDescription="GEM School ES-Kwajalein", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC22", ItemDescription="Jebro Kabua ES-Kwajalein", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC23", ItemDescription="Queen of Peace ES-Kwajalein", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC24", ItemDescription="Aerok ES-Ailinglaplap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC25", ItemDescription="Buoj ES-Ailinglaplap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC26", ItemDescription="Enewa ES-Ailinglaplap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC27", ItemDescription="Jah ES-Ailinglaplap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC28", ItemDescription="Jeh ES-Ailinglaplap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC29", ItemDescription="Jobwan ES-Ailinglaplap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC30", ItemDescription="Mejel ES-Ailinglaplap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC31", ItemDescription="Woja ES-Ailinglaplap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC32", ItemDescription="Ailuk ES-Ailuk", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC33", ItemDescription="Enejelar ES-Ailuk", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC34", ItemDescription="Arno ES-Arno", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC35", ItemDescription="Bikarej ES-Arno", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC36", ItemDescription="Ine ES-Arno", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC37", ItemDescription="Japo ES-Arno", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC38", ItemDescription="Longar ES-Arno", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC39", ItemDescription="Lukoj ES-Arno", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC40", ItemDescription="St. Paul ES-Arno", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC41", ItemDescription="Tutu ES-Arno", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC42", ItemDescription="Ulien ES-Arno", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC43", ItemDescription="Aur ES-Aur", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC44", ItemDescription="Tobal ES-Aur", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC45", ItemDescription="Ebon ES-Ebon", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC46", ItemDescription="Toka ES-Ebon", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC47", ItemDescription="Enewetak ES-Enewetak", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC48", ItemDescription="Jabat ES-Jabat", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC49", ItemDescription="Imiej ES-Jaluit", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC50", ItemDescription="Imroj ES-Jaluit", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC51", ItemDescription="Jabenoden ES-Jaluit", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC52", ItemDescription="Jabor ES-Jaluit", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC53", ItemDescription="Jaluit ES-Jaluit", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC54", ItemDescription="Mejrirok ES-Jaluit", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC55", ItemDescription="Narmej ES-Jaluit", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC56", ItemDescription="St. Joseph ES-Jaluit", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC57", ItemDescription="Ejit ES-Kili", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC58", ItemDescription="Kili ES-Kili", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC59", ItemDescription="Lae ES-Lae", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC60", ItemDescription="Lib ES-Lib", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC61", ItemDescription="Jebal ES-Likiep", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC62", ItemDescription="Melan ES-Likiep", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC63", ItemDescription="Aerok ES-Maloelap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC64", ItemDescription="Jang ES-Maloelap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC65", ItemDescription="Kaven ES-Maloelap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC66", ItemDescription="Ollet ES-Maloelap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC67", ItemDescription="Tarawa ES-Maloelap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC68", ItemDescription="Mejit ES-Mejit", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC69", ItemDescription="Enejet ES-Mili", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC70", ItemDescription="Lukonwod ES-Mili", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC71", ItemDescription="Mili ES-Mili", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC72", ItemDescription="Nallo ES-Mili", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC73", ItemDescription="Tokewa ES-Mili", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC74", ItemDescription="Namdrik ES-Namdrik", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC75", ItemDescription="Loen ES-Namu", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC76", ItemDescription="Mae ES-Namu", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC77", ItemDescription="Majkin ES-Namu", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC78", ItemDescription="Namu ES-Namu", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC79", ItemDescription="Mejatto ES-Ronglap", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC80", ItemDescription="Ujae ES-Ujae", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC81", ItemDescription="Utrik ES-Utrik", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC82", ItemDescription="Wotho ES-Wotho", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC83", ItemDescription="Wodmej ES-Wotje", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC84", ItemDescription="Wotje ES-Wotje", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC85", ItemDescription="Long Island ES - Majuro", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC86", ItemDescription="Matolen ES - Arno", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC87", ItemDescription="Malel & Kilane ES - Arno", Remark="", CreateDate=DateTime.Now},
                new CodeFile(){ID=iflag++, ItemType="SC", ItemCode="SC88", ItemDescription="Tinak Es - Arno", Remark="", CreateDate=DateTime.Now}
                
                
#endregion
            #endregion
             };
            #region 預設Village/Zone
            //  var AllVillage = "Aerok;Ajeltake;Arba;Arno, arno;Aur, Aur;Bikarej;Bikiej;Bouj;Delap;Ebeye;Ebon, Ebon;Elenak;Enebin;Enejet;Enmat;Guggegue;Imiej;Imroj;Ine;Jabwor;Jah;Jaluit, Jaluit;Jang;Jebal;Jebwan;Jeh;Kaven;Kilange;Laura;Loen;Lojaion;Longar;Looj;Lukonwor;Mae;Majkin;Mejatto;Mejririok;Melang;Mili, Mili;Nallu;Namu, namu;Narmij;Odmej;Ollet;Rairok;Rita;Roi-Namur;Santo;Tarawa;Tinak;Tobal;Toka;Tokewa;Tutu;Ulien;Uliga;Woja;Wotje, Wotje;";
            var mapping = new Dictionary<string, List<string>> { 
                {"Ebon",new List<string >{"Ebon, Ebon","Toka"}},
                {"Jaluit",new List<string>{"Jaluit, Jaluit","Narmij","Jabwor","Mejririok","Imiej","Imroj","Mejatto"}},
                {"Ailinglaplap", new List<string>{"Aerok","Bouj","Woja","Jeh","Jah","Jebwan","Enebin"}},
                {"Namu", new List<string>{"Namu, namu","Loen","Majkin","Mae"}},
                {"Kwajalein",new List<string>{"Ebeye","Mejatto","Santo","Roi-Namur","Elenak","Enmat","Bikiej","Arba","Looj","Lojaion","Guggegue"}},
                {"Mili", new List<string>{"Mili, Mili","Nallu","Enejet","Lukonwor","Tokewa"}},
                {"Arno",new List<string>{"Arno, arno","Tinak","Kilange","Ine","Ulien","Bikarej","Tutu","Longar"}},
                {"Aur",new List<string>{"Aur, Aur","Tobal"}},
                {"Maloelap",new List<string>{"Aerok ","Tarawa","Jang","Ollet","Kaven"}},
                {"Wotje", new List<string>{"Wotje, Wotje","Odmej"}},
                {"Likiep", new List<string >{"Jebal","Melang"}},
                {"Majuro", new List<string>{"Rita","Uliga","Delap","Rairok","Ajeltake","Woja","Laura"}}
            };

            //var Village_Array = AllVillage.Split(';');
            var VIcode = 1;
            //foreach (var village in Village_Array)
            //{
            //    CodeFile code = new CodeFile();
            //    code.ID = iflag++;
            //    code.ItemType = "VI";
            //    code.ItemCode = "VI" + VIcode++;
            //    code.ItemDescription = village;
            //    code.Remark = "default";
            //    code.CreateDate = DateTime.Now;
            //    codeFiles.Add(code);
            //}

            foreach (var at in mapping)
            {
                var p = codeFiles.FirstOrDefault(a => a.ItemType == "AT" && a.ItemDescription == at.Key);
                if (p != null)
                {
                    foreach (var v in at.Value)
                    {
                        codeFiles.Add(new CodeFile
                        {
                            ID = iflag++,
                            ParentCodeFile = p.ID,
                            ItemType = "VI",
                            ItemCode = "VI" + VIcode++,
                            ItemDescription = v,
                            Remark = "",
                            CreateDate = DateTime.Now
                        });
                    }
                }
            }

            #endregion
            #region 預設國家
            var AllCountry = "Afghanistan;Åland Islands;Albania;Algeria;American Samoa;Andorra;Angola;Anguilla;Antarctica;Antigua And Barbuda;Argentina;Armenia;Aruba;Australia;Austria;Azerbaijan;Bahamas;Bahrain;Bangladesh;Barbados;Belarus;Belgium;Belize;Benin;Bermuda;Bhutan;Bolivia;Bosnia And Herzegovina;Botswana;Bouvet Island;Brazil;British Indian Ocean Territory;Brunei Darussalam;Bulgaria;Burkina Faso;Burundi;Cambodia;Cameroon;Canada;Cape Verde;Cayman Islands;Central African Republic;Chad;Chile;China;Christmas Island;Cocos (Keeling) Islands;Colombia;Comoros;Congo;Congo, The Democratic Republic Of The;Cook Islands;Costa Rica;Cote D'ivoire;Croatia;Cuba;Cyprus;Czechia;Denmark;Djibouti;Dominica;Dominican Republic;Ecuador;Egypt;El Salvador;Equatorial Guinea;Eritrea;Estonia;Ethiopia;Falkland Islands (Malvinas);Faroe Islands;Fiji;Finland;France;French Guiana;French Polynesia;French Southern Territories;Gabon;Gambia;Georgia;Germany;Ghana;Gibraltar;Greece;Greenland;Grenada;Guadeloupe;Guam;Guatemala;Guernsey;Guinea;Guinea-bissau;Guyana;Haiti;Heard Island And Mcdonald Islands;Holy See (Vatican City State);Honduras;Hong Kong;Hungary;Iceland;India;Indonesia;Iran, Islamic Republic Of;Iraq;Ireland;Isle Of Man;Israel;Italy;Jamaica;Japan;Jersey;Jordan;Kazakhstan;Kenya;Kiribati;Korea, Democratic People's Republic Of;Korea, Republic Of;Kuwait;Kyrgyzstan;Lao People's Democratic Republic;Latvia;Lebanon;Lesotho;Liberia;Libyan Arab Jamahiriya;Liechtenstein;Lithuania;Luxembourg;Macao;Macedonia, The Former Yugoslav Republic Of;Madagascar;Malawi;Malaysia;Maldives;Mali;Malta;Marshall Islands;Martinique;Mauritania;Mauritius;Mayotte;Mexico;Micronesia, Federated States Of;Moldova, Republic Of;Monaco;Mongolia;Montenegro;Montserrat;Morocco;Mozambique;Myanmar;Namibia;Nauru;Nepal;Netherlands;Netherlands Antilles;New Caledonia;New Zealand;Nicaragua;Niger;Nigeria;Niue;Norfolk Island;Northern Mariana Islands;Norway;Oman;Pakistan;Palau;Palestinian Territory, Occupied;Panama;Papua New Guinea;Paraguay;Peru;Philippines;Pitcairn;Poland;Portugal;Puerto Rico;Qatar;Reunion;Romania;Russian Federation;Rwanda;Saint Helena;Saint Kitts And Nevis;Saint Lucia;Saint Pierre And Miquelon;Saint Vincent And The Grenadines;Samoa;San Marino;Sao Tome And Principe;Saudi Arabia;Senegal;Serbia;Seychelles;Sierra Leone;Singapore;Slovakia;Slovenia;Solomon Islands;Somalia;South Africa;South Georgia And The South Sandwich Islands;Spain;Sri Lanka;Sudan;Suriname;Svalbard And Jan Mayen;Swaziland;Sweden;Switzerland;Syrian Arab Republic;Taiwan;Tajikistan;Tanzania, United Republic Of;Thailand;Timor-leste;Togo;Tokelau;Tonga;Trinidad And Tobago;Tunisia;Turkey;Turkmenistan;Turks And Caicos Islands;Tuvalu;Uganda;Ukraine;United Arab Emirates;United Kingdom;United States;United States Minor Outlying Islands;Uruguay;Uzbekistan;Vanuatu;Venezuela;Viet Nam;Virgin Islands, British;Virgin Islands, U.S.;Wallis And Futuna;Western Sahara;Yemen;Zambia;Zimbabwe";
            var Country_Array = AllCountry.Split(';');
            var CTcode = 1;
            foreach (var country in Country_Array)
            {
                CodeFile code = new CodeFile();
                code.ID = iflag++;
                code.ItemType = "CT";
                code.ItemCode = "CT" + CTcode++;
                code.ItemDescription = country;
                code.Remark = "default";
                code.CreateDate = DateTime.Now;
                codeFiles.Add(code);
            }
            #endregion
            #region 預設國籍(Nationality or Citizen)
            var AllNationality = @"Afghan;Albanian;Algerian;American;Andorran;Angolan;Antiguans;Argentinean;Armenian;Australian;Austrian;Azerbaijani;Bahamian;Bahraini;Bangladeshi;Barbadian;Barbudans;Batswana;Belarusian;Belgian;Belizean;Beninese;Bhutanese;Bolivian;Bosnian;Brazilian;British;Bruneian;Bulgarian;Burkinabe;Burmese;Burundian;Cambodian;Cameroonian;Canadian;CapeVerdean;CentralAfrican;Chadian;Chilean;Chinese;Colombian;Comoran;Congolese;CostaRican;Croatian;Cuban;Cypriot;Czech;Danish;Djibouti;Dominican;Dutch;EastTimorese;Ecuadorean;Egyptian;Emirian;EquatorialGuinean;Eritrean;Estonian;Ethiopian;Fijian;Filipino;Finnish;French;Gabonese;Gambian;Georgian;German;Ghanaian;Greek;Grenadian;Guatemalan;Guinea-Bissauan;Guinean;Guyanese;Haitian;Herzegovinian;Honduran;Hungarian;Icelander;Indian;Indonesian;Iranian;Iraqi;Irish;Israeli;Italian;Ivorian;Jamaican;Japanese;Jordanian;Kazakhstani;Kenyan;KittianandNevisian;Kuwaiti;Kyrgyz;Laotian;Latvian;Lebanese;Liberian;Libyan;Liechtensteiner;Lithuanian;Luxembourger;Macedonian;Malagasy;Malawian;Malaysian;Maldivan;Malian;Maltese;Marshallese;Mauritanian;Mauritian;Mexican;Micronesian;Moldovan;Monacan;Mongolian;Moroccan;Mosotho;Motswana;Mozambican;Namibian;Nauruan;Nepalese;NewZealander;Ni-Vanuatu;Nicaraguan;Nigerien;NorthKorean;NorthernIrish;Norwegian;Omani;Pakistani;Palauan;Panamanian;PapuaNewGuinean;Paraguayan;Peruvian;Polish;Portuguese;Qatari;Romanian;Russian;Rwandan;SaintLucian;Salvadoran;Samoan;SanMarinese;SaoTomean;Saudi;Scottish;Senegalese;Serbian;Seychellois;SierraLeonean;Singaporean;Slovakian;Slovenian;SolomonIslander;Somali;SouthAfrican;SouthKorean;Spanish;SriLankan;Sudanese;Surinamer;Swazi;Swedish;Swiss;Syrian;Taiwanese;Tajik;Tanzanian;Thai;Togolese;Tongan;TrinidadianorTobagonian;Tunisian;Turkish;Tuvaluan;Ugandan;Ukrainian;Uruguayan;Uzbekistani;Venezuelan;Vietnamese;Welsh;Yemenite;Zambian;Zimbabwean";
            var Nationality_Array = AllNationality.Split(';');
            var NAcode = 1;
            foreach (var Nationality in Nationality_Array)
            {
                CodeFile code = new CodeFile();
                code.ID = iflag++;
                code.ItemType = "NA";
                code.ItemCode = "NA" + NAcode++;
                code.ItemDescription = Nationality;
                code.Remark = "default";
                code.CreateDate = DateTime.Now;
                codeFiles.Add(code);
            }
            #endregion


            codeFiles.AddRange(subCatList.Select(a => new CodeFile { ID = iflag++, ItemType = "DC", ItemCode = subCatList.IndexOf(a).ToString(), ItemDescription = a, Remark = "", CreateDate = DateTime.Now }));

            #region language
            Dictionary<string, string> datas = new Dictionary<string, string>(){
              {"om","Afaan Oromoo"},
                {"aa","Afaraf"},
                {"af","Afrikaans"},
                {"ak","Akan"},
                {"an","Aragonés"},
                {"ig","Asụsụ Igbo"},
                {"gn","Avañe'ẽ"},
                {"ae","Avesta"}, {"ay","Aymar Aru"},
                {"az","Azərbaycan Dili"},
                {"id","Bahasa Indonesia"},
                {"ms","Bahasa Melayu"},
                {"bm","Bamanankan"},
                {"jv","Basa Jawa"},
                {"su","Basa Sunda"},
                {"bi","Bislama"},
                {"bs","Bosanski Jezik"},
                {"br","Brezhoneg"},
                {"ca","Català"},
                {"ch","Chamoru"},
                {"ny","Chicheŵa"},
                {"sn","Chishona"},
                {"co","Corsu"},
                {"cy","Cymraeg"},
                {"da","Dansk"},
                {"se","Davvisámegiella"},
                {"de","Deutsch"},
                {"nv","Diné Bizaad"},
                {"et","Eesti"},
                {"na","Ekakairũ Naoero"},
                {"en","English"},
                {"es","Español"},
                {"eo","Esperanto"},
                {"eu","Euskara"},
                {"ee","Eʋegbe"},
                {"to","Faka Tonga"},
                {"mg","Fiteny Malagasy"},
                {"fr","Français"},
                {"fy","Frysk"},
                {"ff","Fulfulde"},
                {"fo","Føroyskt"},
                {"ga","Gaeilge"},
                {"gv","Gaelg"},
                {"sm","Gagana Fa'a Samoa"},
                {"gl","Galego"},
                {"sq","Gjuha Shqipe"},
                {"gd","Gàidhlig"},
                {"ki","Gĩkũyũ"},
                {"ha","Hausa"},
                {"ho","Hiri Motu"},
                {"hr","Hrvatski Jezik"},
                {"io","Ido"},
                {"rw","Ikinyarwanda"},
                {"rn","Ikirundi"},
                {"ia","Interlingua"},
                {"nd","Isindebele"},
                {"nr","Isindebele"},
                {"xh","Isixhosa"},
                {"zu","Isizulu"},
                {"it","Italiano"},
                {"ik","Iñupiaq"},
                {"pl","Polski"},
                {"mh","Kajin M̧ajeļ"},
                {"kl","Kalaallisut"},
                {"kr","Kanuri"},
                {"kw","Kernewek"},
                {"kg","Kikongo"},
                {"sw","Kiswahili"},
                {"ht","Kreyòl Ayisyen"},
                {"kj","Kuanyama"},
                {"ku","Kurdî"},
                {"la","Latine"},
                {"lv","Latviešu Valoda"},
                {"lt","Lietuvių Kalba"},
                {"ro","Limba Română"},
                {"li","Limburgs"},
                {"ln","Lingála"},
                {"lg","Luganda"},
                {"lb","Lëtzebuergesch"},
                {"hu","Magyar"},
                {"mt","Malti"},
                {"nl","Nederlands"},
                {"no","Norsk"},
                {"nb","Norsk Bokmål"},
                {"nn","Norsk Nynorsk"},
                {"uz","O'zbek"},
                {"oc","Occitan"},
                {"ie","Interlingue"},
                {"hz","Otjiherero"},
                {"ng","Owambo"},
                {"pt","Português"},
                {"ty","Reo Tahiti"},
                {"rm","Rumantsch Grischun"},
                {"qu","Runa Simi"},
                {"sc","Sardu"},
                {"za","Saɯ Cueŋƅ"},
                {"st","Sesotho"},
                {"tn","Setswana"},
                {"ss","Siswati"},
                {"sl","Slovenski Jezik"},
                {"sk","Slovenčina"},
                {"so","Soomaaliga"},
                {"fi","Suomi"},
                {"sv","Svenska"},
                {"mi","Te Reo Māori"},
                {"vi","Tiếng Việt"},
                {"lu","Tshiluba"},
                {"ve","Tshivenḓa"},
                {"tw","Twi"},
                {"tk","Türkmen"},
                {"tr","Türkçe"},
                {"ug","Uyƣurqə"},
                {"vo","Volapük"},
                {"fj","Vosa Vakaviti"},
                {"wa","Walon"},
                {"tl","Wikang Tagalog"},
                {"wo","Wollof"},
                {"ts","Xitsonga"},
                {"yo","Yorùbá"},
                {"sg","Yângâ Tî Sängö"},
                {"is","ÍSlenska"},
                {"cs","čEština"},
                {"el","ελληνικά"},
                {"av","авар мацӀ"},
                {"ab","аҧсуа бызшәа"},
                {"ba","башҡорт теле"},
                {"be","беларуская мова"},
                {"bg","български език"},
                {"os","ирон æвзаг"},
                {"kv","коми кыв"},
                {"ky","Кыргызча"},
                {"mk","македонски јазик"},
                {"mn","монгол"},
                {"ce","нохчийн мотт"},
                {"ru","русский язык"},
                {"sr","српски језик"},
                {"tt","татар теле"},
                {"tg","тоҷикӣ"},
                {"uk","українська мова"},
                {"cv","чӑваш чӗлхи"},
                {"cu","ѩзыкъ словѣньскъ"},
                {"kk","қазақ тілі"},
                {"hy","Հայերեն"},
                {"yi","ייִדיש"},
                {"he","עברית"},
                {"ur","اردو"},
                {"ar","العربية"},
                {"fa","فارسی"},
                {"ps","پښتو"},
                {"ks","कश्मीरी"},
                {"ne","नेपाली"},
                {"pi","पाऴि"},
                {"bh","भोजपुरी"},
                {"mr","मराठी"},
                {"sa","संस्कृतम्"},
                {"sd","सिन्धी"},
                {"hi","हिन्दी"},
                {"as","অসমীয়া"},
                {"bn","বাংলা"},
                {"pa","ਪੰਜਾਬੀ"},
                {"gu","ગુજરાતી"},
                {"or","ଓଡ଼ିଆ"},
                {"ta","தமிழ்"},
                {"te","తెలుగు"},
                {"kn","ಕನ್ನಡ"},
                {"ml","മലയാളം"},
                {"si","සිංහල"},
                {"th","ไทย"},
                {"lo","ພາສາລາວ"},
                {"bo","བོད་ཡིག"},
                {"dz","རྫོང་ཁ"},
                {"ka","ქართული"},
                {"ti","ትግርኛ"},
                {"am","አማርኛ"},
                {"iu","ᐃᓄᒃᑎᑐᑦ"},
                {"oj","ᐊᓂᔑᓈᐯᒧᐎᓐ"},
                {"cr","ᓀᐦᐃᔭᐍᐏᐣ"},
                {"zh","中文&nbsp;(Zhōngwén)"},
                {"ja","日本語&nbsp;(にほんご)"},
                {"ko","한국어&nbsp;(韓國語)"}
           };


            foreach (var item in datas)
            {
                codeFiles.Add(new CodeFile
                {
                    ID = iflag++,
                    ItemType = "LG",
                    ItemCode = item.Key,
                    ItemDescription = item.Value,
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    ModUser = "root"
                });
            }


            #endregion
            context.CodeFile.AddRange(codeFiles);
            #endregion

            #region Role
            List<Role> Roles = new List<Role>() {
                new Role(){name = "admin" },
                new Role(){name = "doctor" },
                new Role(){name = "registration" },
                new Role(){name = "cashier" },                
                new Role(){name = "mrr" },  
                new Role(){name = "triage" },
                new Role(){name = "pharmacy" }
            };

            context.Role.AddRange(Roles);
            #endregion

            #region ApToRole
            List<Ap2Role> ap2Role = new List<Ap2Role>() {
                //root
                new Ap2Role(){Role=Roles[0],ap_key="A001",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="A010",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="B001",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="B002",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="C001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[0],ap_key="D001",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},                
                new Ap2Role(){Role=Roles[0],ap_key="E001",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="E010",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},                
                new Ap2Role(){Role=Roles[0],ap_key="E030",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="E040",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="H002",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="H003",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="H010",isRead="Y",isAdd="Y",isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[0],ap_key="I001",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},                
                new Ap2Role(){Role=Roles[0],ap_key="K001",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"}, 
                new Ap2Role(){Role=Roles[0],ap_key="K002",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"}, 
                new Ap2Role(){Role=Roles[0],ap_key="K003",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"}, 
                new Ap2Role(){Role=Roles[0],ap_key="K004",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"}, 
                new Ap2Role(){Role=Roles[0],ap_key="Z020",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},  
                new Ap2Role(){Role=Roles[0],ap_key="Z030",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="Z040",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="Z050",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="Z060",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="Z063",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="Z064",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="Z065",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[0],ap_key="Z067",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},                                
                new Ap2Role(){Role=Roles[0],ap_key="Z070",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},                                
                //doctor
                new Ap2Role(){Role=Roles[1],ap_key="A001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[1],ap_key="A010",isRead="Y",isAdd="Y",isUpdate="Y",isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[1],ap_key="B001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[1],ap_key="B002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[1],ap_key="C001",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[1],ap_key="D001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[1],ap_key="E001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[1],ap_key="E010",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[1],ap_key="E030",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[1],ap_key="E040",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[1],ap_key="H002",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[1],ap_key="H003",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[1],ap_key="H010",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[1],ap_key="I001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[1],ap_key="K001",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"}, 
                new Ap2Role(){Role=Roles[1],ap_key="K002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[1],ap_key="K003",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[1],ap_key="K004",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[1],ap_key="Z020",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},  
                new Ap2Role(){Role=Roles[1],ap_key="Z030",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[1],ap_key="Z040",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[1],ap_key="Z050",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[1],ap_key="Z060",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[1],ap_key="Z063",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[1],ap_key="Z064",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[1],ap_key="Z065",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[1],ap_key="Z067",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                                
                new Ap2Role(){Role=Roles[1],ap_key="Z070",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},  
                //registration
                new Ap2Role(){Role=Roles[2],ap_key="A001",isRead="Y",isAdd="Y",isUpdate=null,isDelete=null,isPrint="Y"},
                new Ap2Role(){Role=Roles[2],ap_key="A010",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[2],ap_key="B001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="B002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="C001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="D001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[2],ap_key="E001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="E010",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[2],ap_key="E030",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="E040",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="H002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="H003",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="H010",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="I001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[2],ap_key="K001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[2],ap_key="K002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[2],ap_key="K003",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[2],ap_key="K004",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[2],ap_key="Z020",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},  
                new Ap2Role(){Role=Roles[2],ap_key="Z030",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="Z040",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="Z050",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="Z060",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="Z063",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="Z064",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="Z065",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[2],ap_key="Z067",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                                
                new Ap2Role(){Role=Roles[2],ap_key="Z070",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},  
                //cashier
                new Ap2Role(){Role=Roles[3],ap_key="A001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="A010",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[3],ap_key="B001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="B002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="C001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="D001",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},                
                new Ap2Role(){Role=Roles[3],ap_key="E001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="E010",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[3],ap_key="E030",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="E040",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="H002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="H003",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="H010",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="I001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[3],ap_key="K001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[3],ap_key="K002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[3],ap_key="K003",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[3],ap_key="K004",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[3],ap_key="Z020",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},  
                new Ap2Role(){Role=Roles[3],ap_key="Z030",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="Z040",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="Z050",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="Z060",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="Z063",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="Z064",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="Z065",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[3],ap_key="Z067",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                                
                new Ap2Role(){Role=Roles[3],ap_key="Z070",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},  
                 //mrr                   
                new Ap2Role(){Role=Roles[4],ap_key="A001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="A010",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="B001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="B002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="C001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="D001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[4],ap_key="E001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="E010",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[4],ap_key="E030",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="E040",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="H002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="H003",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="H010",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="I001",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},                
                new Ap2Role(){Role=Roles[4],ap_key="K001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[4],ap_key="K002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[4],ap_key="K003",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[4],ap_key="K004",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[4],ap_key="Z020",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},  
                new Ap2Role(){Role=Roles[4],ap_key="Z030",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="Z040",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="Z050",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="Z060",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="Z063",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="Z064",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="Z065",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[4],ap_key="Z067",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                                
                new Ap2Role(){Role=Roles[4],ap_key="Z070",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},  
                //triage                
                new Ap2Role(){Role=Roles[5],ap_key="A001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="A010",isRead="Y",isAdd="Y",isUpdate=null,isDelete=null,isPrint="Y"},
                new Ap2Role(){Role=Roles[5],ap_key="B001",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[5],ap_key="B002",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[5],ap_key="C001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="D001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[5],ap_key="E001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="E010",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[5],ap_key="E030",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="E040",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="H002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="H003",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="H010",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="I001",isRead="Y",isAdd="Y",isUpdate=null,isDelete=null,isPrint="Y"},                
                new Ap2Role(){Role=Roles[5],ap_key="K001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[5],ap_key="K002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[5],ap_key="K003",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[5],ap_key="K004",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[5],ap_key="Z020",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},  
                new Ap2Role(){Role=Roles[5],ap_key="Z030",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="Z040",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="Z050",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="Z060",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="Z063",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="Z064",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="Z065",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[5],ap_key="Z067",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                                
                new Ap2Role(){Role=Roles[5],ap_key="Z070",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                 //pharmacy                
                new Ap2Role(){Role=Roles[6],ap_key="A001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="A010",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="B001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="B002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="C001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="D001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[6],ap_key="E001",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[6],ap_key="E010",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},                
                new Ap2Role(){Role=Roles[6],ap_key="E030",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[6],ap_key="E040",isRead="Y",isAdd="Y",isUpdate="Y",isDelete="Y",isPrint="Y"},
                new Ap2Role(){Role=Roles[6],ap_key="H002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="H003",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="H010",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="I001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                
                new Ap2Role(){Role=Roles[6],ap_key="K001",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[6],ap_key="K002",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[6],ap_key="K003",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[6],ap_key="K004",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}, 
                new Ap2Role(){Role=Roles[6],ap_key="Z020",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},  
                new Ap2Role(){Role=Roles[6],ap_key="Z030",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="Z040",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="Z050",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="Z060",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="Z063",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="Z064",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="Z065",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},
                new Ap2Role(){Role=Roles[6],ap_key="Z067",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null},                                
                new Ap2Role(){Role=Roles[6],ap_key="Z070",isRead=null,isAdd=null,isUpdate=null,isDelete=null,isPrint=null}
            };

            context.Ap2Role.AddRange(ap2Role);
            #endregion



            #region Dept
            List<int> dps = new List<int>(){
                codeFiles.Where(x => x.ItemType == "DP" && x.ItemCode == "1").Select(x => x.ID).First(),
                codeFiles.Where(x => x.ItemType == "DP" && x.ItemCode == "2").Select(x => x.ID).First(),
                codeFiles.Where(x => x.ItemType == "DP" && x.ItemCode == "3").Select(x => x.ID).First(),
                codeFiles.Where(x => x.ItemType == "DP" && x.ItemCode == "4").Select(x => x.ID).First()
            };
            int MedicalUnitId = codeFiles.FirstOrDefault(a => a.ItemType == "DU" && a.ItemCode == "DU01").ID;
            int AdministratoinUnitId = codeFiles.FirstOrDefault(a => a.ItemType == "DU" && a.ItemCode == "DU02").ID;
            List<Dept> depts = new List<Dept>()
            {
                new Dept(){Category=dps[0], UnitId=MedicalUnitId,DepNo="01",DepName="OPD-GP", IsRegistered="Y", CreateDate=DateTime.Now},
                new Dept(){Category=dps[0], UnitId=MedicalUnitId,DepNo="02",DepName="OPD-IM",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[0], UnitId=MedicalUnitId,DepNo="03",DepName="OPD-ENT",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[0], UnitId=MedicalUnitId,DepNo="04",DepName="OPD-Surg",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[0], UnitId=MedicalUnitId,DepNo="05",DepName="OPD-Eye",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[1], UnitId=MedicalUnitId,DepNo="06",DepName="PH-NCD",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[1], UnitId=MedicalUnitId,DepNo="07",DepName="PH-STD/HIV",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[1], UnitId=MedicalUnitId,DepNo="08",DepName="PH-RH",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[1], UnitId=MedicalUnitId,DepNo="09",DepName="PH-FP",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[1], UnitId=MedicalUnitId,DepNo="10",DepName="PH-BH",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[1], UnitId=MedicalUnitId,DepNo="11",DepName="PH-PE",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[1], UnitId=MedicalUnitId,DepNo="12",DepName="PH-MCH",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[1], UnitId=MedicalUnitId,DepNo="13",DepName="PH-TB",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[1], UnitId=MedicalUnitId,DepNo="14",DepName="PH-HD",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[2], UnitId=MedicalUnitId,DepNo="15",DepName="Dental",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[2], UnitId=MedicalUnitId,DepNo="16",DepName="ER",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[2], UnitId=MedicalUnitId,DepNo="17",DepName="RHC",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[2], UnitId=MedicalUnitId,DepNo="18",DepName="177",IsRegistered="Y",CreateDate=DateTime.Now},
                new Dept(){Category=dps[3], UnitId=AdministratoinUnitId,DepNo="19",DepName="Administration",IsRegistered="",CreateDate=DateTime.Now}
            };

            #region Room
            var Rooms = new List<Room>();
            iflag = 1;
            foreach (var r in depts)
            {
                Rooms.Add(new Room() { RoomNo = "R" + iflag, RoomName = r.DepName + "-Room", RoomMax = 0, CreateDate = DateTime.Now, ModDate = DateTime.Now, ModUser = "sys" });
                iflag++;
            };

            context.Room.AddRange(Rooms);
            #endregion

            foreach (var r in depts)
            {
                var _tempData = Rooms.Where(x => x.RoomName == r.DepName + "-Room").FirstOrDefault();
                if (_tempData != null)
                {
                    var _thisData = new List<Dept2Room>();
                    _thisData.Add(new Dept2Room() { Room = _tempData });
                    r.Dept2Room = _thisData;
                }
            }

            context.Dept.AddRange(depts);
            #endregion

            #region Account
            var Accounts = new List<Account>()
            {
            #region 機關用demo帳號
                new Account()
                {
                    ID = 1,
                    Name = "root",
                    Email = "root@majuro.com",
                    UserNo = "U000001",
                    Password = "XZTMpaPAnb1KjNwmFR03lw==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,                    
                    Status="1"
                },
                new Account()
                {
                    ID = 2,
                    Name = "doctor",
                    Email = "doctor@majuro.com",
                    UserNo = "D000002",
                    Password = "XZTMpaPAnb1KjNwmFR03lw==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",
                    IsDoctor = "Y"
                },
                new Account()
                {
                    ID = 3,
                    Name = "reg",
                    Email = "reg@majuro.com",
                    UserNo = "U000003",
                    Password = "XZTMpaPAnb1KjNwmFR03lw==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1"
                },
                new Account()
                {
                    ID = 4,
                    Name = "cashier",
                    Email = "cashier@majuro.com",
                    UserNo = "U000004",
                    Password = "XZTMpaPAnb1KjNwmFR03lw==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1"
                },
                new Account()
                {
                    ID = 5,
                    Name = "mrr",
                    Email = "mrr@majuro.com",
                    UserNo = "U000005",
                    Password = "XZTMpaPAnb1KjNwmFR03lw==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1"
                },
                new Account()
                {
                    ID = 6,
                    Name = "triage",
                    Email = "triage@majuro.com",
                    UserNo = "U000006",
                    Password = "XZTMpaPAnb1KjNwmFR03lw==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1"
                },
                new Account()
                {
                    ID = 7,
                    Name = "pharmacy",
                    Email = "pharmacy@majuro.com",
                    UserNo = "U000007",
                    Password = "XZTMpaPAnb1KjNwmFR03lw==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1"
                },
#endregion
            #region Doctor Account 
                new Account()
                {
                    ID = 8,
                    Name = "Dr. Mary Jane Gancio",
                    Email = "Jane@majuro.com",
                    UserNo = "U000008",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title= "Pediatrician",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 9,
                    Name = "Dr. Virgilio  Villaroya",
                    Email = "Bong@majuro.com",
                    UserNo = "U000009",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title= "Internist",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 10,
                    Name = "Dr. Tarine Butuna",
                    Email = "Tarine@majuro.com",
                    UserNo = "U000010",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                   Title= "Internist",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 11,
                    Name = "Dr. Peter Hasagulmal",
                    Email = "Peter@majuro.com",
                    UserNo = "U000011",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title= "Surgeon",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 12,
                    Name = "Dr. Marie Lanwi-Paul",
                    Email = "Marie@majuro.com",
                    UserNo = "U000012",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Family  Physician",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 13,
                    Name = "Dr. Tom Jack",
                    Email = "Tom@majuro.com",
                    UserNo = "U000013",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Public Health Medical Director",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 14,
                    Name = "Dr. Zachraias Zachraias",
                    Email = "Zach@majuro.com",
                    UserNo = "U000014",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Family  Physician",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 15,
                    Name = "Dr. Kennar Briand",
                    Email = "Kennar@majuro.com",
                    UserNo = "U000015",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Chief of Staff",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 16,
                    Name = "Dr. Maria Theresa Cristobal",
                    Email = "Theresa@majuro.com",
                    UserNo = "U000016",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Dentist",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 17,
                    Name = "Dr. Robert Maddison",
                    Email = "Robert@majuro.com",
                    UserNo = "U000017",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 18,
                    Name = "Medex Yoseph Kintaro",
                    Email = "Yoseph@majuro.com",
                    UserNo = "U000018",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Medical Assistant",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 19,
                    Name = "Ken Jetton",
                    Email = "Kennar@majuro.com",
                    UserNo = "U000019",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Medical Assistant",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",                    
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 20,
                    Name = "Dr. Dustin Maita Bantol",
                    Email = "Dustin@majuro.com",
                    UserNo = "U000020",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Dentist",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 21,
                    Name = "Dr. Aristotle Cruz",
                    Email = "Aristotle@majuro.com",
                    UserNo = "U000021",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="ER Doctor",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 22,
                    Name = "Dr. Gael Lavina",
                    Email = "Gael@majuro.com",
                    UserNo = "U000022",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="DOE Physician",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 23,
                    Name = "Dr. Helentina Garstang",
                    Email = "Helentina@majuro.com",
                    UserNo = "U000023",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Family  Physician",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 24,
                    Name = "Dr. Tessie Briand",
                    Email = "Tessie@majuro.com",
                    UserNo = "U000024",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Dentist",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 25,
                    Name = "David T. Ackley",
                    Email = "David@majuro.com",
                    UserNo = "U000025",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Family  Physician",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 26,
                    Name = "Dr. Helen Salvador",
                    Email = "Helen@majuro.com",
                    UserNo = "U000026",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="OBGYNE",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 27,
                    Name = "Dr. Jofiti Tuiloma",
                    Email = "Jofiti@majuro.com",
                    UserNo = "U000027",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Dentist",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 28,
                    Name = "Dr. Rodney Catilo",
                    Email = "Rodney@majuro.com",
                    UserNo = "U000028",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Surgeon",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 29,
                    Name = "Dr.Manasa Baleinamau",
                    Email = "Manasa@majuro.com",
                    UserNo = "U000029",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Pediatrician",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 30,
                    Name = "Dr.Caryl Labe",
                    Email = "Caryl@majuro.com",
                    UserNo = "U000030",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Internist",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 31,
                    Name = "Dr. Maribeth Caguingin",
                    Email = "Maribeth@majuro.com",
                    UserNo = "U000031",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="ER Doctor",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 32,
                    Name = "Dr.Geremias Caguingin",
                    Email = "Geremias@majuro.com",
                    UserNo = "U000032",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="ER Doctor",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 33,
                    Name = "Dr.Ivy Claire Lapidez",
                    Email = "Ivy@majuro.com",
                    UserNo = "U000033",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="OBGYNE",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 34,
                    Name = "Dr.Diona Mae Cabrera",
                    Email = "Diona@majuro.com",
                    UserNo = "U000034",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="ER Doctor",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 35,
                    Name = "DR.David Alfred",
                    Email = "David@majuro.com",
                    UserNo = "U000035",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Family  Physician",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 36,
                    Name = "Dr.Darlene Belonio",
                    Email = "Darlene@majuro.com",
                    UserNo = "U000036",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Internist",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 37,
                    Name = "Dr.Joemil Donasco",
                    Email = "Joemil@majuro.com",
                    UserNo = "U000037",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Surgeon",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 38,
                    Name = "Dr. Andrea Abello",
                    Email = "Andrea@majuro.com",
                    UserNo = "U000038",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="OBGYNE",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },new Account()
                {
                    ID = 39,
                    Name = "Uraia Rogdtava",
                    Email = "Uraia@majuro.com",
                    UserNo = "U000039",
                    Password = "IDrZOObDiQ44OPt/xOak3w==",
                    Gender = "M",
                    Birthday = new DateTime(1940, 10, 29),
                    Tel = "",
                    Comment = "",
                    Experience = "",
                    Major = "",
                    Title="Pediatrician",
                    CreateDate = DateTime.Now,
                    ModDate = DateTime.Now,
                    Status="1",          
                    IsDoctor = "Y"
                },

#endregion
            };

            //add all dept
            foreach (var r in Accounts)
            {
                if (r.IsDoctor == "Y")
                {
                    List<Account2Dept> _acc2dept = new List<Account2Dept>();
                    foreach (var r1 in depts.Where(x => x.DepNo != "19"))
                    {
                        _acc2dept.Add(new Account2Dept() { Dept = r1 });
                    }
                    r.Account2Role = new List<Account2Role>() { new Account2Role() { Role = Roles[1] } };
                    r.Account2Dept = _acc2dept;
                }
            }

            context.Account.AddRange(Accounts);
            #endregion

            #region AccountToRole
            context.Account2Role.AddOrUpdate(new Account2Role() { Account = Accounts[0], Role = Roles[0] },
                new Account2Role() { Account = Accounts[1], Role = Roles[1] },
                new Account2Role() { Account = Accounts[2], Role = Roles[2] },
                new Account2Role() { Account = Accounts[3], Role = Roles[3] },
                new Account2Role() { Account = Accounts[4], Role = Roles[4] },
                new Account2Role() { Account = Accounts[5], Role = Roles[5] },
                new Account2Role() { Account = Accounts[6], Role = Roles[6] });
            #endregion

            #region phrase
            context.Phrase.AddOrUpdate(
                new Phrase() { Account = Accounts[1], PhraseCode = "IVH", PhaereContent = "intraventricular hemorrhage" },
                new Phrase() { Account = Accounts[1], PhraseCode = "CHD", PhaereContent = "congenital heart disease" },
                new Phrase() { Account = Accounts[1], PhraseCode = "CHT", PhaereContent = "congenital hypothyroidism" },
                new Phrase() { Account = Accounts[1], PhraseCode = "CLD", PhaereContent = "chronic liver disease" },
                new Phrase() { Account = Accounts[1], PhraseCode = "ARF", PhaereContent = "acute renal failure" }
            );
            #endregion
            #region package
            context.Kit.AddOrUpdate(
                new Kit() { ID = Guid.NewGuid(), Account = Accounts[1], KitCode = "P001", KitDescription = "type 1 diabetes", Subjective = "This 65-year-old woman returns to the wound care center for followup of left plantar foot wound. The patient comes in without any dressing on her foot for approximately the fourth time in the last few weeks. The patient states that she was too tired to put her dressing on. She recently took a medical leave from work for the next three months to try and stay off her feet. She has been taking her antibiotics and denies any constitutional symptoms at this time.", Objective = "The patient has a large wound on the plantar aspect of her left forefoot area. There is a significant amount of periwound callus with maceration. She also has a malodor coming from the foot wound. The wound bed is fibrotic with some bleeding with debridement. The foot appears to be much more swollen than last visit. There is no streaking or purulent drainage. No bone visible in the wound at this time. The patient is status post left first ray amputation and right BKA. Left plantar foot wound is cultured today. The patient is also being sent for hemoglobin A1c to assess her diabetes.", ICD10Code1 = "E10" },
                new Kit() { ID = Guid.NewGuid(), Account = Accounts[1], KitCode = "P002", KitDescription = "COPD/Pneumonia", Subjective = "Pt. reports not feeling well today, I'm very tired.", Objective = "Auscultation findings: scattered rhonchi all lung fields. Chest PT was performed in sitting (ant. and post.). Techniques included percussion, vibration, and shaking. Pt. performed a weak combined abdominal and upper costal cough that was nonbronchospastic, congested, and non-productive. The cough/huff was performed with VC. Pectoral stretch/thoracic cage mobilizations performed in seated position. Pt. given towel roll placed in back of seat to open up ant. chest wall. Strengthening exercises in standing - pt. performed hip flexion, extension, and abduction; knee flexion 10 reps x 1 set B. Pt. performs HEP with supervision (in evenings with wife). Pt. instructed to hold tissue over trach when speaking to prevent infection and explained importance of drinking enough water" },
                new Kit() { ID = Guid.NewGuid(), Account = Accounts[1], KitCode = "P003", KitDescription = "type 2 diabetes", Subjective = @"Client said, I am happy now that I have gone down a pants size.Feeling “deprived” on self-imposed diet.Inquired about blood cholesterol changes resulting from exercising.Client seems much more upbeat about exercise compared with earlier sessions, when she was pessimistic about the prospects of making progress.", Objective = "Waist circumference = 42 inches (has dropped 1 inch since 01/15/08).Weight = 190 lb (2 lb less than last week).RHR has decreased from 75 bpm to 70 bpm since 01/15/08." }
                );
            #endregion

            #region elearning
            context.Course.AddOrUpdate(
                    new Course()
                    {
                        Name = "Cardiopulmonary resuscitatio",
                        Description = "Cardiopulmonary resuscitation, commonly known as CPR, is an emergency procedure that combines chest compression often with artificial ventilation in an effort to manually preserve intact brain function until further measures are taken to restore spontaneous blood circulation and breathing in a person who is in cardiac arrest. It is indicated in those who are unresponsive with no breathing or abnormal breathing, for example, agonal respirations.",
                        Room = Rooms[0],
                        CourseType = codeFiles.Where(x => x.ItemType == "CS").Select(x => x.ID).FirstOrDefault(),
                        WayOfTeaching = "Classroom",
                        Enrollment = 0,
                        NeedRecord = false,
                        BroadcastLive = false,
                        BeginTime = new DateTime(2018, 3, 27),
                        EndTime = new DateTime(2018, 3, 27, 23, 59, 59),
                        OpenEnrollment = false,
                        EmailNotice = false,
                        IsDeleted = false,
                        IsEnabled = true,
                        Created = System.DateTime.Now,
                        Creator = "root",
                        CreatorID = 1
                    }
                );
            #endregion
            #region Drug
            List<Drug> drugs = new List<Drug>() {                
                new Drug(){OrderCode="P0001", DrugCode="P0001",Title="[P01]panadol" },
                new Drug(){OrderCode="P0002", DrugCode="P0002", Title="[P01]Prednisolone"},                        
                new Drug(){OrderCode="A0001", DrugCode="A0001",DrugType="Default", Title="Per Admission Fee - RMI CITIZEN", PatientFromType=PatientFrom.Local},
                new Drug(){OrderCode="A0002", DrugCode="A0002",DrugType="Default", Title="Delivery with recorded Prenatal visit starting on the 1st Trimester - RMI CITIZEN", PatientFromType=PatientFrom.Local},
                new Drug(){OrderCode="A0003", DrugCode="A0003",DrugType="Default", Title="Delivery without recorded Prenatal visit starting on the 1st Trimester - RMI CITIZEN", PatientFromType=PatientFrom.Local},
                new Drug(){OrderCode="A0004", DrugCode="A0004",DrugType="Default", Title="Emergency Per Visit - RMI CITIZEN", PatientFromType=PatientFrom.Local},
                new Drug(){OrderCode="A0005", DrugCode="A0005",DrugType="Default", Title="Dental Visit - RMI CITIZEN", PatientFromType=PatientFrom.Local},
                new Drug(){OrderCode="A0006", DrugCode="A0006",DrugType="Default", Title="Partial Denture Per Service - RMI CITIZEN", PatientFromType=PatientFrom.Local},
                new Drug(){OrderCode="A0007", DrugCode="A0007",DrugType="Default", Title="Whole Denture Per Service - RMI CITIZEN", PatientFromType=PatientFrom.Local},
                new Drug(){OrderCode="A0008", DrugCode="A0008",DrugType="Default", Title="Outpatient Visit (All Type) - RMI CITIZEN", PatientFromType=PatientFrom.Local},
                new Drug(){OrderCode="A0009", DrugCode="A0009",DrugType="Default", Title="Health Certificate  - RMI CITIZEN", PatientFromType=PatientFrom.Local},
                new Drug(){OrderCode="A0010", DrugCode="A0010",DrugType="Default", Title="Food Handler Exam - RMI CITIZEN", PatientFromType=PatientFrom.Local},
                new Drug(){OrderCode="A0011", DrugCode="A0011",DrugType="Default", Title="Taxi Driver Exam - RMI CITIZEN", PatientFromType=PatientFrom.Local},
                new Drug(){OrderCode="A0012", DrugCode="A0012",DrugType="Default", Title="Yello Card Certificate - RMI CITIZEN", PatientFromType=PatientFrom.Local},

                new Drug(){OrderCode="A0013", DrugCode="A0013",DrugType="Default", Title="Per Admission Fee - NON CITIZEN", PatientFromType=PatientFrom.Visitor},
                new Drug(){OrderCode="A0014", DrugCode="A0014",DrugType="Default", Title="Delivery with recorded Prenatal visit starting on the 1st Trimester - NON CITIZEN", PatientFromType=PatientFrom.Visitor},
                new Drug(){OrderCode="A0015", DrugCode="A0015",DrugType="Default", Title="Delivery without recorded Prenatal visit starting on the 1st Trimester - NON CITIZEN", PatientFromType=PatientFrom.Visitor},
                new Drug(){OrderCode="A0016", DrugCode="A0016",DrugType="Default", Title="Emergency Per Visit - NON CITIZEN", PatientFromType=PatientFrom.Visitor},
                new Drug(){OrderCode="A0017", DrugCode="A0017",DrugType="Default", Title="Dental Visit - NON CITIZEN", PatientFromType=PatientFrom.Visitor},
                new Drug(){OrderCode="A0018", DrugCode="A0018",DrugType="Default", Title="Partial Denture Per Service - NON CITIZEN", PatientFromType=PatientFrom.Visitor},
                new Drug(){OrderCode="A0019", DrugCode="A0019",DrugType="Default", Title="Whole Denture Per Service - NON CITIZEN", PatientFromType=PatientFrom.Visitor},
                new Drug(){OrderCode="A0020", DrugCode="A0020",DrugType="Default", Title="Outpatient Visit (All Type) - NON CITIZEN", PatientFromType=PatientFrom.Visitor},
                new Drug(){OrderCode="A0021", DrugCode="A0021",DrugType="Default", Title="Health Certificate  - NON CITIZEN", PatientFromType=PatientFrom.Visitor},
                new Drug(){OrderCode="A0022", DrugCode="A0022",DrugType="Default", Title="Food Handler Exam - NON CITIZEN", PatientFromType=PatientFrom.Visitor},
                new Drug(){OrderCode="A0023", DrugCode="A0023",DrugType="Default", Title="Taxi Driver Exam - NON CITIZEN", PatientFromType=PatientFrom.Visitor},
                new Drug(){OrderCode="A0024", DrugCode="A0024",DrugType="Default", Title="Yello Card Certificate - NON CITIZEN", PatientFromType=PatientFrom.Visitor},
            };
            List<DrugAppearance> drugApp = new List<DrugAppearance>() { 
                new DrugAppearance(){Drug=drugs[0], MajorType=codeFiles.Where(x=>x.ItemType=="TP").Select(x=>x.ID).First().ToString(), Color=codeFiles.Where(x=>x.ItemType=="CO").Select(x=>x.ID).First().ToString(), Shape=codeFiles.Where(x=>x.ItemType=="SP").Select(x=>x.ID).First().ToString()},
                new DrugAppearance(){Drug=drugs[1], MajorType=codeFiles.Where(x=>x.ItemType=="TP").Select(x=>x.ID).First().ToString(), Color=codeFiles.Where(x=>x.ItemType=="CO").Select(x=>x.ID).First().ToString(), Shape=codeFiles.Where(x=>x.ItemType=="SP").Select(x=>x.ID).First().ToString()}
            };
            iflag = 0;
            List<DrugCost> drugCost = new List<DrugCost>() { 
                new DrugCost(){Drug=drugs[iflag++], Price=20, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=50, Ver="1", CreateAt=DateTime.Now},                                
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=5, DailyFee=5, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=5, DailyFee=5, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=20, DailyFee=5, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=10, DailyFee=10, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=5, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=5, DailyFee=10, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=5, DailyFee=20, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=5, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=8, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=8, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=8, Ver="1", CreateAt=DateTime.Now},                                            
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=8, Ver="1", CreateAt=DateTime.Now},                                         
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=125, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=125, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=125, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=35, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=17, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=17, DailyFee=50, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=17, DailyFee=100, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=20, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=20, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=20, Ver="1", CreateAt=DateTime.Now},
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=20, Ver="1", CreateAt=DateTime.Now},                                            
                new DrugCost(){Drug=drugs[iflag++], Price=0, InitialFee=null, DailyFee=20, Ver="1", CreateAt=DateTime.Now}
            };
            List<DrugSetting> drugSetting = new List<DrugSetting>() { 
                new DrugSetting(){Drug=drugs[0], Dose=3,  Frequency=codeFiles.Where(x=>x.ItemType=="FQ").Select(x=>x.ID).First().ToString(),Route=codeFiles.Where(x=>x.ItemType=="RU").Select(x=>x.ID).First().ToString(), Days=5, Quantity=15},
                new DrugSetting(){Drug=drugs[1], Dose=3,  Frequency=codeFiles.Where(x=>x.ItemType=="FQ").Select(x=>x.ID).First().ToString(),Route=codeFiles.Where(x=>x.ItemType=="RU").Select(x=>x.ID).First().ToString(), Days=5, Quantity=15}
            };

            context.Drug.AddRange(drugs);
            context.DrugAppearance.AddRange(drugApp);
            context.DrugCost.AddRange(drugCost);
            context.DrugSetting.AddRange(drugSetting);
            #endregion

            //#region execute sql file in (icd10)
            //var sqlFiles = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "/Sql/", "*.sql");
            //foreach (var file in sqlFiles)
            //{
            //    context.Database.ExecuteSqlCommand(System.IO.File.ReadAllText(file));
            //}
            //#endregion

            base.Seed(context);
        }
    }

    internal class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetCreatedDateColumn(addColumnOperation.Column);

            base.Generate(addColumnOperation);
        }

        protected override void Generate(CreateTableOperation createTableOperation)
        {
            SetCreatedDateColumn(createTableOperation.Columns);

            base.Generate(createTableOperation);
        }

        private static void SetCreatedDateColumn(IEnumerable<ColumnModel> columns)
        {
            foreach (var columnModel in columns)
            {
                SetCreatedDateColumn(columnModel);
            }
        }

        private static void SetCreatedDateColumn(PropertyModel column)
        {
            List<string> listCreateCol = new List<string>() { "CreateDate", "CreatedAt", "Created" };
            if (listCreateCol.Contains(column.Name))
            {
                column.DefaultValueSql = "GETDATE()";
            }
        }
    }
}
