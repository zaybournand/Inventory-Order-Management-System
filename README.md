# Inventory & Order Management System

A robust C# console application designed to simulate a warehouse inventory system. This project demonstrates **Clean Architecture** principles, **Dependency Injection**, and **Atomic Transaction** logic to ensure data consistency during order fulfillment.

## 🚀 Features

- **Atomic Order Processing:** Implements "All-or-Nothing" logic. If even one item in an order is out of stock, the entire order is rejected to maintain inventory integrity.
- **Clean Architecture:** strictly separated into Domain (Core), Logic (Application), and Data (Infrastructure) layers.
- **In-Memory Storage:** Uses Dependency Injection to inject repositories, making it easy to swap for a real SQL database later.
- **Unit Testing:** Includes automated tests using xUnit to verify business rules and edge cases.

## 🏗️ Architecture

The solution is organized into four decoupled projects:

1.  **Core (Domain Layer):** Contains the enterprise logic, Interfaces (`IInventoryRepository`), Models (`Order`, `InventoryItem`), and Enums. No external dependencies.
2.  **Application (Service Layer):** Orchestrates the business logic. Contains `OrderService` which handles the transaction validation.
3.  **Infrastructure (Data Layer):** Implements the interfaces using In-Memory collections.
4.  **ConsoleApp (Presentation Layer):** The entry point for user interaction via CLI.

## 🛠️ Tech Stack

- **Language:** C# (.NET 8/9/10)
- **Testing:** xUnit
- **Design Patterns:** Repository Pattern, Dependency Injection

## 💻 Getting Started

### Prerequisites

- .NET SDK (Version 6.0 or higher)

### Installation

1.  Clone the repository:
    ```bash
    git clone [https://github.com/YOUR_USERNAME/InventoryOrderManagement.git](https://github.com/YOUR_USERNAME/InventoryOrderManagement.git)
    ```
2.  Navigate to the project directory:
    ```bash
    cd InventoryOrderManagement
    ```
3.  Build the solution:
    ```bash
    dotnet build
    ```

## 🎮 Usage

Run the application using the dotnet CLI:

```bash
dotnet run --project InventoryOrderManagement.ConsoleApp
```
