# Task Manager using DevExpress WinForms Data Grid and .NET Core Service

## Prerequisites

- [Visual Studio 2022 v17.0+](https://visualstudio.microsoft.com/vs/)
- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download/dotnet)
- [DevExpress](https://www.devexpress.com/): Used to enhance the user interface with advanced controls. Ensure you have an active DevExpress license or use the trial version. 

## Getting Started

1. Open *TaskManagerApp.sln*.
2. Restore NuGet packages in the solution. the solution:

<p align="left">
  <img src="https://github.com/user-attachments/assets/cccf3cc8-351c-4fa7-89f6-92b15390371f" alt="Task Manager App Solution" width="600">
</p>
3. Run the TaskManager.View and TaskManager.ViewModel projects. Right-click each project in Solution Explorer and select Start to launch a new instance for both.

<p align="left">
  <img src="https://github.com/user-attachments/assets/7c67a7c4-0f4a-40fb-a4cf-da243a170b66" alt="Running Task Manager Projects" width="600">
</p>

  <p align="left">
    https://github.com/user-attachments/assets/466c0bce-95ad-4e22-9cfc-7e82d05903cd
  </p>
4. You can navigate to the end of the data list in the grid. Sorting and filtering are available by clicking on the column headers and using the filters. In the Visual Studio Output tool window, you can monitor the load status of both running processes. The image below illustrates the results

 
https://github.com/user-attachments/assets/688b2278-e3ce-4bbe-bf71-29dc18749052


## The Backend: An ASP.NET Core WebAPI service using ADO.NET </h1>
The backend project was created using the standard ASP.NET Core Web API template, and it includes different endpoints to handle requests in the service

## The Frontend: A Windows Forms app with a DevExpress Data Grid

In the MainForm of the Windows Forms application, the DevExpress GridControl is bound to a VirtualServerModeSource instance. The VirtualServerModeSource handles two events to fetch data:

ConfigurationChanged: Triggered when the grid's runtime configuration changes, like when a user clicks a column header to sort.
MoreRows: Triggered when data is initially fetched and more rows are available, prompting the grid to load additional rows as the user scrolls to the bottom.
## **CRUD Operations Status**
✔️ Implementation ready for:  
- [x] **Insert (Create)**
- [x] **Read (Retrieve)**
- [x] **Update**
- [x] **Delete**
