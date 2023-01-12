namespace AccountOne.Domain.Settings;

public class MailSettings {
    public string EmailFrom { get; set; }
    public string SmtpHost { get; set; }
    public string SmtpPort { get; set; }
    public string SmtpUsername { get; set; }
    public string SmtpPassword { get; set; }
    public string DisplayName { get; set; }
}