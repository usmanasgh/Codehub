
if exists (select * from sysobjects where id = object_id('[dbo].[pGetEmployeeById]') and OBJECTPROPERTY(id, 'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[pGetEmployeeById]
GO
/******
<Object Scope='Public'> pGetEmployeeById
<Copyright> usmanasgh.com </Copyright>
<Author Company='usmanasgh'> Usman Asghar </Author>
<Create> 23102022 </Create>
<Description>  </Description>
<Parameter Direction='Input' Name='@Id'> </Parameter>
<History Author='' Date=''>  </History>
</Object>
******/
Create Procedure [dbo].pGetEmployeeById
	
@Id int
As
Begin
 Select * from Employees
 Where Id = @Id
End
GO
PRINT 'Created pGetEmployeeById'

GO

if exists (select * from sysobjects where id = object_id('[dbo].[spInsertEmployee]') and OBJECTPROPERTY(id, 'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[spInsertEmployee]
GO
/******
<Object Scope='Public'> spInsertEmployee
<Copyright> usmanasgh.com </Copyright>
<Author Company='usmanasgh'> Usman Asghar </Author>
<Create> 23102022 </Create>
<Description>  </Description>
<Parameter Direction='Input' Name='@Id'> </Parameter>
<History Author='' Date=''>  </History>
</Object>
******/
Create Procedure [dbo].spInsertEmployee
@Name nvarchar(100),
@Email nvarchar(100),
@PhotoPath nvarchar(100),
@Dept int
AS
BEGIN

 INSERT INTO Employees
       (Name, Email, PhotoPath, Department)
   VALUES (@Name, @Email, @PhotoPath, @Dept)
END
GO
PRINT 'Created spInsertEmployee'
