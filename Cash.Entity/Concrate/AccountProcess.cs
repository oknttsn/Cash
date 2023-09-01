namespace Cash.Entity.Concrate
{
    public class AccountProcess : Entity //Musteri Hesap Haraketleri Takibi 
    {
        public int ProcessType { get; set; } //Islem Turu
        public decimal Amount { get; set; } //Miktar (ne kadar para gonderildi?)
        public DateTime ProcessDate { get; set; } //islem saati
    }
}
