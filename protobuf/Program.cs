using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Chatroom.Protobuf.Test;

Console.WriteLine("Welcome to Protobuf test!");

var emp = new Employee();

emp.FirstName = "Sayan";
emp.LastName = "Pramanik";
emp.IsRetired = false;

var birthdate = new DateTime(2000, 2, 3);
birthdate = DateTime.SpecifyKind(birthdate, DateTimeKind.Utc);
emp.BirthDate = Timestamp.FromDateTime(birthdate);

emp.MaritalStatus = Employee.Types.MaritalStatus.Single;
emp.PreviousEmployers.Add("Cognizant Technology Solutions");
emp.PreviousEmployers.Add("Bracebridge Capital LLC");

emp.CurrentAddress = new Address();

emp.CurrentAddress.City = "New York";
emp.CurrentAddress.StreetName = "5th Ave";
emp.CurrentAddress.HouseNumber = 50;
emp.Relatives.Add("Friend", "IronMan");
emp.Relatives.Add("Fav Actor", "Robert D Jr.");

using (var output = File.Create("emp.dat"))
{
    emp.WriteTo(output);
}

Employee employeeFromFile;

using (var input = File.OpenRead("emp.dat"))
{
    employeeFromFile = Employee.Parser.ParseFrom(input);
}

Console.WriteLine("Protobuf test complete");