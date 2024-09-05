using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek1.Models
{
    internal class DefenceModel
    {
        public int MinSeverity { get; set; } = 0;
        public int MaxSeverity { get; set; } = 0;
        public List<string> Defenses { get; set; } = [];


        public override string ToString()
        {
            return $"MinSeverity: {MinSeverity}, MaxSeverity: {MaxSeverity}";
        }
    }
}
