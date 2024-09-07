using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotoAppmod4App.Data;


using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using MotoAppmod4App.Data.Entities;


namespace MotoAppmod4App.Components.DataProviders
{
    public interface ICarsProvider
    {
        List<string> GetUnqiueCarColors()
        {
            throw new NotImplementedException();
        }

        decimal GetMinimumPriceOfAllCars()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetSpecificColumns()
        {
            throw new NotImplementedException();
        }
        string AnonymousClass()
        {
            throw new NotImplementedException();
        }


        //order by
        public List<Car> OrderByName()

        {
            throw new NotImplementedException();
        }

        public List<Car> OrderByNameDescending()

        {
            throw new NotImplementedException();
        }

        public List<Car> OrderByColorAndName()

        {
            throw new NotImplementedException();
        }

        public List<Car> OrderByColorAndNameDesc()

        {
            throw new NotImplementedException();
        }

        //where filtrowanie

        public List<Car> WhereStartsWith(string prefix);

        public List<Car> WhereStartsWithAndCostIsGraterThan(string prefix, decimal cost);

        public List<Car> WhereColorIs(string color);

        //first, last, single

        Car FirstByColor(string color);

        Car? FirstOrDefaultByColor(string color);

        Car FirstOrDeafultByColorWithDefault(string color);

        Car LastByColor(string color);

        Car SingleById(int id);

        Car? SingleOrDefaultById(int id);


        //Take

        List<Car> TakeCars(int howMany);

        List<Car> TakeCars(Range range);

        List<Car> TakeCarsWhileNameStartsWith(string prefix);

        //Skip

        List<Car> SkipCars(int howMany);

        List<Car> SkipCarsWhileNameStartsWith(string prefix);

        //Distinct
        List<string> DistinctAllColors();

        List<Car> DistinctByColors();


        //chunk  cars

        List<Car[]> ChunkCars(int size);

    }
}
