# EclipsePOS
Point of Sales for Retail and Restaurants ( C#, pos for .net)


How to configure and use EclipsePOS

This article describes how to configure and use EclipsePOS point of sales system. Below you will find an overview of the topics.
•	Introduction
•	Prerequisites
•	How to install
•	Creating the Store database
•	Exploring with demo data
•	Completing the configuration
•	Connecting POS peripherals
•	Receipt print layout
•	POS parameters that you may want to change
•	Data synchronization in a multi store setups



Introduction
Operational benefits
EclipsePOS point of sales solution is a highly configurable, event driven, transaction recording system suitable for single or multiple store operation. It can be configured for a retail or restaurant operation.
It's modern, intuitive user interface is suitable for touch enabled modern monitors. It can also be operated with PC keyboard keys for faster data entry. 
EclipsePOS was designed from the ground up to make use of the strength of ERP system.  Integration into Sage ERP Accpac 6.0 is built into EclipsePOS system. Accpac master data can be imported into EclipsePOS and EclipsePOS invoices can be export into accpac's shipments entry.

Technical highlights
EclipsePOS is entirely developed using C#, .Net 3.5 and WPF. It has a modular and extensible architecture. User interface is very much decoupled from processing logic and can be changed very quickly. 
Microsoft SQL server express edition is used as the store's transaction recording database.  
In a networked setup, data upload and download facility is provided using Microsoft Sync Framework v2.1.    

Prerequisites
You can download and install following prerequisites before or after installation of EclipsePOS.
1. Microsoft SQL Express edition of your choice (2005, 2008 32 bit, or 2008 64 bit)
2. Microsoft POS for .Net V1.12 (Install this API before connection pos peripherals such as receipt printer, line display, scanner etc.)
3. Microsoft sync framework 2.1 (Install this API when you have more than one EclipsePOS installations and you want to synchronize data between the installations).

How to install
EclipsePOS.exe setup program can be downloaded from following URL.
http://www.eclipsesoftware.com.sg/Download.htm
Run the EclipsePOS.exe setup program and follow the standard setup instructions displayed on the screen.
When asked to 'Choose server or client setup' do the following:-
For standalone point of sales system, choose install System manager and POS workbench.
For networked setups, if you are configuring the head office EclipsePOS server then choose Install System Manager only.

Creating the Store database
Before configuring EclipsePOS you need to download and install Microsoft SQL Server.  An express edition of Microsoft SQL server can be downloaded freely from Microsoft web site.
After installing the MS SQL server, you can to create the store's database.
Run the EclipsePOS system manger and choose 'Store Data Source' tab.
Click the 'Create a New Database' button. Fill the SQL server parameters needed. For first time users, we recommend that you leave the 'Create sample data' choice box clicked.
Click the Run button to create the store's database with sample data.

Exploring with demo data
If you have chosen to create sample data you can explore the EclipsePOS system very quickly.
Run the EclipsePOS system manager and choose the 'Store Organization' Tab.
Click the 'Startup Settings' button.
Login to the system with user name 'admin' and password 'admin'.
If you want to configure EclipsePOS for retail operations then choose following parameters:- 
•	Organization		:	 1 -Eclipse Retail
•	Store			:	 2 - Eclipse Retail
•	Station			:	105 - Station A
•	Configuration		:	1- Retail
•	Print receipt immediate	:	True
•	Debug mode		:	Yes
Click save button to save the setting and quit the System manager.
If you want to configure EclipsePOS for restaurant operation then choose following parameters:- 
•	Organization		:	 12  -Eclipse Restaurants 
•	Store			:	 20 - Eclipse Restaurant
•	Station			:	125 - Counter 01
•	Configuration		:	2- Restaurants
•	Print receipt immediate	:	false
•	Debug mode		:	Yes
Click save button to save the setting and quit the System manager.

Now, you can run the EclipsePOS workbench and start entering transaction in the demonstration company.
Retail sample data has an employee with login id of '100' and a password '100'.
Restaurant sample data has an employee with login id of '200' and a password '200'.
Use above employee login ids to login into POS Workbench.
 

Completing the configuration
If you are setting up a new organization, you need to complete following steps.
Run the System Manager and choose the 'Store Organization' tab.
•	Add an Organization and Set it as your default organization in Startup settings.
•	Add a Store Location and set it as your default store.
•	Add a Station and set it as your default station.
Choose 'Store operations' tab and setup the following:-
•	Employee roles
•	Employee ( Without employees you can't login to the pos workbench)
•	Tax groups and rates
•	Table groups and Table setup for restaurant setups if table prompting is enabled.
Choose 'Inventory' tab and setup item list.
•	Setup items and Prices 
Other setup options are optional and you can configure it whenever necessary.

Connecting POS peripherals
Before connection pos hardware, you need to install Microsoft POS for .Net V1.12. You can download it free from Microsoft web site.
You also need to install .Net or OPOS driver supplied by the hardware manufacture. Most of the leading pos peripherals manufacturers make these drivers available at no cost from their web sites. 
After the driver is installed use the setup program to define a Logical Device Name.  Once it is done EclipsePOS will automatically detect the hardware.
Following pos hardware are supported.
Pos Printer
Line Display
Cash Drawer
MSR
Scanner

Receipt print layout
1. Receipt Heading
Receipt header text is taken from Store location data. You can change the store name and address from EclipsePOS System Manager.
2. Receipt Header Message
Promotional or any other text can be printed after header text.  You can change these texts from parameter setup 
Change following pos parameter values:
ReceiptTopMOD1
ReceiptTopMOD2
ReceiptTopMOD3
ReciptTopMOD4
If these values are blanks then nothing is printed.
3. Tax Line
You can change the text for tax line from pos parameters
Change the 'TaxIncludedText' pos parameter.  
4. Item Count Text
Change the 'TotalItemCountText' pos parameter value.
5. Transaction number and Station number text
Change the 'TrxNo' and 'PosNo' pos parameter values.
6. Receipt trailer message
Change the 'ReceiptBottomMOD' pos parameter value.

POS parameters that you may want to change
All text literals displayed in POS workbench can be changed.
Run System Manager and choose 'Workbench Configurations' tab. Click the parameters button to display pos parameter maintenance view.
Change these parameter values and save it to suite your operation.
You can also disable cash back prompt and Table number entry prompts.

Data synchronization in a multi store setups
Before stating the data sync options you need to install Microsoft Sync Framework 2.1 API in client and server computers.
EclipsePOS data sync server can be started within System Manger. You may have to run the system manager with administrative privileges, otherwise data sync web services server may not start successfully.   Data synchronization options are in 'Network Configuration' tab of System Manager.
Ideally, remote EclipsePOS host should synchronize data with the Server in following order at least for the first run.
•	Download only  the master data 
•	Set Default startup settings in 'Store organization' tab
•	Enter transactions and Upload transaction data
•	Resolve any sync data conflicts if any

