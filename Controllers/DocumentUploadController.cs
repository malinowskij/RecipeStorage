using RecipeStorageAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace RecipeStorageAPI.Controllers
{
    public class DocumentUploadController : ApiController
    {
        [Authorize]
        [HttpPost]
        [Route("api/DocumentUpload/MediaUpload")]
        public async Task<HttpResponseMessage> MediaUpload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = await Request.Content.ReadAsMultipartAsync<InMemoryMultipartFormDataStreamProvider>(new InMemoryMultipartFormDataStreamProvider());
            
            NameValueCollection formData = provider.FormData;
           
            IList<HttpContent> files = provider.Files;

            HttpContent file1 = files[0];
            var thisFileName = file1.Headers.ContentDisposition.FileName.Trim('\"');

            string filename = String.Empty;
            Stream input = await file1.ReadAsStreamAsync();
            string directoryName = String.Empty;
            string URL = String.Empty;
            string tempDocUrl = WebConfigurationManager.AppSettings["DocsUrl"];

            if (formData["ClientDocs"] == "ClientDocs")
            {
                var path = HttpRuntime.AppDomainAppPath;
                directoryName = System.IO.Path.Combine(path, "ClientDocument");
                filename = System.IO.Path.Combine(directoryName, thisFileName);

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                string DocsPath = tempDocUrl + "/" + "ClientDocument" + "/";
                URL = DocsPath + thisFileName;

            }

            using (Stream file = File.OpenWrite(filename))
            {
                input.CopyTo(file);
                //close file  
                file.Close();
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("DocsUrl", URL);
            response.Headers.Add("Access-Control-Expose-Headers", "Access-Token, Uid");
            response.Content = new StringContent(URL, Encoding.UTF8);
            return response;
        }

    }
}
