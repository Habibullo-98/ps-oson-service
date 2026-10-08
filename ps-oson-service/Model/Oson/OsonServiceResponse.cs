namespace ps_oson_service.Model.Oson;

[PublicAPI]
public record OsonServiceResponse
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;
    
    [JsonPropertyName("min_amount")]
    public decimal MinAmount { get; init; }
    
    [JsonPropertyName("max_amount")]
    public decimal MaxAmount { get; init; }
    
    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    [JsonPropertyName("fields")] 
    public List<Field> Fields { get; init; } = [];
    
    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true } );
}

[PublicAPI]
public record Field
{
    [JsonPropertyName("id")]
    public int Id { get; init; }
    
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;
    
    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;
    
    [JsonPropertyName("required")]
    public bool Required { get; init; }
    
    [JsonPropertyName("service_id")]
    public int ServiceId { get; init; }
    
    [JsonPropertyName("parent_id")]
    public int ParentId { get; init; }

    [JsonPropertyName("value_list")]
    public List<Value> ValueList { get; init; } = [];
    
    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true } );
}

[PublicAPI]
public record Value
{
    [JsonPropertyName("id")]
    public int Id { get; init; }
    
    [JsonPropertyName("title")]
    public string Title { get; init; } = string.Empty;
    
    [JsonPropertyName("condition")]
    public string Condition { get; init; } = string.Empty;
    
    [JsonPropertyName("field_id")]
    public int FieldId { get; init; }
    
    [JsonPropertyName("parent_id")]
    public int ParentId { get; init; }
    
    public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true } );
}