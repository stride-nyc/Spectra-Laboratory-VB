CREATE TABLE Patient (
  PatientID INT PRIMARY KEY IDENTITY(11,1),
  Name VARCHAR(255) NOT NULL,
  DateOfBirth DATE,
  Gender VARCHAR(10),
  Address VARCHAR(255),
  PhoneNumber VARCHAR(20),
  MedicalHistory TEXT,
  EmergencyContactName VARCHAR(255),
  EmergencyContactPhone VARCHAR(20)
);
CREATE TABLE Doctor (
  DoctorID INT PRIMARY KEY IDENTITY,
  Name VARCHAR(255) NOT NULL,
  Specialization VARCHAR(100),
  PID INT --FOREIGN KEY REFERENCES Patient(PatientID)
);

CREATE TABLE DEPARTMENT(
DNO INT PRIMARY KEY,
DNMAE VARCHAR(255)
);

CREATE TABLE STAFF(
Staff_ID INT PRIMARY KEY,
NAME VARCHAR(255),
PHONE_NUMBER bigint,
ADDRESS VARCHAR(255),
DNO INT --FOREIGN KEY REFERENCES DEPARTMENT(DNO),
);

CREATE TABLE SALARY(
EMPLOYEE_ID INT, --FOREIGN KEY REFERENCES STAFF(STAFF_ID),
SALARY MONEY,
DNO INT, -- FOREIGN KEY REFERENCES DEPARTMENT(DNO),
EFFECTIVE_DATE DATE
);
CREATE TABLE TEST_REQ(
RequestID INT PRIMARY KEY IDENTITY,
  PID INT, --FOREIGN KEY REFERENCES Patient(PatientID),
  DoctorID INT,-- FOREIGN KEY REFERENCES Doctor(DoctorID) ON DELETE SET NULL,
  DateRequested DATE NOT NULL,
  TestName Varchar(255)
);
CREATE TABLE Test (
  TestID INT PRIMARY KEY IDENTITY,
  TestName VARCHAR(255) NOT NULL,
  Description TEXT,
  Category VARCHAR(50),
  --SectionID INT,
  --FOREIGN KEY (SectionID) REFERENCES TestSection(SectionID)******************************************
);

CREATE TABLE TestResult (
  ResultID INT PRIMARY KEY IDENTITY,
  PID int ,--foreign key references patient(PatientID),
  RequestID INT,-- FOREIGN KEY REFERENCES TEST_REQ(RequestID),
  TestID INT,-- FOREIGN KEY REFERENCES Test(TestID),
  ResultValue FLOAT,
  ResultDate DATE NOT NULL,
  PerformedBy INT,-- FOREIGN KEY REFERENCES STAFF(STAFF_ID) ON DELETE SET NULL,
  Flag VARCHAR(10),
  Notes TEXT
);

CREATE TABLE LabSupplies (
  SupplyID INT PRIMARY KEY IDENTITY,
  SupplyName VARCHAR(255) NOT NULL,
  Description TEXT,
  Unit VARCHAR(20),
  StockLevel INT
);
CREATE TABLE ReferenceRange (
  ReferenceRangeID INT PRIMARY KEY IDENTITY,
  --TestID INT FOREIGN KEY REFERENCES Test(TestID),
  AgeGroup VARCHAR(20),
  Gender VARCHAR(10),
  LowerLimit FLOAT,
  UpperLimit FLOAT
);

CREATE TABLE Lab_Report(
Report_id int Identity,
Patient_name varchar(255), --foreign key references Patient(name),

ReportDate DATE,
ReportText TEXT
);

CREATE TABLE TestPrice (
  TestID INT PRIMARY KEY,
  Price DECIMAL(10, 2) NOT NULL,
  --FOREIGN KEY (TestID) REFERENCES Test(TestID)
);

CREATE TABLE LabEquipment (
  EquipmentID INT PRIMARY KEY IDENTITY,
  EquipmentName VARCHAR(255) NOT NULL,
  Description TEXT,
  AcquisitionDate DATE,
  LastMaintenanceDate DATE,
  Status VARCHAR(50)
);
Create Table Lab_Location(
LabID int primary key,
Location_Name varchar(255),
Full_Address TEXT,
);


