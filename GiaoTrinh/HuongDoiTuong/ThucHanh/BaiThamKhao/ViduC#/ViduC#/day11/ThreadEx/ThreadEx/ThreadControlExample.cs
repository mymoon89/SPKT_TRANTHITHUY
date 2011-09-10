using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; 
namespace ThreadEx
{
    class ThreadControlExample
    {
           static   void DisplayMessage()
        {
            // Lặp đi lặp lại việc hiển thị một thông báo ra cửa sổ Console.  
            while (true)
            {
                try
                {
                    Console.WriteLine("{0} : Second thread running. Enter"
                    + " (S)uspend, (R)esume, (I)nterrupt, or (E)xit.", DateTime.Now.ToString("HH:mm:ss.ffff"));
                    // Nghỉ 2 giây.   
                    Thread.Sleep(2000);
                }
                catch (ThreadInterruptedException)
                {
                    // Tiểu trình đã bị gián đoạn. Việc bắt ngoại lệ  
                    // ThreadInterruptedException cho phép ví dụ này  
                    // thực hiện hành động phù hợp và tiếp tục thực thi.   
                    Console.WriteLine("{0} : Second thread interrupted.", DateTime.Now.ToString("HH:mm:ss.ffff"));
                }
                catch (ThreadAbortException abortEx)
                {
                    // Đối tượng trong thuộc tính  
                    // ThreadAbortException.ExceptionState được cung cấp  
                    // bởi tiểu trình đã gọi Thread.Abort.  
                    // Trong trường hợp này, nó chứa một chuỗi  
                    // mô tả lý do của việc hủy bỏ.  
                    Console.WriteLine("{0} : Second thread aborted ({1})", DateTime.Now.ToString("HH:mm:ss.ffff"),
                    abortEx.ExceptionState);
                    // Mặc dù ThreadAbortException đã được thụ lý,  
                    // bộ thực thi sẽ ném nó lần nữa để bảo đảm  
                    // tiểu trình kết thúc.  
                }
            }
        }
           static void Main(string[] args)
           {
               // Tạo một đối tượng Thread và truyền cho nó một thể hiện  
               // ủy nhiệm ThreadStart tham chiếu đến DisplayMessage.  
               Thread thread = new Thread(new ThreadStart(DisplayMessage));
               Console.WriteLine("{0} : Starting second thread.", DateTime.Now.ToString("HH:mm:ss.ffff"));
               // Khởi chạy tiểu trình thứ hai.   
               thread.Start();
               // Lặp và xử lý lệnh do người dùng nhập.   
               char command = ' ';
               do
               {
                   string input = Console.ReadLine();
                   if (input.Length > 0) command = input.ToUpper()[0];
                   else command = ' ';
                   switch (command)
                   {
                       case 'S':
                           // Tạm hoãn tiểu trình thứ hai.  
                           Console.WriteLine("{0} : Suspending second thread.", DateTime.Now.ToString("HH:mm:ss.ffff"));
                           thread.Suspend();
                           break;
                       case 'R':
                           // Phục hồi tiểu trình thứ hai.   
                           try
                           {
                               Console.WriteLine("{0} : Resuming second " + "thread.", DateTime.Now.ToString("HH:mm:ss.ffff"));
                               thread.Resume();
                           }
                           catch (ThreadStateException)
                           {
                               Console.WriteLine("{0} : Thread wasn't " + "suspended.", DateTime.Now.ToString("HH:mm:ss.ffff"));
                           }
                           break;
                       case 'I':
                           // Gián đoạn tiểu trình thứ hai.  
                           Console.WriteLine("{0} : Interrupting second " + "thread.", DateTime.Now.ToString("HH:mm:ss.ffff"));
                           thread.Interrupt();
                           break;
                       case 'E':
                           // Hủy bỏ tiểu trình thứ hai và truyền một đối tượng 
                           // trạng thái cho tiểu trình đang bị hủy, 
                           // trong trường hợp này là một thông báo.  
                           Console.WriteLine("{0} : Aborting second thread.", DateTime.Now.ToString("HH:mm:ss.ffff"));
                           thread.Abort("Terminating example.");
                           // Đợi tiểu trình thứ hai kết thúc. 
                           thread.Join();
                           break;
                   }
               } while (command != 'E');

               // Nhấn Enter để kết thúc.  
               Console.WriteLine("Main method complete. Press Enter.");
               Console.ReadLine();
           }  
    }
}

