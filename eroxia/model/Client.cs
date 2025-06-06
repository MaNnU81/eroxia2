﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eroxia.model
{
    internal class Client : Person
    {
        public string Address { get; set; }
        public string? FiscalCodeEmployee { get; set; }
        public Employee? Employee { get; set; }
        public Client(string fiscalCode, string name, string surname, string address): base(fiscalCode, name, surname)
        {
            Address = address;
        }

        public Client(string fiscalCode, string? fiscalCodeEmployee, string name, string surname, string address) : base(fiscalCode, name, surname)
        {
            FiscalCodeEmployee = fiscalCodeEmployee;


            Address = address;
        }
        public override string? ToString()
        {
            return $"{FiscalCode} - {Name} {Surname} - {Address} - EMPLOYEE: {FiscalCodeEmployee} ";
        }
    }
}
