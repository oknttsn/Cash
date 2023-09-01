using Cash.DataAccess.Abstract;
using Cash.Entity.Concrate;

namespace Cash.Business.Concrete;

public class AccountProcessService : IAccountProcessService
{
    private readonly IAccountProcessDal _accountProcessDal;

    public AccountProcessService(IAccountProcessDal accountProcessDal)
    {
        _accountProcessDal = accountProcessDal;
    }

    public void TAdd(AccountProcess entity)
    {
        _accountProcessDal.Add(entity);
    }

    public void TDelete(AccountProcess entity)
    {
        _accountProcessDal.Delete(entity);
    }

    public List<AccountProcess> TGetAll()
    {
        return _accountProcessDal.GetAll();
    }

    public AccountProcess TGetById(Guid id)
    {
       return _accountProcessDal.GetById(id);
    }

    public void TUpdate(AccountProcess entity)
    {
        _accountProcessDal.Update(entity);
    }
}
