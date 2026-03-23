# APBD Task 2 - Equipment Rental System

Console app in C# for a university equipment rental service.

## How to Run

1. Clone the repo
2. Open in Rider
3. .NET 10 required
4. Run the project

## Project Structure

- **Models** - Equipment (abstract), Laptop, Projector, Camera, User, Rental
- **Services** - RentalService, ReportService
- **Enum** - EquipmentStatus, UserType

## Design Decisions

I separated the code into Models, Services and Enums. Equipment is abstract because all equipment types share common fields but each has its own specific ones.

RentalService contains all business logic. ReportService only handles reports. Program.cs only runs the demo scenario.

ReportService receives RentalService through the constructor to avoid tight coupling.

## Business Rules

- Student: max 2 active rentals
- Employee: max 5 active rentals
- Late return penalty: 5 PLN per day