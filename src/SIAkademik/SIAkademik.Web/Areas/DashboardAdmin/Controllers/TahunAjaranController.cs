using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAkademik.Domain.Abstracts;
using SIAkademik.Domain.Authentication;
using SIAkademik.Domain.ModulSiakad.Repositories;

namespace SIAkademik.Web.Areas.DashboardAdmin.Controllers;

[Area(AreaNames.DashboardAdmin)]
[Authorize(Roles = AppUserRoles.Admin)]
public class TahunAjaranController : Controller
{
    private readonly ITahunAjaranRepository _tahunAjaranRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TahunAjaranController(
        ITahunAjaranRepository tahunAjaranRepository,
        IUnitOfWork unitOfWork)
    {
        _tahunAjaranRepository = tahunAjaranRepository;
        _unitOfWork = unitOfWork;
    }


    public IActionResult Index()
    {
        return View();
    }
}
