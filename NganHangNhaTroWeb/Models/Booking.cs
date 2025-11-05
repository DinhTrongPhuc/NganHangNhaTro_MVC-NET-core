namespace NganHangNhaTroWeb.Models
{
    public class Booking
    {
        public int IdBooking { get; set; }
        public int IdUser { get; set; }
        public int IdProperty { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookingStatus { get; set; } // Pending, Confirmed, Cancelled

        public User User { get; set; }
        public Property Property { get; set; }
    }
}
