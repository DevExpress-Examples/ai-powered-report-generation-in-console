' Retrieve the Azure OpenAI endpoint, key, and model from user environment variables.
' Create an Azure OpenAI client to work with the chat agent.
' Register chat client and reporting extensions.
' Ask the user for a report description in natural language.
' Create a host to handle clarification questions and progress notifications.
' Build a generation request from the user prompt.
' Generate a report layout and save it to a REPX file.
' TODO: Error SkippedTokensTrivia 'try'
' TODO: Error SkippedTokensTrivia '{'
' TODO: Error SkippedTokensTrivia '{'
' TODO: Error SkippedTokensTrivia ';'
' TODO: Error SkippedTokensTrivia ';'
' TODO: Error SkippedTokensTrivia ';'
' TODO: Error SkippedTokensTrivia ';'
' TODO: Error SkippedTokensTrivia '}'
' TODO: Error SkippedTokensTrivia ';'
 ''' Cannot convert FieldDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 852
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 451
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\CommentConvertingVisitorWrapper.cs:line 26
''' 
''' Input:
''' 
''' // Retrieve the Azure OpenAI endpoint, key, and model from user environment variables.
''' string endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT", EnvironmentVariableTarget.User) ?? throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT is not set.");
''' 
'''   ''' Cannot convert FieldDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 852
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 451
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\CommentConvertingVisitorWrapper.cs:line 26
''' 
''' Input:
''' string apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY", EnvironmentVariableTarget.User) ?? throw new InvalidOperationException("AZURE_OPENAI_API_KEY is not set.");
''' 
'''   ''' Cannot convert FieldDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 852
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 451
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\CommentConvertingVisitorWrapper.cs:line 26
''' 
''' Input:
''' string deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT", EnvironmentVariableTarget.User) ?? "gpt-5.2";
''' 
'''   ''' Cannot convert FieldDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 852
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 451
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\CommentConvertingVisitorWrapper.cs:line 26
''' 
''' Input:
''' 
''' // Create an Azure OpenAI client to work with the chat agent.
''' Microsoft.Extensions.AI.IChatClient chatClient = new Azure.AI.OpenAI.AzureOpenAIClient(new Uri(endpoint), new System.ClientModel.ApiKeyCredential(apiKey))
'''     .GetChatClient(deploymentName)
'''     .AsIChatClient();
''' 
'''   ''' Cannot convert FieldDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 852
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 451
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\CommentConvertingVisitorWrapper.cs:line 26
''' 
''' Input:
''' 
''' // Register chat client and reporting extensions.
''' DevExpress.AIIntegration.AIExtensionsContainerDefault container = DevExpress.AIIntegration.AIExtensionsContainerConsole.CreateDefaultAIExtensionContainer(chatClient);
''' 
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in 'container.RegisterReporting...' at character 1344
''' 
''' 
''' Input:
''' container.RegisterReportingExtensions
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in '()' at character 1381
''' 
''' 
''' Input:
''' ();
''' 
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in 'Console.WriteLine' at character 1451
''' 
''' 
''' Input:
''' 
''' // Ask the user for a report description in natural language.
''' Console.WriteLine
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in '(' at character 1468
''' 
''' 
''' Input:
''' ("Specify a prompt to generate the report:");
''' 
'''   ''' Cannot convert FieldDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 852
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 451
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\CommentConvertingVisitorWrapper.cs:line 26
''' 
''' Input:
''' string prompt = Console.ReadLine();
''' try {
''' 
'''   ''' Cannot convert FieldDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 852
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 451
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\CommentConvertingVisitorWrapper.cs:line 26
''' 
''' Input:
'''     // Create a host to handle clarification questions and progress notifications.
'''     Reporting.Generation.Console.ConsoleAIReportGenerationHost host = new Reporting.Generation.Console.ConsoleAIReportGenerationHost();
''' 
'''   ''' Cannot convert FieldDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 852
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 451
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\CommentConvertingVisitorWrapper.cs:line 26
''' 
''' Input:
''' 
'''     // Build a generation request from the user prompt.
'''     DevExpress.AIIntegration.Reporting.Common.Extensions.PromptToReportRequest generationRequest = new DevExpress.AIIntegration.Reporting.Common.Extensions.PromptToReportRequest(userPrompt: prompt, dataSourceSchema: null, report: null) {
'''         ReportGenerationHost = host
'''     };
''' 
'''   ''' Cannot convert FieldDeclarationSyntax, System.ArgumentOutOfRangeException: Exception of type 'System.ArgumentOutOfRangeException' was thrown.
''' Parameter name: member
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.GetMemberContext(MemberDeclarationSyntax member) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 852
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitFieldDeclaration(FieldDeclarationSyntax node) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\NodesVisitor.cs:line 451
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping) in C:\builds\CS2VB\CodeConverter-master\CodeConverter\VB\CommentConvertingVisitorWrapper.cs:line 26
''' 
''' Input:
''' 
'''     // Generate a report layout and save it to a REPX file.
'''     DevExpress.XtraReports.UI.XtraReport report = await container.GeneratePromptToReportAsync(generationRequest, default);
''' 
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in 'report.SaveLayoutToXml' at character 2314
''' 
''' 
''' Input:
'''     report.SaveLayoutToXml
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in '(' at character 2336
''' 
''' 
''' Input:
''' ("generatedReport.repx");
''' }
''' catch
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in '(Exception ex)' at character 2371
''' 
''' 
''' Input:
''' (Exception ex) {
''' 
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in 'Console.ForegroundColor' at character 2393
''' 
''' 
''' Input:
'''     Console.ForegroundColor = 
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in 'ConsoleColor.Red' at character 2419
''' 
''' 
''' Input:
''' ConsoleColor.Red;
''' 
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in 'Console.WriteLine' at character 2442
''' 
''' 
''' Input:
'''     Console.WriteLine
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in '(ex.Message)' at character 2459
''' 
''' 
''' Input:
''' (ex.Message);
''' 
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in 'Console.ResetColor' at character 2478
''' 
''' 
''' Input:
'''     Console.ResetColor
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in '()' at character 2496
''' 
''' 
''' Input:
''' ();
''' 
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in 'Console.WriteLine' at character 2505
''' 
''' 
''' Input:
'''     Console.WriteLine
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in '()' at character 2522
''' 
''' 
''' Input:
''' ();
''' }
''' 
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in 'Console.ReadLine' at character 2532
''' 
''' 
''' Input:
''' 
''' Console.ReadLine
'''   ''' Cannot convert IncompleteMemberSyntax, CONVERSION ERROR: Conversion for IncompleteMember not implemented, please report this issue in '()' at character 2548
''' 
''' 
''' Input:
''' ();
''' 
''' 