Imports Azure.AI.OpenAI
Imports DevExpress.AIIntegration.Reporting
Imports DevExpress.XtraReports.UI
Imports Microsoft.Extensions.AI
Imports System.ClientModel

Module Program
    Async Function Main() As Task
        ' Retrieve the Azure OpenAI endpoint, key, and model from user environment variables.
        Dim endpoint As String = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT", EnvironmentVariableTarget.User)
        If String.IsNullOrEmpty(endpoint) Then
            Throw New InvalidOperationException("AZURE_OPENAI_ENDPOINT is not set.")
        End If
        Dim apiKey As String = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY", EnvironmentVariableTarget.User)
        If String.IsNullOrEmpty(apiKey) Then
            Throw New InvalidOperationException("AZURE_OPENAI_API_KEY is not set.")
        End If
        Dim deploymentName As String = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT", EnvironmentVariableTarget.User)
        If String.IsNullOrEmpty(deploymentName) Then
            deploymentName = "gpt-5-mini"
        End If
        ' Create an Azure OpenAI client for working with the chat agent.
        Dim chatClient As IChatClient =
            (New AzureOpenAIClient(New Uri(endpoint), New ApiKeyCredential(apiKey))) _
            .GetChatClient(deploymentName) _
            .AsIChatClient()
        ' Create an AI extension container and enable reporting extensions.
        Dim container As AIExtensionsContainerDefault =
            AIExtensionsContainerConsole.CreateDefaultAIExtensionContainer(chatClient)
        container.RegisterReportingExtensions()
        ' Ask the user for a report description in natural language.
        Console.WriteLine("Input a prompt for report generation:")
        Dim prompt As String = Console.ReadLine()
        Try
            ' Enable interactive clarification questions and progress notifications.
            Dim host As New ConsoleAIReportGenerationHost()
            ' Build a generation request from the user prompt.
            Dim generationRequest As New PromptToReportRequest(
                userPrompt:=prompt,
                dataSourceSchema:=Nothing,
                report:=Nothing
            ) With {
                .ReportGenerationHost = host,
                .FixLayoutErrors = True
            }
            ' Generate a report layout and save it to a REPX file.
            Dim report As XtraReport =
                Await container.GeneratePromptToReportAsync(generationRequest, Nothing)
            report.SaveLayoutToXml("generatedReport.repx")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        ' Keep the console window open.
        Console.ReadLine()
    End Function
End Module
