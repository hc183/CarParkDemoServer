using System;

namespace AbcCorp.CarPark.Services.Interfaces
{
    public interface IRateCalculator
    {
        DateTime EntryDateTime { get;  }
        DateTime ExitDateTime { get;  }
        double CalculateRate();
    }
}
