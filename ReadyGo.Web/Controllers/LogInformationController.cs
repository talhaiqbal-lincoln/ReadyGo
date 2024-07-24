using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Entities.ViewModels;

namespace ReadyGo.Web.Controllers
{
    [Authorize]
    public class LogInformationController : BaseController
    {
     
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetLogs()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var status = Request.Form["status"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search"].FirstOrDefault().Trim();
                int pageSize = Convert.ToInt32(length ?? "0");
                int skip = Convert.ToInt32(start ?? "0");
                int recordsTotal = 0;

                var userLogs = _logsRepo.FindAll(u => u.DeletedAt == null && string.IsNullOrEmpty(u.Exception))
                    .Include(x => x.ChangedBy).ThenInclude(x => x.Role)
                    .Select(x => new LogInformationViewModel
                    {
                        ChangedBy = x.ChangedBy.FirstName + " " + x.ChangedBy.LastName,
                        RoleName = x.ChangedBy.Role.NormalizedName,
                        ActionSource = x.ActionSource,
                        Action = x.Action,
                        IPAddress = x.IPAddress,
                        CreatedAt = x.CreatedAt
                    }).ToList();


                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    int column = Int32.Parse(sortColumn);
                    switch (column)
                    {
                        case 0:
                            userLogs = (sortColumnDirection == "asc" ? userLogs.OrderBy(c => c.ChangedBy) : userLogs.OrderByDescending(c => c.ChangedBy)).ToList();
                            break;
                        case 5:
                            userLogs = (sortColumnDirection == "asc" ? userLogs.OrderBy(c => c.CreatedAt) : userLogs.OrderByDescending(c => c.CreatedAt)).ToList();
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    userLogs = userLogs.Where(m => m.ChangedBy.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                        || m.RoleName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                        || m.ActionSource.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                        || m.Action.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                        || m.IPAddress.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                recordsTotal = userLogs.Count();
                var data = userLogs.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;            }
        }
    }
}
