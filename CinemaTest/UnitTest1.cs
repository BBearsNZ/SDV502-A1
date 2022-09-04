namespace CinemaAppTests
{
    [TestFixture]
    public class TestingTicketPriceController
    {
        [TestCase(1, "Adult", "Monday", 4, 14.50)]
        [TestCase(2, "Adult", "Monday", 4, 29.00)]
        [TestCase(0, "Adult", "Monday", 4, -1)]
        [TestCase(1, "Student", "Monday", 4, -1)]
        [TestCase(1, "Adult", "Tuesday", 4, -1)]
        [TestCase(1, "Adult", "Monday", 6, -1)]
        public void Testing_Adult_Before_5(int quantity, string person, string day, decimal time, decimal expected)
        {
            TicketPriceController TPC = new TicketPriceController();



            decimal price = TPC.Adult_Before_5(quantity, person, day, time);



            Assert.That(price == expected);
        }

    }
}