using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniCore_MR.Models;

namespace MiniCore_MR.Controllers
{
    public class ComisionesController : Controller
    {
        private readonly ComisionesContext _context;

        public ComisionesController(ComisionesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new ComisionViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Calcular(ComisionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reglas = _context.Reglas
                    .OrderByDescending(r => r.ValorMinimo)
                    .ToList();

                var ventas = _context.Ventas
                    .Include(v => v.Vendedor)
                    .Where(v => v.FechaVenta >= model.FechaInicio && v.FechaVenta <= model.FechaFin)
                    .ToList();

                var ventasPorVendedor = ventas.GroupBy(v => v.Vendedor);

                foreach (var grupo in ventasPorVendedor)
                {
                    var resultado = new ResultadoComision
                    {
                        Vendedor = grupo.Key.Usuario
                    };

                    foreach (var venta in grupo)
                    {
                        var detalle = new DetalleVenta
                        {
                            Fecha = venta.FechaVenta,
                            Monto = venta.Monto
                        };

                        foreach (var regla in reglas)
                        {
                            if (venta.Monto >= regla.ValorMinimo)
                            {
                                detalle.PorcentajeAplicado = regla.Porcentaje;
                                detalle.Comision = venta.Monto * (regla.Porcentaje / 100);
                                break;
                            }
                        }

                        resultado.TotalVentas += venta.Monto;
                        resultado.TotalComision += detalle.Comision;
                        resultado.Ventas.Add(detalle);
                    }

                    model.Resultados.Add(resultado);
                }
            }

            return View("Index", model);
        }
    }
}
