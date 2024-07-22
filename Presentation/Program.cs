using Application.Services.Concrete;
using Azure;
using Core.Constants;

public static class Program
{
    private static readonly GroupService _groupService;
    private static readonly StudentService _studentService;

    static Program()
    {
        _groupService = new GroupService();
        _studentService = new StudentService();

    }
    public static void Main()
    {

        Console.WriteLine("--Menu--");
        Console.WriteLine("1.Get All Group");
        Console.WriteLine("2.Get Group");
        Console.WriteLine("3.Add Group");
        Console.WriteLine("4.Update Group");
        Console.WriteLine("5.Delete Group");
        Console.WriteLine("6.Get All Students");
        Console.WriteLine("7.Get Student");
        Console.WriteLine("8.Add Student");
        Console.WriteLine("9.Update Student");
        Console.WriteLine("10.Delete Student");

        Console.WriteLine("Menyudan secim edin");
        string choiceInput = Console.ReadLine();
        int choice;
        bool isSucceeded = int.TryParse(choiceInput, out choice);
        if (isSucceeded)
        {
            switch ((Operations)choice)
            {
                case Operations.AllGroups:
                    _groupService.AddGroup();
                    break;
                case Operations.GroupById:
                    _groupService.GetGroupById();
                    break;
                case Operations.AddGroup:
                    _groupService.AddGroup();
                    break;
                case Operations.UpdateGroup:    
                    _groupService.UpdateGroup();
                    break;
                case Operations.DeleteGroup:
                        _groupService.RemoveGroup();
                    break;
                case Operations.AllStudents :
                    _studentService.GetAllStudents();
                    break;
             
                case Operations.Exit:
                    Console.WriteLine("Çıxış edildi...");
                    return;

                default:
                    Messages.InvalidInputMessage("choice");
                    break;


            }
        }
}
