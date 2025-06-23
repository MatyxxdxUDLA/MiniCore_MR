namespace MiniCore_MR.Models
{
    public class ComisionViewModel
    {
        public DateTime FechaInicio { get; set; } = DateTime.Today.AddMonths(-1);
        public DateTime FechaFin { get; set; } = DateTime.Today;
        public List<ResultadoComision> Resultados { get; set; } = new List<ResultadoComision>();
    }

    public class ResultadoComision
    {
        public string Vendedor { get; set; }
        public decimal TotalVentas { get; set; }
        public decimal TotalComision { get; set; }
        public List<DetalleVenta> Ventas { get; set; } = new List<DetalleVenta>();
    }

    public class DetalleVenta
    {
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public decimal Comision { get; set; }
        public decimal PorcentajeAplicado { get; set; }
    }
}
