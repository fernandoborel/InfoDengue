using InfoDengue.Context;
using InfoDengue.Entities;
using InfoDengue.Interfaces.Repositories;

namespace InfoDengue.Repositories;

public class RelatorioRepository : BaseRepository<Relatorio>, IRelatorioRepository
{
    private readonly InfoDengueDbContext _context;

    public RelatorioRepository(InfoDengueDbContext context) : base(context)
      =>  _context = context;

    public Relatorio BuscarCpf(string cpf)
    {
        var cpfRelatorio = _context.Relatorios.FirstOrDefault(x => x.CpfSolicitante == cpf);
        return cpfRelatorio;
    }

    override public void Create(Relatorio entity)
    {
        var cpfRelatorio = BuscarCpf(entity.CpfSolicitante);
        if (cpfRelatorio != null)
            throw new Exception("CPF já cadastrado");
        base.Create(entity);
    }
}