--Adding foreign keys
ALTER TABLE DOCTOR ADD FOREIGN KEY(PID) REFERENCES Patient(PatientID);
ALTER TABLE STAFF ADD FOREIGN KEY(DNO) REFERENCES DEPARTMENT(DNO)
ALTER TABLE SALARY ADD FOREIGN KEY (EMPLOYEE_ID) REFERENCES STAFF(STAFF_ID);
ALTER TABLE SALARY ADD FOREIGN KEY (DNO) REFERENCES DEPARTMENT(DNO);
ALTER TABLE TEST_REQ ADD FOREIGN KEY (PID) REFERENCES Patient(PatientID);
ALTER TABLE TESTRESULT ADD foreign key (PID) references patient(PatientID)
ALTER TABLE TESTRESULT ADD FOREIGN KEY (RequestID) REFERENCES TEST_REQ(RequestID);
ALTER TABLE TESTRESULT ADD FOREIGN KEY (TestID) REFERENCES Test(TestID);
ALTER TABLE TESTPRICE ADD FOREIGN KEY (TestID) REFERENCES TEST(TestID);
ALTER TABLE TESTRESULT ADD FOREIGN KEY (PerformedBy) REFERENCES STAFF(STAFF_ID);





-- Inserting data into Patient table
INSERT INTO Patient (Name, DateOfBirth, Gender, Address, PhoneNumber, MedicalHistory, EmergencyContactName, EmergencyContactPhone)
VALUES 
  ('John Doe', '1980-05-15', 'Male', '123 Main St, Cityville', '555-1234', 'No major medical history', 'Jane Doe', '555-5678'),
  ('Jane Smith', '1995-10-20', 'Female', '456 Elm St, Townsville', '555-5678', 'Allergic to penicillin', 'John Smith', '555-9012'),
  ('Michael Johnson', '1972-08-03', 'Male', '789 Oak St, Villagetown', '555-9012', 'Hypertension', 'Michelle Johnson', '555-3456'),
  ('Emily Brown', '1988-03-10', 'Female', '321 Pine St, Hamlet', '555-6789', 'Asthma', 'Eric Brown', '555-7890'),
  ('Daniel Garcia', '1990-12-25', 'Male', '654 Cedar St, Village', '555-8901', 'Diabetes', 'Danielle Garcia', '555-2345'),
  ('Sophia Martinez', '1985-07-18', 'Female', '987 Maple St, City', '555-2345', 'None', 'Sam Martinez', '555-6789'),
  ('William Clark', '1976-09-05', 'Male', '741 Oak St, Town', '555-3456', 'High blood pressure', 'Wendy Clark', '555-1234'),
  ('Olivia Wilson', '1992-04-30', 'Female', '852 Elm St, Village', '555-4567', 'None', 'Oscar Wilson', '555-8901'),
  ('James Taylor', '1983-11-15', 'Male', '963 Pine St, Hamlet', '555-5678', 'Anemia', 'Jessica Taylor', '555-3456'),
  ('Emma Anderson', '1978-06-20', 'Female', '159 Maple St, Cityville', '555-6789', 'Arthritis', 'Ethan Anderson', '555-2345');

-- Inserting data into Doctor table
INSERT INTO Doctor (Name, Specialization)
VALUES 
  ('Dr. Smith', 'Cardiologist'),
  ('Dr. Johnson', 'Pediatrician'),
  ('Dr. Lee', 'Oncologist'),
  ('Dr. Williams', 'Neurologist'),
  ('Dr. Brown', 'Gynecologist'),
  ('Dr. Garcia', 'Dermatologist'),
  ('Dr. Martinez', 'Psychiatrist'),
  ('Dr. Clark', 'Orthopedic Surgeon'),
  ('Dr. Wilson', 'Urologist'),
  ('Dr. Taylor', 'Endocrinologist');

-- Inserting data into DEPARTMENT table
INSERT INTO DEPARTMENT (DNO, DNMAE)
VALUES 
  (1, 'Cardiology'),
  (2, 'Pediatrics'),
  (3, 'Oncology'),
  (4, 'Neurology'),
  (5, 'Gynecology'),
  (6, 'Dermatology'),
  (7, 'Psychiatry'),
  (8, 'Orthopedics'),
  (9, 'Urology'),
  (10, 'Endocrinology');

