using Azure;
using Azure.AI.OpenAI;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Models;
using OpenAI.Images;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller for managing car operations
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CarController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Gets a description of a basic car
        /// </summary>
        /// <returns>A description string that includes details about the car's cylinders and doors</returns>
        /// <remarks>
        /// The BasicCar has the following properties:
        /// - 4 cylinders
        /// - 2 doors
        /// - Basic honker for beeping
        /// - Speed calculated based on cylinder count
        /// 
        /// Sample response:
        /// 
        ///     "Basic old looking car with 4 cylinders and 2 doors."
        /// </remarks>
        [HttpGet("basic", Name = "GetBasicCarDescription")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public string GetBasicCarDescription()
        {
            BasicCar basicCar = new(new BasicHonker()); // 4 cylinders and 2 doors and custom cheap honker
            return basicCar.GetDescription();
        }

        [HttpGet("upgraded", Name = "GetUpgradedCarDescription")]
        public string GetUpgradedCarDescription()
        {
            UpgradedCar upgradedCar = new(new UpgradedEngine(6), new UpgradedDoor(6), new UpgradedHonker(6));
            return upgradedCar.GetDescription();
        }

        /// <summary>
        /// Generates an AI image of a car using Azure OpenAI DALL-E
        /// </summary>
        /// <returns>URL of the generated car image</returns>
        /// <response code="200">Returns the URL of the generated image</response>
        /// <response code="500">If there was an error generating the image</response>
        [HttpGet("generate-image", Name = "GenerateCarImage")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GenerateCarImagesUsingClient()
        {
            BasicCar basicCar = new(new BasicHonker()); // 4 cylinders and 2 doors and custom cheap honker

            try
            {
                string? endpoint = _configuration["AzureOpenAI:Endpoint"];
                string? deploymentName = _configuration["AzureOpenAI:DeploymentName"];
                string? apiKey = _configuration["AzureOpenAI:ApiKey"];

                if (string.IsNullOrEmpty(endpoint))
                {
                    return StatusCode(500, "Azure OpenAI endpoint not configured");
                }

                if (string.IsNullOrEmpty(apiKey))
                {
                    return StatusCode(500, "Azure OpenAI API key not configured");
                }

                if (string.IsNullOrEmpty(deploymentName))
                {
                    return StatusCode(500, "Azure OpenAI deployment name not configured");
                }

                // Create the Azure OpenAI ImageClient
                ImageClient client = new AzureOpenAIClient(new Uri(endpoint), new AzureKeyCredential(apiKey))
                    .GetImageClient(deploymentName);

                // Generate the image
                GeneratedImage generatedImage = await client.GenerateImageAsync(
                    basicCar.GetDescription(),
                    new ImageGenerationOptions { Size = GeneratedImageSize.W1024xH1024 });

                // Get the URL of the generated image
                Uri imageUrl = generatedImage.ImageUri;

                return imageUrl == null ? StatusCode(500, "Failed to generate image") : (IActionResult)Ok(imageUrl.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating image: {ex.Message}");
            }
        }
    }
}
