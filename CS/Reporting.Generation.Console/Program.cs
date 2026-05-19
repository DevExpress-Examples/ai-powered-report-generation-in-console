using Reporting.Generation.Console;
using System;
using Azure.AI.OpenAI;
using DevExpress.AIIntegration.Reporting;
using System.ClientModel;
using Microsoft.Extensions.AI;
using DevExpress.AIIntegration.Reporting.Common.Extensions;
using DevExpress.AIIntegration;
using DevExpress.XtraReports.UI;


//configure chatClient
string endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT", EnvironmentVariableTarget.User) ?? throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT is not set.");
string apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY", EnvironmentVariableTarget.User) ?? throw new InvalidOperationException("AZURE_OPENAI_API_KEY is not set.");
string deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT", EnvironmentVariableTarget.User) ?? "gpt-5.2";

IChatClient chatClient = new AzureOpenAIClient(new Uri(endpoint), new ApiKeyCredential(apiKey))
    .GetChatClient(deploymentName)
    .AsIChatClient();

//register chat client and reporting extensions
AIExtensionsContainerDefault container = AIExtensionsContainerConsole.CreateDefaultAIExtensionContainer(chatClient);
container.RegisterReportingExtensions();



Console.WriteLine("Input a prompt for report generation:");
string prompt = Console.ReadLine();


try {

    //if you want to interact with llm
    ConsoleAIReportGenerationHost host = new ConsoleAIReportGenerationHost();

    PromptToReportRequest generationRequest = new PromptToReportRequest(userPrompt: prompt, dataSourceSchema: null, report: null) {
        ReportGenerationHost = host
    };

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

