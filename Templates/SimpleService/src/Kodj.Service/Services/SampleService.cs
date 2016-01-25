using Kodj.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kodj.Service
{
    public class SampleService
    {
        private SampleDbContext sampleContext;
        public SampleService(SampleDbContext sampleContext)
        {
            this.sampleContext = sampleContext;
        }

        public IQueryable<SampleEntity> GetSomeData()
        {
            return sampleContext.SampleEntities.Select(x => x);
        }
    }
}
