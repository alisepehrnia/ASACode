# 🧪 ASACode – Advanced Software Architecture Sample Projects

A collection of **three independent .NET Framework solutions** built for an **Advanced Software Architecture (ASA)** course.  
Each folder is a self-contained Visual Studio solution demonstrating a different pattern or technology:

- **`RecursiveFileList`** – a WinForms tool that recursively lists files and folders with a background worker.
- **`StudentsCrudADOWinform`** – a WinForms CRUD app using **ADO.NET** (stored procedures + inline SQL) against SQL Server.
- **`StudentsCrudMVC`** – an **ASP.NET MVC 5 + Entity Framework 6** CRUD app for the same Student model.

> **Note:** There is no README, license, or test project in the repository. This document was written from the source code.

---

## 📖 Overview

| Project | Type | Framework | Data access | Purpose |
|---------|------|-----------|-------------|---------|
| **`RecursiveFileList`** | WinForms desktop | .NET Framework **4.5.2** | None (filesystem only) | Recursively enumerate files/folders under a chosen directory |
| **`StudentsCrudADOWinform`** | WinForms desktop | .NET Framework **4.8** | **ADO.NET** (`SqlConnection`, `SqlDataAdapter`, stored procedures) | Create, read, update, delete, and search Student records |
| **`StudentsCrudMVC`** | ASP.NET MVC web app | .NET Framework **4.8** | **Entity Framework 6.4.4** (Code First DbContext) | Full CRUD scaffolding for the Student entity |

The two Student projects share the same simple domain model — a student with an **Id**, **FirstName**, and **LastName** — and illustrate how the same CRUD requirements are implemented with two very different data-access stacks: raw ADO.NET versus an ORM.

---

## 🗂️ Repository Structure

```text
ASACode/
├── RecursiveFileList/
│   ├── Properties/
│   ├── App.config
│   ├── Form1.Designer.cs
│   ├── Form1.cs
│   ├── Form1.resx
│   ├── Program.cs
│   ├── RecursiveFileList.csproj      # .NET Framework 4.5.2, WinExe
│   ├── RecursiveFileList.sln
│   └── app.jpg                       # Screenshot
├── StudentsCrudADOWinform/
│   ├── Properties/
│   ├── ADO1.csproj                   # .NET Framework 4.8, WinExe
│   ├── ADO1.sln
│   ├── App.config
│   ├── Form1.Designer.cs
│   ├── Form1.cs
│   ├── Form1.resx
│   ├── Program.cs
│   └── app.jpg                       # Screenshot
├── StudentsCrudMVC/
│   ├── MVCApp1/
│   │   ├── App_Start/
│   │   ├── Assets/
│   │   ├── Content/
│   │   ├── Controllers/
│   │   │   └── StudentsController.cs # Index, Details, Create, Edit, Delete
│   │   ├── Models/
│   │   │   └── Student.cs            # Id (identity), FirstName, LastName
│   │   ├── Properties/
│   │   ├── Scripts/
│   │   ├── Views/
│   │   │   ├── Shared/
│   │   │   └── Students/             # Scaffolded Index/Details/Create/Edit/Delete
│   │   ├── App1DbContext.cs          # DbContext ("name=Model1")
│   │   ├── Global.asax(.cs)
│   │   ├── MVCApp1.csproj            # .NET Framework 4.8, MVC 5.2.7, EF 6.4.4
│   │   ├── packages.config
│   │   └── Web.config
│   ├── MVCApp1.sln
│   ├── Web.config
│   ├── alisepehrnia-001-site1 - Web Deploy.pubxml
│   └── site1.PublishSettings
└── .gitignore
```

## 🧩 Project 1 – `RecursiveFileList`

### What it does

A **WinForms utility** that lets you pick a folder and recursively enumerate its contents.  
You choose what to list with radio buttons — **All**, **Folders only**, or **Files only** — and the results appear as full paths in a multiline text box.

### How it works

- **Folder selection** — `BrowseButton_Click` opens a `FolderBrowserDialog` and stores `SelectedPath` in `DirPath` .
    
- **Background execution** — `SearchButton_Click` shows a “Please Wait…” message, sets the wait cursor, and starts a `BackgroundWorker` so the UI stays responsive during deep recursion .
    
- **Recursion** — `RecListFolders` uses `DirectoryInfo.EnumerateFileSystemInfos` (top-directory only) and recurses into every subdirectory. Directories are added only when **All** or **Folders** is selected; files only when **All** or **Files** is selected .
    
- **Error tolerance** — enumeration is wrapped in `try/catch` so inaccessible subfolders do not abort the whole scan .
    
- **Completion** — `WorkerOnRunWorkerCompleted` joins the collected paths with `Environment.NewLine` and writes them to the text box, restoring the default cursor .
    

### Key source

