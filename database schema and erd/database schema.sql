
CREATE TABLE PizzaTypes(
PizzaTypeId nvarchar(75) NOT NULL CONSTRAINT PK_PizzaTypes PRIMARY KEY,
Name nvarchar(150) NOT NULL,
Category nvarchar(75) NOT NULL,
Ingredients nvarchar(300) NOT NULL)
go


CREATE TABLE Pizzas(
PizzaId nvarchar(75) NOT NULL CONSTRAINT PK_Pizzas PRIMARY KEY,
PizzaTypeId nvarchar(75) NOT NULL,
Size nvarchar(10) NOT NULL,
Price decimal(16,2) NOT NULL,
CONSTRAINT FK_Pizzas_PizzaTypeId FOREIGN KEY (PizzaTypeId) REFERENCES PizzaTypes (PizzaTypeId))
go


CREATE TABLE Orders(
OrderId int identity(1,1) NOT NULL CONSTRAINT PK_Orders PRIMARY KEY,
Date date NOT NULL,
Time time NOT NULL)
go


CREATE TABLE OrderDetails(
OrderDetailsId int identity(1,1) NOT NULL CONSTRAINT PK_OrderDetails PRIMARY KEY,
OrderId int NOT NULL,
PizzaId nvarchar(75) NOT NULL,
Quantity int NOT NULL,
CONSTRAINT FK_OrderDetails_OrderId FOREIGN KEY (OrderId) REFERENCES Orders (OrderId),
CONSTRAINT FK_OrderDetails_PizzaId FOREIGN KEY (PizzaId) REFERENCES Pizzas (PizzaId))
go

