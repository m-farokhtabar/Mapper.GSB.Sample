# Mapper.GSB

## 🩺 Overview

This project is a sample and personal practice project, created to explore architectural patterns, event-driven design, and evaluate potential side effects in a real-world-like medical data processing pipeline.
The application uses an event-driven architecture to validate, snapshot, and transform data while integrating with third-party APIs. It supports robust error handling, retry logic, and response-based processing. All actions are logged via Elasticsearch for traceability.

---

## 🧱 Define

The solution is organized into modular layers for better maintainability and scalability:

### 🧩 Common

- **Mapper.GSB.Share**: Contains shared utilities, helper methods, and common classes.
- **Logging**: A shared logging service that integrates with **Elasticsearch** for centralized logging.

### 💡 Core

- **Mapper.GSB.Application**  
  - Validates incoming data.
  - Creates snapshots and persists the data as an event.
  - Publishes the initial processing event.

- **Mapper.GSB.Application.GSBAPICaller**  
  - Subscribes to events.
  - Connects to an external REST API.
  - Handles errors with retries.
  - On success, publishes a follow-up event.

- **Mapper.GSB.Application.DDRAPICaller**  
  - Subscribes to confirmation events.
  - Maps the data to another business model.
  - Sends data in a request-response manner.
  - Waits and processes the final result.

- **Mapper.GSB.Domain**: Holds domain entities and core business logic.
- **MOHME.Lib**: Utilities and libraries related to the Ministry of Health and Medical Education.

### 🌐 Gateways

- **Mapper.GSB.Host.DDRAPICaller**: Worker service hosting DDR API integration.
- **Mapper.GSB.Host.GSBAPICaller**: Worker service for GSB API integration.
- **Mapper.GSB.Rest.API**:  
  - REST API entry point.  
  - Supports API versioning.  
  - Uses custom Swagger for documentation.  
  - Sends messages/events to backend services.

### 🛠 Infrastructure

- **Mapper.GSB.Infrastructure**:  
  Manages external services like:
  - Caching
  - Messaging
  - Database access
  - Third PArty API

- **Mapper.GSB.Infrastructure.DbConfig.BI**:  
  Stores SQL scripts and database configuration files.


## 🚀 Features

- ✅ Event-driven data processing
- 🔁 Retry mechanism for API failures
- 🔁 Request-response pattern with external services
- 📄 API versioning & Swagger documentation
- 📦 Elastic logging for all services
- 🧩 Modular, clean architecture
- 🔐 Isolated infrastructure components
