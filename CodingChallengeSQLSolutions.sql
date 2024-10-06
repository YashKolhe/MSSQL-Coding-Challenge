create database [Coding Challenge - Car Rental System – SQL]
use [Coding Challenge - Car Rental System – SQL]

create table Vehicle (
 vehicleID int Primary Key ,
 make varchar(30),
 model varchar(30),
 year int,
 dailyRate decimal(10,2),
 status varchar(30) check(status in ('available', 'notAvailable')), 
 passengerCapacity  int,
 engineCapacity int)

 insert into Vehicle 
 values 
 (1, 'Toyota', 'Camry', 2022, 50.00, 'available' ,4, 1450), 
(2, 'Honda' ,'Civic', 2023, 45.00, 'available', 7, 1500), 
(3 ,'Ford' ,'Focus' ,2022, 48.00, 'notAvailable', 4, 1400 ),
(4, 'Nissan', 'Altima', 2023, 52.00, 'available', 7, 1200), 
(5, 'Chevrolet','Malibu' ,2022 ,47.00 ,'available', 4, 1800), 
(6 ,'Hyundai', 'Sonata', 2023, 49.00, 'notAvailable', 7, 1400 ),
(7 ,'BMW 3' ,'Series' ,2023 ,60.00 ,'available' ,7 ,2499 ),
(8 ,'Mercedes' ,'C-Class' ,2022 ,58.00 ,'available' ,8 ,2599), 
(9, 'Audi', 'A4', 2022, 55.00, 'notAvailable', 4, 2500), 
(10 ,'Lexus' ,'ES' ,2023 ,54.00 ,'available' ,4 ,2500)

create table Customer (
 customerID int Primary Key, 
 firstName varchar(30),
 lastName varchar(30),
 email varchar(30),
 phoneNumber varchar(30))

 insert into Customer 
 values
 (1, 'John', 'Doe', 'johndoe@example.com','555-555-5555'), 
(2 ,'Jane' ,'Smith' ,'janesmith@example.com' ,'555-123-4567'), 
(3, 'Robert', 'Johnson', 'robert@example.com', '555-789-1234'), 
(4 ,'Sarah' ,'Brown' ,'sarah@example.com' ,'555-456-7890'), 
(5 ,'David' ,'Lee' ,'david@example.com' ,'555-987-6543'), 
(6, 'Laura', 'Hall', 'laura@example.com','555-234-5678'), 
(7 ,'Michael' ,'Davis' ,'michael@example.com' ,'555-876-5432'), 
(8 ,'Emma' ,'Wilson' ,'emma@example.com' ,'555-432-1098'), 
(9, 'William', 'Taylor', 'william@example.com', '555-321-6547'), 
(10 ,'Olivia' ,'Adams' ,'olivia@example.com' ,'555-765-4321')

create table Lease(
 leaseID int Primary Key, 
 vehicleID int Foreign Key references Vehicle (vehicleID), 
 customerID int Foreign Key references Customer (customerID), 
 startDate date,
 endDate date,
 type varchar(20) check(type in('DailyLease','MonthlyLease')))

 insert into Lease
 values
( 1, 1, 1, '2023-01-01', '2023-01-05', 'DailyLease'), 
(2, 2, 2, '2023-02-15', '2023-02-28', 'MonthlyLease'),  
(3, 3, 3, '2023-03-10', '2023-03-15', 'DailyLease'),  
(4, 4, 4, '2023-04-20', '2023-04-30', 'MonthlyLease'),  
(5, 5, 5, '2023-05-05', '2023-05-10', 'DailyLease'),  
(6, 4, 3, '2023-06-15', '2023-06-30', 'MonthlyLease'),  
(7, 7, 7, '2023-07-01', '2023-07-10', 'DailyLease'),  
(8, 8, 8, '2023-08-12', '2023-08-15', 'MonthlyLease'),  
(9, 3, 3, '2023-09-07', '2023-09-10' ,'DailyLease'),  
(10, 10,10, '2023-10-10', '2023-10-31', 'MonthlyLease')

create table Payment( 
 paymentID int Primary Key, 
 leaseID int Foreign Key references Lease (leaseID), 
 paymentDate date,
 amount int)

 insert into Payment
 values
 (1, 1, '2023-01-03', 200), 
