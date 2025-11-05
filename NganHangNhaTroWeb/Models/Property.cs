namespace NganHangNhaTroWeb.Models
{
    public class Property
    {
        public int IdProperty { get; set; }
        public int IdOwner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int MaxOccupancy { get; set; }
        public string Status { get; set; } // Available, Booked

        public User Owner { get; set; } // Navigation property
    }
}
