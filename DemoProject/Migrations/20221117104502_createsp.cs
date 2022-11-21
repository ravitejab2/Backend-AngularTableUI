using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoProject.Migrations
{
    public partial class createsp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp1 = @"create Procedure [dbo].[AddorEditPatient]
                    @id int=0,
                    @firstName nvarchar(50),
                    @lastName nvarchar(50),
					@gender nvarchar(10),
					@dob date,
					@joiningDate date
                    As
                    Begin
	                    if(@id=0)
	                        Begin
		                     Insert into Patients values(@firstName,@lastName,@gender,@dob,@joiningDate)
		
	                        End
	                    else
	                    Begin                   
	                	update Patients set FirstName=@firstName,LastName=@lastName,Gender=@gender,BirthDate=@dob,JoiningDate=@joiningDate
		                where PatientId=@id
	                    End
                        END";
            var sp2 = @"Create Procedure[dbo].[DeletePatient]
            @id int

             As
                     Begin

                            Delete from Patients where PatientId = @id

                        End";

            var sp3 = @"create Procedure [dbo].[GetAllPatients]              
                         As
                         Begin              
		                        Select * from Patients 
	                        End";


            var sp4 = @"Create Procedure [dbo].[GetPatientById]
                    @id int
                    
                     As
                     Begin
	                 
		                    Select * from Patients where PatientId=@id
	                    End";
            migrationBuilder.Sql(sp2);
            migrationBuilder.Sql(sp1);
            migrationBuilder.Sql(sp3);
            migrationBuilder.Sql(sp4);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
