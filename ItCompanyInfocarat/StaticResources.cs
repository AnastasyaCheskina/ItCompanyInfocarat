using ItCompanyInfocarat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItCompanyInfocarat
{
    internal class StaticResources
    {
        public static ItCompanyEntities db = new ItCompanyEntities();
        private static Employees user = new Employees();
        private static Applications applications = new Applications();
        private static List<Done_applications> doneApplications = new List<Done_applications>();
        public static Employees User { get => user; set => user = value; }
        public static Applications Applications { get => applications; set => applications = value; }
        public static List<Done_applications> DoneApplications { get => doneApplications; set => doneApplications = value; }
    }
}
