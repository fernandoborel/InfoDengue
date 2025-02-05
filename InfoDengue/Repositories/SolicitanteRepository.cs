using InfoDengue.Context;
using InfoDengue.Entities;
using InfoDengue.Interfaces.Repositories;

namespace InfoDengue.Repositories;

public class SolicitanteRepository : BaseRepository<Solicitante>, ISolicitanteRepository
{
    private readonly InfoDengueDbContext _context;

    public SolicitanteRepository(InfoDengueDbContext context) : base(context)
      => _context = context;

    public Solicitante GetCpfAsync(string cpf)
    {
        var cpfSolicitante = _context.Solicitantes.FirstOrDefault(s => s.Cpf == cpf);
        return cpfSolicitante;
    }

    override public void Create(Solicitante entity)
    {
        var cpfSolicitante = GetCpfAsync(entity.Cpf);
        if(cpfSolicitante != null)
            throw new Exception("CPF já cadastrado");

        base.Create(entity);
    }
}