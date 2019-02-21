update MedicalRecord set VisitDate=CreatedAt
update Dept set Clinic='OPD' where DepName like 'OPD%'
update Dept set Clinic=depName  where DepName in ('PH-NCD','PH-STD/HIV','PH-RH','PH-FP','PH-BH','PH-PE','PH-MCH','PH-TB','PH-HD','Dental','ER','177','Pharmacy','Taiwan Mission')
update dept set clinic ='RHC' where DepName in ('RHC-Women''s Health','RHC-FP','RHC-Prenatal')

update mr set dept_id=d.ID 
from MedicalRecord mr
inner join Dept d on mr.DeptName=d.clinic

update OpdRecord set TempCreatedAt=SubmitedAt where SubmitedAt is not null
update record set opdregisterid=reg.id from OpdRecord record inner join OpdRegister reg on record.id=reg.OpdRecordID