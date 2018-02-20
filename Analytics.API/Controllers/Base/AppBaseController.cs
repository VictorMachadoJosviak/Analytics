using Analytics.Core.Interfaces.Services;
using Analytics.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Analytics.API.Controllers.Base
{
    public class AppBaseController : ApiController
    {
        // GET: AppBase
        private readonly IUnitOfWork _unitOfWork;
        private IServiceBase _serviceBase;

        public AppBaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HttpResponseMessage> ResponseAsync(object result, IServiceBase serviceBase)
        {
            _serviceBase = serviceBase;
            try
            {
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                // Aqui devo logar o erro
                return Request.CreateResponse(HttpStatusCode.Conflict,
                    "Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: " + ex.Message);
            }
        }

        public async Task<HttpResponseMessage> ResponseExceptionAsync(Exception ex)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { errors = ex.Message, exception = ex.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            //Realiza o dispose no serviço para que possa ser zerada as notificações
            if (_serviceBase != null)
            {
                _serviceBase.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}