using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace IEnumeratorTest
{
    class Container:IEnumerable
    {
        private class LopEnum : IEnumerator
        {
            private Container con;
            private int index;
            public LopEnum(Container con)
            {
                this.con = con;
                index = -1;
            }
            //cac ham cua Enumerator
            public bool MoveNext()
            {
                index++;
                if (index >= con.myString.Length)
                    return false;
                else return true;
            }
            public void Reset()
            {
                index = -1;
            }
            // current lay phan tu cuoi va them vao
            public object Current
            {
                get { return (con[index]); }
            }
        }
        //lop enum tra ve mot enumerator
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)new LopEnum(this);// this o day co nghia la Container con)
        }
        private string[] myString;
        private int myConStr;
        public Container(params string[] khoitaoString)
        {
            myString = new String[10];
            //chuyen chuoi qua cho ham Constructor
            foreach (string s in khoitaoString)
            {
                myString[myConStr++]=s;
            }
        }
        //them phan tu bang Add
        public void Add(string theString)
        {
            if (myConStr >= myString.Length)
            { }
            else myString[myConStr++] = theString;
        }
        // tao 1 indexer
        public string this[int index]
        {
            get { return myString[index]; }
            set { myString[index] = value; }
        }
        // ham tra ve so luong chuoi
        public int GetNoString() { return myConStr; }
        
    }
}