```csharp
private void RecListFolders(string path)
{
    var dirInfo = new DirectoryInfo(path);
    if (!dirInfo.Exists) { list.Add(path); return; }
    var fsInfos = Enumerable.Empty<FileSystemInfo>();
    try { fsInfos = dirInfo.EnumerateFileSystemInfos("*", SearchOption.TopDirectoryOnly); }
    catch (Exception e) { Console.WriteLine(e); }
    foreach (var fsInfo in fsInfos)
    {
        if ((fsInfo.Attributes & FileAttributes.Directory) != 0)
        {
            if (allRadioButton.Checked || foldersRadioButton.Checked) list.Add(fsInfo.FullName);
            RecListFolders(fsInfo.FullName);
        }
        else
        {
            if (allRadioButton.Checked || filesRadioButton.Checked) list.Add(fsInfo.FullName);
        }
    }
}
```

### Run

1. Open `RecursiveFileList.sln` in Visual Studio.
    
2. Build and press **F5**.
    
3. Click **Browse**, pick a folder, select **All/Folders/Files**, then click **Search**.
    

---
## 🧩 Project 2 – `StudentsCrudADOWinform`

### What it does

A **WinForms CRUD application** for a `Students` table, using **[ADO.NET](https://ado.net/)** directly.  
It supports **Insert**, **Delete**, **Update**, **Search**, and a **DataGridView** that refreshes after every operation.

### Data access

The connection string is **hard-coded** in `Form1.cs`:

```csharp
private const string ConnString =
    "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Test;Data Source=.";
private static readonly SqlConnection DbConn = new SqlConnection(ConnString);
private static readonly DataTable Dt = new DataTable();
```


The project expects a SQL Server instance at `"."` (the default instance on the local machine) with a database named **`Test`** .

### Operations

|Button|Method|SQL mechanism|
|---|---|---|
|**Load**|`GetList()`|`SqlDataAdapter("GetStudents", DbConn)` — **stored procedure** fills the `DataTable`|
|**Insert**|`Insert(...)`|`SqlCommand("InsertStudent")` with `@StudentId`, `@FirstName`, `@LastName`, and a `@R` **return value**; success when `@R == "1"`|
|**Delete**|`Delete(...)`|`SqlCommand("DeleteStudent")` — **stored procedure**; success when `ExecuteNonQuery()` returns `1`|
|**Update**|`Update(...)`|**Inline SQL** built with string interpolation: `update dbo.Students set FirstName='…', LastName='…' where StudentId = …`|
|**Search**|`Search(...)`|**Inline SQL**: `select * from dbo.Students where StudentId = …`, then reads `Rows[0][1]` / `Rows[0][2]`|

### Validation

Every operation validates the inputs before touching the database and shows a `MessageBox` on failure:

- Empty ID / first name / last name → “Fill All Text Boxes!”
    
- Non-numeric ID → “Enter Correct Id!”
    
- Duplicate ID on insert → “Student With Same Id Already Exists!”
    
- Missing ID on delete/update/search → “Student With Provided Id Not Exists!”
    

### Required database objects

To run the project, the `Test` database needs:

- Table **`dbo.Students`** with columns `StudentId`, `FirstName`, `LastName`.
    
- Stored procedure **`GetStudents`** — returns the student list.
    
- Stored procedure **`InsertStudent`** — parameters `@StudentId`, `@FirstName`, `@LastName`, and a return value `@R` (`1` on success).
    
- Stored procedure **`DeleteStudent`** — parameter `@StudentId`.
    

> These objects are **not included** in the repository; you must create them manually or adapt the code to an existing schema.

### Run

1. Create the `Test` database and the objects listed above.
    
2. Open `ADO1.sln` in Visual Studio.
    
3. Build and press **F5**.
    
4. Use the ID / first-name / last-name fields with the Insert, Update, Delete, and Search buttons.
    

---
## 🧩 Project 3 – `StudentsCrudMVC`

### What it does

An **[ASP.NET](https://asp.net/) MVC 5** web application with **Entity Framework 6** that provides scaffolded CRUD pages for the `Student` entity.

### Model

```csharp
public class Student
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
```

### DbContext

```csharp
public class App1DbContext : DbContext
{
    public App1DbContext() : base("name=Model1") { }
    public DbSet<Student> Students { get; set; }
}
```

The context reads the **`Model1`** connection string from `Web.config` .

### Controller

`StudentsController` contains the full set of actions:

|Action|Route|Behaviour|
|---|---|---|
|`Index`|`GET /Students`|`db.Students.ToList()`|
|`Details`|`GET /Students/Details/{id}`|`Find(id)`, `HttpNotFound()` if missing|
|`Create`|`GET /Students/Create`|Returns the empty form|
|`Create`|`POST /Students/Create`|`Add(student)` + `SaveChanges()`, then redirects to `Index`|
|`Edit`|`GET /Students/Edit/{id}`|`Find(id)`|
|`Edit`|`POST /Students/Edit/{id}`|`Entry(student).State = Modified` + `SaveChanges()`|
|`Delete`|`GET /Students/Delete/{id}`|Shows the confirmation page|
|`Delete`|`POST /Students/Delete/{id}`|`Remove(student)` + `SaveChanges()`|

Create and Edit use `[ValidateAntiForgeryToken]` and `[Bind(Include = "Id,FirstName,LastName")]` .

### Views

The `Views/Students` folder contains the standard scaffolded Razor pages (**Index**, **Details**, **Create**, **Edit**, **Delete**), with shared layout and partials under `Views/Shared`.

### NuGet packages

The project references (among others):

- **Microsoft.AspNet.Mvc 5.2.7**
    
- **EntityFramework 6.4.4**
    
- **Microsoft.AspNet.Razor 3.2.7**
    
- **Newtonsoft.Json 13.0.1**
    
- **Microsoft.AspNet.Web.Optimization 1.1.3**
    
- **BundleTransformer** / **LibSassHost** (asset bundling and Sass compilation)
    

> The `.csproj` uses relative `..\packages\…` paths, so **NuGet package restore is required** before building.

### Run

1. Open `MVCApp1.sln` in Visual Studio (2019/2022 with the [ASP.NET](https://asp.net/) and web development workload).
    
2. Right-click the solution → **Restore NuGet Packages**.
    
3. Ensure the **`Model1`** connection string in `Web.config` points at a valid SQL Server / LocalDB database.
    
4. Create the `Students` table (EF Code First, or manually) — there is no `Migrations` folder in the repository.
    
5. Build and press **F5**; the app launches at the IIS Express URL configured in the project (`https://localhost:44321/`).
    
6. Navigate to **`/Students`** for the CRUD list.
    

---
## 🛠️ Technologies

|Item|Details|
|---|---|
|**Language**|C#|
|**Desktop UI**|Windows Forms (WinForms)|
|**Web framework**|[ASP.NET](https://asp.net/) MVC 5 (`Microsoft.AspNet.Mvc 5.2.7`)|
|**ORM**|Entity Framework 6.4.4 (Code First `DbContext`)|
|**[ADO.NET](https://ado.net/)**|`SqlConnection`, `SqlCommand`, `SqlDataAdapter`, `DataTable`|
|**Database**|SQL Server (local default instance `"."`; database `Test`)|
|**Target frameworks**|`RecursiveFileList` → 4.5.2 · `StudentsCrudADOWinform` → 4.8 · `StudentsCrudMVC` → 4.8|
|**IDE**|Visual Studio (solutions use the classic `.sln` + `.csproj` format)|

---
## 🚀 Getting Started (All Projects)

### Prerequisites

- **Visual Studio 2019/2022** with:
    
    - **.NET desktop development** (for the two WinForms projects)
        
    - **[ASP.NET](https://asp.net/) and web development** (for the MVC project)
        
- **.NET Framework 4.5.2 and 4.8 targeting packs**
    
- **SQL Server** (Express / Developer / LocalDB) for the two Student projects
    
- **NuGet** package restore (required by the MVC project)
    

### General steps

```bash
git clone https://github.com/alisepehrnia/ASACode.git
cd ASACode
```

Then open the solution for the project you want:

- `RecursiveFileList/RecursiveFileList.sln`
    
- `StudentsCrudADOWinform/ADO1.sln`
    
- `StudentsCrudMVC/MVCApp1.sln`
    

Each project can be built and run independently; they share no code.

---
## ⚠️ Notes & Caveats

- **No tests** 
    
- **Hard-coded connection string** in `StudentsCrudADOWinform/Form1.cs` (`Initial Catalog=Test; Data Source=.`). Change it to match your SQL Server instance.
    
- **Missing database objects** — the stored procedures (`GetStudents`, `InsertStudent`, `DeleteStudent`) and the `Students` table are **not** in the repository. You must create them before the ADO project will run.
    
- **SQL injection risk** — `Exists`, `Update`, and `Search` in the ADO project build SQL with **string interpolation** rather than parameters:
    
    ```csharp
    var adapter = new SqlDataAdapter($"select StudentId from dbo.Students where StudentId = {id}", DbConn);
    ```
    
    This is fine for a classroom demo but should be parameterised in real code.
    
- **Shared static connection/DataTable** — `DbConn` and `Dt` are `static`, so the ADO form is effectively single-instance. Not thread-safe.
    
- **No EF migrations** — `StudentsCrudMVC` has a `DbContext` but no `Migrations` folder, so the database/table must be created separately (or migrations added).
    
- **Identity column bound on Create** — the MVC `Create` action binds `Id`, but `Student.Id` is `DatabaseGeneratedOption.Identity`; inserting an explicit `Id` may conflict with the identity column depending on the database configuration.
    
- **Screenshots** — each project folder includes an `app.jpg` screenshot of the running application; these are illustrative, not required to build.
    
- **Old project format** — the solutions use the legacy (non-SDK-style) `.csproj` format and require the .NET Framework targeting packs; they will not build with `dotnet build` alone on a machine without those packs.
    

---
## 🤝 Contributing

This is a personal coursework archive.  
If you want to extend it — e.g. parameterise the [ADO.NET](https://ado.net/) queries, add EF migrations to the MVC project, or add a README per project — issues and pull requests are welcome.

---
## 📄 License

Feel free to use :)
