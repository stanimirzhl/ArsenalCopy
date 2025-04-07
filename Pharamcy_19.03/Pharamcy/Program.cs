using Microsoft.EntityFrameworkCore;
using Pharamcy.Data;

var dbContext = new PharmacyDbContext();

/*
•	всички лекарства
•	всички лекарства с наличност под 50
•	най-скъпите 3 лекарства в аптеката
•	всички служители
•	всички поръчки от даден доставчик
•	лекарства с изчерпано количество
•	всички имена на лекари, които са писали рецепти
•	при въвеждане на лекар да се изведат имената на пациентите, на които този лекар е изписвал лекарства
•	общата стойност на всички поръчки
*/

Console.WriteLine("All medicines:");
if (!dbContext.Medicines.Any())
{
    Console.WriteLine("No medicines yet!");
    return;
}
foreach (var medicine in dbContext.Medicines)
{
    Console.WriteLine($"Medicine Name: {medicine.Name}, Manufacturer: {medicine.Manufacturer}, Price: {medicine.Price:f2}, Quantity: {medicine.QuantityInStock}");
}

Console.WriteLine("All medicine with stock under 50:");
foreach (var medicine in dbContext.Medicines.Where(x => x.QuantityInStock > 50))
{
   Console.WriteLine($"Medicine Name: {medicine.Name}, Manufacturer: {medicine.Manufacturer}, Price: {medicine.Price:f2}, Quantity: {medicine.QuantityInStock}");
}

Console.WriteLine("The 3 most expensive medicines:");
foreach (var medicine in dbContext.Medicines.OrderByDescending(x => x.Price).Take(3))
{
    Console.WriteLine($"Medicine Name: {medicine.Name}, Manufacturer: {medicine.Manufacturer}, Price: {medicine.Price:f2}, Quantity: {medicine.QuantityInStock}");
}

Console.WriteLine("All employees");
if (!dbContext.Employees.Any())
{
    Console.WriteLine("No employees"); 
    return;
}

foreach (var employee in dbContext.Employees)
{
    Console.WriteLine($"Name: {employee.Name}, Salary: {employee.Salary:f2}, Position: {employee.Position}");
}

Console.WriteLine("All orders by given supplier:");
if (!dbContext.Orders.Any())
{
    Console.WriteLine("No orders");
    return;
}
var suppliers = dbContext.Orders.Select(x => x.SupplierName).ToList();
Console.WriteLine($"Write from the given suppliers name to search all orders: {string.Join(", ", suppliers)}");
string supplier = Console.ReadLine();
if (!suppliers.Contains(supplier))
{
    Console.WriteLine("Invalid supplier");
    return;
}
foreach (var order in dbContext.Orders.Where(x => x.SupplierName == supplier).Include(x => x.Medicine).Include(x => x.Employee))
{
    Console.WriteLine($"Medicine name: {order.Medicine.Name}, Supplier name: {order.SupplierName}, Order date: {order.OrderDate.ToString("yyyy-MM-dd")}, Employee name: {order.Employee.Name}, Quantity: {order.QuantityOrdered}");
}

Console.WriteLine("Inactive medicine");
foreach (var medicine in dbContext.Medicines.Where(x => x.QuantityInStock == 0))
{
    Console.WriteLine($"Medicine Name: {medicine.Name}, Manufacturer: {medicine.Manufacturer}, Price: {medicine.Price:f2}, Quantity: {medicine.QuantityInStock}");
}

if (!dbContext.Prescriptions.Any())
{
    Console.WriteLine("No prescriptions yet!");
    return;
}
var doctorNames = dbContext.Prescriptions.Select(x => x.DoctorName).ToList();
foreach (var doctor in doctorNames)
{
    Console.WriteLine($"Doctor name: {doctor}");
}

Console.WriteLine($"Here are all the doctors, choose a name to see all patients: {string.Join(", ", doctorNames)}, must include Dr.");
string doctor2 = Console.ReadLine();
if (!doctorNames.Contains(doctor2))
{
    Console.WriteLine("No such doctor!");
    return;
}
foreach (var patient in dbContext.Prescriptions.Where(x => x.DoctorName == doctor2).Select(x => x.PatientName))
{
    Console.WriteLine($"Patient been in the specific doctor: {patient}");
}

Console.WriteLine("All the sum of all orders");
decimal price = 0;
foreach(var order in dbContext.Orders.Include(x => x.Medicine))
{
    price += order.Medicine.Price * order.QuantityOrdered;
}

Console.WriteLine($"Full price: {price:f2}");


