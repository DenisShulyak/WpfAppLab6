using System;
using WpfApplab6.Objects.Abstracts;

namespace WpfApplab6.Objects
{
    public class Contract : Entity
    {
        public DateTime BeginDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public  Organization Customer { get; set; }
        
        public  Guid CustomerId { get; set; }
        
        public  Organization Executor { get; set; }
        
        public  Guid ExecutorId { get; set; }
    }
}