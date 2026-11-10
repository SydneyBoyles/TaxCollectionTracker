# Tax Collection Tracker

## Project Overview

Tax Collection Tracker is a Windows desktop application developed using C# Windows Forms and Microsoft SQL Server Express.

The application allows users to manage fictional taxpayer records, view tax account balances, record payments, and review payment history.

I developed this project to practice database-driven application development, SQL queries, input validation, and common business application operations.

**This is an independent educational portfolio project. It is not affiliated with a government agency and uses fictional taxpayer information.**

## Technologies Used

- C#
- Windows Forms (.NET 10)
- Microsoft SQL Server Express
- SQL Server Management Studio (SSMS)
- Microsoft.Data.SqlClient
- Visual Studio

## Application Features

### Taxpayer Management
- Search for taxpayers using account numbers
- Add new taxpayer records
- View existing taxpayer information
- Update taxpayer names and email addresses
- Refresh search results after updates

### Tax Account Management
- Display original tax amounts
- Track the total amount paid
- Calculate remaining account balances
- Connect taxpayer records to financial accounts using foreign keys

### Payment Processing
- Record individual payments
- Validate payment amounts before saving
- Prevent payments that exceed the remaining balance
- Use SQL transactions to keep payment records and account balances consistent
- Update balances after successful payments

### Payment History
- Display recorded payments for a selected tax account
- Show payment dates, amounts, and notes
- Sort payments by date
- Keep payment history read-only in the application

## Database Structure

The project uses three main SQL Server tables:

**Taxpayers**
Stores taxpayer account numbers, names, and contact information.

**TaxAccounts**
Stores tax account amounts, total payments, and calculated remaining balances.

**Payments**
Stores individual payments, including the amount, date, and optional notes.

The tables are connected using primary and foreign keys.

## Database Operations

The application demonstrates SQL operations such as:

- `SELECT` — Retrieve taxpayer and payment information
- `INSERT` — Add taxpayer and payment records
- `UPDATE` — Modify taxpayer information and payment totals
- `JOIN` — Combine related information from multiple tables

SQL parameters are used to safely pass values into database queries.

## Input Validation and Error Handling

The application includes validation to:

- Prevent required taxpayer fields from being empty
- Reject duplicate taxpayer account numbers
- Reject invalid or negative payment amounts
- Prevent payments that exceed account balances
- Restrict payments to two decimal places
- Display error messages when database operations fail

SQL transactions are used when recording payments so the payment record and account balance update succeed or fail together.

## Testing

The application was manually tested using fictional taxpayer information.

Testing included:

- Adding and searching for taxpayer records
- Editing and retrieving updated taxpayer information
- Recording a payment and confirming the remaining balance changed
- Viewing saved payment history
- Rejecting invalid payment amounts
- Confirming invalid payments did not change account balances

## Skills Demonstrated

This project demonstrates practical experience with:

- C# application development
- Windows Forms interface design
- Relational database design
- SQL Server database connections
- CRUD operations
- Parameterized SQL queries
- SQL transactions
- Input validation
- Exception handling
- Testing and troubleshooting

## Project Purpose

I created this project to strengthen my C# and SQL Server skills while gaining experience developing a desktop application that supports business record management and financial transactions.

The project is intended to demonstrate foundational programming, database, and application support skills relevant to entry-level software development and application services positions.