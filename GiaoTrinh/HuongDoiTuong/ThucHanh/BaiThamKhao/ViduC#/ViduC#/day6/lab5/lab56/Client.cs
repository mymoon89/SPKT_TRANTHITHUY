using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab56
{
    class Client
    {
        delegate void NotifyMe(string sInfo);
        static void InvokeDelegate(NotifyMe d)
        {
            d("You are late paying your bills!");
        } 

        static void Main(string[] args)
        {
            //use static function of Listener class for delegate //call 
            //create instance of Notify delegate and point it at static function to call 
            NotifyMe d = new NotifyMe(Listener.GetNotifiedAgain);
            //invoke the delegate function 
            //notice function being called below takes a delegate //that can point 
            //to ANY function on any class - this is loosly coupled! 
            InvokeDelegate(d);
            Listener lsnr = new Listener();// tao object vi ham ko la static
            //create delegate and point to listener instance method 
            NotifyMe d2 = new NotifyMe(lsnr.GetNotified);
            InvokeDelegate(d2);
            NotifyMe d3 = new NotifyMe(Lis2.Speak);// khi la static thi ko can tao Object
            InvokeDelegate(d3);
            //invoke just like before 
            
            


        }
    }
}
