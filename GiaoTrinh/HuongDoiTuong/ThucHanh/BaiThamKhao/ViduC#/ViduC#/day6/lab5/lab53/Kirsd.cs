using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab53
{
    class Kirsd : IEHuman
    {
        private string m_Name;
        void IEHuman.Speak(string Message)
        {
            Console.WriteLine(Message);
        }
        string IEHuman.Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }

        }
    }
}
