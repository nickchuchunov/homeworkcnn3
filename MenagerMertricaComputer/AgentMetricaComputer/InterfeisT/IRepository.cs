using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentMetricaComputer
{



    

    public  interface IRepository <T> 
    {
        public void Create(T item);

        IEnumerable<T> GetByTimePeriod(int fromParameter, int toParameter);


    }
}
