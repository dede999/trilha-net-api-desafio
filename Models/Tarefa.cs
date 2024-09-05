using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrilhaApiDesafio.Models.DTOs;

namespace TrilhaApiDesafio.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }
        
        public Tarefa(string titulo, string descricao, EnumStatusTarefa status)
        {
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
            Data = DateTime.UtcNow;
        }
    }
}