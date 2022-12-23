namespace CleanArchitecture.Infrastructure.Services;

internal static class EmailService
{

    private const string APIKey = "xxxxxxxxxxxxxxx-xxxxx-xxxxx";
    private const string BaseUri = "https://api.mailgun.net/v3";
    private const string Domain = "xxxxxx.xxx";
    private const string SenderAddress = "sender@xxxxxxxx.xxx";
    private const string SenderDisplayName = "Sender Name";
    private const string Tag = "sampleTag";

    /*public static IRestResponse SendEmail(UserEmailOptions userEmailOptions)
    {

        RestClient client = new RestClient
        {
            BaseUrl = new Uri(BaseUri),
            Authenticator = new HttpBasicAuthenticator("api", APIKey)
        };

        RestRequest request = new RestRequest();
        request.AddParameter("domain", Domain, ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", $"{SenderDisplayName} <{SenderAddress}>");

        foreach (var toEmail in userEmailOptions.ToEmails)
        {
            request.AddParameter("to", toEmail);
        }

        request.AddParameter("subject", userEmailOptions.Subject);
        request.AddParameter("html", userEmailOptions.Body);
        request.AddParameter("o:tag", Tag);
        request.Method = Method.POST;
        return client.Execute(request);
    }*/

}