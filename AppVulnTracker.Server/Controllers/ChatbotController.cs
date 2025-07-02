using AppVulnTracker.Server.Modelos;
using AppVulnTracker.Server.Sql;
using AppVulnTracker.Server.Utilidades;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json.Linq;
using OpenAI_API;
using OpenAI_API.Chat;
using Org.BouncyCastle.Asn1.Crmf;

namespace AppVulnTracker.Server.Controllers
{
    public class ChatbotController : ControllerBase
    {
        private readonly AplicationDbContext context;
        private readonly IConfiguration config;

        public ChatbotController(AplicationDbContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }
        public async Task<ActionResult> Responder(ChatbotDTO respuesta)
        {
            string? pregunta = respuesta.mensaje;

            // Paso 1: Generar la intención con GPT
            string prompt = @$"
                            Eres un asistente que interpreta preguntas sobre vulnerabilidades. 
                            Devuélveme un JSON con esta estructura:
                            {{
                              'accion': 'contar',
                              'filtro': {{
                                'severidad': 'crítica' | 'alta' | 'media' | 'baja' | null,
                                'estado': 'detectada' | 'en revisión' | 'mitigada' | 'cerrada' | null
                              }}
                            }}

                            Pregunta: {pregunta}";

            var cliente = new OpenAIAPI(config["OpenAI:ApiKey"]);
            var chat = await cliente.Chat.CreateChatCompletionAsync(new ChatRequest
            {
                Model = "gpt-4o",
                Messages = new List<ChatMessage>()
                {
                    new ChatMessage(ChatMessageRole.User, prompt)
                }
            });

            var jsonText = chat.Choices[0].Message.Content;
            var json = JObject.Parse(jsonText);

            string? severidad = json["filtro"]?["severidad"]?.ToString();
            string? estado = json["filtro"]?["estado"]?.ToString();

            // Paso 2: Consulta real en base de datos usando Dapper
            var sql = "SELECT COUNT(*) FROM vulnerabilidades WHERE 1=1";
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(severidad))
            {
                sql += " AND LOWER(severidad) = @Severidad";
                parameters.Add("Severidad", severidad.ToLower());
            }
            if (!string.IsNullOrEmpty(estado))
            {
                sql += " AND LOWER(estado) = @Estado";
                parameters.Add("Estado", estado.ToLower());
            }

            if (context._connection.State != System.Data.ConnectionState.Open)
                context._connection.Open();

            int total = await context._connection.ExecuteScalarAsync<int>(sql, parameters);

            // Paso 3: Pedirle a OpenAI una respuesta natural
            string responsePrompt = $"El usuario preguntó: {pregunta}. El resultado es: {total}. Devuelve una respuesta natural.";

            var finalReply = await cliente.Chat.CreateChatCompletionAsync(new ChatRequest()
            {
                Model = "gpt-4o",
                Messages = new List<ChatMessage>()
                {
                    new ChatMessage(ChatMessageRole.User, responsePrompt)
                }
            });

            return Ok(new { reply = finalReply.Choices[0].Message.Content });
        }
    }
}



