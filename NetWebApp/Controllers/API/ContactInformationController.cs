using BLL;
using BLL.Interface;
using BLL.Model;
using NetWebApp.App_Start.Filter;
using NetWebApp.Models;
using System.Web.Http;

namespace NetWebApp.Controllers.API
{
    [RoutePrefix("api")]
    [EvolentExceptionFilter]
    public class ContactInformationController : ApiController
    {
        protected log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IContactRepository ContactRepository { get; set; }

        public ContactInformationController(ContactRepository repository)
        {
            ContactRepository = repository;
        }

        // GET: api/ContactInformation
        public IHttpActionResult Get()
        {
            var apiResponse = new ApiResponse();
            var list = ContactRepository.Get();
            apiResponse.Data = list;

            return Ok(apiResponse);
        }

        // GET: api/ContactInformation/5
        public IHttpActionResult Get(int id)
        {
            var contactInformation = ContactRepository.Get(id);
            var apiResponse = new ApiResponse();

            if (contactInformation == null)
            {
                apiResponse.Errors = new Errors { new Error {
                    ResponseCode  = ResponseCodes.ContactNotFound
                } };
            }

            apiResponse.Data = contactInformation;

            return Ok(apiResponse);
        }

        // POST: api/ContactInformation
        public IHttpActionResult Post(Contact value)
        {
            var validator = new ContactValidator();
            var apiResponse = new ApiResponse();

            //validate the model
            var results = validator.Validate(value);

            if (!results.IsValid)
            {
                apiResponse.Errors = new Errors(results.Errors);

                return Ok(apiResponse);
            }

            apiResponse.Data = ContactRepository.Add(value);

            return Ok(apiResponse);
        }

        // PUT: api/ContactInformation
        public IHttpActionResult Put(Contact contact)
        {
            var validator = new ContactValidator();
            var apiResponse = new ApiResponse();

            var results = validator.Validate(contact);

            if (!results.IsValid)
            {
                apiResponse.Errors = new Errors(results.Errors);

                return Ok(apiResponse);
            }

            var isUpdated = ContactRepository.Update(contact);

            if (!isUpdated)
            {
                apiResponse.Errors = new Errors { new Error {
                    ResponseCode  = ResponseCodes.ContactNotFound
                } };
            }

            return Ok(apiResponse);
        }

        // DELETE: api/ContactInformation/5
        public IHttpActionResult Delete(int id)
        {
            var apiResponse = new ApiResponse();
            var contactInformation = ContactRepository.Delete(id);

            if (!contactInformation)
            {
                apiResponse.Errors = new Errors { new Error {
                    ResponseCode  = ResponseCodes.ContactNotFound
                } };
            }

            return Ok(apiResponse);
        }
    }
}
