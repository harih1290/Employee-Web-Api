Create Procedure [dbo].[EmployeeMeta](@EmyDetails NVarchar(100),@Action Varchar(15))  
as  
Begin  
 
Declare @emp_id int,@emp_name varchar(50),@emp_salary money,@created_on datetime  
 Select @emp_id=isnull(emp_id,0),  
 @emp_name=ISNULL(emp_name,''),  
 @emp_salary=ISNULL(emp_salary,0),  
 @created_on=ISNULL(created_on,'')  
 from OpenJson(@EmyDetails) with(  
 emp_id int '$.emp_id',  
 emp_name varchar(50) '$.emp_name',  
 emp_salary money '$.emp_salary',  
 created_on datetime '$.created_on'  
 )  
IF @Action='Create'  
	BEGIN  
	 insert into Employee values(@emp_name,@emp_salary,Cast(GETDATE() as date));  
	 select 'Information Inserted Sucessfully in Employee Table!' As Response  
	END  
ELSE IF @Action='Update'  
	BEGIN   
	 update Employee set emp_name=ISNULL(@emp_name,emp_name),emp_salary=ISNULL(@emp_salary,emp_salary),created_on=ISNULL(@created_on,created_on) where emp_id=@emp_id  
	 Select  emp_name+' Information Updated Sucessfully in Employee Table !' as Response,emp_salary from employee where emp_id=@emp_id  
	END  
Else IF @Action='Delete'  
	BEGIN  
	if((select COUNT(emp_id) From Employee where emp_id=@emp_id)>0) 
    begin
		 Delete From Employee where emp_id=@emp_id  
		 Select 'Information is Removed from Employee Table' As Response,@emp_id as [Employee ID]
	End
	Else
	Begin
		Select 'No Data Available !'
	End  
	END  
ELSE IF @Action='GET'  
	BEGIN   
	 Select * from Employee  
	END  
END  