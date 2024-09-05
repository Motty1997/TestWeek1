using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek1.Models
{
    internal class Threat
    {
        public string ThreatType { get; set; }
        public int Volume { get; set; }
        public int Sophistication { get; set; }
        public string Target { get; set; }


        public int SeverityCalculation()
        {
            int TargetValue = Target switch
            {
                "Web Server" => 10,
                "Database" => 15,
                "User Credentials" => 20,
                _ => 5
            };
            int severity = (Volume * Sophistication) + TargetValue;
            return severity;
        }
    }
}
