# Doctor Office 

#### Doctor office with patients management system, 03.23.2020 - 03.25.20

#### By **Jiwon Han and Adela Darmansyah**

[![Project Status: WIP – Initial development is in progress, but there has not yet been a stable, usable release suitable for the public.](https://www.repostatus.org/badges/latest/wip.svg)](https://www.repostatus.org/#wip)
![LastCommit](https://img.shields.io/github/last-commit/jiwon-seattle/VendorOrderTracker.Solution)
![Languages](https://img.shields.io/github/languages/top/jiwon-seattle/VendorOrderTracker.Solution)
[![MIT license](https://img.shields.io/badge/License-MIT-orange.svg)](https://lbesson.mit-license.org/)

---
## 1. User Flow

1. As an administrator, I want to be able to enter a doctor, so I can keep track of all the doctors in the hospital. I should be able to enter their contact information such as first name, last name, specialty, pager number, hire date, and if they are accepting new patients.
2. As an administrator, I want to be able to enter a patient, so I can keep track of all the patients coming to the hospital. I should be able to enter their contact information such as first name, last name, date of birth, medical record number (MRN#), phone number, allergies, medical history.
3. As an administrator, I want to assign patients to the doctors, so I can keep track of which patients are seeing specific doctors.
4. As an adiministrator, I want to assign doctors to the patients, so I can keep track of which specialties patients are seeing.
5. As an administrator, I want to be able to see a list of all doctors and their specialties, so that I know which medical specialties are offered in the hospital.
6. As an administrator, I want new patients to have unique Medical Record Numbers (MRN) that auto-increments starting from 202003000 so that each patient can have a unique identifier.
7. As an administrator, I want to be able to search for a doctor, so I can see their contact info and page them.
8. As an administrator, I want to be able to search for a patient, so I can look up patient info details.
9. As an administator, I want to assign patients to doctors who only accepts new patients.
10. As a developer, I want to be able to see exception error messages, so that I can debug any exceptions that appears.

Parking Lot/Improvement Opportunities:
- Add a class for Appointments(doesn't allow conflicts)
- Separate Specialty into a different class? Make a join class of DoctorSpecialty
- Use try/catch functions to make sure there is no duplicates added to the database.

<image src="./DoctorOffice.Solution/DoctorOffice/wwwroot/img/doctorOffice.gif" width="750px" />

## 2. Development
### Tech stack:
+ [.NET CORE](https://dotnet.microsoft.com/download/dotnet-core/) for package management
+ [MySQL](https://dev.mysql.com/downloads/file/?id=484919) 

### To run dev mode locally:
```bash
  $ git clone https://github.com/jiwon-seattle/DoctorOffice.git
  $ cd DoctorOffice.Solution/DoctorOffice
  $ dotnet add package Microsoft.EntityFrameworkCore -v 2.2.0
  $ dotnet add package Pomelo.EntityFrameworkCore.MySql -v 2.2.0
  $ dotnet build
  $ dotnet ef migrations add Initial
  $ dotnet ef database update  
  # After successfull pkg installtion
  $ dotnet run
```
Now, it will automatically open http://localhost:5000 and show you the Doctor's Office main page.

You might encounter a MySql database related errors on initial loading since this application needs a specific data route to fetch data.

## 3. Known Bugs

- SEARCH patients functionality currently does not work only by patient's last name. A user will have to search patients only by date of birth or both by last name and date of birth.
- EDIT doctor's hire date input form type is currently not a date type. A user will have to type in the date if they need to edit it.

## 4. Support and contact details

Any feedbacks are appreciated! Please contact at email: jiwon1.han@gmail.com or adela.yohana@gmail.com

### License

*This software is licensed under the MIT license*

Copyright (c) 2020 **_Jiwon Han & Adela Darmansyah_**
