﻿using System;

namespace IUR.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public int GroupID { get; set; }
    }
}