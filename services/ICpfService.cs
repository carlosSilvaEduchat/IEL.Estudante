// Services/ICpfService.cs
using System.Threading.Tasks;

namespace IEL.Estudantes.Services
{
    public interface ICpfService
    {
        Task<bool> CpfExistsAsync(string cpf, int? currentId = null);
    }
}