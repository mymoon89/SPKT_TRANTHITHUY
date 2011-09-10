using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringBuliderEx
{
    class Program
    {
        static void Main(string[] args)
        {
            // khởi tạo chuỗi để sử dụng
            string s1 = "Mot,hai,baTrungTamDaoTaoCNTT";
// tạo ra hằng ký tự khoảng trắng và dấu phẩy
            const char Space = ' ';
            const char Comma = ',';
// tạo ra mảng phân cách
            char[] delimiters = new char[]
                {
                    Space,
                    Comma
                    };
// sử dụng StringBuilder để tạo chuỗi output
            StringBuilder output = new StringBuilder();
            int ctr = 1;
// chia chuỗi và dùng vòng lặp để đưa kết quả vào
// mảng các chuỗi, sẽ tìm các " ," hay " " để tách ra
            foreach ( string subString in s1.Split(delimiters) )
{
// AppendFormat nối một chuỗi được định dạng
        output.AppendFormat("{0}: {1}\n", ctr++, subString);
}// end foreach
            Console.WriteLine( output );
        }
    }
}
