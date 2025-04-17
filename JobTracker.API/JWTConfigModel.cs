﻿namespace JobTracker.API
{
    public class JWTConfigModel
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public int ExpireDays { get; set; }
    }
}
