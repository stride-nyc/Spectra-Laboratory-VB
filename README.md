# ![Lab logo](https://github.com/user-attachments/assets/be518450-f038-4c09-b6a8-4a48fb35422c)
**The Spectra Lab Management System, integrates SQL Server with a Visual Basic GUI to manage medical lab operations. Developed by a multidisciplinary team, it enhances efficiency and accuracy in patient care through advanced technologies and streamlined processes.**

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

# Connecting to the Database
## **Creating the Database from the lab3.sql file**
* Create the database: Use SQL Server Management Studio (SSMS) to create a new database named lab3.
* Populate the database: Execute the SQL script lab3.sql in SSMS to populate the database with necessary tables and data.
* Connecting VB.NET to the Database
* Open database.vb: Locate the database.vb file in your project.
* Modify the connection string: Edit the sqlcon variable's value in the database module to match your SSMS server name.
* Replace "Add Your Server Name on SSMS eg: Legion-5\SQLEXPRESS" with the actual name of your server.
* Ensure the correct authentication method (Windows Authentication or SQL Server Authentication) is used.

### **Example:**
```.Net
Public sqlcon As New SqlConnection("server=YOUR_SERVER_NAME;database=lab3;Integrated Security=True")
```
 _Use code with caution._

* Build and run the application: Compile and run your VB.NET application.
* Note: Replace YOUR_SERVER_NAME with the actual name of your SQL Server instance.

# Visuals:
## **Database Schema Visualization**

### ER Diagram
![ER Diagram](https://github.com/user-attachments/assets/7484d2be-a0dc-4467-b547-9f6a94b381a7)

### Relational Model
![Relational Model](https://github.com/user-attachments/assets/797af1d1-4f23-4d64-ba91-6a91e3e0729d)

## **GUI Interface Design**

### Login Page
![image](https://github.com/user-attachments/assets/1fd4666c-8f9f-465c-b2c8-2adc2e365b4c)

### Admin Page
![Admin Page](https://github.com/user-attachments/assets/6ff5af36-b7fe-4f77-9d32-dc8306e4cbe1)

### Staff Data Display Page
![image](https://github.com/user-attachments/assets/ace96f0a-d57e-43b6-95e1-6388481d8e22)

### User Login Page
![image](https://github.com/user-attachments/assets/be2fc4cd-4082-4bbe-8842-97976aaee185)

### User Test Results Page using Request ID
![image](https://github.com/user-attachments/assets/7846bc05-08b1-4c19-9cb7-d4d9003219f1)



# License Agreement

This project is licensed under the License Agreement. See the [LICENSE.md](LICENSE.md) file for details.

