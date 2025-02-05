using InfoDengue.Entities;

namespace InfoDengue.Interfaces.Repositories;

public interface IRelatorioRepository : IBaseRepository<Relatorio>
{
    Relatorio BuscarCpf(string cpf);
}