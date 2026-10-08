namespace ps_oson_service.Client;

public interface IOsonClient : 
    IPostRequest<OsonAccountRequest, OsonAccountResponse>,
    IPostRequest<OsonPaymentRequest, OsonPaymentResponse>,
    IPostRequest<OsonStatusRequest, OsonStatusResponse>,
    IPostRequest<OsonCalculateRequest, OsonCalculateResponse>,
    IGetRequest<OsonTransactionsRequest, OsonTransactionsResponse>,
    IGetRequest<OsonServicesRequest, List<OsonServiceResponse>>,
    IGetRequest<OsonDepositRequest, OsonDepositResponse>
{
    
}