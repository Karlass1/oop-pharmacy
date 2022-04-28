using System;
using System.Collections.Generic;


namespace oop_pharmacy
{
    public class Pharmacy
    {
        static Pharmacy pharmacy;

        public static Pharmacy GetPharmacy() //singleton
        {
            if (pharmacy == null)
            {
                return pharmacy = new Pharmacy();
            }
            return pharmacy;
        }

        public List<Medication> MedList = new List<Medication>();
    }
}
