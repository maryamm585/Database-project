# Library Management System
this project is a Library Management System built using C#. It allows administrators and students to manage book borrowing, user details, and categories of books. The project uses a repository pattern for data access and interaction with a database context.

## Features:

### 1. Student Management:
 - Update student informations (e.g., password, age).
 - Add preferred book categories for a student.

### 2. Book Management:
- Book data is managed and retrieved using a Book model.
- Search book using book name.
- Get all books
- review a certain book details

### 3. Admin Management:
- Admins can manage add/delete/update Books and Users
- Update admin informations (e.g., password, adress).

### 4. Borrow and Return Books:
 - Manage book borrowing transactions.
 - Configurations to manage how borrow data is handled.

## Project Structure

The project is organized into several components:

### Models
- Contains the data models (Admin, Book, Borrow, Category, Faculty, Student) representing various entities in the library system.

### Repositories
- Implements the data access layer using the repository pattern.
  - `GenericRepository`: A generic repository for common database operations.
  - `StudentRepo`, `BooksRepo`, `AdminRepo`: Repositories for specific entities.

### Configurations
- Contains configuration files for various entities, like `BookConfiguration`, `BorrowConfiguration`, and more.

### Context
- Contains the `LibraryDBContext` that connects to the database and manages entity models.
  
## Repository Pattern

The project implements a repository pattern to abstract away the database logic. This approach allows for more maintainable and testable code. Each entity has a corresponding repository responsible for CRUD operations.

### StudentRepo
- Student authentication and authorization.
- `UpdateStudent`: Updates student details like password and age.
- `AddPreferredCategories`: Allows a student to add categories they are interested in.
- 'BorrowBook' : allow the user to borrow a certain book

### AdminRepo
-  Admin authentication and authorization.
- `UpdateAdmin`: Updates student details like password and address.
- 'AddBook': allow an admin to add book.
- 'RemoveBooks': allow an admin to delete book.
- 'UpdateBook': allow an admin to update book.
- 'RemoveStudent': allow an admin to delete student.
- 'MoveStudentsToNextYear': allow an admin to update student college Year.

### BooksRepo
- 'ShowAllBooks' : Display all available books.
- 'ViewBooks' : Display books of a certain Category or by Author's Name.
- 'SearchBook' : Display books of a certain book name.

## Additional Notes
- The project uses LINQ to query data and Entity Framework for database operations.
- Error handling is done by printing error messages in the console for failed updates or data modifications.
