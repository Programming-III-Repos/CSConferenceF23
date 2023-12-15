using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Conference_WPF.Models
{
    public class Visitor
    {
        //For this demo only
        public string Name { get; set; }
        public Status VisitorStatus { get; set; }
        public bool IsSpeaker { get; set; }
        public DateTime CheckInDate { get; set; }

        public override string ToString()
        {
            return $"{Name}...";
        }
    }

    public enum Status
    {
        Teacher, Student, Professional
    }

}
