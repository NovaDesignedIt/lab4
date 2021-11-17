using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab5.Data;
using Lab5.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Azure;
using System.IO;

namespace Lab5.Pages.AnswerImages
{
    public class CreateModel : PageModel
    {
        private readonly Lab5.Data.AnswerImageDataContext _context;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string earthContainerName = "earthimages";
        private readonly string computerContainerName = "computerimages";
        public CreateModel(Lab5.Data.AnswerImageDataContext context, BlobServiceClient  blobServiceClient)
        {
            _context = context;

            _blobServiceClient = blobServiceClient;


        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AnswerImage AnswerImage { get; set; }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(AnswerImage answerImage)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            var file = HttpContext.Request.Form.Files[0];
            var containerName = answerImage.Question == Question.Computer ? computerContainerName : earthContainerName;

            BlobContainerClient containerClient;
            // Create the container and return a container client object
            try
            {
                containerClient = await _blobServiceClient.CreateBlobContainerAsync(containerName);
                // Give access to public
                containerClient.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);
            }
            catch (RequestFailedException)
            {
                containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            }


            try
            {
                string fileName = file.FileName;
                // create the blob to hold the data
                var blockBlob = containerClient.GetBlobClient(fileName);
                if (await blockBlob.ExistsAsync())
                {
                    await blockBlob.DeleteAsync();
                }

                using (var memoryStream = new MemoryStream())
                {
                    // copy the file data into memory
                    await file.CopyToAsync(memoryStream);

                    // navigate back to the beginning of the memory stream
                    memoryStream.Position = 0;

                    // send the file to the cloud
                    await blockBlob.UploadAsync(memoryStream);
                    memoryStream.Close();
                }

                // add the photo to the database if it uploaded successfully
                var image = new AnswerImage
                {
                    Url = blockBlob.Uri.AbsoluteUri,
                    FileName = fileName,
                    Question = answerImage.Question
                };

                _context.AnswerImage.Add(image);
                await _context.SaveChangesAsync();
            }
            catch (RequestFailedException)
            {
                return RedirectToPage("Error");
            }

            return RedirectToPage("./Index");
        }
    }
}
