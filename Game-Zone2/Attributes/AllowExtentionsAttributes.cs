namespace Game_Zone2.Attributes;

public class AllowExtentions: ValidationAttribute
{
    private readonly string _allowedExtensions;
    public AllowExtentions(string allowedExtensions)
    {
        _allowedExtensions = allowedExtensions;
    }

    protected override ValidationResult? IsValid
        (object? value, ValidationContext validationContext)
    {
        var file=value as IFormFile;

        if (file is not null) 
        {
            var extention =Path.GetExtension(file.FileName);
            var isallow= _allowedExtensions.Split(',').Contains(extention,StringComparer.OrdinalIgnoreCase);
            if (!isallow) 
            {
                return new ValidationResult($"only {_allowedExtensions } is using");
            }
        }
        return ValidationResult.Success;
        
    }
}
