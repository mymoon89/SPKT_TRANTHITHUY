using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "abcd";
            string s2 = "ABCD";
            string s3 = @"Trung Tam Dao Tao CNTT
            Thanh pho Ho Chi Minh Viet Nam";
            int result;

            // So sánh hai chuỗi với nhau có phân biệt chữ thường và chữ hoa
            result = string.Compare( s1 ,s2);
            Console.WriteLine("So sanh hai chuoi S1: {0} và S2: {1} ket qua: {2} \n", s1 ,s2 ,result);
            // result=-1 khi s1 <s2; =0 khi s1=s2; =1 khi s1 >s2
            // Sử dụng tiếp phương thức Compare() nhưng trường hợp này không biệt
            // chữ thường hay chữ hoa
            // Tham số thứ ba là true sẽ bỏ qua kiểm tra ký tự thường – hoa

            result = string. Compare(s1, s2, true);

            Console.WriteLine("Khong phan biet chu thuong va hoa\n");

            Console.WriteLine("S1: {0} , S2: {1}, ket qua : {2}\n", s1, s2, result);

            // phương thức nối các chuỗi

            string s4 = string.Concat(s1, s2);

            Console.WriteLine("Chuoi S4 noi tu chuoi S1 va S2: {0}", s4);

            // sử dụng nạp chồng toán tử +

            string s5 = s1 + s2;

            Console.WriteLine("Chuoi S5 duoc noi tu chuoi S1 va S2: {0}", s5);

            // Sử dụng phương thức copy chuỗi

            string s6 = string.Copy(s5);

            Console.WriteLine("S6 duoc sao chep tu S5: {0}", s6);

            // Sử dụng nạp chồng toán tử =

            string s7 = s6;

            Console.WriteLine("S7 = S6: {0}", s7);

            // Sử dụng ba cách so sánh hai chuỗi

            // Cách 1 sử dụng một chuỗi để so sánh với chuỗi còn lại

            Console.WriteLine("S6.Equals(S7) ?: {0}", s6.Equals(s7));

            // Cách 2 dùng hàm của lớp string so sánh hai chuỗi

            Console.WriteLine("Equals(S6, s7) ?: {0}", string.Equals(s6, s7));

            // Cách 3 dùng toán tử so sánh

            Console.WriteLine("S6 == S7 ?: {0}", s6 == s7);

            // Sử dụng hai thuộc tính hay dùng là chỉ mục và chiều dài của chuỗi
            Console.WriteLine("\nChuoi S7 co chieu dai la : {0}", s7.Length);

            Console.WriteLine("Ky tu thu 3 cua chuoi S7 la : {0}", s7[2] );

            // Kiểm tra xem một chuỗi có kết thúc với một nhóm ký

            // tự xác định hay không

            Console.WriteLine("S3: {0}\n ket thuc voi chu CNTT ? : {1}\n",s3, s3.EndsWith("CNTT"));


            Console.WriteLine("S3: {0}\n ket thuc voi chu Nam ? : {1}\n",s3, s3.EndsWith("Nam"));


            // Trả về chỉ mục của một chuỗi con

            Console.WriteLine("\nTim vi tri xuat hien dau tien cua chu CNTT ");

            Console.WriteLine("trong chuoi S3 là {0}\n", s3.IndexOf("CNTT"));

            // Chèn từ nhân lực vào trước CNTT trong chuỗi S3

            string s8 = s3.Insert(18, "nhan luc ");

            Console.WriteLine(" S8 : {0}\n", s8);
            // Ngoài ra ta có thể kết hợp như sau

            string s9 = s3.Insert( s3.IndexOf( "CNTT" ) , "nhan luc ");

            Console.WriteLine(" S9 : {0}\n", s9);
        }
    }
}
