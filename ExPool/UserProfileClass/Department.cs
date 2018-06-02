using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfile.Exercise
{
    class Department
    {
        private int? department_id;
        public int? Department_ID
        {
            get
            {
                return department_id;
            }

            set
            {
                department_id = value;
            }
        }

        public String Get_Department()
        {
            // 1 : 축구
            // 2 : 농구
            // 3 : 탁구
            // 4 : 배드민턴
            switch(this.department_id){
                case 1: return "축구";
                case 2: return "농구";
                case 3: return "탁구";
                case 4: return "배드민턴";
                default: throw new System.ArgumentException("Invalid value", "original");
            }
        }
    }
}
