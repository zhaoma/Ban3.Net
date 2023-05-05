using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Reports;
using Microsoft.AspNetCore.Mvc;

namespace Ban3.Labs.TeamFoundationCollector.Presentation.Report.Controllers
{
    public class HomeController : Controller
    {
        #region tfvc

        public IActionResult Index( string id )
        {
            if (string.IsNullOrEmpty(id))
                id = Platforms.TeamFoundationCollector.Domain.Contract.Config.DefaultTeam;
            
            var filter = new TfvcFilter
            {
                    LimitTeamNames = new List<string> { id },
                    //FromDate = new DateTime( now.Year, now.Month, 1 ).ToString( "yyyy-MM-dd" ),
                    //ToDate = now.ToString( "yyyy-MM-dd" )
            };

            return View( filter );
        }

        /// <summary>
        /// 显示team 列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Teams( string id )
        {
            var allTeams = DevOps.Reportor.Core.LoadTeams();

            return string.IsNullOrEmpty( id )
                           ? View( allTeams )
                           : View( id, allTeams );
        }
        
        /// <summary>
        /// 显示组员列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IActionResult Identities( TfvcFilter filter )
        {
            var allTeam = _exportService.AllTeams();

            if( filter.LimitTeamIds != null && filter.LimitTeamIds.Any() )
            {
                allTeam = allTeam.FindAll( o => filter.LimitTeamIds.Any( x => x == o.Team.Id ) );
            }
            else
            {
                allTeam = allTeam.FindAll( o => o.Team.Name == Domain.Platform.Config.CurrrentEnvironment.DefaultTeamName );
            }

            return View( allTeam );
        }

        /// <summary>
        /// 输出内容列表(changeset/shelveset)
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IActionResult Table( TfvcFilter filter )
        {
            var report = _exportService.GenerateReport( filter );

            return View( report );
        }

        /// <summary>
        /// export Excel
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IActionResult Excel( TfvcFilter filter )
        {
            var excel = _exportService.GenerateExcel( filter );

            return new FileStreamResult( excel, "application/vnd.ms-excel" );
        }

        #endregion
    }
}