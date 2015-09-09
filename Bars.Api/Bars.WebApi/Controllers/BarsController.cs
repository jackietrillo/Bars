using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Bars.WebApi.Models;
using Bars.Services;
using Bars.WebApi.Mappers;

namespace Bars.WebApi.Controllers
{
    public class BarsController : ApiController
    {       
        private IBarsFacade _barsFacade;
        public BarsController(IBarsFacade barsFacade)
        {
            _barsFacade = barsFacade;
        }
      
        [HttpGet]
        public HttpResponseMessage Get()
        {      
            var bars = new List<Bar>();
            foreach (var bar in _barsFacade.GetBars())
	        {
                bars.Add(DomainModelToApiModelMapper.Map(bar));
	        }
            return Request.CreateResponse(HttpStatusCode.OK, bars);
        }
      
        
        [HttpGet]
        public HttpResponseMessage Get(string name)
        {                    
            var existingBar = _barsFacade.GetBar(name);
            if (existingBar != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, DomainModelToApiModelMapper.Map(existingBar));
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.Content = new StringContent(String.Format("No Bar with name {0} was found.", name));              
                return response;
            }
        }
    
        [HttpPost]
        public HttpResponseMessage Add(Bar bar)
        {          
            var existingBar = _barsFacade.GetBar(bar.Name);
            if (existingBar == null)
            {
                _barsFacade.AddBar(bar.Name);
                var response = Request.CreateResponse(HttpStatusCode.Created);
                response.Content = new StringContent(String.Format("Bar {0} was addied successfully.", bar.Name));
                return response;
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.Content = new StringContent(String.Format("Bar with name {0} already exists.", bar.Name));                
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage Update(Bar bar)
        {
            var existingBar = _barsFacade.GetBar(bar.Name);
            if (existingBar != null)
            {
                _barsFacade.UpdateBar(bar.Name);
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(String.Format("Bar {0} was updated successfully.", bar.Name));
                return response;
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.Content = new StringContent(String.Format("An Bar with name {0} was not found.", bar.Name));            
                return response;
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(string name)
        {
            var bar = _barsFacade.GetBar(name);
            if (bar != null)
            {
                _barsFacade.DeleteBar(name);
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(String.Format("Bar {0} was deleted successfully.", name));
                return response;
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                response.Content = new StringContent(String.Format("A Bar with name {0} was not found.", name));               
                return response;
            } 
        }
        
    }
}