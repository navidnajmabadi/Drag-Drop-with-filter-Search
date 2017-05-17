using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarControlUI
{
    public class ApplicationInfo
    {
        public Double Price
        {
            get;
            set;
        }
        public String IconPath
        {
            get;
            set;
        }
        public String Name
        {
            get;
            set;
        }
        public String Author
        {
            get;
            set;
        }

        public static ObservableCollection<ApplicationInfo> GenerateApplicationInfos()
        {
            ObservableCollection<ApplicationInfo> result = new ObservableCollection<ApplicationInfo>();
            
        ApplicationInfo info1 = new ApplicationInfo();
            info1.Name = "camera";
            info1.Author = "C.E.R.N.";
            info1.IconPath = @"C:\Users\admin\Documents\Visual Studio 2017\Projects\StarControlUI\StarControlUI\img\camera.png";
            result.Add(info1);

            ApplicationInfo info2 = new ApplicationInfo();
            info2.Name = "Person";
            info2.Author = "Imagine Inc.";
            info2.IconPath = @"C:\Users\admin\Documents\Visual Studio 2017\Projects\StarControlUI\StarControlUI\img\person.png";
            result.Add(info2);

            ApplicationInfo info3 = new ApplicationInfo();
            info3.Name = "Data Base";
            info3.Author = "Control AG";
            info3.IconPath = @"C:\Users\admin\Documents\Visual Studio 2017\Projects\StarControlUI\StarControlUI\img\db.png";
            result.Add(info3);

            ApplicationInfo info4 = new ApplicationInfo();
            info4.Name = "Calender";
            info4.Author = "The CD Factory";
            info4.IconPath = @"C:\Users\admin\Documents\Visual Studio 2017\Projects\StarControlUI\StarControlUI\img\calender.png";
            result.Add(info4);

            ApplicationInfo info5 = new ApplicationInfo();
            info5.Name = "Internet Explorer";
            info5.Author = "Star Factory";
            info5.IconPath = @"C:\Users\admin\Documents\Visual Studio 2017\Projects\StarControlUI\StarControlUI\img\ie.png";
            result.Add(info5);

            ApplicationInfo info6 = new ApplicationInfo();
            info6.Name = "chart";
            info6.Author = "Open Org";
            info6.IconPath = @"C:\Users\admin\Documents\Visual Studio 2017\Projects\StarControlUI\StarControlUI\img\chart.png";
            result.Add(info6);

            return result;
        }
    }
}
