using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DelegateEvents
{
    public delegate void DoSomeThing();

    class ThucVat
    {
        public event DoSomeThing OnSayHello;


        public string Ten { get; set; }
        public ThucVat(string name)
        { Ten = name;   
            
        }
        public void PhatSinhSuKienSayHello()
        {
            if (OnSayHello != null)
                try
                {
                    Delegate[] dsDelegate = OnSayHello.GetInvocationList();
                    foreach (Delegate del in dsDelegate)
                    {
                        try
                        {
                            del.DynamicInvoke();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message);
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Bị lỗi: " + ex.Message);
                }
        }
        public void SayHello()
        {
            MessageBox.Show("Hello " + Ten);

        }
        public void SayGoodBye()
        {
            MessageBox.Show("Goodbye " + Ten);
        }
    }
}
