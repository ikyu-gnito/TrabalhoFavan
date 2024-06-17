using System.ComponentModel.DataAnnotations;

namespace Cartorio_CRUD.Models
{
    public class RegistroModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Produto { get; set; }

        public string Email { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;
    }
}
