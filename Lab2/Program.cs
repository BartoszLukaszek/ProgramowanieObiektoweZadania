using System;

namespace Lab2
{
    class Program
    {
        abstract class AbstractMessage
        {
            public string Content { get; init; }
            abstract public void Send();
        }

        class EmalMessage : AbstractMessage
        {
            public string To { get; set; }
            public string From { get; set; }
            public string Subject { get; set; }

            public override void Send()
            {
                Console.WriteLine($"Do: {To} Od: {From} Tytuł: {Subject} Treść {Content}");
            }
        }
        class SmsMessage : AbstractMessage
        {
            public string To { get; set; }
            public override void Send()
            {
                Console.WriteLine($"Do: {To} Treść {Content}");
            }
        }

        class MessangerMessage : AbstractMessage
        {
            public override void Send()
            {
                Console.WriteLine($"Wiadomoś messenger: {Content}");
            }
        }

        interface IFly
        {
            void Fly();
        }

        interface ISwim
        {
            void Swim();
        }

        interface IFlyAndSwim : IFly, ISwim
        {

        }

        class Duck : IFlyAndSwim
        {
            public void Fly()
            {
                throw new NotImplementedException();
            }

            public void Swim()
            {
                throw new NotImplementedException();
            }
        }

        class Wasp: IFly
        {
            public void Fly()
            {
                throw new NotImplementedException();
            }
        }

        class HydroPlane : IFlyAndSwim
        {
            public void Fly()
            {
                throw new NotImplementedException();
            }

            public void Swim()
            {
                throw new NotImplementedException();
            }
        }

        // Do zrobienia Ćwiczenie 1,2,3
        public abstract class Vehicle
        {
            public double Weight { get; init; }
            public int MaxSpeed { get; init; }
            protected int _mileage;
            public int Mealeage
            {
                get { return _mileage; }
            }
            public abstract decimal Drive(int distance);
            public override string ToString()
            {
                return $"Vehicle{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage} }}";
            }
        }

        public class Car : Vehicle
        {
            public bool isFuel { get; set; }
            public bool isEngineWorking { get; set; }
            public override decimal Drive(int distance)
            {
                if (isFuel && isEngineWorking)
                {
                    _mileage += distance;
                    return (decimal)(distance / (double)MaxSpeed);
                }
                return -1;
            }
            public override string ToString()
            {
                return $"Car{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}";
            }
        }

        public class Bicycle : Vehicle
        {
            public bool isDriver { get; set; }
            public override decimal Drive(int distance)
            {
                if (isDriver)
                {
                    _mileage += distance;
                    return (decimal)(distance / (double)MaxSpeed);
                }
                return -1;
            }
            public override string ToString()
            {
                return $"Bicycle{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}"; ;
            }
        }

        public abstract class Scooter : Vehicle { }

        public class ElectricScooter : Scooter
        {
            private int _battery = 0;
            public int BatteriesLevel { get { return _battery; }}
            public int MaxRange = 100;

