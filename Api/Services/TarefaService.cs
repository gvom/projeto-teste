
using System.Collections.Generic;
using System.Linq;
using Api.Configuration;
using Api.Interface;
using Microsoft.Extensions.Options;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly AplicacaoContext _context;
        private readonly AppSettings _appSettings;

        public TarefaService(IOptions<AppSettings> appSettings, AplicacaoContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public List<Tarefa> GetAll() {

            return this._context.Tarefa.ToList();
        }

        public Tarefa GetById(int id) {

            return this._context.Tarefa.FirstOrDefault(tarefa => tarefa.Id == id);
        }

        public void Create(Tarefa tarefa){

            this._context.Tarefa.Add(tarefa);
            this._context.SaveChanges();
        }

        public void Update(Tarefa tarefa){
            this._context.Tarefa.Update(tarefa);
            this._context.SaveChanges();
        }

        public void Delete(Tarefa tarefa){

            this._context.Tarefa.Remove(tarefa);
            this._context.SaveChanges();
        }
    }
}