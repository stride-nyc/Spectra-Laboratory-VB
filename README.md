# Spectra-Laboratory
This repository contains the Spectra Lab Management System, integrating SQL Server with a Visual Basic GUI to manage medical lab operations. Developed by a multidisciplinary team, it enhances efficiency and accuracy in patient care through advanced technologies and streamlined processes.

# Database Management Information System
This project aims to design and develop a database management information system for a specific domain. 
The project will involve:
* Identifying a real-world use case for a relational database
* Defining the functional requirements for the database
* Designing the database schema
* Developing the logical specifications
* Building and populating the database
* Creating queries and views to demonstrate the database's capabilities
* Developing a graphical user interface (GUI) for user interaction

# Tools and Technologies
* Microsoft SQL Server Management System (SSMS)
* Microsoft Visual Basic (.NET)
* Microsoft Word & Excel
* ER diagramming tools: lucid.app or erdplus.com
* Online resources: Stack Overflow (www.Stackflow.com)
* Free image resources: Freepik.com
* Color scheme inspiration: colorsinspo.com

# ER Diagram
![ER Diagram](https://github.com/user-attachments/assets/7484d2be-a0dc-4467-b547-9f6a94b381a7)

# Relational Mode
![Relational Model](https://github.com/user-attachments/assets/797af1d1-4f23-4d64-ba91-6a91e3e0729d)

# Connecting to the Database
# Creating the Database from the lab3.sql file
* Create the database: Use SQL Server Management Studio (SSMS) to create a new database named lab3.
* Populate the database: Execute the SQL script lab3.sql in SSMS to populate the database with necessary tables and data.
* Connecting VB.NET to the Database
* Open database.vb: Locate the database.vb file in your project.
* Modify the connection string: Edit the sqlcon variable's value in the database module to match your SSMS server name.
* Replace "Add Your Server Name on SSMS eg: Legion-5\SQLEXPRESS" with the actual name of your server.
* Ensure the correct authentication method (Windows Authentication or SQL Server Authentication) is used.

# Example:

VB.Net
Public sqlcon As New SqlConnection("server=YOUR_SERVER_NAME;database=lab3;Integrated Security=True")

Use code with caution.

Build and run the application: Compile and run your VB.NET application.
Note: Replace YOUR_SERVER_NAME with the actual name of your SQL Server instance.

# MIT License
Copyright (c) 2024 - Mohammed Hany Gabr - Hazem Shereef

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and its associated documentation, the SQL database, and the logo, and to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
