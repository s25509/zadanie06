INSERT INTO Patient (FirstName, LastName, Birthdate)
VALUES ('Karol', 'Smarol', '1996-07-14'),
       ('Antek', 'Śmantek', '1988-11-26'),
       ('Nina', 'Malina', '1998-01-08'),
       ('Monika', 'Tika', '2002-02-21')

INSERT INTO Doctor (FirstName, LastName, Email)
VALUES ('Doktor', 'Proktor', 'test1@te.st'),
       ('James', 'House', 'test2@te.st'),
       ('Maria', 'Curie', 'test3@te.st')

INSERT INTO Medicament (Name, Description, Type)
VALUES ('Viagra', 'It gets hard', 'annoying'),
       ('Prozac', 'Funny story...', 'psychotic'),
       ('Ibuprofen', 'For boo boos', 'painkiller')

INSERT INTO Prescription (IdPatient, IdDoctor, Date, DueDate)
VALUES (1, 1, '2024-05-01', '2024-06-01'),
       (3, 1, '2024-05-01', '2024-06-01'),
       (2, 2, '2024-05-13', '2024-06-13')

INSERT INTO PrescriptionMedicament (IdMedicament, IdPrescription, Dose, Details)
VALUES (1, 1, 5, 'details'),
       (3, 1, 10, 'details'),
       (2, 2, 15, 'details')