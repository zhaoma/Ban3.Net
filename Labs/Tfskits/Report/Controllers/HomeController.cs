using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using Tfvckits.Domain.Platform.Interfaces;
using Tfvckits.Domain.Platform.Request.Reports;
using log4net;
using Tfvckits.Domain.LocalAgent.Request;

namespace Tfvckits.Presentation.WebReport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _logger= LogManager.GetLogger(typeof(HomeController));

        private readonly IExportService _exportService;

        public HomeController(
            IExportService exportService
            )
        {
            _exportService = exportService;
        }

        #region tfvc

        public IActionResult Index( string id )
        {
            var now = DateTime.Now;
            var allTeams = _exportService.AllTeams();

            if( string.IsNullOrEmpty( id ) )
                id = Domain.Platform.Config.CurrrentEnvironment.DefaultTeamName;

            var team = allTeams.FindLast( o => o.Team.Name == id );

            var filter = new DataFilter
            {
                    LimitTeamIds = new List<string> { team.Team.Id },
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
            var allTeams = _exportService.AllTeams();

            return string.IsNullOrEmpty( id )
                           ? View( allTeams )
                           : View( id, allTeams );
        }

        /// <summary>
        /// 关注团队/取消关注
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Follow( string id )
        {
            return Ok( _exportService.Follow( id ) );
        }

        /// <summary>
        /// 显示组员列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IActionResult Identities( DataFilter filter )
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
        public IActionResult Table( DataFilter filter )
        {
            var report = _exportService.GenerateReport( filter );

            return View( report );
        }

        /// <summary>
        /// export Excel
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IActionResult Excel( DataFilter filter )
        {
            var excel = _exportService.GenerateExcel( filter );

            return new FileStreamResult( excel, "application/vnd.ms-excel" );
        }

        #endregion

        public IActionResult WhatIs(QueryAnything request)
        {
            return View(request);
        }
    }
}