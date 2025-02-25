# Serenity-Practice-Tasks
A comprehensive collection of 19 implementation tasks for Serenity.is, demonstrating UI enhancements, data management, search functionality, and security features.
# 🚀 Serenity Practice
## 📋 Overview
This repository documents various tasks implemented in a Serenity.is-based project. These tasks will enrich your knowledge about Serenity.is features and teach you how to customize your Serenity.is-based applications. While solutions are provided, I recommend trying to solve the tasks on your own first, and consulting the README.md hints if you encounter difficulties.

## 🔧 Technologies Used
- **Framework**: Serenity.is
- **Backend**: C# & ASP.NET Core
- **Database**: SQL Server
- **Frontend**: TypeScript, React, JSON
- **Styling**: CSS & Frontend Customization

## 📑 Table of Contents
- [Accomplished Tasks](#-accomplished-tasks)
- [Implemented Solutions](#-implemented-solutions)
- [Getting Started](#-getting-started)
- [Contributing](#-contributing)
- [License](#-license)
- [Author](#-author)

## 📌 Accomplished Tasks

### UI Enhancements
1. [Converted Notes Field to Textarea](#1-converted-notes-field-to-a-textarea)
2. [Customized Label Colors in MedicalRecords Dialog](#2-customized-label-colors-in-medicalrecords-dialog)
3. [Implemented Toggle Read-Only Mode for Patients Form](#26-toggle-read-only-mode-for-patients-form)
4. [Created Gender-Specific Tabs in Patients Grid](#27-create-gender-specific-tabs-in-the-patients-grid)
5. [Applied Different Background Colors Based on Gender](#23-applying-different-background-colors-to-male-and-female-patients-in-the-grid)

### Data Management
1. [Added Age Field to Patients Table](#5-added-age-field-to-the-patients-table)
2. [Implemented Gender Enum in Patients Row](#7-implemented-gender-enum-in-patients-row)
3. [Added Speciality Selection in Doctors Form](#8-enabled-speciality-selection-in-doctors-form)
4. [Enabled Adding New Speciality in Patients Form](#9-allowed-adding-new-speciality-in-patients-form)
5. [Implemented Cost and Loyalty-Based Discount](#10-implemented-cost-loyalty-based-discount--total-cost-calculation)
6. [Supported Multiple Specialties for Doctors](#11-allowed-doctors-to-have-multiple-specialties)
7. [Created Tables for Governorates and Cities](#15-created-tables-for-governorates-and-cities)
8. [Added "Other" Option in Gender Enum and Disabled It](#25-adding-a-other-option-in-gender-enum-and-disabling-it)

### Search & Filtering
1. [Enhanced Search Functionality in MedicalRecords Grid](#3-enabled-search-by-doctor-name--patient-name-in-medicalrecords-grid)
2. [Implemented Column-Specific Search in QuickSearch](#4-implemented-column-specific-search-in-quicksearch)
3. [Enabled Age-Based Search in Patients Grid](#6-enabled-age-based-search-in-patients-grid)

### Security & Validation
1. [Registered New Permissions & User Access Control](#16-implemented-permissions--user-access-control)
2. [Created Action Button for Cost Multiplication (Permission-Based)](#17-created-an-action-button-for-cost-multiplication)
3. [Prevented Duplicate Patient Entries](#19-prevented-duplicate-patient-entries-in-the-database)
4. [Restricted User Access to Editing Specific Patient](#22-restricting-user-access-to-editing-only-one-specific-patient)
5. [Dynamic Field Requirements Based on Gender](#24-dynamically-requiring-and-displaying-the-address-field-based-on-gender-selection)

## 🛠 Implemented Solutions

### 1. Converted Address Field to a Textarea
```csharp
[TextAreaEditor(Rows = 5)]
public string Notes { get; set; }
```
- Added the `[TextAreaEditor(Rows = 5)]` attribute to the **Notes** field in `MedicalRecordsForm.cs`, enabling multi-line input.

### 2. Enabled Search by Doctor Name & Patient Name in MedicalRecords Grid
```csharp
[QuickSearch(SearchType.StartsWith)]
public string DoctorFullName { get; set; }

[QuickSearch(SearchType.StartsWith)]
public string PatientFullName { get; set; }
```
- Added the `[QuickSearch]` attribute to the fields in `MedicalRecordsColumns.cs`.
- Configured the search to **"starts with"** instead of **"contains"** for optimized results.

### 3. Implemented Column-Specific Search in QuickSearch
```typescript
    protected getQuickSearchFields(): Q.QuickSearchField[] {
        return [
            { name: "", title: "all" },
            { name: "DoctorName", title: "doctor" },
            { name: "PatientName", title: "patient" }
        ];
    }
```
- Implemented `getQuickSearchFields()` in `MedicalRecordsGrid.ts` to enable column-specific searching.

### 4. Added Age Field to the Patients Table
```sql
ALTER TABLE Patients
ADD Age INT NULL;
```
```csharp
[DisplayName("Age"), NotNull]
public int? Age { get; set; }
```
- Created a new `Age` column in the database
- Updated `PatientsRow.cs` to include the field and made it visible in forms and grids.

### 5. Enabled Age-Based Search in Patients Grid
```typescript
protected getQuickSearchFields(): Q.QuickSearchField[] {
    return [
        { name: "", title: "all" },
        { name: "PatientName", title: "name" },
        { name: "Age", title: "age" }
    ];
}
```
- Modified `getQuickSearchFields()` in the Patients Grid to allow searching by age.

### 6. Implemented Gender Enum in Patients Row
```csharp
[EnumKey("Patients.Gender")]
public enum Gender {
    [Description("Male")]
    Male = 1,
    [Description("Female")]
    Female = 2
}
```
```csharp
[DisplayName("Gender"), NotNull]
 public GenderEnum Gender { get; set; }
```
- Created a Gender Enum class
- Updated `PatientsRow.cs` to use the enum for standardized gender selection.

### 7. Enabled Speciality Selection in Doctors Form
```csharp
    [DisplayName("Speciality"), LookupEditor(typeof(SpecialityRow), Multiple = true), NotMapped]
    [LinkingSetRelation(typeof(DocSpecRow), nameof(DocSpecRow.DoctorId), nameof(DocSpecRow.SpecialityId))]
 public List<int> SpecialityList
 {
     get => fields.SpecialityList[this];
     set => fields.SpecialityList[this] = value;
 }
```
```csharp
[LookupScript]
public class SpecialityRow { /*...*/ }
```
- Mapped **SpecialityId** in `DoctorsRow.cs`
- Used `[LookupEditor]` and added `[LookupScript]` to `SpecialityRow.cs`.

### 8. Implemented Cost, Loyalty-Based Discount & Total Discount Calculation
```csharp
[DisplayName("Cost"), NotNull]
public decimal? Cost { get; set; }

[DisplayName("Loyalty Years"), NotNull]
public int? LoyaltyYears { get; set; }

[DisplayName("Total Discount"), [Expression("(t0.Cost * t0.LoyaltyYears * 0.05)")]
public int TotalDiscount { get; set; }
```
- Added the required fields and implemented an expression-based Loyalty-Based 

### 9. Allowed Doctors to Have Multiple Specialties
```sql
CREATE TABLE DoctorSpecialties (
    DoctorId INT NOT NULL,
    SpecialtyId INT NOT NULL,
    PRIMARY KEY (DoctorId, SpecialtyId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId),
    FOREIGN KEY (SpecialtyId) REFERENCES Specialties(SpecialtyId)
);
```
```csharp
[LookupEditor(typeof(SpecialtyRow), Multiple = true)]
[LinkingSetRelation(typeof(DoctorSpecialtyRow), "DoctorId", "SpecialtyId")]
public List<int> SpecialtyList { get; set; }
```
- Created a many-to-many relationship table
- Used `[LookupEditor(Multiple = true)]` for multiple selection
- Applied `[LinkingSetRelation]` to define the relationship.

### 10. Created Tables for Governorates and Cities
```csharp
[DisplayName("Governorate"), NotNull, ForeignKey("Governorates", "Id")]
[LookupEditor(typeof(GovernorateRow))]
public int? GovernorateId { get; set; }

[DisplayName("City"), NotNull, ForeignKey("Cities", "Id")]
[LookupEditor(typeof(CityRow), CascadeFrom = "GovernorateId", CascadeField = "GovernorateId")]
public int? CityId { get; set; }
```
- Created tables with appropriate foreign key relationships
- Implemented cascading dropdowns using `CascadeFrom` and `CascadeField`.

### 11. Implemented Permissions & User Access Control
```csharp
[NestedPermissionKeys]
[DisplayName("Hospital")]
public class PermissionKeys
{
    [DisplayName("Doctors")]
    public class Doctors
    {
        public const string View = "Hospital:Doctor:View";
        public const string Create = "Hospital:Doctor:Create";
        public const string Update = "Hospital:Doctor:Update";
        public const string Delete = "Hospital:Doctor:Delete";
    }
    
    // Other modules...
}
```
- Created a structured permission system
- Assigned specific permissions to modules and operations
- Applied permissions to row classes and endpoints.

### 12. Created an Action Button for Task Value Multiplication
```typescript
protected getToolbarButtons(): Q.ToolButton[] {
    let buttons = super.getToolbarButtons();
    
    buttons.push({
         title: "Multiply TaskValue by 2",
         icon: "fa-calculator",
         cssClass: 'multiply-button',
        onClick: () => {
            let value = this.form.TaskValue.value;
            let newValue = value * 2;
            this.updateTaskValueInDatabase(newValue);
        }
    });
    
    return buttons;
}
protected afterLoadEntity(): void {
    super.afterLoadEntity();
    
    // Show button only for existing records and users with permission
    let isNew = this.isNew();
    let hasPermission = Authorization.hasPermission("Hospital:Patients:Multiply");
    
    this.toolbar.findButton("multiply-cost-button").toggle(!isNew && hasPermission);
}
```
- Added a custom button in the toolbar
- Implemented logic for Task Value multiplication
- Applied permission-based visibility control.

### 13. Prevented Duplicate Patient Entries in the Database
```csharp
private checkForDuplicatePatient() {
    {
        // Skip check if this is an existing record and values haven't changed
        if (!this.isNew() &&
            this.form.PatientName.value === this.originalPatientName &&
            this.form.DateOfBirth.value === this.originalDateOfBirth) {
            return;
        }

        // Call service to check for duplicates
        PatientsService.List({
            EqualityFilter: {
                PatientName: this.form.PatientName.value,
                DateOfBirth: this.form.DateOfBirth.value
            }
        }, response => {
            if (response.Entities && response.Entities.length > 0) {
                // Check if the found entity is not the current one
                const isDuplicate = this.isNew() ||
                    (response.Entities.some(e => e.PatientId !== this.entityId));

                if (isDuplicate) {
                    Q.notifyError("A patient with the same name and date of birth already exists.");
                }
```
- Implemented database-level validation to prevent duplicates
- Used criteria to check for existing records.

### 14. Applying Different Background Colors to Male and Female Patients in the Grid
```typescript
protected getItemCssClass(item: PatientsRow, index: number): string {
    let gender = item.Gender;
    
    if (gender === Gender.Male)
        return "male-patient-row";
    else if (gender === Gender.Female)
        return "female-patient-row";
        
    return "";
}
```
```css
.s-hospital-PatientsGrid .male-row {
  background-color: #ADD8E6;
}
.s-hospital-PatientsGrid .female-row {
  background-color:  hotpink;
}
.s-hospital-PatientsGrid .male-row {
  background-color: #ADD8E6;
}

.s-hospital-PatientsGrid .female-row {
  background-color: hotpink;
}

.s-hospital-PatientsGrid .nav  {
  margin-top: 6px;
}

.s-hospital-PatientsGrid .nav > li > a {
      padding: 8px 12px;
      border-radius: 4px 4px 0 0;
      text-decoration: none;
      color: black;
    }
```
- Implemented `getItemCssClass()` to assign gender-specific CSS classes
- Created styles for visual differentiation between genders.

### 15. Dynamically Requiring and Displaying the Address Field Based on Gender Selection
```typescript
private updateAddressFieldVisibility(): void {
    let gender = this.form.Gender.value;
    
    if (gender === Gender.Male) {
        // Make Address required and visible for male patients
        Serenity.EditorUtils.setRequired(this.form.Address, true);
        this.form.Address.element.closest('.field').show();
    } else {
        // Make Address optional and hidden for female patients
        Serenity.EditorUtils.setRequired(this.form.Address, false);
        this.form.Address.element.closest('.field').hide();
    }
}

constructor() {
    super();
    
    // Listen for gender changes
    this.form.Gender.changeSelect2(e => {
        this.updateAddressFieldVisibility();
    });
}

protected afterLoadEntity() {
    super.afterLoadEntity();
    
    // Update field visibility based on current gender
    this.updateAddressFieldVisibility();
}
```
- Created a method to update the Address field's visibility and requirement
- Added event handlers to respond to gender selection changes.

### 16. Toggle Read-Only Mode for Patients Form
```typescript
protected getToolbarButtons(): Serenity.ToolButton[] {
    let buttons = super.getToolbarButtons();
    
    buttons.push({
        title: "Toggle Read-Only Mode",
        cssClass: "toggle-readonly-button",
        icon: "fa fa-lock",
        onClick: () => {
            this.toggleReadOnly();
        }
    });
    
    return buttons;
}

private isReadOnly = false;

private toggleReadOnly(): void {
    this.isReadOnly = !this.isReadOnly;
    
    // Toggle each editor's read-only state
    Object.keys(this.form).forEach(key => {
        let editor = this.form[key];
        if (editor && editor.element) {
            editor.readOnly = this.isReadOnly;
        }
    });
    
    // Update button icon
    let button = this.toolbar.findButton("toggle-readonly-button");
    button.toggleClass("fa-lock", this.isReadOnly);
    button.toggleClass("fa-unlock", !this.isReadOnly);
    
    // Disable/enable other buttons
    this.toolbar.findButton("save-and-close-button").toggleClass("disabled", this.isReadOnly);
    this.toolbar.findButton("apply-changes-button").toggleClass("disabled", this.isReadOnly);
    this.toolbar.findButton("delete-button").toggleClass("disabled", this.isReadOnly);
}
```
- Added a button to toggle read-only mode
- Implemented a method to update all form fields and buttons accordingly.

### 17. Create Gender-Specific Tabs in the Patients Grid
```typescript
protected createToolbarExtensions(): void {
    super.createToolbarExtensions();
    
    // Add tab container
    let tabs = $("<div class='patient-tabs'></div>")
        .insertBefore(this.slickGrid.element);
        
    // Add tab list
    let tabList = $("<ul class='tab-list'></ul>").appendTo(tabs);
    
    // Add tab items
    this.addTab(tabList, "male", "Male Patients", true);
    this.addTab(tabList, "female", "Female Patients", false);
    this.addTab(tabList, "all", "All Patients", false);
    
    // Handle tab switching
    tabList.find("li").on("click", e => {
        let target = $(e.target).closest("li");
        let tabKey = target.data("tab-key");
        
        // Update active state
        tabList.find("li").removeClass("active");
        target.addClass("active");
        
        // Apply filter based on selected tab
        switch (tabKey) {
            case "male":
                this.setFilter(GenderFilter, Gender.Male);
                break;
            case "female":
                this.setFilter(GenderFilter, Gender.Female);
                break;
            case "all":
                this.setFilter(GenderFilter, null);
                break;
        }
    });
}

private addTab(tabList: JQuery, key: string, title: string, isActive: boolean): void {
    $(`<li data-tab-key="${key}" class="${isActive ? 'active' : ''}">${title}</li>`)
        .appendTo(tabList);
}

private setFilter(filter: string, value: any): void {
    this.view.params.GenderFilter = value;
    this.refresh();
}
```
```css
.patient-tabs {
    margin-bottom: 15px;
}

.tab-list {
    display: flex;
    list-style: none;
    padding: 0;
    margin: 0;
    border-bottom: 1px solid #ddd;
}

.tab-list li {
    padding: 8px 15px;
    cursor: pointer;
    border: 1px solid transparent;
    border-bottom: none;
    margin-bottom: -1px;
}

.tab-list li.active {
    background-color: #fff;
    border-color: #ddd;
    border-bottom-color: #fff;
    font-weight: bold;
}
```
- Implemented a tabbed interface for the Patients grid
- Created methods to handle tab switching and filtering.


## 🚀 Getting Started

To apply these solutions in your Serenity project:

1. **Prerequisites**
   - Visual Studio 2019 or higher
   - .NET 5.0 or higher
   - SQL Server 2016 or higher
   - Node.js 14.x or higher

2. **Setup**
   ```bash
   # Install Sergen CLI globally
   dotnet tool install -g sergen
   
   # Create a new Serenity project
   dotnet new serenity
   
   # Restore packages
   dotnet restore
   npm install
   
   # Configure your connection string in appsettings.json
   # Then run the project
   dotnet run
   ```

3. **Database Setup**
   - Execute the SQL scripts from the `Scripts` folder to create the database schema
   - Update the connection string in `appsettings.json`

4. **Build and Run**
   ```bash
   dotnet build
   dotnet run
   ```

## 💡 Contributing

Contributions are welcome! If you have suggestions or improvements:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 👨‍💻 Author

**Mohamed Amr**
- 📧 [Email](mailto:memoamr@icloud.com)
- 💼 [LinkedIn](www.linkedin.com/in/mohamed--amr)


<p align="center">Made with ❤️ for Serenity.is enthusiasts</p>