            public void ChargeBatteries()
            {
                _battery = 100;
            }
            public override decimal Drive(int distance)
            {
                if(distance > 0)
                {
                    if (_battery/MaxRange*100 > distance)
                    {
                        _battery -= distance;
                        return distance;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public class KickScooter : Scooter
        {
            public override decimal Drive(int distance)
            {
                throw new NotImplementedException();
            }
        }


        static void Main(string[] args)
        {

            ElectricScooter scooter = new ElectricScooter();
            scooter.ChargeBatteries();
            scooter.Drive(10);
            Console.WriteLine(scooter.BatteriesLevel);

            Vehicle[] vehicles =
            {
                new Bicycle(){Weight = 15, MaxSpeed = 30, isDriver = true},
                new Car(){Weight = 900, MaxSpeed = 120, isFuel = true, isEngineWorking = true},
                new Bicycle(){Weight = 21, MaxSpeed = 40, isDriver = true},
                new Bicycle(){Weight = 19, MaxSpeed = 35, isDriver = true},
                new Car(){Weight = 1200, MaxSpeed = 130, isFuel = true, isEngineWorking = true}
            };
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine("Time for distance: " + vehicle.Drive(45));
            }
            int bicycleCounter = 0;
            int carCounter = 0;
            foreach (var vehicle in vehicles)
            {
                if (vehicle is Bicycle)
                {
                    bicycleCounter++;
                    Bicycle bicycle = (Bicycle)vehicle;
                    Console.WriteLine("Czy rower ma kierowcę: " + bicycle.isDriver);
                }
                if (vehicle is Car)
                {
                    carCounter++;
                }
            }
            Console.WriteLine($"Liczba rowerów: {bicycleCounter}, liczba samochodów: {carCounter}");
            
            
            
            
            
            
            
            //
            AbstractMessage[] messages = new AbstractMessage[4];
            messages[0] = new EmalMessage() { Content = "Hello Email", From = "A@abc.net", To = "B@abc.net", Subject = "Title" };
            messages[1] = new SmsMessage() { Content = "Hello SMS", To = "9992"};
            messages[2] = new EmalMessage() { Content = "Hello Email", From = "C@abc.net", To = "G@abc.net", Subject = "Title5" };
            messages[3] = new MessangerMessage() { Content = "Hello Messager" };
            int mailCounter = 0;
            foreach (var item in messages)
            {
                item.Send();
                //1
                if (item is EmalMessage)
                {
                    mailCounter++;
                }
                //2 jesli message nie jest tpu emailemmessage to daje null
                EmalMessage email = item as EmalMessage;
                mailCounter += email == null ? 0 : 1;
            }
            Console.WriteLine(mailCounter);
            //
            IFly[] fly = new IFly[3];
            fly[0] = new Duck();
            fly[1] = new HydroPlane();
            fly[2] = new Wasp();

            int flyCounter = 0;
            int swimCounter = 0;
            foreach (var item in fly)
            {
                if (item is IFly)
                {
                    flyCounter++;
                }
                if (item is ISwim)
                {
                    swimCounter++;
                }
            }
            Console.WriteLine($"Liczba Latajacych: {flyCounter}, liczba pływających: {swimCounter}");



            //

            string[] names = { "a", "b" };
            IAggreagate aggreagate = new StringAggreagate(names);
            aggreagate = new SimpleAggregate() { Firstname="Adrian",Lastname="R"};
            //
            IIterator iterator = aggreagate.createIterator();
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.GetNext());
            }
        }

    }

    interface IAggreagate
    {
        IIterator createIterator();
    }
    interface IIterator
    {
        bool HasNext();
        string GetNext();
    }
    class SimpleAggregate : IAggreagate
    {
        public string Firstname { get; init; }
        public string Lastname { get; init; }


        public IIterator createIterator()
        {
            return new SimpleIteraror(this);
        }
    }

    class SimpleIteraror : IIterator
    {
        private SimpleAggregate aggreagate;
        public int count = 0;

        public SimpleIteraror(SimpleAggregate aggreagate)
        {
            this.aggreagate = aggreagate;
        }

        public string GetNext()
        {
            switch (++count)
            {
                case 1:
                    return aggreagate.Firstname;
                case 2:
                    return aggreagate.Lastname;
                default:
                    throw new ArgumentException();
                    
            }
        }

        public bool HasNext()
        {
            return count < 2;
        }
    }
    class StringAggreagate : IAggreagate
    {
        internal string[] names;

        public StringAggreagate(string[] names)
        {
            this.names = names;
        }

        public IIterator createIterator()
        {
            return new StringIterrator(this);
        }
    }

    class StringIterrator : IIterator
    {
        private StringAggreagate aggreagate;
        private int currentIndex = 0;
        public StringIterrator(StringAggreagate aggreagate)
        {
            this.aggreagate = aggreagate;
        }

        public string GetNext()
        {
            return aggreagate.names[currentIndex++];
        }

        public bool HasNext()
        {
            return currentIndex < aggreagate.names.Length;
        }
    }
}
