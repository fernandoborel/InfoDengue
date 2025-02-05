using InfoDengue.Entities;

namespace InfoDengue.Interfaces.Repositories;

public interface ISolicitanteRepository : IBaseRepository<Solicitante>
{
    Solicitante GetCpfAsync(string cpf);
}