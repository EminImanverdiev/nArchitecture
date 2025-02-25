﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Model:Entity<Guid>
{
    public Guid BrandId { get; set; }
    public Guid FuelId { get; set; }
    public Guid TransmissionId { get; set; }
    public string Name { get; set; }
    public string ImageURL { get; set; }
    public decimal DailyPrice { get; set; }
    public virtual Brand? Brand { get; set; }
    public virtual Fuel? Fuel { get; set; }
    public virtual Transmission? Transmission { get; set; }
    public virtual ICollection<Car> Cars { get; set; }
    public Model()
    {
        Cars = new HashSet<Car>();
    }
    public Model(Guid Id,Guid brandId,Guid fuelId,Guid transmissionId,string name,decimal dailyPrice,string imageURL):this()
    {
        Id = Id;
        BrandId=brandId;
        FuelId=fuelId;
        TransmissionId=transmissionId;
        Name=name;
        DailyPrice=dailyPrice;
        ImageURL=imageURL;
            
    }
}
