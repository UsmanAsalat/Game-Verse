# Game Verse

Game Verse is a web-based gaming platform where users can explore games, manage wishlists and carts, and place orders. The project uses a Connected SQL approach with SQL Server Management Studio (SSMS) for database operations.

## Features

* User authentication with roles (Admin / User)
* View available games with complete details
* Add games to Wishlist
* Add games to Cart
* Place game Orders
* Admin can manage games

## Technologies Used

* Frontend / Backend: ASP.NET (as implemented in the project)
* Database: Microsoft SQL Server
* Database Tool: SQL Server Management Studio (SSMS)
* Database Architecture: Connected Architecture
* Version Control: Git and GitHub

## Database Design (SSMS – Connected Approach)

This project follows a Connected SQL approach where the application maintains a direct connection with the SQL Server database. All database operations are performed using SQL queries executed through SSMS and application-side connections.

### Database Creation

```sql
CREATE DATABASE GameVerse;
USE GameVerse;
```

### Tables Structure

#### Users Table

Stores user login credentials and role information.

```sql
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(10) NOT NULL
);
```

#### Games Table

Stores information about games available on the platform.

```sql
CREATE TABLE Games (
    GameID INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100) NOT NULL,
    ImageUrl NVARCHAR(MAX),
    Description NVARCHAR(MAX),
    Price DECIMAL(10,2)
);
```

#### Wishlist Table

Stores games that users add to their wishlist.

```sql
CREATE TABLE Wishlist (
    WishlistID INT PRIMARY KEY IDENTITY,
    UserID INT,
    GameID INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (GameID) REFERENCES Games(GameID)
);
```

#### Cart Table

Stores games added by users to their cart.

```sql
CREATE TABLE Cart (
    CartID INT PRIMARY KEY IDENTITY,
    UserID INT,
    GameID INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (GameID) REFERENCES Games(GameID)
);
```

#### Orders Table

Stores order details of users.

```sql
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY,
    UserID INT,
    GameID INT,
    OrderDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (GameID) REFERENCES Games(GameID)
);
```

### Default Admin Account

```sql
INSERT INTO Users (Email, Password, Role)
VALUES ('admin@gv.com', 'admin123', 'admin');
```

## Database Connectivity Approach

* The project uses a Connected Architecture
* The application directly communicates with the SQL Server database
* SQL queries are executed using SSMS and application-level database connections
* This approach is suitable for small to medium-scale applications

## How to Run the Project

1. Clone the GitHub repository:

   ```bash
   git clone https://github.com/UsmanAsalat/Game-Verse.git
   ```
2. Open the project in Visual Studio
3. Open SQL Server Management Studio and execute the provided SQL queries
4. Configure the database connection string if required
5. Run the project from Visual Studio

## Project Purpose

This project is developed for educational purposes to demonstrate database design, connected SQL architecture, and basic e-commerce-like functionality in a gaming platform.

## Author

Usman Asalat
Software Engineering Student

## License

This project is intended for academic and learning purposes only.
