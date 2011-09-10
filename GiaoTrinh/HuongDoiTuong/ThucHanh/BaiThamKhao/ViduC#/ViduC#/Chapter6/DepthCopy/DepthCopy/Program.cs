using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DepthCopy
{
    class Number
    {
        int m_a;

        public Number(int r_a)
        {
            m_a = r_a;

        }
        public void Change(int r_c)
        {
            m_a = r_c;
        }

        public void Show()
        {
            Console.Write(m_a.ToString() +" ");
        }

    }

    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Show(ArrayList r_Array)
        {
            foreach (Number i in r_Array)
            {
                i.Show();
            }

            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            ArrayList m_ArrayList = new ArrayList();

            m_ArrayList.Add(new Number(1));

            m_ArrayList.Add(new Number(2));

            m_ArrayList.Add(new Number(3));

            //////////////////////////////////////////////

            Console.WriteLine("ArrayList da duoc tao:");

            Show(m_ArrayList);

            ///////////////////////////////////////////////
            ArrayList m_ArrayListCopy = new ArrayList(m_ArrayList);

            m_ArrayListCopy = (ArrayList) m_ArrayList.Clone();

            Console.WriteLine("ArrayList duoc copy:");

            Show(m_ArrayListCopy);

            //////////////////////////////////////////////

            Number a;

            a = (Number)m_ArrayList[0];

            a.Change(6);  

            //Number a = new Number(6);

           // m_ArrayList[0] = a;

            Console.WriteLine("Sau khi them gia tri 4");

            Console.WriteLine("ArrayList goc:");

            Show(m_ArrayList);

            Console.WriteLine("ArrayList duoc copy:");

            Show(m_ArrayListCopy);

            /////////////////////////////////////////////
            Console.ReadKey();
        }



    }
}