(2 ,2 ,'2023-02-20' ,1000), 
(3 ,3 ,'2023-03-12' ,75), 
(4, 4,  '2023-04-25',900),  
(5, 5, '2023-05-07',60), 
(6, 6, '2023-06-18',1200), 
(7, 7, '2023-07-03',40), 
(8 ,8, '2023-08-14',1100), 
(9, 9, '2023-09-09' ,80),
(10,  10, '2023-10-25',1500) 

--Q 1. Update the daily rate for a Mercedes car to 68. 
update Vehicle
set dailyRate = 68.00
where make = 'Mercedes'
select * from Vehicle

--Q2. Delete a specific customer and all associated leases and payments. 
delete from Payment
where leaseID in (select leaseID from Lease where customerID = 3)
delete from Lease
where customerID = 3
delete from Customer
where customerID = 3

--3. Rename the "paymentDate" column in the Payment table to "transactionDate". 
exec sp_rename 'Payment.paymentDate', 'transactionDate', 'column'
select* from Payment

--Q4. Find a specific customer by email. 
select *
from Customer
where email = 'laura@example.com'

--5. Get active leases for a specific customer. 
select c.customerID,l.leaseID,c.firstName,l.type
from Customer as c
join Lease as l on c.customerID = l.customerID and endDate > getdate()
where c.customerID = 1

--6. Find all payments made by a customer with a specific phone number. 
select c.customerID,c.firstName,c.phoneNumber
from Customer as c
join Lease as l on c.customerID=l.customerID
join Payment as p on p.leaseID = l.leaseID
where c.customerID =5 

--Q7. Calculate the average daily rate of all available cars. 
select avg(dailyRate) as AverageDailyRate
from Vehicle
where status = 'available'

--8. Find the car with the highest daily rate. 
select top 1 *
from Vehicle
order by dailyRate desc

--9. Retrieve all cars leased by a specific customer. 
select v.*
from Vehicle v
join Lease l on v.vehicleID = l.vehicleID
join Customer c on l.customerID = c.customerID
where c.customerID = 2

--10. Find the details of the most recent lease. 
select top 1 *
from Lease
order by endDate desc

--11. List all payments made in the year 2023. 
select *
from payment
where year(transactionDate) = 2023

--12. Retrieve customers who have not made any payments. 
select c.*
from Customer as c
left join lease as l on c.customerID=l.customerID
left join Payment as p on l.leaseID=p.leaseID
where p.paymentID is null

--13. Retrieve Car Details and Their Total Payments. 
select v.vehicleID,v.make,v.model,v.passengerCapacity,v.engineCapacity,sum(p.amount) as totalpayment
from Vehicle as v
left join Lease as l on v.vehicleID = l.leaseID
left join Payment as p on l.leaseID = p. leaseID
group by  v.vehicleID,v.make,v.model,v.passengerCapacity,v.engineCapacity

 --14. Calculate Total Payments for Each Customer. 
select c.customerID,c.firstName,c.lastName,sum(p.amount) isnull(sum(p.amount),'No Lease')
from Customer as c
left join Lease as l on c.customerID = l.customerID
left join Payment as p on l.leaseID = p.leaseID
group by c.customerID,c.firstName,c.lastName

--15. List Car Details for Each Lease. 
select l.leaseID,v.vehicleID,v.make,v.model,v.passengerCapacity,v.engineCapacity
from Lease as l
left join Vehicle as v on l.vehicleID=v.vehicleID

--16. Retrieve Details of Active Leases with Customer and Car Information. 
select l.leaseID,l.startDate,l.endDate,c.customerID,c.firstName,c.lastName,v.vehicleID,v.make,v.model,v.year,v.dailyRate
from Lease l
join Customer c on l.customerID = c.customerID
join Vehicle v on l.vehicleID = v.vehicleID
where l.endDate > getdate()

--17. Find the Customer Who Has Spent the Most on Leases. 
select top 1 c.*
from Customer as c
join Lease as l on c.customerID = l.customerID
join Payment as p on l.leaseID = p.leaseID
order by p.amount desc

--18. List All Cars with Their Current Lease Information. 
select v.vehicleID,v.make,v.model,v.year,v.dailyRate,l.leaseID,l.startDate,l.endDate,c.customerID,c.firstName,c.lastName
from Vehicle v
left join Lease l on v.vehicleID = l.vehicleID AND l.endDate > getdate() 
left join Customer c on l.customerID = c.customerID