                                ##Restaurant Project Documentation##

1. Project Overview

This project is a Restaurant Management Web Application developed using ASP.NET Core MVC (.NET 8) and Entity Framework Core.

The application consists of two main sections:

Public Client Website

Admin Panel (implemented using ASP.NET Core Areas)

The system follows the MVC design pattern and uses a Repository Pattern for data access abstraction.

*****************************
2. Technologies Used

ASP.NET Core MVC (.NET 8)

Entity Framework Core

ASP.NET Identity

SQL Server

Repository Pattern

Areas Structure (Admin Section)

*******************************
3. Project Structure

Resturant/
├── Program.cs
├── Resturant.csproj
├── appsettings.json
├── appsettings.Development.json
├── Properties/
│   └── launchSettings.json
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   ├── ApplicationUser.cs
│   ├── BaseEntity.cs
│   ├── MasterCategoryMenu.cs
│   ├── MasterFeedback.cs
│   ├── MasterItemMenu.cs
│   ├── MasterMenu.cs
│   ├── MasterOffer.cs
│   ├── MasterPartner.cs
│   ├── MasterService.cs
│   ├── MasterSlider.cs
│   ├── MasterSocialMedia.cs
│   ├── MasterWorkingHour.cs
│   ├── SystemSetting.cs
│   ├── TransactionBookTable.cs
│   ├── TransactionContactUs.cs
│   ├── TransactionNewsletter.cs
│   └── Repositories/
│       ├── IRepository.cs
│       ├── MasterCategoryMenuRepository.cs
│       ├── MasterMenuRepository.cs
│       ├── MasterFeedbackRepository.cs
│       ├── MasterItemMenuRepository.cs
│       ├── MasterOfferRepository.cs
│       ├── MasterPartnerRepository.cs
│       ├── MasterServiceRepository.cs
│       ├── MasterSliderRepository.cs
│       ├── MasterSocialMediaRepository.cs
│       ├── MasterWorkingHourRepository.cs
│       ├── SystemSettingRepository.cs
│       ├── TransactionBookTableRepository.cs
│       ├── TransactionContactUsRepository.cs
│       └── TransactionNewsletterRepository.cs
│
├── Migrations/
│   ├── 20260125222525_newDb.cs (+ .Designer.cs)
│   ├── 20260131174917_addImgToFeedbacks.cs (+ .Designer.cs)
│   ├── 20260131190631_addFeedbackDesc.cs (+ .Designer.cs)
│   ├── 20260131190839_addFeedbackDescription.cs (+ .Designer.cs)
│   ├── 20260131202544_addMenuItemDesc.cs (+ .Designer.cs)
│   ├── 20260131212510_editCreatedate.cs (+ .Designer.cs)
│   ├── 20260131213438_editCreatedate1.cs (+ .Designer.cs)
│   ├── 20260131214833_editCreatedate2.cs (+ .Designer.cs)
│   ├── 20260201203456_addFileOffer.cs (+ .Designer.cs)
│   ├── 20260201212459_addFilePartner.cs (+ .Designer.cs)
│   └── AppDbContextModelSnapshot.cs
│
├── Controllers/
│   ├── AccountController.cs
│   ├── HomeController.cs
│   ├── ContactUsController.cs
│   ├── MasterCategoryMenuController.cs
│   └── MasterItemMenuController.cs
│
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── About.cshtml
│   ├── ContactUs/
│   │   └── Index.cshtml
│   ├── MasterItemMenu/
│   │   ├── Index.cshtml
│   │   └── Details.cshtml
│   ├── Shared/
│   │   └── _Layout.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
│
├── Areas/
│   └── Admin/
│       ├── Components/
│       │   └── MasterMenuComponent.cs
│       ├── Controllers/
│       │   ├── AccountController.cs
│       │   ├── HomeController.cs
│       │   ├── MasterCategoryMenuController.cs
│       │   ├── MasterFeedbackController.cs
│       │   ├── MasterItemMenuController.cs
│       │   ├── MasterMenuController.cs
│       │   ├── MasterOfferController.cs
│       │   ├── MasterPartnerController.cs
│       │   ├── MasterServiceController.cs
│       │   ├── MasterSliderController.cs
│       │   ├── MasterSocialMediaController.cs
│       │   ├── MasterWorkingHourController.cs
│       │   ├── SystemSettingController.cs
│       │   ├── TransactionBookTableController.cs
│       │   ├── TransactionContactUsController.cs
│       │   └── TransactionNewsletterController.cs
│       ├── ViewModels/
│       │   ├── LoginModel.cs
│       │   ├── RegisterModel.cs
│       │   ├── SystemSettingModel.cs
│       │   ├── MasterFeedbackModel.cs
│       │   ├── MasterItemMenuModel.cs
│       │   ├── MasterOfferModel.cs
│       │   ├── MasterPartnerModel.cs
│       │   ├── MasterServiceModel.cs
│       │   ├── MasterSliderModel.cs
│       │   └── MasterSocialMediaModel.cs
│       └── Views/
│           ├── Shared/   (admin layout/partials live here)
│           ├── Account/
│           ├── Home/
│           ├── MasterCategoryMenu/
│           ├── MasterFeedback/
│           ├── MasterItemMenu/
│           ├── MasterMenu/
│           ├── MasterOffer/
│           ├── MasterPartner/
│           ├── MasterService/
│           ├── MasterSlider/
│           ├── MasterSocialMedia/
│           ├── MasterWorkingHour/
│           ├── SystemSetting/
│           ├── TransactionBookTable/
│           ├── TransactionContactUs/
│           ├── TransactionNewsletter/
│           ├── _ViewImports.cshtml
│           └── _ViewStart.cshtml
│
├── ViewModel/
│   └── DataModel.cs
│
├── wwwRoot/
│   ├── Admin/
│   │   └── assets/
│   │       ├── css/
│   │       ├── img/
│   │       ├── js/
│   │       └── vendor/