-- Inserting data into STAFF table
INSERT INTO STAFF (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO)
VALUES 
  (1, 'Alice', 5551234567, '10 Broad St, Cityville', 1),
  (2, 'Bob', 5552345678, '20 Main St, Townsville', 2),
  (3, 'Carol', 5553456789, '30 Elm St, Villagetown', 3),
  (4, 'David', 5554567890, '40 Oak St, Village', 4),
  (5, 'Emma', 5555678901, '50 Pine St, Hamlet', 5),
  (6, 'Frank', 5556789012, '60 Maple St, City', 6),
  (7, 'Grace', 5557890123, '70 Elm St, Town', 7),
  (8, 'Henry', 5558901234, '80 Oak St, Village', 8),
  (9, 'Ivy', 5559012345, '90 Cedar St, Cityville', 9),
  (10, 'Jack', 5550123456, '100 Pine St, Hamlet', 10);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (11, 'Kyle', '5556789123', '101 Birch St, Cityville', 1);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (12, 'Laura', '5557890123', '202 Maple St, Townsville', 2);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (13, 'Megan', '5558901234', '303 Pine St, Villagetown', 3);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (14, 'Nathan', '5559012345', '404 Oak St, Village', 4);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (15, 'Olivia', '5550123456', '505 Elm St, Hamlet', 5);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (16, 'Paul', '5551234567', '606 Cedar St, City', 6);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (17, 'Quinn', '5552345678', '707 Birch St, Town', 7);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (18, 'Rachel', '5553456789', '808 Maple St, Villagetown', 8);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (19, 'Steven', '5554567890', '909 Pine St, Village', 9);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (20, 'Tina', '5555678901', '1010 Oak St, Hamlet', 10);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (21, 'Uma', '5556789012', '1111 Elm St, Cityville', 1);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (22, 'Vince', '5557890124', '1212 Cedar St, Townsville', 2);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (23, 'Wendy', '5558901235', '1313 Birch St, Villagetown', 3);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (24, 'Xander', '5559012346', '1414 Maple St, Village', 4);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (25, 'Yara', '5550123457', '1515 Pine St, Hamlet', 5);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (26, 'Zach', '5551234568', '1616 Oak St, City', 6);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (27, 'Ava', '5552345679', '1717 Elm St, Town', 7);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (28, 'Brian', '5553456780', '1818 Cedar St, Villagetown', 8);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (29, 'Cindy', '5554567891', '1919 Birch St, Village', 9);
INSERT INTO staff (Staff_ID, NAME, PHONE_NUMBER, ADDRESS, DNO) VALUES (30, 'Derek', '5555678902', '2020 Maple St, Hamlet', 10);



-- Inserting data into SALARY table

INSERT INTO SALARY (EMPLOYEE_ID, SALARY, DNO, EFFECTIVE_DATE) VALUES (1, 50000, 1, '2024-01-01'),
																		(2, 55000, 2, '2024-01-01'),
																		(3, 60000, 3, '2024-01-01'),
																		(4, 65000, 4, '2024-01-01'),
																		(5, 70000, 5, '2024-01-01'),
																		(6, 75000, 6, '2024-01-01'),
																		(7, 80000, 7, '2024-01-01'),
																		(8, 85000, 8, '2024-01-01'),
																		(9, 90000, 9, '2024-01-01'),
																		(10, 95000, 10, '2024-01-01'),
																		(11, 51000, 1, '2024-01-01'),
																		(12, 56000, 2, '2024-01-01'),
																		(13, 61000, 3, '2024-01-01'),
																		(14, 66000, 4, '2024-01-01'),
																		(15, 71000, 5, '2024-01-01'),
																		(16, 76000, 6, '2024-01-01'),
																		(17, 81000, 7, '2024-01-01'),
																		(18, 86000, 8, '2024-01-01'),
																		(19, 91000, 9, '2024-01-01'),
																		(20, 96000, 10, '2024-01-01'),
																		(21, 52000, 1, '2024-01-01'),
																		(22, 57000, 2, '2024-01-01'),
																		(23, 62000, 3, '2024-01-01'),
																		(24, 67000, 4, '2024-01-01'),
																		(25, 72000, 5, '2024-01-01'),
																		(26, 77000, 6, '2024-01-01'),
																		(27, 82000, 7, '2024-01-01'),
																		(28, 87000, 8, '2024-01-01'),
																		(29, 92000, 9, '2024-01-01'),
																		(30, 97000, 10, '2024-01-01');


