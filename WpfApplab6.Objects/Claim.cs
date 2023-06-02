﻿using System;
using WpfApplab6.Objects.Abstracts;

namespace WpfApplab6.Objects
{
    public class Claim : Entity
    {
        public DateTime FilingDate { get; set; }
        
        public bool CategoryCustomer { get; set; }
        
        public string District { get; set; }
        
        public string Description { get; set; }
        
        public bool IsSpeed { get; set; }
        
        public Guid CityId { get; set; }
        
        public City City { get; set; }
    }
}