using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Enums
{
    public enum Category
    {
        Completed,
        Cancelled,
        InProgress
    }
    public class CategoryManager
    {
        public static Dictionary<int, string> Categories = new Dictionary<int, string>(
            new List<KeyValuePair<int, string>>() 
            {
                new KeyValuePair<int, string>(1,"Completed"),
                new KeyValuePair<int, string>(2,"Cancelled"),
                new KeyValuePair<int, string>(3,"InProgress"),
            }
            );
        
    }
    

}
