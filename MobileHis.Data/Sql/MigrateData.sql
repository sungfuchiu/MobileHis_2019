DECLARE @mrId INT
	,@deptid INT
	,@drid INT
	,@PatientID NVARCHAR(12)
	,@date VARCHAR(10)
	,@orderdate VARCHAR(10)
	,@cnt INT
	,@regid INT
	,@recordid INT
	,@defaultDr INT
	,@defaultDept INT = 1
	,@defaultRm INT;

SELECT TOP 1 @defaultDr = id
FROM Account WITH (NOLOCK)
WHERE Name = 'doctor'

SELECT TOP 1 @defaultDept = id
FROM Dept WITH (NOLOCK)
WHERE DepName = 'Taiwan Mission'

SELECT TOP 1 @defaultRm = id
FROM Room WITH (NOLOCK)
WHERE RoomName = 'Administration-Room'

UPDATE reg
SET reg.MedicalRecordid = mr.id
FROM opdregister reg
INNER JOIN MedicalRecord mr ON reg.id = mr.opdregisterid

UPDATE r
SET r.opdregisterid = reg.id
FROM opdrecord r
INNER JOIN opdregister reg ON r.id = reg.opdrecordid

PRINT 'update mr which hv no record'

DECLARE contact_cursor CURSOR
FOR
SELECT mr.id
	,mr.Dept_ID
	,mr.Doctor
	,mr.PatientID
	,convert(VARCHAR(10), mr.createdAt, 112) orderDate
	,mr.CreatedAt
	,reg.id regid
	,r.id recordid
FROM [MedicalRecord] mr WITH (NOLOCK)
LEFT JOIN OpdRegister reg WITH (NOLOCK) ON mr.id = reg.MedicalRecordid
LEFT JOIN OpdRecord r WITH (NOLOCK) ON r.OpdRegisterId = reg.id
WHERE mr.IsDeleted = 0
	AND DeptName IS NOT NULL
	AND DeptName <> ''
	AND deptName NOT LIKE '%Pharmacy%'
	AND (
		mr.OpdRegisterId IS NOT NULL
		OR ICD10_1 IS NOT NULL
		)
	AND r.id IS NULL
	AND dept_id IS NOT NULL
ORDER BY mr.CreatedAt DESC
	,PatientID DESC

OPEN contact_cursor;

FETCH NEXT
FROM contact_cursor
INTO @mrId
	,@deptId
	,@drid
	,@PatientID
	,@orderdate
	,@date
	,@regid
	,@recordid;

