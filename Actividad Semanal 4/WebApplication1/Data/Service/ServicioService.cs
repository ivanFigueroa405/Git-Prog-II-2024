using WebApiTurnos.Data.Models;
using WebApiTurnos.Data.Repositories;

namespace WebApiTurnos.Data.Service
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repository;

        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(TServicio oServicio)
        {
            return await _repository.Create(oServicio);
        }

        public async Task <bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task< List<TServicio>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<List<TServicio>> GetByActive(bool active)
        {
            return await _repository.GetByActive(active);
        }

        public async Task<List<TServicio>> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<List<TServicio>> GetName(string name)
        {

            return await _repository.GetName(name);
        }

        public async Task<bool> Update(int? id, TServicio oServicio)
        {
            return await _repository.Update(id, oServicio);
        }
    }
}
