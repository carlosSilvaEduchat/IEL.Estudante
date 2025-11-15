using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Adicione esta linha
using IEL.Estudantes.Data;
using IEL.Estudantes.Models;

namespace IEL.Estudantes.Services
{
    public class CpfService : ICpfService
    {
        private readonly AppDbContext _context;

        public CpfService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CpfExistsAsync(string cpf, int? currentId = null)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            // Remove a máscara do CPF para comparação
            var cpfSemMascara = Regex.Replace(cpf, @"[^\d]", "");

            var query = _context.Estudantes
                .Where(e => e.CPF.Replace(".", "").Replace("-", "") == cpfSemMascara);

            // Se estiver editando, não considerar o próprio registro
            if (currentId.HasValue)
            {
                query = query.Where(e => e.Id != currentId.Value);
            }

            return await query.AnyAsync();
        }
    }
}