-- Inserting data into TEST_REQ table
INSERT INTO TEST_REQ (PID, DoctorID, DateRequested, TestName)
VALUES 
  (11, 1, '2024-05-01' , 'add later'),
  (12, 2, '2024-05-02' , 'add later'),
  (13, 3, '2024-05-03' , 'add later'),
  (14, 4, '2024-05-04' , 'add later'),
  (15, 5, '2024-05-05' , 'add later'),
  (16, 6, '2024-05-06' , 'add later'),
  (17, 7, '2024-05-07' , 'add later'),
  (18, 8, '2024-05-08' , 'add later'),
  (19, 9, '2024-05-09' , 'add later'),
  (20, 10, '2024-05-10', 'add later');

-- Inserting data into Test table
INSERT INTO Test (TestName, Description, Category)
VALUES 
  ('Blood Test', 'General blood analysis', 'General'),
  ('MRI Scan', 'Magnetic Resonance Imaging', 'Imaging'),
  ('Biopsy', 'Tissue sample analysis', 'Pathology'),
  ('EKG', 'Electrocardiogram', 'Cardiology'),
  ('Ultrasound', 'Imaging using sound waves', 'Obstetrics and Gynecology'),
  ('Skin Biopsy', 'Skin tissue sample analysis', 'Dermatology'),
  ('Psychological Evaluation', 'Mental health assessment', 'Psychiatry'),
  ('Bone Density Test', 'Assessment of bone health', 'Orthopedics'),
  ('Urinalysis', 'Examination of urine sample', 'Urology'),
  ('Thyroid Function Test', 'Assessment of thyroid gland function', 'Endocrinology');

-- Inserting data into TestResult table
INSERT INTO TestResult (PID, RequestID, TestID, ResultValue, ResultDate, PerformedBy, Flag, Notes)
VALUES 
  (11, 1, 1, 120, '2024-05-05', 1, 'Normal', 'No abnormalities detected'),
  (12, 2, 2, NULL, '2024-05-06', 2, 'Abnormal', 'Anomaly detected, further investigation needed'),
  (13, 3, 3, NULL, '2024-05-07', 3, 'Normal', 'Healthy tissue sample'),
  (14, 4, 4, NULL, '2024-05-08', 4, 'Normal', 'Normal heart rhythm'),
  (15, 5, 5, NULL, '2024-05-09', 5, 'Normal', 'Healthy fetal development'),
  (16, 6, 6, NULL, '2024-05-10', 6, 'Normal', 'No abnormalities detected'),
  (17, 7, 7, NULL, '2024-05-11', 7, 'Normal', 'No significant findings'),
  (18, 8, 8, NULL, '2024-05-12', 8, 'Abnormal', 'Low bone density detected'),
  (19, 9, 9, NULL, '2024-05-13', 9, 'Normal', 'No abnormalities detected'),
  (20, 10, 10, NULL, '2024-05-14', 10, 'Abnormal', 'Thyroid hormone levels outside normal range');

-- Inserting data into LabSupplies table
INSERT INTO LabSupplies (SupplyName, Description, Unit, StockLevel)
VALUES 
  ('Needles', 'Various sizes for blood draws', 'Boxes', 100),
  ('Chemicals', 'Reagents for laboratory tests', 'Bottles', 50),
  ('Gloves', 'Latex-free examination gloves', 'Boxes', 200),
  ('Ultrasound Gel', 'Conductive gel for ultrasound imaging', 'Bottles', 20),
  ('Specimen Jars', 'Containers for collecting samples', 'Boxes', 50),
  ('EKG Electrodes', 'Electrodes for EKG testing', 'Packs', 100),
  ('Biopsy Needles', 'Needles for tissue sample collection', 'Boxes', 30),
  ('Thyroid Test Kits', 'Kits for thyroid function testing', 'Kits', 10),
  ('Urine Test Strips', 'Strips for urinalysis', 'Boxes', 100),
  ('Bone Density Scanner', 'Equipment for bone density testing', 'Units', 2);

-- Inserting data into ReferenceRange table
INSERT INTO ReferenceRange (AgeGroup, Gender, LowerLimit, UpperLimit)
VALUES 
  ('Adult', 'Male', 3.5, 5.5),
  ('Adult', 'Female', 4.0, 5.0),
  ('Child', 'Male', 3.0, 5.0),
  ('Child', 'Female', 3.5, 4.5),
  ('Elderly', 'Male', 3.0, 6.0),
  ('Elderly', 'Female', 4.0, 6.0),
  ('Pregnant', 'Female', 4.5, 5.5),
  ('Infant', 'Male', 2.5, 4.5),
  ('Infant', 'Female', 3.0, 5.0),
  ('Teenager', 'Male', 3.0, 5.5);

