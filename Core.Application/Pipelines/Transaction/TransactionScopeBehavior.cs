using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Application.Pipelines.Transaction;

public class TransactionScopeBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> ,ITransactionalRequest
    where TRequest : IRequest<TResponse>, new()
{
    //request bir ITransactionalRequest ise Handle çalışır. 
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        using TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled); //async çalıştığımız için
        TResponse response;
        try
        {
            response = await next();
            transactionScope.Complete();
        }
        catch (Exception)
        {
            transactionScope.Dispose(); //başarısız olursa geri al, iptal et
            throw;
        }
        return response;
    }
}
