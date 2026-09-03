# AwladAli Cashier Desktop Project

AwladAli Cashier is a Windows desktop point-of-sale (POS) application for managing restaurant sales, products, customers, cashier shifts, and administrative reports. It is built with C# Windows Forms and stores application data locally in a SQLite database.

> The source code uses the existing `AwladAli_Buisness` spelling for the business-layer project name. The project name is preserved to keep the solution references working.

## Features

### Cashier and sales operations

- Secure login for active users.
- Optional **Remember username** functionality.
- Cashier session/shift management with:
  - Start and end session controls.
  - Live session duration timer.
  - Session sales total.
  - Session recovery after restarting the application.
  - Detection of an active session belonging to another user.
- Product selection grouped by category.
- Product size selection where configured, including S, M, L, XL, or normal sizes.
- Add-on/extra selection with quantities.
- Takeaway orders.
- Delivery orders with customer details and delivery fees.
- Current-order reset before saving.
- Transactional order saving so the order header and its line items are committed together.
- Order summary and receipt printing.

### Customers

- Search customers by name or phone number.
- Add and update customer records.
- Store delivery information for an order.
- Activate, deactivate, and delete customer records where permitted.

### Products and menu administration

- Create and update product categories.
- Create and update products.
- Configure product sizes and prices.
- Create, update, and list extras/add-ons.
- Enable the menu to be refreshed after administrative changes.

### Users and administration

- Add and update application users.
- Assign **Admin** and **Cashier** roles.
- Activate or deactivate users.
- Restrict administrative settings to administrator accounts.
- View dashboard statistics for a selected date range, including revenue and order counts.
- Review top products, categories, and extras.
- Browse orders and session reports.
- View and print session details.

## Technology stack

- **Language:** C#
- **UI framework:** Windows Forms
- **Target framework:** .NET Framework 4.8
- **Database:** SQLite 3
- **Data access:** `System.Data.SQLite` and SQLitePCLRaw
- **IDE:** Visual Studio 2022 or another Visual Studio version that supports .NET Framework 4.8
- **Supported build configurations:** Debug/Release and Any CPU/x86

## Solution structure

```text
Code/
├── AwladAli/                 # Windows Forms user interface and application startup
├── AwladAli_Buisness/        # Business entities and application rules
└── AwladAli_Data/            # SQLite queries and data-access classes
Other Related Data/
├── AwladAli_Cashier_App V1.0/
├── AwladAli_Cashier_App V2.0/
├── AwladAli_Cashier_App V3.0/
└── DataBase/                 # Database files for the different project versions
```

Important UI areas include:

- `Code/AwladAli/Login` — login screen.
- `Code/AwladAli/Bill` — order information and receipt printing.
- `Code/AwladAli/Category` — categories, products, and extras.
- `Code/AwladAli/Customer` — customer and delivery details.
- `Code/AwladAli/Session` — cashier session and session-order reports.
- `Code/AwladAli/User` — user management and the administrator dashboard.

The three projects are connected as follows:

```text
AwladAli (UI)
	↓
AwladAli_Buisness (business layer)
	↓
AwladAli_Data (data-access layer)
	↓
AwladAli.db (SQLite database)
```

## Database

The application expects a file named `AwladAli.db` in the same directory as the running executable. The connection string is generated in `Code/AwladAli_Data/clsDataAccessSettings.cs`:

```text
Data Source=<application directory>\AwladAli.db;Version=3;
```

Database files included in this repository are available under:

- `Other Related Data/DataBase/Database V1.0/AwladAli.db`
- `Other Related Data/DataBase/Empty Database V2.0/AwladAli.db`
- `Other Related Data/DataBase/Empty Database V3.0/AwladAli.db`

The database contains the data used by the application, including users, categories, products, product sizes, extras, customers, orders, order details, and sessions.

### Choosing a database

- Use the versioned database that matches the application version you want to run.
- Use an empty database when starting a new installation or test environment.
- Copy the selected file beside `AwladAli.exe` after building or publishing the application.
- Back up `AwladAli.db` before upgrading the application or changing its schema.

The source project does not automatically copy the database to the build output directory, so this step must be handled manually or by the deployment process.

## Requirements

1. Windows.
2. .NET Framework 4.8.
3. Visual Studio with the .NET desktop development workload.
4. NuGet package restore enabled.
5. A compatible `AwladAli.db` file beside the executable.

## Build and run from source

1. Clone or download this repository.
2. Open `Code/AwladAli/AwladAli.sln` in Visual Studio.
3. Allow NuGet packages to restore. The projects use `packages.config` files and include the required package references.
4. Select `AwladAli` as the startup project.
5. Select `Debug` or `Release` and either `Any CPU` or `x86`.
6. Build the solution.
7. Copy a compatible `AwladAli.db` file into the output folder, for example:
   - `Code/AwladAli/bin/Debug/`
   - `Code/AwladAli/bin/Release/`
   - `Code/AwladAli/bin/x86/Debug/`
   - `Code/AwladAli/bin/x86/Release/`
8. Run `AwladAli.exe`.

If the application reports that categories or users cannot be found, verify that the database file is present in the executable directory and that it is the intended database version.

## Running a packaged version

Packaged application files for previous releases are stored under:

- `Other Related Data/AwladAli_Cashier_App V1.0`
- `Other Related Data/AwladAli_Cashier_App V2.0`
- `Other Related Data/AwladAli_Cashier_App V3.0`

For a packaged installation, keep the executable, its configuration files, required DLLs, and `AwladAli.db` together in the same application directory. The V3.0 folder also contains ClickOnce publishing artifacts.

## First-use workflow

1. Start the application and sign in with an active user already stored in the database.
2. If no user exists, prepare the database with an administrator account before launching the application.
3. Start a cashier session before attempting to save an order.
4. Select products and extras.
5. Choose **Takeaway** or **Delivery**.
6. For delivery, select or enter the customer details and delivery fee.
7. Review the total, save the order, and print or view its receipt.
8. End the session when the shift is complete.

No default username or password is documented in the source repository. Do not assume credentials; use the credentials seeded in the selected database or create an administrator account through an appropriate database setup process.

## Security and data notes

- Only active users can log in.
- Password values are encrypted before they are compared with stored credentials.
- Usernames may be remembered through Windows user settings/registry functionality when the option is enabled.
- The database is local and file-based. Protect access to the application directory and back up the database regularly.
- This application is designed for local Windows deployment; it does not provide a central server or multi-site synchronization service.

## Troubleshooting

### The application cannot find the database

Confirm that the file is named exactly `AwladAli.db` and is beside `AwladAli.exe`. Do not place it only in the repository root or in the source project folder unless that is also the executable directory.

### NuGet or SQLite build errors occur

Restore NuGet packages and rebuild the solution. The main package dependencies are listed in `Code/AwladAli/packages.config`, `Code/AwladAli_Buisness/packages.config`, and `Code/AwladAli_Data/packages.config`.

### The application starts but the menu is empty

Verify that the selected database contains categories and products, and that the database schema matches the application version.

### A cashier cannot save an order

The cashier must have an active session, the order total must be greater than zero, and delivery orders must include a valid customer phone number and customer record.

## License

See [`LICENSE.txt`](LICENSE.txt) for the project license.

## Project status

This repository contains the source solution, local SQLite database files, and packaged artifacts for multiple application versions. The application is a traditional .NET Framework desktop project and is not an ASP.NET, web, or cloud application.
