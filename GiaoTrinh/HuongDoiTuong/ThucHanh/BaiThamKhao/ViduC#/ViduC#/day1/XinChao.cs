/*  class XinChao
{
	public static void Main() {
		System.Console.WriteLine("Hello C#");
		
	
	}
}*/
// Ham main co thong so
/*class XinChao

{
	public static int Main(string[] args) {
		for(int i=0;i<args.Length;i++)
		//foreach(string s in args)
		{
		
		//System.Console.WriteLine("arguments are: {0}",s) ;
		System.Console.WriteLine("Agruments are:{0}",args[i]);
						
			}
		System.Console.WriteLine("Hello C#");
		System.Console.ReadLine();
		return 0;
		
	
	}
} */

//Gioi thieu so luoc ve dinh dang chuoi trong C#
using System;
	class XinChao {
	public static void Main(string[] args){
		int soNguyen=90;
		float soThuc=9.999999f;
		XinChao chao= new XinChao(); // tao mot doi tuong kieu XinChao
		Console.WriteLine(" So nguyen la : {0} \n So Thuc la:{1:F2} \n Doi tuong la : {2}", soNguyen,soThuc,chao.ToString());
		Console.ReadLine();
}
}
