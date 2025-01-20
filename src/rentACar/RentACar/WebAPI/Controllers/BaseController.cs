using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

//BU classin meqsedi butun controllerlerde inject elediyimizi burada bir defe eliyim her birine miras vere vilerik
//IMediator inject etmesek , commandi mediatora gonderende mediator.send() olan metodu gelmiyecek.
public class BaseController:ControllerBase
{
    private IMediator? _mediator;
    //protected ona gore yaziriqki kimler miras alib onlar istifade edsin
    //eger set edilmis varsa onu geri qaytar yoxdursa, get httpcontexden reqeust servislerinde getservicelere bax uygun olan birin tap set ele
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

}
