using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndexExam
{
    public class Indextest {
        private string[] myWord;
        private int myCont;
        // tao chuoi va khoi gán chuoi bang Constructor
        public Indextest(params string[] taoChuoi){
            myWord = new String[256]; //tao chuoi
            // khoi tạo
            foreach (string s in taoChuoi) {
                myWord[myCont++] = s;
            }
        }
        // hàm Add để thêm chữ vào
        public void Add(string themChu)
        {
            myWord[myCont++] = themChu;
        }
        // dinh nghĩa Indexer để truy xuất giống Array
        public string this[int i] {
            get { return myWord[i]; }
            set { myWord[i] = value; }
        }
        // hàm lấy số lượng các chữ được đưa vào
        public int SoLuong() { 
            return myCont;
        }
    }
    public class Program {

        static void Main() { 
        
            // tạo 1 thể hiện duoi dang liệt kê
            Indextest idt = new Indextest(" kiem", " tra", " Indexer");
            // them vao chuoi khi goi ham Add
           idt.Add(" them 1");
           idt.Add("them 2");
            // có thê truy xuat va thay doi gia trị
          string thayDoi = " THEM 3";
           idt[1] = thayDoi;
            // in ra man hinh
            for (int x = 0; x < idt.SoLuong(); x++) {
                Console.WriteLine("idt[{0}]:{1}", x, idt[x]);
            }

        }
    }
}
