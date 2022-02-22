using System;

namespace CSharpBasicEvents
{

    // Define the delegate for the event handler
    public delegate void myEventHandler(string arg1);

    class EventPublisher
    {
        private string theVal;

        // Declare the event
        public event myEventHandler valueChanged;

        public string Val
        {
            set
            {
                this.theVal = value;
                //When the value changes fire the event
                this.valueChanged(theVal);
            }
        }
    }//End Class EventPublisher

    class Program
    {

        static void Main(string[] args)
        {
            EventPublisher obj = new EventPublisher();
            // obj.valueChanged += new myEventHandler(obj_valuechanged);
            obj.valueChanged += delegate (string arg1)
            {
                Console.WriteLine("In anon the value is {0}", arg1);
            };
            string str;

            do
            {
                Console.WriteLine("Enter a value");
                str = Console.ReadLine();
                if (!str.Equals("exit"))
                {
                    obj.Val = str;
                }

            } while (!str.Equals("exit"));
            Console.WriteLine("Goodbye!");
        } //End Main

        static void obj_valuechanged(string stringValue)
        {
            Console.WriteLine("The value changed to {0}", stringValue);
        }
    }//End Class Program
}