WHILE @@FETCH_STATUS = 0
BEGIN
	PRINT 'Patient: ' + @PatientID
	PRINT 'Date: ' + @orderdate
	PRINT 'MR id: ' + convert(VARCHAR, @mrid)
	PRINT 'regId: ' + convert(VARCHAR, @regid)
	PRINT 'recordid: ' + convert(VARCHAR, @recordid)

	SET @drid = ISNULL(@drid, @defaultdr)

	IF (
			SELECT count(*)
			FROM patient
			WHERE PatientID = @PatientID
			) > 0
	BEGIN
		IF @regid IS NULL
		BEGIN
			PRINT 'need to make appointment'

			--check sch by date n dept n doctor
			DECLARE @schId INT = NULL

			PRINT 'dept: ' + convert(VARCHAR, @deptid) + ', dr: ' + convert(VARCHAR, @drid)

			SET @schId = (
					SELECT TOP 1 id
					FROM DorSchedule
					WHERE AccountID = @drid
						AND DeptID = @deptid
						AND convert(VARCHAR(10), schdate, 112) = @orderdate
						AND isDeleted = 0
					)

			IF @schId IS NULL
			BEGIN
				PRINT 'need create sch'

				DECLARE @reg_rm INT = NULL

				SET @reg_rm = (
						SELECT TOP 1 Room_id
						FROM Dept2Room
						WHERE Dept_id = @deptid
						)

				PRINT 'Create sch: dept: ' + convert(VARCHAR, @deptid) + ', doctor: ' + convert(VARCHAR, @drid) + ', rm: ' + convert(VARCHAR, @reg_rm)

				INSERT INTO [dbo].[DorSchedule] (
					[SchDate]
					,[AccountID]
					,[ShiftNo]
					,[DeptID]
					,[RoomID]
					,[isDeleted]
					,[CreateDate]
					,[ModDate]
					,[ModUser]
					)
				VALUES (
					@date
					,@drid
					,'1'
					,@deptid
					,@reg_rm
					,0
					,@date
					,getdate()
					,'sys'
					)

				SELECT TOP 1 @schId = id
				FROM [dbo].[DorSchedule] WITH (NOLOCK)
				WHERE AccountID = @drid
					AND ShiftNo = 1
					AND DeptID = @deptid
					AND convert(VARCHAR(10), schdate, 112) = @orderdate
					AND isDeleted = 0
				ORDER BY [ModDate] DESC
			END

			PRINT 'create reg for: ' + @PatientID

			INSERT INTO [dbo].[OpdRegister] (
				[OpdDate]
				,[PatinetID]
				,[Deptid]
				,[RoomID]
				,[ShiftNo]
				,[CreateDate]
				,[ModDate]
				,[ModUser]
				,[DorScheduleId]
				,[MedicalRecordId]
				)
			VALUES (
				@date
				,@PatientID
				,@deptid
				,@reg_rm
				,'1'
				,@date
				,getdate()
				,'sys'
				,@schId
				,@mrId
				)

			SET @regid = (
					SELECT TOP 1 id
					FROM OpdRegister
					WHERE DorScheduleId = @schId
						AND OpdDate = @date
						AND PatinetID = @PatientID
					ORDER BY ModDate DESC
					)

			PRINT 'regId update to : ' + convert(VARCHAR, @regid)
		END

		--------------------------------------------------	
		PRINT 'create record by mr'

		DECLARE @icd1 NVARCHAR(10) = NULL
			,@icd2 NVARCHAR(10) = NULL
			,@icd3 NVARCHAR(10) = NULL
			,@icd4 NVARCHAR(10) = NULL

		SELECT @icd1 = ICD10_1
			,@icd2 = ICD10_2
			,@icd3 = ICD10_3
			,@icd4 = ICD10_4
		FROM MedicalRecord
		WHERE id = @mrId

		INSERT INTO [dbo].[OpdRecord] (
			[OpdRegisterId]
			,[PatinetID]
			,[DoctorID]
			,[Date]
			,[DeptID]
			,[SubmitedAt]
			,[CreatedAt]
			)
		VALUES (
			@regid
			,@PatientID
			,@drid
			,@date
			,@deptid
			,@date
			,getdate()
			)

		SELECT TOP 1 @recordId = id
		FROM OpdRecord
		ORDER BY id DESC

		IF @icd1 IS NOT NULL
		BEGIN
			INSERT INTO OpdRecord2ICD10 (
				OpdRecordID
				,ICD10Code
				,[Index]
				)
			VALUES (
				@recordId
				,@icd1
				,1
				)
		END

		IF @icd2 IS NOT NULL
		BEGIN
			INSERT INTO OpdRecord2ICD10 (
				OpdRecordID
				,ICD10Code
				,[Index]
				)
			VALUES (
				@recordId
				,@icd2
				,2
				)
		END

		IF @icd3 IS NOT NULL
		BEGIN
			INSERT INTO OpdRecord2ICD10 (
				OpdRecordID
				,ICD10Code
				,[Index]
				)
			VALUES (
				@recordId
				,@icd3
				,3
				)
		END

		IF @icd4 IS NOT NULL
		BEGIN
			INSERT INTO OpdRecord2ICD10 (
				OpdRecordID
				,ICD10Code
				,[Index]
				)
			VALUES (
				@recordId
				,@icd4
				,4
				)
		END

		SET @regid = NULL
		SET @recordid = NULL
		SET @date = NULL
		SET @mrId = NULL
		SET @deptid = NULL
		SET @drid = NULL
	END

	FETCH NEXT
	FROM contact_cursor
	INTO @mrId
		,@deptId
		,@drid
		,@PatientID
		,@orderdate
		,@date
		,@regid
		,@recordid;
END

CLOSE contact_cursor;

DEALLOCATE contact_cursor;

PRINT 'update mr which hv record'

