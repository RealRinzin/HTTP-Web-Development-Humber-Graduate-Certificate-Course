using ApiConnection.Services;
using Microsoft.AspNetCore.Mvc;
namespace ApiConnection.Controllers;

/** This controller is responsible for handling requests related to the Rapid API and returning the appropriate views. 
 * It uses the RapidApiService to retrieve data from the API and pass it to the views for display.
 */
public class RapidApiController : Controller
{
    /** Declare a property of type RapidApiService to be used for retrieving data from the API.
     * The constructor for the RapidApiController class takes a RapidApiService object as a parameter and assigns it to the service property. 
     * This allows the controller to use the service to retrieve data from the API when handling requests.
     */
    public RapidApiService service { get; set; }
    // The constructor for the RapidApiController class takes a RapidApiService object as a parameter and assigns it to the service property. 
    // This allows the controller to use the service to retrieve data from the API when handling requests.
    public RapidApiController(RapidApiService service_)
    {
        // Assign the RapidApiService object passed as a parameter to the service property of the controller
        service = service_;
    }

    // Asynchronous method that handles requests to the ListJobs action and returns a view with the data retrieved from the API.
    // IactionResult is used to indicate that the method will return a result that can be rendered as a view, while Task<IActionResult> 
    // indicates that the method is asynchronous and will return a result in the future.
    public async Task<IActionResult> ListJobs()
    {
        var content = await service.getData();
        Console.WriteLine(content);
        return View(content);

    }
}

