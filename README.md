# 🚗 CarReservation

**Test assignment for the position of Senior Developer C#/.NET (Blazor)**

---

## 📋 Requirements

### Application Tasks

1. Booking a rental car for the cities of **Berlin**, **Munich**, **Hamburg**, **Frankfurt**, and **Stuttgart** (the car must be returned in the same city).  
2. Each rental location must offer **at least 5 different vehicles** (model selection is flexible).  
3. The rental period can be selected **by day** (e.g., August 1st–5th) but **cannot be in the past**.  
4. If a vehicle is already booked for a given period, it **cannot be reserved** again for those dates.

### Nice to Have

- A **user interface** (preferably built with MudBlazor) for booking, using a small grid or table (alternatively, "Scribble" may be used).  
- Support for **rebooking or cancellation**.  
- A **small flowchart** illustrating the process.

---

## ✅ Completion Status

### Core Tasks

| Task | Status |
|------|---------|
| Booking by city | ✅ Done |
| Multiple cars per location | ✅ Done |
| Rental period validation | ✅ Done |
| Prevent overlapping bookings | ✅ Done |

### Additional Features

| Feature | Status |
|----------|---------|
| User interface (MudBlazor) | ✅ Done |
| Rebooking / cancellation | 🟡 In development |
| Flowchart | 🟡 In development |

---

## 🧩 Solution Architecture Overview

To accelerate prototype development, an **in-memory data storage** approach was chosen.  
A static list–based database is initialized and populated with test data when the host application starts.

The **Repository pattern** is used to separate business logic from the data layer.  
This design enables an easy transition to any other data storage system in the future.

The **core business logic** is implemented within dedicated services.

For the UI layer, the **MVVM pattern** is applied, implemented using the `CommunityToolkit.Mvvm` package.

The main UI components are built with the **MudBlazor** library, following the initial project requirements.

---

## 🏗️ Solution Structure

| Folder | Description |
|---------|--------------|
| **wwwroot** | Static files (CSS, JS, etc.) |
| **Components** | All UI representations (Razor components and pages) |
| **Data** | Data layer implementation and Repository pattern |
| **Domain** | Domain model classes |
| **Localization** | Resource files and localization helpers |
| **Mapping** | Object mapping profiles (AutoMapper) |
| **Navigation** | Routes and navigation helpers |
| **Services** | Core business logic layer |
| **ViewModels** | Data transformation, state management, and business logic invocation |

---

## ⚠️ Known Issues and Limitations

- **Business logic is not fully separated** into the service layer.  
  For example, the rental price calculation is still handled outside the service layer.

- **No automated tests** have been implemented yet.  
  Unit and integration tests should be added to improve reliability and maintainability.

- It is recommended to **introduce a state machine** within the ViewModel layer  
  to better manage and track view states in a structured way.