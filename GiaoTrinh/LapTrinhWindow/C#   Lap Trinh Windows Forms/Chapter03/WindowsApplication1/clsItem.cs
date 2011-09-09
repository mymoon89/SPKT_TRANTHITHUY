
namespace WindowsApplication1
{
    class clsItem
    {
        private string pstrValue = "";
        private string pstrName = "";
        public clsItem()
        {

        }
        public clsItem(string strValue, 
            string strName)
        {
            pstrValue = strValue;
            pstrName = strName;
        }
        public string Name
        {
            get { return pstrName; }
            set { pstrName = value; }
        }
        public string Value
        {
            get { return pstrValue; }
            set { pstrValue = value; }
        }
    }
}
