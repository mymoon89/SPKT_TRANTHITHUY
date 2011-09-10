using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_2_MaTran
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tao ma tran A
            MaTran maTranA = new MaTran(2, 2);

            //Nhap ma tran A
            Console.WriteLine("Moi ban nhap ma tran A:");
            maTranA.nhapMaTran();

            //Tao ma tran B
            MaTran maTranB = new MaTran(2, 2);

            //Nhap ma tran B
            Console.WriteLine("Moi ban nhap ma tran B:");
            maTranB.nhapMaTran();

            //Cong hai ma tran A va B
            maTranA.congMaTran(maTranB);

            //Xuat ket qua tong cua 2 ma tran A + B
            Console.WriteLine("Tong cua 2 ma tran A va B la:");
            maTranA.xuatMaTran();

            //Tao ma tran C
            MaTran maTranC = new MaTran(2, 2);

            //Nhap ma tran C
            Console.WriteLine("Moi ban nhap ma tran C:");
            maTranC.nhapMaTran();

            //Tru 2 ma tran B va C
            maTranB.truMaTran(maTranC);

            //Xuat ket qua hieu cua 2 ma tran B va C
            Console.WriteLine("Hieu cua 2 ma tran B va C la:");
            maTranB.xuatMaTran();

            //Dao dau cac phan tu cua ma tran C
            maTranC.doiDauMaTran();
            
            //Dung man hinh
            Console.ReadLine();
        }
    }
}
