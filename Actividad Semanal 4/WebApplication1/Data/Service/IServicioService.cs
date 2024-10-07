using WebApiTurnos.Data.Models;

namespace WebApiTurnos.Data.Service
{
    public interface IServicioService
    {
        Task<bool> Create(TServicio oServicio);
        Task<bool> Delete(int id);
        Task<bool> Update(int? id, TServicio oServicio);
        Task<List<TServicio>> GetAll();
        Task<List<TServicio>> GetById(int id);
        Task<List<TServicio>> GetByActive(bool active);
        Task<List<TServicio>> GetName(string name);
    }
}
