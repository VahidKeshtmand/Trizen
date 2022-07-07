using System.Net;

namespace T.Application.Services.Account;

public interface ISmsService
{
    void Send(string phoneNumber, string token);
}


public class SmsService : ISmsService
{
    public void Send(string phoneNumber, string token)
    {
        var client = new WebClient();
        var url = $"https://panel.kavenegar.com/v1/2B683866394F652B76504631786F2B4D794777466D436C7A68676B657859763032415436567361724743513D/verify/lookup.json?receptor={phoneNumber}&token={token}&template=VerifyAccount";
        var content = client.DownloadString(url);

    }
}
