var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddScoped<IOsonClient, OsonClient>();

builder.Services.AddScoped<IQueryHandler<StatusQuery, OsonStatusResponse>, StatusQueryHandler>();
builder.Services.AddScoped<IQueryHandler<ServicesQuery, List<OsonServiceResponse>>, ServicesQueryHandler>();
builder.Services.AddScoped<IQueryHandler<TransactionsQuery, OsonTransactionsResponse>, TransactionsQueryHandler>();
builder.Services.AddScoped<IQueryHandler<CalculateQuery, OsonCalculateResponse>, CalculateQueryHandler>();
builder.Services.AddScoped<IQueryHandler<DepositQuery, OsonDepositResponse>, DepositQueryHandler>();
builder.Services.AddScoped<ICommandHandler<PayCommand, OsonPaymentResponse>, PayCommandHandler>();

builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Host.UseSerilog();

builder.Services.Configure<OsonOptions>(builder.Configuration.GetSection("OsonOptions"));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    // ============================================
    // SWAGGER / OPENAPI CONFIGURATION
    // ============================================

    // Генерируем swagger документ
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "openapi/{documentName}.json"; // теперь документ будет по /openapi/v1.json
    });

    // Modern OpenAPI UI (Scalar - более красивый чем Swagger UI)
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("VTB Bank Transfer API")
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });

    //// Альтернатива: классический Swagger UI
    //app.UseSwaggerUI(options =>
    //{
    //    options.SwaggerEndpoint("/openapi/v1.json", "VTB Bank Transfer API v1");
    //    options.RoutePrefix = "swagger";
    //});
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();