using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap_12
{
    class LopHoc
    {
        #region LopHoc properties
		Dictionary<string, object> _DSHocVien;

        public Dictionary<string, object> DSHocVien
        {
          get { return _DSHocVien; }
          set { _DSHocVien = value; }
        } 
	    #endregion

        #region Create constructor LopHoc have list student is null
        public LopHoc()
        {
            this.DSHocVien = new Dictionary<string, object>();

        } 
        #endregion
                
        #region Print list student
        public void PrintListStudent()
        {
            foreach (KeyValuePair<string, object> kvp in this.DSHocVien)
            {
                Console.Write("\t" + kvp.Key + "\t" + kvp.Value);
                Console.WriteLine();

            }

        } 
        #endregion

        #region Search student by name
        public HocVien SearchStudent(string tenSV)
        {
            foreach (KeyValuePair<string, object> kvp in this.DSHocVien)
            {
                if (kvp.Value == tenSV)
                    return new HocVien(kvp.Key, kvp.Value.ToString());

            }

            return null;

        } 
        #endregion
    }
}
