using BunnyCDN.Net.Storage;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SmartEdu.Models;
using RestSharp;
namespace SmartEdu.Services.BunnyService
{
    public class BunnyService : IBunnyService
    {
        public async Task<ServerResponse<IEnumerable<string>>> UploadFiles(MultipleFilesModel model, string path, string fileName, ModelStateDictionary modelState)
        {
            var bunnyCDNStorage = new BunnyCDNStorage("leonghia", "d1762d53-2d02-4f4e-a8e8d7cc7efe-0bed-4325", "de");
            var serverResponse = new ServerResponse<IEnumerable<string>>();

            if (modelState.IsValid)
            {
                if (model.Files.Count > 0)
                {
                    var imageLinks = new List<string>();
                    var file = model.Files.ElementAt(0);

                    using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        var fileExtension = Path.GetExtension(file.FileName);

                        // Delete the existing image with the same name (if any)
                        await bunnyCDNStorage.DeleteObjectAsync($"/leonghia/images/plant_nest/{path}/{fileName}{fileExtension}");

                        // Upload the new image
                        await bunnyCDNStorage.UploadAsync(ms, $"/leonghia/images/plant_nest/{path}/{fileName}{fileExtension}");

                        // Purge cache on BunnyCDN
                        var options = new RestClientOptions($"https://api.bunny.net/purge?url=https%3A%2F%2Fnghia.b-cdn.net%2Fimages%2Fplant_nest%2F{path}%2F{fileName}{fileExtension}&async=false");
                        var client = new RestClient(options);
                        var request = new RestRequest("");
                        request.AddHeader("accept", "application/json");
                        request.AddHeader("AccessKey", "750146ff-4a46-443d-b930-90a2d32c147448497d22-c5df-4389-a112-215b9c8d5abe");
                        var response = await client.GetAsync(request);


                        imageLinks.Add($"https://nghia.b-cdn.net/images/plant_nest/{path}/{fileName}{fileExtension}");
                    }


                    serverResponse.Data = imageLinks;
                    return serverResponse;
                }
                serverResponse.Succeeded = false;
                serverResponse.Message = "Please select at least 1 file to upload.";

            }
            else
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid.";
            }
            return serverResponse;
        }

        public async Task<ServerResponse<IEnumerable<string>>> UploadMultipleFiles(MultipleFilesModel model, string path, ModelStateDictionary modelState)
        {
            var bunnyCDNStorage = new BunnyCDNStorage("leonghia", "d1762d53-2d02-4f4e-a8e8d7cc7efe-0bed-4325", "de");
            var serverResponse = new ServerResponse<IEnumerable<string>>();

            if (modelState.IsValid)
            {
                if (model.Files.Count > 0)
                {
                    var imageLinks = new List<string>();
                    foreach (var file in model.Files)
                    {

                        using (var ms = new MemoryStream())
                        {
                            await file.CopyToAsync(ms);
                            ms.Seek(0, SeekOrigin.Begin);
                            

                            // Delete the existing image with the same name (if any)
                            await bunnyCDNStorage.DeleteObjectAsync($"/leonghia/images/plant_nest/{path}/{file.FileName}");

                            // Upload the new image
                            await bunnyCDNStorage.UploadAsync(ms, $"/leonghia/images/plant_nest/{path}/{file.FileName}");

                            // Purge cache on BunnyCDN
                            var options = new RestClientOptions($"https://api.bunny.net/purge?url=https%3A%2F%2Fnghia.b-cdn.net%2Fimages%2Fplant_nest%2F{path}%2F{file.FileName}&async=false");
                            var client = new RestClient(options);
                            var request = new RestRequest("");
                            request.AddHeader("accept", "application/json");
                            request.AddHeader("AccessKey", "750146ff-4a46-443d-b930-90a2d32c147448497d22-c5df-4389-a112-215b9c8d5abe");
                            var response = await client.GetAsync(request);


                            imageLinks.Add($"https://nghia.b-cdn.net/images/plant_nest/{path}/{file.FileName}");
                        }
                    }

                    serverResponse.Data = imageLinks;
                    return serverResponse;
                }
                serverResponse.Succeeded = false;
                serverResponse.Message = "Please select at least 1 file to upload.";

            }
            else
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Submitted data is invalid.";
            }
            return serverResponse;
        }
    }
}