-- Inserting data into Lab_Report table
INSERT INTO Lab_Report (Patient_name, ReportDate, ReportText)
VALUES 
  ('John Doe', '2024-05-05', 'Blood test results: Normal. No abnormalities detected.'),
  ('Jane Smith', '2024-05-06', 'MRI scan results: Abnormal. Anomaly detected, further investigation needed.'),
  ('Michael Johnson', '2024-05-07', 'Biopsy results: Normal. Healthy tissue sample.'),
  ('Emily Brown', '2024-05-08', 'EKG results: Normal. Normal heart rhythm.'),
  ('Daniel Garcia', '2024-05-09', 'Ultrasound results: Normal. Healthy fetal development.'),
  ('Sophia Martinez', '2024-05-10', 'Skin biopsy results: Normal. No abnormalities detected.'),
  ('William Clark', '2024-05-11', 'Psychological evaluation results: Normal. No significant findings.'),
  ('Olivia Wilson', '2024-05-12', 'Bone density test results: Abnormal. Low bone density detected.'),
  ('James Taylor', '2024-05-13', 'Urinalysis results: Normal. No abnormalities detected.'),
  ('Emma Anderson', '2024-05-14', 'Thyroid function test results: Abnormal. Thyroid hormone levels outside normal range.');

-- Inserting data into TestPrice table
INSERT INTO TestPrice (TestID, Price)
VALUES 
  (1, 50.00),
  (2, 500.00),
  (3, 200.00),
  (4, 100.00),
  (5, 300.00),
  (6, 150.00),
  (7, 200.00),
  (8, 250.00),
  (9, 80.00),
  (10, 120.00);

-- Inserting data into LabEquipment table
INSERT INTO LabEquipment (EquipmentName, Description, AcquisitionDate, LastMaintenanceDate, Status)
VALUES 
  ('MRI Machine', 'High-field MRI scanner', '2023-01-01', '2024-04-01', 'Operational'),
  ('Microscope', 'High-resolution microscope', '2022-05-01', '2024-03-01', 'Operational'),
  ('Autoclave', 'Sterilization equipment', '2021-10-01', '2024-02-01', 'Needs maintenance'),
  ('EKG Machine', 'Electrocardiogram machine', '2023-03-01', '2024-01-01', 'Operational'),
  ('Ultrasound Machine', 'Diagnostic ultrasound equipment', '2023-05-01', '2024-04-01', 'Operational'),
  ('Dermatoscope', 'Skin examination device', '2022-08-01', '2024-03-01', 'Operational'),
  ('Psychological Assessment Tools', 'Tools for mental health assessment', '2023-02-01', '2024-02-01', 'Operational'),
  ('DEXA Scanner', 'Dual-energy X-ray absorptiometry scanner', '2023-04-01', '2024-03-01', 'Operational'),
  ('Urinalysis Analyzer', 'Equipment for automated urinalysis', '2023-06-01', '2024-05-01', 'Operational'),
  ('Thyroid Function Test Kit', 'Kits for thyroid function testing', '2023-07-01', '2024-04-01', 'Operational');

  INSERT INTO Lab_Location (LabID, Location_Name, Full_Address)
VALUES
(1, 'Central Lab', '123 Main St, Springfield, IL, 62701'),
(2, 'East Side Lab', '456 East St, Springfield, IL, 62702'),
(3, 'West End Lab', '789 West St, Springfield, IL, 62703');
 /* -- Deleting all records from Patient table
DELETE FROM Patient;

-- Deleting all records from Doctor table
DELETE FROM Doctor;

-- Deleting all records from DEPARTMENT table
DELETE FROM DEPARTMENT;

-- Deleting all records from STAFF table
DELETE FROM STAFF;

-- Deleting all records from SALARY table
DELETE FROM SALARY;

-- Deleting all records from TEST_REQ table
DELETE FROM TEST_REQ;

-- Deleting all records from Test table
DELETE FROM Test;

-- Deleting all records from TestResult table
DELETE FROM TestResult;

-- Deleting all records from LabSupplies table
DELETE FROM LabSupplies;

-- Deleting all records from ReferenceRange table
DELETE FROM ReferenceRange;

-- Deleting all records from Lab_Report table
DELETE FROM Lab_Report;

-- Deleting all records from TestPrice table
DELETE FROM TestPrice;

-- Deleting all records from LabEquipment table
DELETE FROM LabEquipment;

*/