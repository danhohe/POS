namespace TrainManagerTests;

/// <summary>
///This is a test class for TrainTest and is intended
///to contain all TrainTest Unit Tests
///</summary>
[TestClass()]
public class TrainTest
{


    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
        get
        {
            return testContextInstance;
        }
        set
        {
            testContextInstance = value;
        }
    }

    #region Additional test attributes
    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize(TestContext testContext)
    //{
    //}
    //
    //Use ClassCleanup to run code after all tests in a class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
    //
    //Use TestInitialize to run code before running each test
    //[TestInitialize()]
    //public void MyTestInitialize()
    //{
    //}
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion

    /// <summary>
    ///A test for AddCarriage
    ///</summary>
    [TestMethod()]
    public void T01_AddCarriageSimpleTest()
    {
        Train train = new Train(500);
        Carriage newPCar1 = new PassengerCar(60, 11121111, 50, 10);
        Carriage newPCar2 = new PassengerCar(50, 12121112, 50, 10);
        Carriage newPCar3 = new PassengerCar(40, 13121113, 50, 10);
        Carriage newPCar4 = new PassengerCar(40, 14121114, 40, 10);
        Carriage newPCar5 = new PassengerCar(40, 15121115, 30, 10);
        Assert.AreEqual(true, train.AddCarriage(newPCar3), "Gültiger Wagon 3 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(true, train.AddCarriage(newPCar2), "Gültiger Wagon 2 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(true, train.AddCarriage(newPCar5), "Gültiger Wagon 5 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(true, train.AddCarriage(newPCar1), "Gültiger Wagon 1 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(true, train.AddCarriage(newPCar4), "Gültiger Wagon 4 hinzugefügt! Sollte true liefern!");
    }

    /// <summary>
    ///A test for AddCarriage
    ///</summary>
    [TestMethod()]
    public void T02_AddCarriageSpecialTest()
    {
        Train train = new Train(500);
        Carriage newCar = new PassengerCar(50, 11121111, 50, 10);
        Assert.AreEqual(true, train.AddCarriage(newCar), "Gültiger Wagon hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(train.CarriageList.Count, 1, "Nach einem hinzugefügten Wagon sollte einer in der Liste sein!");
        Assert.AreEqual(false, train.AddCarriage(new PassengerCar(490, 11121111, 100, 10)), "Subtest1: Zuggesamtgewicht überschritten! Einfügen nicht möglich!");

        train = new Train(500);
        Assert.AreEqual(false, train.AddCarriage(new PassengerCar(495, 11121111, 100, 10)), "Subtest2: Zuggesamtgewicht überschritten! Einfügen nicht möglich!");
    }

    /// <summary>
    ///A test for AddCarriage
    ///</summary>
    [TestMethod()]
    public void T03_AddCarriageSortedTest()
    {
        Train train = new Train(500);
        Carriage newPCar1 = new PassengerCar(60, 11121111, 50, 10);
        Carriage newCCar2 = new CargoCar(50, 12121112, 2, 10);
        Carriage newPCar3 = new PassengerCar(40, 13121113, 50, 10);
        Carriage newPCar4 = new PassengerCar(40, 14121114, 40, 10);
        Carriage newPCar5 = new PassengerCar(40, 15121115, 30, 10);
        Assert.AreEqual(true, train.AddCarriage(newPCar3), "Gültiger Wagon 3 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(true, train.AddCarriage(newCCar2), "Gültiger Wagon 2 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(true, train.AddCarriage(newPCar5), "Gültiger Wagon 5 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(true, train.AddCarriage(newPCar1), "Gültiger Wagon 1 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(true, train.AddCarriage(newPCar4), "Gültiger Wagon 4 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(newPCar1, train.CarriageList[0], "Wagen1 sollte an 1. Stelle stehen!");
        Assert.AreEqual(newCCar2, train.CarriageList[1], "Wagen2 sollte an 2. Stelle stehen!");
        Assert.AreEqual(newPCar3, train.CarriageList[2], "Wagen3 sollte an 3. Stelle stehen!");
        Assert.AreEqual(newPCar4, train.CarriageList[3], "Wagen4 sollte an 4. Stelle stehen!");
        Assert.AreEqual(newPCar5, train.CarriageList[4], "Wagen5 sollte an 5. Stelle stehen!");
        Carriage newCCar1_5 = new CargoCar(50, 16121116, 3, 10);
        Carriage newCCar2_5 = new CargoCar(50, 17121117, 1, 10);
        Assert.AreEqual(true, train.AddCarriage(newCCar1_5), "Gültiger Wagon 1_5 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(true, train.AddCarriage(newCCar2_5), "Gültiger Wagon 2_5 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(newPCar1, train.CarriageList[0], "Wagen1 sollte an 1. Stelle stehen!");
        Assert.AreEqual(newCCar1_5, train.CarriageList[1], "Wagen 1_5 sollte an 2. Stelle stehen!");
        Assert.AreEqual(newCCar2, train.CarriageList[2], "Wagen2 sollte an 3. Stelle stehen!");
        Assert.AreEqual(newCCar2_5, train.CarriageList[3], "Wagen2_5 sollte an 4. Stelle stehen!");
        Assert.AreEqual(newPCar5, train.CarriageList[6], "Wagen1 sollte an 7. Stelle stehen!");
    }


    /// <summary>
    ///A test for CountOfPassengerCars
    ///</summary>
    [TestMethod()]
    public void T04_CheckCarriageNumberTest()
    {
        Train train = new Train(500);
        Carriage newPCar1 = new PassengerCar(60, 11121111, 50, 10);
        Carriage newPCar2 = new PassengerCar(50, 12121113, 50, 10);
        Carriage newPCar3 = new PassengerCar(40, 11127133, 50, 10);
        Carriage newPCar4 = new PassengerCar(40, 64912451, 40, 10);
        Carriage newPCar5 = new PassengerCar(40, 63251679, 30, 10);
        Assert.AreEqual(11121111, newPCar1.CarriageNumber, "Wagen 1 hat gültige Nr.");
        Assert.AreEqual(1, newPCar2.CarriageNumber, "Wagon 2 hat ungültige Nr.");
        Assert.AreEqual(11127133, newPCar3.CarriageNumber, "Wagon 3 hat gültige Nr.");
        Assert.AreEqual(1, newPCar4.CarriageNumber, "Wagon 2 hat ungültige Nr.");
        Assert.AreEqual(63251679, newPCar5.CarriageNumber, "Wagon 5 hat gültige Nr.");
    }


    /// <summary>
    ///A test for GetCarriageWeight
    ///</summary>
    [TestMethod()]
    public void T05_CarriageGetWeightTest()
    {
        Carriage newPCar1 = new PassengerCar(60, 11121111, 50, 10);
        Assert.AreEqual(60 + 50 * Carriage.AVG_WEIGHT_PER_PASSENGER, newPCar1.GetFullWeight(), "Wagen 1 hat das falsche Gewicht");
        Carriage newCCar2 = new CargoCar(100, 11121111, 50, 10);
        Assert.AreEqual(100 + 50, newCCar2.GetFullWeight(), "Wagen 2 hat das falsche Gewicht");
    }

    /// <summary>
    ///A test for GetCarriageWeight
    ///</summary>
    [TestMethod()]
    public void T06_CarriageGetProfitTest()
    {
        Carriage newPCar1 = new PassengerCar(60, 11121111, 50, 10);
        Carriage newCCar2 = new CargoCar(100, 11121111, 100, 20);
        Assert.AreEqual(50 * 10 - Carriage.COST_PER_PASSENGER_CAR, newPCar1.GetProfit(), "Profit von Wagen1 stimmt nicht!");
        Assert.AreEqual(99 * 20 - Carriage.COST_PER_CARGO_CAR, newCCar2.GetProfit(), "Profit von Wagen2 stimmt nicht!");
    }


    /// <summary>
    ///A test for GetTrainWeight
    ///</summary>
    [TestMethod()]
    public void T07_GetTrainWeightTest()
    {
        Train train = new Train(500);
        Carriage newPCar1 = new PassengerCar(60, 11121111, 50, 10);
        Carriage newCCar2 = new CargoCar(50, 12121112, 2, 10);
        Carriage newPCar3 = new PassengerCar(40, 13121113, 50, 10);
        train.AddCarriage(newPCar1);
        train.AddCarriage(newCCar2);
        train.AddCarriage(newPCar3);
        Assert.AreEqual(60 + 50 + 40 + 100 * Carriage.AVG_WEIGHT_PER_PASSENGER + 2, train.GetTrainWeight(), "Gesamtgewicht von Zug1 stimmt nicht!");
    }

    /// <summary>
    ///A test for CountOfPassengerCars
    ///</summary>
    [TestMethod()]
    public void T08_CountOfPassengerCarsTest()
    {
        Train train = new Train(500);
        Assert.AreEqual(0, train.CountOfPassengerCars, "Leerer Zug sollte 0 Passagierwägen liefern!");
        train.AddCarriage(new CargoCar(100, 11121111, 20, 10));
        Assert.AreEqual(0, train.CountOfPassengerCars, "Zug mit nur einem Frachtwagon sollte 0 Passagierwägen liefern!");
        train.AddCarriage(new PassengerCar(100, 12121112, 20, 10));
        Assert.AreEqual(1, train.CountOfPassengerCars, "Zug mit hat 1 Passagierwagen!");
        train.AddCarriage(new PassengerCar(100, 13121113, 20, 10));
        Assert.AreEqual(2, train.CountOfPassengerCars, "Zug mit hat 2 Passagierwagen!");
        train.AddCarriage(new CargoCar(100, 14121114, 20, 10));
        Assert.AreEqual(2, train.CountOfPassengerCars, "Zug mit hat immer noch 2 Passagierwagen!");
    }



    /// <summary>
    ///A test for GetMostProfitableCarriage
    ///</summary>
    [TestMethod()]
    public void T09_GetMostProfitableCarriageTest()
    {
        Train train = new Train(500);
        Assert.IsNull(train.GetMostProfitableCarriage(), "Wenn es keine Wagon gibt muss GetMostProfitableCarriage null zurückliefern!");
        Carriage newPCar1 = new PassengerCar(60, 11121111, 50, 10);
        Carriage newCCar2 = new CargoCar(60, 12121112, 2, 10);
        Carriage newPCar3 = new PassengerCar(60, 14121114, 49, 11);
        Carriage newCCar4 = new CargoCar(60, 15121115, 200, 5);
        train.AddCarriage(newPCar1);
        Assert.AreEqual(newPCar1, train.GetMostProfitableCarriage(), "Nur 1 Wagon: PCar1 sollte der profitabelste sein!");
        train.AddCarriage(newCCar2);
        Assert.AreEqual(newPCar1, train.GetMostProfitableCarriage(), "2 Wagons: PCar1 sollte der profitabelste sein!");
        train.AddCarriage(newPCar3);
        Assert.AreEqual(newPCar3, train.GetMostProfitableCarriage(), "3 Wagons: PCar3 sollte der profitabelste sein!");
        train.AddCarriage(newCCar4);
        Assert.AreEqual(newCCar4, train.GetMostProfitableCarriage(), "4 Wagons: CCar4 sollte der profitabelste sein!");
    }

    /// <summary>
    ///A test for GetAmoutOfPassengersInTrain
    ///</summary>
    [TestMethod()]
    public void T10_GetAmoutOfPassengersInTrainTest()
    {
        Train train = new Train(1000);
        Assert.AreEqual(0, train.GetAmoutOfPassengersInTrain(), "Wenn es keine Wagon gibt muss GetAmoutOfPassengersInTrain 0 zurückliefern!");
        Carriage newPCar1 = new PassengerCar(60, 11121111, 50, 10);
        Carriage newCCar2 = new CargoCar(60, 12121112, 2, 10);
        Carriage newPCar3 = new PassengerCar(60, 13121113, 30, 11);
        Carriage newCCar4 = new CargoCar(60, 14121114, 200, 5);
        Carriage newPCar5 = new PassengerCar(60, 15121115, 7, 100);
        train.AddCarriage(newPCar1);
        Assert.AreEqual(50, train.GetAmoutOfPassengersInTrain(), "Nur 1 Wagon: 50 Passagiere");
        train.AddCarriage(newCCar2);
        Assert.AreEqual(50, train.GetAmoutOfPassengersInTrain(), "2 Wagon: 50 Passagiere");
        train.AddCarriage(newPCar3);
        Assert.AreEqual(80, train.GetAmoutOfPassengersInTrain(), "3 Wagon: 80 Passagiere");
        train.AddCarriage(newCCar4);
        Assert.AreEqual(80, train.GetAmoutOfPassengersInTrain(), "4 Wagon: 80 Passagiere");
        train.AddCarriage(newPCar5);
        Assert.AreEqual(87, train.GetAmoutOfPassengersInTrain(), "5 Wagon: 87 Passagiere");
        train.CarriageList.Remove(newPCar5);
        Assert.AreEqual(80, train.GetAmoutOfPassengersInTrain(), "Wieder nur 4 Wagon: 80 Passagiere");
    }


    /// <summary>
    ///A test for AddPassengersToCar
    ///</summary>
    [TestMethod()]
    public void T11_AddPassengersToCarSimpleTest()
    {
        Train train = new Train(500);
        Carriage newPCar1 = new PassengerCar(60, 11121111, 50, 10);
        Carriage newCCar2 = new CargoCar(50, 12121112, 2, 10);
        Carriage newPCar3 = new PassengerCar(40, 13121113, 50, 10);
        Carriage newPCar4 = new PassengerCar(40, 14121114, 40, 10);
        Carriage newPCar5 = new PassengerCar(40, 15121115, 30, 10);
        train.AddCarriage(newPCar3);
        train.AddCarriage(newCCar2);
        train.AddCarriage(newPCar5);
        train.AddCarriage(newPCar1);
        train.AddCarriage(newPCar4);
        train.AddPassengersToCar(14121114, 5);
        Assert.AreEqual(45, ((PassengerCar)newPCar4).NumberOfPassengers, "Passagiere nicht zugestiegen!");
    }


    /// <summary>
    ///A test for AddPassengersToCar
    ///</summary>
    [TestMethod()]
    public void T12_AddPassengersToCarComplexTest()
    {
        Train train = new Train(231);
        PassengerCar newPCar1 = new PassengerCar(45, 11121111, 50, 10);
        CargoCar newCCar2 = new CargoCar(41, 12121112, 5, 10);
        PassengerCar newPCar3 = new PassengerCar(40, 13121113, 50, 10);
        PassengerCar newPCar4 = new PassengerCar(40, 14121114, 40, 10);
        PassengerCar newPCar5 = new PassengerCar(40, 15121115, 30, 10);
        Assert.AreEqual(true, train.AddCarriage(newPCar3), "Gültiger Wagon 3 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(true, train.AddCarriage(newCCar2), "Gültiger Wagon 2 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(true, train.AddCarriage(newPCar5), "Gültiger Wagon 5 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(true, train.AddCarriage(newPCar1), "Gültiger Wagon 1 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(true, train.AddCarriage(newPCar4), "Gültiger Wagon 4 hinzugefügt! Sollte true liefern!");
        Assert.AreEqual(newPCar1, train.CarriageList[0], "Wagen1 sollte an 1. Stelle stehen!");
        Assert.AreEqual(newCCar2, train.CarriageList[1], "Wagen2 sollte an 2. Stelle stehen!");
        Assert.AreEqual(newPCar3, train.CarriageList[2], "Wagen3 sollte an 3. Stelle stehen!");
        Assert.AreEqual(newPCar4, train.CarriageList[3], "Wagen4 sollte an 4. Stelle stehen!");
        Assert.AreEqual(newPCar5, train.CarriageList[4], "Wagen5 sollte an 5. Stelle stehen!");
        Assert.IsTrue(train.AddPassengersToCar(14121114, 12), "Zustieg 1 ist ok! True erwartet!");
        Assert.AreEqual(newPCar4, train.CarriageList[2], "Zustieg 1: Wagen4 sollte nach Zustieg von 12 Personen an 3. Stelle stehen!");
        Assert.AreEqual(newPCar3, train.CarriageList[3], "Zustieg 1: Wagen3 sollte nun an 4. Stelle stehen!");
        Assert.IsFalse(train.AddPassengersToCar(15121115, 1000), "Maximale Passagiere im Wagon überschritten -> False erwartet");
        Assert.AreEqual(30, newPCar5.NumberOfPassengers, "Wenn nicht alle einsteigen können, sollte keiner einsteigen!");
        Assert.IsTrue(train.AddPassengersToCar(13121113, 150), "Zustieg 2 ist ok! True erwartet!");
        Assert.AreEqual(newPCar3, train.CarriageList[0], "Zustieg 2: Wagen3 sollte nach Zustieg von 150 Personen an 1. Stelle stehen!");
        Assert.IsFalse(train.AddPassengersToCar(15121115, 100), "Gesamtgewicht des Zugs würde überschritten werden! False erwartet!");


    }


}