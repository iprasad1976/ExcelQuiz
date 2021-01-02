using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;

namespace ExcelQuiz.Utilities
{
    public static class IEnumerableExtension
    {
        public static Collection<TSource> ToCollection<TSource>(this IEnumerable<TSource> list)
        {
            Collection<TSource> result;
            result = new Collection<TSource>(new List<TSource>(list));
            return result;
        }

        public static Collection<TSource> Pop<TSource>(this IEnumerable<TSource> list, int count)
        {
            Stack<TSource> inputList = list as Stack<TSource>;
            Collection<TSource> result = new Collection<TSource>();
            if (list == null)
            {
                throw new Exception("Type not supported."); 
            }
            
            for (int n = 0; n < count; n++)
            {
                if (inputList.Count > 0)
                {
                    result.Add(inputList.Pop());    
                }
            }
                       
            return result;
        }
   
    }
}
