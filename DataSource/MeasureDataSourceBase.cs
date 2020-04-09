using EurocomFontysHealth.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EurocomFontysHealth.DataSource
{
    public abstract class MeasurementDataSourceBase<T> : DataSourceBase<T>
            where T : Entity
    {
        private static Random RandomFeed = new Random();


        /// <summary>
        /// Take a random value from a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        protected T TakeRandom<T>(IEnumerable<T> values)
        {
            return values.ElementAt(RandomFeed.Next(0, values.Count()));
        }
    }
}
