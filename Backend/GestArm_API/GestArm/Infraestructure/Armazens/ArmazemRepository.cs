using GestArm.Domain.Armazens;
using GestArm.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace GestArm.Infrastructure.Armazens;

public class ArmazemRepository : BaseRepository<Armazem, ArmazemId>, IArmazemRepository
{
    private readonly GestArmDbContext _context;

    public ArmazemRepository(GestArmDbContext context) : base(context.Armazens)
    {
        _context = context;
    }

    public Task<Armazem> GetByIdAsync(ArmazemId id)
    {
        Armazem armazem = _context.Armazens.Where(a => a.Id == id).FirstOrDefault();
        return Task.FromResult(armazem);
    }

    /*
    public Task<Armazem> GetByAlphaNumIdAsync(AlphaId alphaNumId)
    {
        Armazem armazem = _context.Armazens.AsEnumerable().FirstOrDefault(a => a.AlphaNumId.Equals(alphaNumId));
        return Task.FromResult(armazem);
    }
    */

    public Task<Armazem> GetByDesignacaoAsync(DesignacaoArmazem designacao)
    {
        Armazem armazem = _context.Armazens.Where(a => a.Designacao.Equals(designacao)).FirstOrDefault();
        return Task.FromResult(armazem);
    }

    public Task<List<Armazem>> GetAllAsync()
    {
        List<Armazem> armazens = _context.Armazens.ToList();
        return Task.FromResult(armazens);
    }


    public async Task<Armazem> AddAsync(Armazem armazem)
    {

        _context.Armazens.Add(armazem);
        await _context.SaveChangesAsync();
        return armazem;
    }

    public Task<Armazem> UpdateAsync(Armazem armazem)
    {
        throw new NotImplementedException();
    }

    public Task<Armazem> RemoveAsync(ArmazemId id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(ArmazemId id)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Armazem>> GetAllAsync(int page, int size)
    {
        throw new NotImplementedException();
    }
    
    public async Task<Armazem> GetByArmazemIdAsync(AlphaId armazemId)
    {
        return await _context.Armazens.Where(r => r.AlphaNumId.Equals(armazemId)).FirstOrDefaultAsync();
    }
    
}