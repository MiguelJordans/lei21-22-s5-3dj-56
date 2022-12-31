namespace GestArm.Domain.Users;

public interface IVerifyTokenService
{
   
    Task<UserDTO> VerifyJWTToken(string token);

    Task<UserCredentialDTO> VerifyGoogleTokenAndGenerateUserCredentials(string token);

}