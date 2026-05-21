using Reporting.Generation.Console;
using Azure.AI.OpenAI;
using System.ClientModel;
using Microsoft.Extensions.AI;
using DevExpress.AIIntegration.Reporting.Common.Extensions;
using DevExpress.AIIntegration;
using DevExpress.XtraReports.UI;

// Retrieve the Azure OpenAI endpoint, key, and model from user environment variables.
string endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT", EnvironmentVariableTarget.User) ?? throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT is not set.");
string apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY", EnvironmentVariableTarget.User) ?? throw new InvalidOperationException("AZURE_OPENAI_API_KEY is not set.");
string deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT", EnvironmentVariableTarget.User) ?? "gpt-5.2";

// Create an Azure OpenAI client to work with the chat agent.
IChatClient chatClient = new AzureOpenAIClient(new Uri(endpoint), new ApiKeyCredential(apiKey))
    .GetChatClient(deploymentName)
    .AsIChatClient();

// Register chat client and reporting extensions.
AIExtensionsContainerDefault container = AIExtensionsContainerConsole.CreateDefaultAIExtensionContainer(chatClient);
container.RegisterReportingExtensions();

// Ask the user for a report description in natural language.
Console.WriteLine("Specify a prompt to generate the report:");
string prompt = Console.ReadLine();
try {
    // Create a host to handle clarification questions and progress notifications.
    ConsoleAIReportGenerationHost host = new ConsoleAIReportGenerationHost();

    // Build a generation request from the user prompt.
    PromptToReportRequest generationRequest = new PromptToReportRequest(userPrompt: prompt, dataSourceSchema: null, report: null) {
        ReportGenerationHost = host,
        FixLayoutErrors = true
    };

    // Generate a report layout and save it to a REPX file.
    XtraReport report = await container.GeneratePromptToReportAsync(generationRequest, default);
    report.SaveLayoutToXml("generatedReport.repx");
}
catch(Exception ex) {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
    Console.WriteLine();
}

Console.ReadLine();

