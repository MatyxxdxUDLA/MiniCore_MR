namespace MiniCore_MR.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Usuario { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }
    }
}

