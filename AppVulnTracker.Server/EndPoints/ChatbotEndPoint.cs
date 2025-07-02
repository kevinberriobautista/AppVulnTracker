using AppVulnTracker.Server.Controllers;
using AppVulnTracker.Server.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace AppVulnTracker.Server.EndPoints
{
    [ApiController]
    [Route("api/chatbot")]
    public class ChatbotEndPoint
    {
        private readonly ChatbotController chatbotController;

        public ChatbotEndPoint(ChatbotController parametroChatbotController)
        {
            chatbotController = parametroChatbotController;
        }

        [HttpPost()]
        public async Task<ActionResult<string>> PostRespuesta(ChatbotDTO chatbot)
        {
            return await chatbotController.Responder(chatbot);
        }
    }
}
