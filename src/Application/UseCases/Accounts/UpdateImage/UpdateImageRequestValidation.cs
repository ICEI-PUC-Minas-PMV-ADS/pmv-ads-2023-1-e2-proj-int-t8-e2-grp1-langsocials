using FileSignatures;
using FileSignatures.Formats;
using FluentValidation;

namespace Application.UseCases.Accounts.UpdateImage;

public class UpdateImageRequestValidation : AbstractValidator<UpdateImageRequest>
{
    public UpdateImageRequestValidation(IFileFormatInspector formatInspector)
    {

        When(uic => uic.ImageStream is not null, () =>
            {
                RuleFor(uic => uic.ImageStream)
            .Must(imgstream => imgstream.Length >= 100 && imgstream.Length <= 10485760)
            .Must(uic =>
            {
                var format = formatInspector.DetermineFileFormat(uic);
                return format is Jpeg || format is Png;
            });
        });
    }
}
