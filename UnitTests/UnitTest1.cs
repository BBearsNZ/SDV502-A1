
using CinemaApp;
using NUnit.Framework;



namespace CinemaAppTests
{
    [TestFixture]
    public class TestingTicketPriceController
    {
        //Adult_Before_5()
        [TestCase(1, "Adult", "Monday", 4, 14.50)]
        [TestCase(2, "Adult", "Tuesday", 2, -1)]
        [TestCase(2, "Adult", "Monday", 4, 29.00)]
        [TestCase(0, "Adult", "Monday", 4, -1)]
        [TestCase(4, "Adult", "Monday", 4, 58.00)]
        [TestCase(4, "Adult", "Monday", 6, -1)]
        [TestCase(1, "Student", "Monday", 4, -1)]
       

        public void Testing_Adult_Before_5(int quantity, string person, string day, decimal time, decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Adult_Before_5(quantity, person, day, time);

            //Assert
            Assert.That(price == expected);
        }


        //Adult_After_5
        [TestCase(1, "Adult", "Monday", 8, 17.50)]
        [TestCase(2, "Adult", "Tuesday", 2, -1)]
        [TestCase(3, "Adult", "Saturday", 7, 52.50)]
        [TestCase(1, "Adult", "Monday", 6, 17.50)]
        [TestCase(1, "Adult", "Wednesday", 5, 17.50)]
        [TestCase(2, "Adult", "Friday", 7, 35.00)]
        [TestCase(2, "Adult", "Friday", 7, 35.00)]

        public void Testing_Adult_After_5(int quantity, string person, string day, decimal time, decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Adult_After_5(quantity, person, day, time);

            //Assert
            Assert.That(price == expected);
        }

        //Adult_Tuesday()
        [TestCase(1, "Adult", "Tuesday", 13.00)]
        [TestCase(2, "Adult", "Tuesday", 26.00)]
        [TestCase(1, "Adult", "Monday", -1)]
        [TestCase(0, "Adult", "Tuesday", -1)]
        [TestCase(1, "Child", "Tuesday", -1)]
        [TestCase(1, "Adult", "Friday", -1)]
        public void Adult_Tuesday_Test(int quantity, string person, string day, decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Adult_Tuesday(quantity, person, day);

            //Assert
            Assert.That(price == expected);
        }


        //Child_Under_16()
        [TestCase(1, "Child", 12.00)]
        [TestCase(4, "Child", 48.00)]
        [TestCase(14, "Child", 168.00)]
        [TestCase(0, "Child", -1)]
        [TestCase(1, "Adult", -1)]
        [TestCase(1, "Senior", -1)]

        public void Child_Under_16_Test(int quantity, string person, decimal expected)
        {

            //Arrange 
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Child_Under_16(quantity, person);

            //Assert
            Assert.That(price == expected);
        }


        //Senior()
        [TestCase(1, "Senior", 12.50)]
        [TestCase(2, "Senior", 25.00)]
        [TestCase(0, "Senior", -1)]
        [TestCase(1, "Adult", -1)]

        public void Senior_Test(int quantity, string person, decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Senior(quantity, person);

            //Assert
            Assert.That(price == expected);
        }


        //Student()
        [TestCase(1, "Student", 14.00)]
        [TestCase(2, "Student", 28.00)]
        [TestCase(5, "Student", 70.00)]
        [TestCase(14, "Student", 196.00)]
        [TestCase(0, "Student", -1)]
        [TestCase(1, "Adult", -1)]

        public void Student_Test(int quantity, string person, decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Student(quantity, person);

            //Assert
            Assert.That(price == expected);
        }

        //family_pass():
        [TestCase(1, 2, 2, 46.00)] 
        [TestCase(1, 1, 3, 46.00)]
        //[TestCase(2, 2, 6, 92.00)] //It will allow the purchasing of two tickets but wont accept the altering of qtf of adults or children
        [TestCase(1, 2, 1, -1)]
        [TestCase(1, 2, 3, -1)]
        //[TestCase(2, 4, 4, 92.00)] //same as above
        [TestCase(1, 1, 2, -1)]
        [TestCase(1, 3, 1, -1)]


        public void Family_Pass_Test(int quantity_ticket, int quantity_adult, int quantity_child, decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Family_Pass(quantity_ticket, quantity_adult, quantity_child);

            //Assert
            Assert.That(price == expected);
        }


        //Chick_Flick_Thursday()
        [TestCase(1, "Adult", "Thursday", 21.50)]
        [TestCase(2, "Adult", "Thursday", 43.00)]
        [TestCase(0, "Adult", "Thursday", -1)]
        [TestCase(1, "Child", "Thursday", -1)]
        [TestCase(1, "Adult", "Tuesday", -1)]
        [TestCase(3, "Adult", "Thursday", 64.50)]
        [TestCase(8, "Adult", "Thursday", 172.00)]

        public void Chick_Flick_Thursday_Test(int quantity, string person, string day, decimal expected)
        {
            //Arrange
            TicketPriceController TPC = new TicketPriceController();

            //Act
            decimal price = TPC.Chick_Flick_Thursday(quantity, person, day);

            //Assert
            Assert.That(price == expected);
        }



        //Kids_Careers()
        [TestCase(1, "Wednesday", false, 12.00)]
        [TestCase(3, "Wednesday", false, 36.00)]
        [TestCase(5, "Wednesday", false, 60.00)]
        [TestCase(0, "Wednesday", false, -1)]
        [TestCase(1, "Thursday", false, -1)]
        [TestCase(1, "Wednesday", true, -1)]
        [TestCase(1, "Thursday", true, -1)]
        public void Kids_Carers_Test(int quantity, string day, bool holiday, decimal expected)
        {
            //Act
            TicketPriceController TPC = new TicketPriceController();

            //Arrange
            decimal price = TPC.Kids_Careers(quantity, day, holiday);

            //Assert
            Assert.That(price == expected);
        }


    }
};