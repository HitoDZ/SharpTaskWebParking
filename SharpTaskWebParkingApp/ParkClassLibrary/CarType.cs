using System;
using System.Collections.Generic;
using System.Text;

namespace ParkClassLibrary
{
    class CarType
    {
        public enum carTypes
        {
            PASSENGER,
            TRUCK,
            BUSS,
            MOTOCYCLE
        }


        public carTypes CarTypes
        {
            get { return CarTypes; }
            set {; }
        }

        /*private static  Dictionary<string,float> carTypes;

        public static  Dictionary<string,float> CarTypes {
            get;
            protected set;
        }

        public string type;
        static CarType()
        {
            carTypes = new Dictionary<string,float>
            {
                {
                    "PASSENGER",
                    0
                },
                {
                    "TRUCK", 0
                },
                {
                    "BUSS", 0
                },
                {"MOTOCYCLE", 0}
            };
        }

        public CarType(string t)
        {
            //TODO: ADD VALIDATION OF NEW TYPE
              type = t;
        }*/
    }
}
