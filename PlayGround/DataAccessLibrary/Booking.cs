//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int Booking_ID { get; set; }
        public int User_ID { get; set; }
        public int Turf_ID { get; set; }
        public int Start_Time { get; set; }
        public int End_Time { get; set; }
        public double Amount { get; set; }
        public int Payment_ID { get; set; }
        public Nullable<System.DateTime> Booking_Date { get; set; }
        public int Payment_Status { get; set; }
        public System.DateTime Booking_Time { get; set; }
        public Nullable<bool> Booking_Status { get; set; }
    
        public virtual Time_Slote Time_Slote { get; set; }
        public virtual Payment_Type Payment_Type { get; set; }
        public virtual Time_Slote Time_Slote1 { get; set; }
        public virtual User User { get; set; }
        public virtual Turf Turf { get; set; }
    }
}