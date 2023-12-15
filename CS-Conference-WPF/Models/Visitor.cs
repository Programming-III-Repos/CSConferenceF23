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

        public string CSVData
        {
            get
            {
                return $"{Name},{IsSpeaker},{CheckInDate},{VisitorStatus}";
            }

            set
            {
                //Used for loading data: value, Example
                //Ben,True,12/20/2023 11:44:16 AM,Professional
                //[0]  [1]   [2]                    [3]

                try
                {
                    string[] values = value.Split(',');
                    Name = values[0];
                    IsSpeaker = bool.Parse(values[1]);
                    CheckInDate = DateTime.Parse(values[2]);
                    VisitorStatus = values[3] == Status.Professional.ToString() ? Status.Professional :
                                    values[3] == Status.Teacher.ToString() ? Status.Teacher : Status.Student;
                }
                catch (Exception ex)
                {
                    throw new Exception("CSV Visitor data are not valid" + ex.Message);
                }
                

            }
        }
    }

    public enum Status
    {
        Teacher, Student, Professional
    }

    

}
