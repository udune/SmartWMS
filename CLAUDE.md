# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Smart WMS (Warehouse Management System) is a WPF desktop application for semiconductor materials management. It handles material CRUD operations, inbound/outbound logistics, and environmental monitoring with interlock rules.

## Build and Run Commands

```bash
# Build the project
dotnet build SmartWMS.csproj

# Run the application
dotnet run --project SmartWMS.csproj

# Clean and rebuild
dotnet clean && dotnet build
```

Output executable: `bin/Debug/net10.0-windows/SmartWMS.exe`

## Technology Stack

- **Framework**: WPF on .NET 10.0 (Windows)
- **Language**: C# with nullable reference types enabled
- **Backend**: REST API communication with ShelfSimAPI (.NET 9.0)
- **Development API URL**: `http://localhost:5109`

## Architecture

### Recommended MVVM Structure
```
Models/          - DTOs matching API contracts
ViewModels/      - View logic and state management
Views/           - XAML UI definitions
Services/        - ApiService for HTTP, SensorService for environment data
```

### Key API Endpoints
- `/api/materials` - Material CRUD operations
- `/api/materials/inbound` - Inbound operations
- `/api/materials/outbound` - Outbound operations (requires environment data)
- `/api/inventory/cells` - Cell-based inventory
- `/api/environment/config` - Environmental configuration
- `/api/jobs` - Work history and job tracking

### Environmental Interlock Rules
Outbound operations require environmental validation:
- **Temperature**: 23°C ±2°C (valid: 21-25°C)
- **Humidity**: 45% ±5% (valid: 40-50%)
- **Light**: Must be blocked (light detection = rejection)

Server returns HTTP 406 with error code `ENV_INTERLOCK` when conditions are not met.

### API Error Handling
- 200: Success
- 201: Resource created
- 400: Bad request (validate input)
- 404: Resource not found
- 406: Environment interlock violation
- 500: Server error

Error response format:
```json
{
  "error": "ENV_INTERLOCK",
  "message": "온도 조건 불충족: 30.0℃ (허용: 21~25℃)",
  "jobId": 123
}
```

## Unity Integration

This WPF client works alongside a Unity 3D visualization system:
- WPF handles: Material CRUD, inbound/outbound requests, environment monitoring
- Unity handles: Warehouse 3D visualization, robot animations
- Communication: Both poll the same API; Unity picks up jobs created by WPF
