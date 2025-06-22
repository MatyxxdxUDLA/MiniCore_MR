namespace MiniCore_MR.Models
{
    public class ComisionViewModel
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<Venta> Ventas { get; set; }
        public Dictionary<int, decimal> Comisiones { get; set; }
    }
}
