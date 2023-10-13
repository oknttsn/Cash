namespace Cash.Entity.Concrate
{
    public class ClientAccount : BaseEntity //Musteri Hesabi
    {
        public string Number { get; set; } //Hesap Numarasi
        public string Currency { get; set; } //doviz durumu TL/DOLAR
        public decimal Balance { get; set; } //Mevcut Bakiye
        public string Branch { get; set; } //Hesabin Bagli Oldugu Sube
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
