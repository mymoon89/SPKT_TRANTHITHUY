using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ListBoxCollection911
{
    public class ListBoxTest : IEnumerable 
    {
        // trả về Enumerator cũng như triển khai Hàm GetEnumerator của IEnumerable
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)new ListBoxEnumerator(this);
        }
        private class ListBoxEnumerator : IEnumerator
        {
            //Hai thuộc tính của lop ListBoxEnumerator
            private ListBoxTest lbt;
            private int index;
            //Constructor
            public ListBoxEnumerator(ListBoxTest lbt)
            {
                this.lbt = lbt;
                index = -1;// giá trị báo chưa bắt đâu
            }
            // 2 hàm và thuộc tính của IEnumerator
            // gia tăng index và đảm bảo giá trị này hợp lệ
            public bool MoveNext()
            {
                index++;
                if (index >= lbt.strings.Length)
                    return false;
                else
                    return true;
            }
            public void Reset()
            {
                index = -1;
            }
            // thuộc tính sẽ báo là vị trí sẽ được thêm dữ liệu
            public object Current
            {
                get
                {
                    return (lbt[index]);
                }
            }
        }
        // khởi tạo listboxtestConstructor với chuỗi với từ Khóa Params
        public ListBoxTest(params string[] initStr)
        {
            strings = new String[10];
            // copy từ mảng chuỗi tham số
            foreach (string s in initStr)
            {
                strings[ctr++] = s;
            }
        }
        // Hàm thêm chuổi
        public void Add(string theString)
        {
            strings[ctr] = theString;
            ctr++;
        }
        // tạo Indexer để truy cập giống Array
        public string this[int index]
{
    get
    {
        if (index < 0 || index >= strings.Length)
        {
            // xử lý index sai
        }
        return strings[index];
    }
    set
    {
        strings[index] = value;
    }
}
        // tạo hàm đếm xem đã có bao nhiêu ký tự
        public int GetNumEntries()
        {
            return ctr;
        }
        // Thuộc tính của lớp ListBoxTest
        private string[] strings;
        private int ctr = 0;
    }
}
