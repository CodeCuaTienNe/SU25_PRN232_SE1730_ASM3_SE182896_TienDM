using Grpc.Net.Client;
using DNATestingSystem.GrpcService.TienDM.Protos;
using System;
using System.Threading.Tasks;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("=== gRPC Client for AppointmentsTienDm ===");

// Create a gRPC channel
using var channel = GrpcChannel.ForAddress("https://localhost:7238"); // Adjust port as needed
var client = new AppointmentsTienDmGRPC.AppointmentsTienDmGRPCClient(channel);

try
{
    // Test GetAllAsync
    Console.WriteLine("\n--- Testing GetAllAsync ---");
    var getAllResponse = await client.GetAllAsyncAsync(new EmptyRequest());
    Console.WriteLine($"Found {getAllResponse.Appointments.Count} appointments");

    foreach (var appointment in getAllResponse.Appointments)
    {
        Console.WriteLine($"ID: {appointment.AppointmentsTienDmid}, Phone: {appointment.ContactPhone}, Amount: {appointment.TotalAmount}");
    }

    // Test GetByIdAsync
    Console.WriteLine("\n--- Testing GetByIdAsync ---");
    if (getAllResponse.Appointments.Count > 0)
    {
        var firstId = getAllResponse.Appointments[0].AppointmentsTienDmid;
        var getByIdResponse = await client.GetByIdAsyncAsync(new GetByIdRequest { AppointmentsTienDmid = firstId });
        Console.WriteLine($"Retrieved appointment: ID={getByIdResponse.AppointmentsTienDmid}, Phone={getByIdResponse.ContactPhone}");
    }
    else
    {
        Console.WriteLine("No appointments found to test GetByIdAsync");
    }

    // Test CreateAsync
    Console.WriteLine("\n--- Testing CreateAsync ---");
    var newAppointment = new AppointmentsTienDm
    {
        AppointmentsTienDmid = 0, // Will be auto-generated
        UserAccountId = 1,
        ServicesNhanVtid = 1,
        AppointmentStatusesTienDmid = 1,
        AppointmentDate = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd"),
        AppointmentTime = DateTime.Now.AddHours(2).ToString("HH:mm:ss"),
        SamplingMethod = "Home Visit",
        Address = "123 Test Street, Test City",
        ContactPhone = "+1234567890",
        Notes = "Test appointment created via gRPC client",
        CreatedDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
        ModifiedDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
        TotalAmount = 299.99,
        IsPaid = false
    };

    var createResponse = await client.CreateAsyncAsync(newAppointment);
    Console.WriteLine($"Created appointment with result: {createResponse.Result}");

    // Test UpdateAsync
    if (createResponse.Result > 0)
    {
        Console.WriteLine("\n--- Testing UpdateAsync ---");
        newAppointment.AppointmentsTienDmid = createResponse.Result;
        newAppointment.Notes = "Updated via gRPC client";
        newAppointment.TotalAmount = 399.99;
        newAppointment.ModifiedDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

        var updateResponse = await client.UpdateAsyncAsync(newAppointment);
        Console.WriteLine($"Updated appointment with result: {updateResponse.Result}");
    }

    // Test DeleteAsync (Optional - uncomment if you want to test deletion)
    /*
    if (createResponse.Result > 0)
    {
        Console.WriteLine("\n--- Testing DeleteAsync ---");
        var deleteResponse = await client.DeleteAsyncAsync(new DeleteRequest { Id = createResponse.Result });
        Console.WriteLine($"Deleted appointment with result: {deleteResponse.Result}");
    }
    */

    Console.WriteLine("\n=== All tests completed successfully! ===");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    if (ex.InnerException != null)
    {
        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
    }
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
