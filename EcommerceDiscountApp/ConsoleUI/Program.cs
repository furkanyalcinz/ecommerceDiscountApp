DateTime start = DateTime.Parse("20/04/2023 17:44:18");
DateTime end = DateTime.Parse("20/04/2023 17:45:00");
DateTime currentTime = DateTime.UtcNow;


float price = 50;
int rate = 50;

var result = price * rate/100;
Console.WriteLine(result);