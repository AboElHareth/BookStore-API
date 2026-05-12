# BookStore API

A simple and clean ASP.NET Core Web API project for managing books, authors, and publishers using Entity Framework Core and SQL Server.

## Features

- Manage Books
- Manage Authors
- Manage Publishers
- CRUD Operations
- Entity Framework Core
- SQL Server Database
- RESTful API Architecture
- Clean Project Structure

## Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI

## Project Structure

```text
BookStore
│
├── Controllers
├── Data
├── Migrations
├── Model
├── Service
├── ViewModel
├── Program.cs
└── appsettings.json
```

## API Endpoints

# Authors

| Method | Endpoint |
|--------|----------|
| GET | `/get-all-authors` |
| POST | `/add-new-author` |
| GET | `/get-author-byid` |
| GET | `/get-author-byid-with-books` |
| GET | `/get-author-byname` |
| DELETE | `/delete-author` |
| PUT | `/Update-author` |

# Books

| Method | Endpoint |
|--------|----------|
| GET | `/get-all-books` |
| GET | `/get-all-books-with-publisher` |
| POST | `/add-new-book` |
| GET | `/get-book-byid` |
| GET | `/get-book-byid-with-publisher` |
| GET | `/get-book-byname` |
| GET | `/get-book-byname-with-publisher` |
| DELETE | `/delete-book` |
| PUT | `/Update-book` |

# Publishers

| Method | Endpoint |
|--------|----------|
| GET | `/get-all-publishers` |
| POST | `/add-new-publisher` |
| GET | `/get-publisher-byid` |
| GET | `/get-publisher-byid-with-books` |
| GET | `/get-publisher-byname` |
| DELETE | `/delete-publisher` |
| PUT | `/Update-publisher` |

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/AboElHareth/BookStore-API.git
```

### Open the Project

Open the solution in Visual Studio.

### Configure Database

Update the connection string in:

```text
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "conString": "Server=.;Database=BookStore;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### Apply Migrations

Run the following command in Package Manager Console:

```powershell
Update-Database
```

### Run the Project

Press:

```text
Ctrl + F5
```

or click the Run button in Visual Studio.

## Swagger Documentation

After running the project, Swagger will be available at:

```text
https://localhost:7130/swagger
```

## Future Improvements

- Authentication & Authorization
- Pagination
- Search & Filtering
- DTO Validation
- Repository Pattern
- Unit Testing

## Author

Mohamed Ali

