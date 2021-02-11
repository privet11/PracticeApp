using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp.Pages
{
    public class PagesGet
    {
        public static T GetPages<T>() where T : new() 
        {
            var page = new T();
            return page;
        }
    }
}
