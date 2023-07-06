using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Json;
using ApiTest.Resource;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("api/sections")]
    public class SectionsController : ControllerBase
    {
        [HttpGet(Name = "GetSection")]
        public dynamic listSection()
		{

           DataTable tSection = Resource.Conn.Listar("Areas_BuscarTodos");
            string jsonSection = JsonConvert.SerializeObject(tSection);

            return new
            {
                status = 200,
                message = "success",
                result = new
                {
                    section = JsonConvert.DeserializeObject<List<Models.Sections>>(jsonSection)
                }

            };


        }

        [HttpPost(Name = "PostSection")]
        public dynamic addSection([FromBody] Models.Sections sections)
        {
            var activo = 0;
            if(sections.Activo == true)
            {
                activo = 1;
            }else if(sections.Activo == false){
                activo = 0;
            }
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@ID_Empresa", sections.ID_Empresa.ToString()),
                new Parametro("@ID_Establecimiento", sections.ID_Establecimiento.ToString()),
                new Parametro("@RazonSocial", sections.RazonSocial),
                new Parametro("@Activo", activo.ToString())

            };

          

            var function = Resource.Conn.Ejecutar("Areas_Agregar", parametros);
            if(function == false)
            {
                return new
                {
                    status = 401,
                    message = "error"
                };
            }
            else
            {
                return new
                {
                    status = 200,
                    message = "success"
                };
            }
            
          
        }
    }
}

