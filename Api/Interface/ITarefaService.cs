using System.Collections.Generic;
using WebApi.Entities;

namespace Api.Interface
{
    public interface ITarefaService
    {
        List<Tarefa> GetAll();
        Tarefa GetById(int id);
        void Create(Tarefa tarefa);
        void Update(Tarefa tarefa);
        void Delete(Tarefa tarefa);
    }
}