DECLARE hv_record_cursor CURSOR
FOR
WITH data
AS (
	SELECT mr.PatientID
		,convert(VARCHAR(10), mr.createdAt, 112) orderDate
		,CONVERT(VARCHAR, mr.CreatedAt, 101) DATE
		,count(mr.id) cnt
	FROM [MedicalRecord] mr WITH (NOLOCK)
	LEFT JOIN OpdRegister reg WITH (NOLOCK) ON mr.id = reg.MedicalRecordid
	LEFT JOIN OpdRecord r WITH (NOLOCK) ON r.OpdRegisterId = reg.id
	WHERE mr.IsDeleted = 0
		AND DeptName IS NOT NULL
		AND DeptName <> ''
		AND deptName NOT LIKE '%Pharmacy%'
		AND (
			r.id IS NOT NULL
			OR reg.id IS NOT NULL
			)
	GROUP BY mr.PatientID
		,convert(VARCHAR(10), mr.createdAt, 112)
		,CONVERT(VARCHAR, mr.CreatedAt, 101)
	)
SELECT *
FROM data
WHERE cnt > 1

OPEN hv_record_cursor;

FETCH NEXT
FROM hv_record_cursor
INTO @PatientID
	,@orderdate
	,@date
	,@cnt;

WHILE @@FETCH_STATUS = 0
BEGIN
	DECLARE @hv_mrid INT = NULL

	SET @hv_mrid = (
			SELECT TOP 1 id
			FROM [MedicalRecord]
			WHERE patientid = @PatientID
				AND convert(VARCHAR(10), createdat, 101) = @date
			ORDER BY createdat DESC
			)

	PRINT 'map opd register n mr'

	UPDATE opdregister
	SET [MedicalRecordid] = @hv_mrid
		,moduser = 'sys'
		,moddate = getdate()
	WHERE PatinetID = @PatientID
		AND convert(VARCHAR(10), createdate, 101) = @date

	PRINT 'update ss';

	WITH a
	AS (
		SELECT convert(INT, Diarrhea) 'Diarrhea'
			,convert(INT, ILI) ILI
			,convert(INT, Prolonged_Fever) Prolonged_Fever
			,convert(INT, AFR) AFR
			,convert(INT, NoneAll) NoneAll
		FROM MedicalRecord
		WHERE PatientID = @PatientID
			AND CONVERT(VARCHAR(10), createdat, 101) = @date
		)
		,cntList
	AS (
		SELECT @mrId AS mrid
			,sum(Diarrhea) AS d
			,sum(ili) AS ili
			,sum(Prolonged_Fever) AS p
			,sum(afr) AS afr
			,sum(noneall) AS n
		FROM a
		)
		,result
	AS (
		SELECT mrid
			,CASE 
				WHEN d > 0
					THEN 1
				ELSE 0
				END AS 'Diarrhea'
			,CASE 
				WHEN ili > 0
					THEN 1
				ELSE 0
				END AS 'ILI'
			,CASE 
				WHEN p > 0
					THEN 1
				ELSE 0
				END AS 'Prolonged_Fever'
			,CASE 
				WHEN afr > 0
					THEN 1
				ELSE 0
				END AS 'AFR'
			,CASE 
				WHEN n > 0
					THEN 1
				ELSE 0
				END AS 'NoneAll'
		FROM cntList
		)
	UPDATE mr
	SET Diarrhea = r.Diarrhea
		,ILI = r.ILI
		,Prolonged_Fever = r.Prolonged_Fever
		,AFR = r.AFR
		,NoneAll = r.NoneAll
		,mr.UpdatedBy = 'sys'
		,mr.UpdatedAt = GETDATE()
	FROM MedicalRecord mr
	INNER JOIN result r ON mr.ID = r.mrid

	PRINT 'set delete'

	UPDATE [MedicalRecord]
	SET isdeleted = 1
		,UpdatedBy = 'sys'
		,UpdatedAt = GETDATE()
	WHERE patientid = @PatientID
		AND convert(VARCHAR(10), createdat, 101) = @date
		AND id <> @hv_mrid

	FETCH NEXT
	FROM hv_record_cursor
	INTO @PatientID
		,@orderdate
		,@date
		,@cnt;
END

CLOSE hv_record_cursor;

DEALLOCATE hv_record_cursor;