******************************

4. Database Schema

-> The project uses Entity Framework Core with AppDbContext
-> Connection String Name : defaultDbConnect

Tables:

| Table Name             | Purpose                      |
| ---------------------- | ---------------------------- |
| MasterCategoryMenus    | Food categories              |
| MasterItemMenus        | Food items (FK → CategoryId) |
| MasterMenus            | Navigation menu              |
| MasterOffers           | Offers                       |
| MasterPartners         | Partners                     |
| MasterServices         | Services                     |
| MasterSliders          | Homepage slider              |
| MasterSocialMedia      | Social media links           |
| MasterWorkingHours     | Restaurant working hours     |
| SystemSettings         | Global system configuration  |
| TransactionBookTables  | Table bookings               |
| TransactionContactUs   | Contact messages             |
| TransactionNewsletters | Newsletter subscriptions     |
| MasterFeedback         | Customer feedback            |

******************************

5. Repository Layer

-> The project uses a Generic Repository Pattern.

IRepository<T> Methods:

| Method                   | Description                                     |
| ------------------------ | ----------------------------------------------- |
| Add(T entity)            | Adds a new record                               |
| Delete(int id)           | Soft delete (IsDelete = true)                   |
| Update(int id, T entity) | Updates record                                  |
| Active(int id)           | Toggles IsActive flag                           |
| ViewAdmin()              | Returns non-deleted records (active & inactive) |
| ViewClient()             | Returns non-deleted & active records only       |
| Find(int id)             | Returns record by ID                            |


************************************

6. Repository Logic Implementation

-> Soft Delete:

Records are not physically removed from the database.
Instead, the IsDelete property is set to true.

-> Active Toggle:

 - Finds the entity by ID

- Toggles IsActive using NOT

- Updates and saves changes


-> Add:

- By default IsDelete = false & IsActive = true

- Saves changes

-> ViewAdmin:
 - Returns All records where IsDelete = false

-> ViewClient:
- Returns Records where: IsDelete = false && IsActive = true

******************************************

7. Areas Structure

-> The project uses ASP.NET Core Areas to separate the Admin Panel from the Public Website.
-> Structure:
                 Main project → Public website
                 Areas/Admin → Admin dashboard
-> This allows:
          
   - Logical separation

   - Clean routing

   - Better project organization

********************************************

8. Architecture & Design Pattern
-> The project follows:

MVC (Model – View – Controller)

Models → Database entities

Views → UI rendering

Controllers → Business logic handling