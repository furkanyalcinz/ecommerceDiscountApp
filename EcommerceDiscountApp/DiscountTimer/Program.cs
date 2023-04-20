

DiscountService discountService = new DiscountService();
PeriodicTimer periodicTimer = new PeriodicTimer(TimeSpan.FromMinutes(10));
while (await periodicTimer.WaitForNextTickAsync())
{
        Console.WriteLine(DateTime.Now.ToString());
}
