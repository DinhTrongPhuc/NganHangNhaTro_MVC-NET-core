namespace NganHangNhaTroWeb.Models
{
    public class Payment
    {
        public int IdPayment { get; set; }
        public int IdBooking { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; } // Pending, Completed, Failed

        public Booking Booking { get; set; }
    }
}
