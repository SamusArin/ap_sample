using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Sample
{
    public interface INavigation
    {
        void SetTrip(string startAddr, string endAddr);        
        void StartTurnByTurn();
    }

    public abstract class Automobile
    {
        public enum IgnitionType { TURNKEY = 0, PUSHBUTTON, REMOTE }

        protected string _make;
        protected string _model;

        public virtual string Make {
            get { return _make; }
            set { _make = value; }
        }

        public virtual string Model {
            get { return _model; }
            set { _model = value; }
        }

        public Automobile(string make, string model)
        {
            _make = make;
            _model = model;
        }

        public abstract void StartEngine(IgnitionType ignitionType); // throws StartEngineFailureException;
    }

    public class Car : Automobile, INavigation
    {
        public enum TransType { MANUAL = 0, AUTOMATIC, TRIPTRONIC }

        //private IgnitionType _ignitionType;
        private string _navStartAddr;
        private string _navEndAddr;

        public string VIN { get; set; }
        public int EngineCylinders { get; set; }
        public TransType Transmission { get; set; }

        public Car(string vin, string make, string model, int cylinders, TransType trans) : base(make, model)
        {
            VIN = vin;
            EngineCylinders = cylinders;
            Transmission = trans;
        }

        public override void StartEngine( IgnitionType ignitionType)
        {
            switch (ignitionType)
            {
                case IgnitionType.TURNKEY:
                    // turnKeyStart
                    break;
                case IgnitionType.PUSHBUTTON:
                    // pushButtonStart
                    break;
                case IgnitionType.REMOTE:
                    // remoteStart
                    break;
            }
        }

        public void SetTrip(string startAddr, string endAddr)
        {
            _navStartAddr = startAddr;
            _navEndAddr = endAddr;
        }
        public void StartTurnByTurn()
        {
            // start turn by turn
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car commuter = new Car("2jzXXXYYY", "chevy", "sonic", 4, Car.TransType.MANUAL);

            Console.WriteLine("Make: " + commuter.Make);
            Console.WriteLine("Model: " + commuter.Model);
            Console.WriteLine("Cylinders: " + commuter.EngineCylinders);
            Console.WriteLine("Transmission: " + commuter.Transmission);
        }
    }
}
