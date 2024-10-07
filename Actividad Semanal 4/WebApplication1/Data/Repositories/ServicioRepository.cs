using Microsoft.EntityFrameworkCore;
using WebApiTurnos.Data.Models;

namespace WebApiTurnos.Data.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        //private readonly ITurnosDbContextProcedures db;
        private readonly Turnos_DbContext _ServicioDbContext;
        public ServicioRepository(Turnos_DbContext servicioDbContext /*, ITurnosDbContextProcedures db*/)
        {
            _ServicioDbContext = servicioDbContext;
            //this.db = db;
        }
        public async Task<bool> Create(TServicio oServicio)
        {
            if (oServicio != null)
            {
                _ServicioDbContext.TServicios.Add(oServicio);
                return await _ServicioDbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var servicio = await _ServicioDbContext.TServicios.FindAsync(id);
            if (servicio != null)
            {
                servicio.Activo= false;
                _ServicioDbContext.Update(servicio);
                return await _ServicioDbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<TServicio>> GetAll()
        {
            return await _ServicioDbContext.TServicios.ToListAsync();
        }

        public async Task<List<TServicio>> GetByActive(bool active)
        {
            var lista= await _ServicioDbContext.TServicios.Where(x=>x.Activo==active).ToListAsync();
            return lista;
        }
        public async Task<List<TServicio>> GetName(string name)
        {
            var lista = await _ServicioDbContext.TServicios.Where(x=>x.Nombre==name).ToListAsync();
            return lista;
        }
        

        public async Task<List<TServicio>> GetById(int id)
        {
            var lista= await _ServicioDbContext.TServicios.Where(x=>x.Id==id).ToListAsync();
            return lista;
        }

        public async Task<bool> Update(int? id, TServicio oServicio)
        {
            var servicio = await _ServicioDbContext.TServicios.FindAsync(id);
            if (servicio != null)
            {
                servicio.Nombre = oServicio.Nombre;
                servicio.Costo = oServicio.Costo;
                servicio.EnPromocion = oServicio.EnPromocion;
                _ServicioDbContext.Update(servicio);
                return await _ServicioDbContext.SaveChangesAsync()>0;
            }
            else
                return false;
        }
    }
}
