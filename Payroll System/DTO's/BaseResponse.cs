﻿using System.Collections.Generic;

namespace Payroll_System.DTO_s
{
    public class BaseResponse<T>
    {
        public string Message { get; set; }

        public bool Status { get; set; } = false;

        public List<string> ValidationResults { get; set; } = new List<string>();

    }
   
}
