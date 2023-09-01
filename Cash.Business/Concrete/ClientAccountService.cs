using Cash.DataAccess.Abstract;
using Cash.Entity.Concrate;

namespace Cash.Business.Concrete;

public class ClientAccountService : IClientAccountService
{
    private readonly IClientAccountDal _clientAccountDal;

    public ClientAccountService(IClientAccountDal clientAccountDal)
    {
        _clientAccountDal = clientAccountDal;
    }

    public void TAdd(ClientAccount entity)
    {
        _clientAccountDal.Add(entity);
    }

    public void TDelete(ClientAccount entity)
    {
        _clientAccountDal.Delete(entity);
    }

    public List<ClientAccount> TGetAll()
    {
        return _clientAccountDal.GetAll();
    }

    public ClientAccount TGetById(Guid id)
    {
        return _clientAccountDal.GetById(id);
    }

    public void TUpdate(ClientAccount entity)
    {
        _clientAccountDal.Update(entity);
    }
}
