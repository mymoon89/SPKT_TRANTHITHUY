using System;
using System.Collections;
using System.Text;

namespace Generictest
{
     public class List<T>
    {
       public   T m_a;
          public List(T  r_a)
        {
            m_a = r_a;

        } 
          public void Show()
          {
              Console.WriteLine (m_a.ToString() + " ");
          }

          public T Add(T input) {
              m_a = input;
              return input; }
    }  
    
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>(5);
            List<string > list2 =new List<string>("a b c") ; 
            // No boxing, no casting:
            list1.Add(4);
            list1.Show();
            list2.Add("It is raining in Redmond.");
            list2.Show();
             ArrayList list = new ArrayList();
              list.Add(1);
              list.Add(2);
            //list.Add("wrong No");
           //  list.Add(3.14);
         int  total = 0;
         foreach(int val in list)
            {
                total = total +  val ;
            }

            Console.WriteLine( "Total is {0}", total);
        }
    }
}

