using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentMetricaComputer
{



    

    public  interface IRepository <T> 
    {
        public void Create(T item);

        public IList<T> GetByTimePeriod( );


    }
}
