﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Model
{
    public class Registration
    {
        private Activity _activatie; 
        public Activity Activatie { get; set; }
        private Customer _customer;
        public Customer Customer { get; set; }
        private int _participating;
        public int Participating { get; set; }

        public Registration(Activity activatie, Customer customer, int participating)
        {
            Activatie = activatie;
            Customer = customer;
            Participating = participating;
        }

        
    }
}
